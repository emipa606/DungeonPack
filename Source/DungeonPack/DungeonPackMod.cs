using Verse;

namespace DungeonPack;

public sealed class DungeonPackMod : Mod
{
    public DungeonPackMod(ModContentPack content)
        : base(content)
    {
        HarmonyPatches.EnsurePatched();
    }
}
