using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace DungeonPack;

[StaticConstructorOnStartup]
public static class HarmonyPatches
{
    private const string HarmonyId = "rimworld.dungeonpack";

    private static bool patched;

    static HarmonyPatches()
    {
        EnsurePatched();
    }

    public static void EnsurePatched()
    {
        if (patched)
        {
            return;
        }

        patched = true;
        var harmony = new Harmony(HarmonyId);
        harmony.PatchAll(Assembly.GetExecutingAssembly());
        PatchQuestEditorPawnSpawnDataCtor(harmony);
    }

    private static void PatchQuestEditorPawnSpawnDataCtor(Harmony harmony)
    {
        var pawnSpawnDataType = AccessTools.TypeByName("QuestEditor_Library.PawnSpawnData");
        if (pawnSpawnDataType == null)
        {
            return;
        }

        var constructor = AccessTools.Constructor(pawnSpawnDataType, Type.EmptyTypes);
        if (constructor == null)
        {
            return;
        }

        harmony.Patch(constructor,
            transpiler: new HarmonyMethod(typeof(HarmonyPatches), nameof(PawnSpawnDataCtorTranspiler)));
    }

    private static IEnumerable<CodeInstruction> PawnSpawnDataCtorTranspiler(IEnumerable<CodeInstruction> instructions)
    {
        var defendField = AccessTools.Field(typeof(DutyDefOf), nameof(DutyDefOf.Defend));
        var safeDefaultDutyMethod = AccessTools.Method(typeof(HarmonyPatches), nameof(GetSafeDefaultDuty));

        foreach (var instruction in instructions)
        {
            if (instruction.opcode == OpCodes.Ldsfld && Equals(instruction.operand, defendField))
            {
                yield return new CodeInstruction(OpCodes.Call, safeDefaultDutyMethod);
                continue;
            }

            yield return instruction;
        }
    }

    private static DutyDef GetSafeDefaultDuty()
    {
        return DefDatabase<DutyDef>.GetNamedSilentFail("Defend");
    }
}