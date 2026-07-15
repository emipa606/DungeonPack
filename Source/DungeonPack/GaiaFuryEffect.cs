using RimWorld;
using Verse;

namespace DungeonPack;

public class GaiaFuryEffect : CompUseEffect
{
    public override void DoEffect(Pawn usedBy)
    {
        if (usedBy.Map.GameConditionManager.GetActiveCondition(GameConditionDefOf.PsychicDrone) != null)
        {
            return;
        }

        var incidentParms = StorytellerUtility.DefaultParmsNow(IncidentCategoryDefOf.ThreatSmall, usedBy.Map);
        Find.Storyteller.incidentQueue.Add(DefDatabase<IncidentDef>.GetNamed("PsychicDrone"),
            Find.TickManager.TicksGame, incidentParms);
    }
}