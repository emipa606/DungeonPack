using RimWorld;
using Verse;

namespace DungeonPack;

public class LostMercyEffect : HediffWithComps
{
    public override void PostAdd(DamageInfo? dinfo)
    {
        base.PostAdd(dinfo);
        pawn.needs.mood.thoughts.memories.TryGainMemory(DefDatabase<ThoughtDef>.GetNamed("DP_LostMercy")
            .producesMemoryThought);
    }

    public override void PostRemoved()
    {
        pawn.needs.mood.thoughts.memories.RemoveMemoriesOfDef(DefDatabase<ThoughtDef>.GetNamed("DP_LostMercy")
            .producesMemoryThought);
    }
}