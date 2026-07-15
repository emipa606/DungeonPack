using RimWorld;
using Verse;

namespace DungeonPack;

public class PandoraBoxEffect : CompUseEffect
{
    public override void DoEffect(Pawn usedBy)
    {
        var numIncidents = Rand.Range(1, 5);
        var incidentParms2 = StorytellerUtility.DefaultParmsNow(IncidentCategoryDefOf.ThreatSmall, usedBy.Map);
        for (var i = 0; i < numIncidents || Rand.Range(0, 2) == 0; i++)
        {
            var randomIncident = DefDatabase<IncidentDef>.GetRandom();

            if (randomIncident.baseChance == 0 || !randomIncident.TargetAllowed(usedBy.Map))
            {
                continue;
            }

            Find.Storyteller.incidentQueue.Add(randomIncident, Find.TickManager.TicksGame + 500 + (i * 10),
                incidentParms2);
        }
    }
}