using RimWorld;
using Verse;

namespace DungeonPack;

public class RealitybreakerEffect : CompUseEffect
{
    public override void DoEffect(Pawn usedBy)
    {
        foreach (var item in usedBy.MapHeld.mapPawns.AllPawnsSpawned)
        {
            var hediff = HediffMaker.MakeHediff(HediffDefOf.PsychicShock, item);
            hediff.Severity = 1.0f;
            item.health.AddHediff(hediff);
        }
    }
}