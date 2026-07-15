using System;
using HarmonyLib;
using RimWorld;
using Verse;

namespace DungeonPack;

[HarmonyPatch(typeof(ResearchManager), nameof(ResearchManager.FinishProject))]
public static class ResearchManager_FinishProject
{
    public static void Postfix(ResearchProjectDef proj, Pawn researcher)
    {
        var iIncident = proj.defName.IndexOf("DP_RGive", StringComparison.Ordinal);
        if (iIncident != -1)
        {
            // Trigger quest
            // Schema, DP_RGive[QuestName] -> DP_IGive[QuestName]
            var map = Find.CurrentMap;
            if (researcher != null)
            {
                map = researcher.Map;
            }

            var incidentParms = StorytellerUtility.DefaultParmsNow(IncidentCategoryDefOf.GiveQuest, map);
            var questName = $"DP_IGive{proj.defName[(iIncident + "DP_RGive".Length)..]}";
            Find.Storyteller.incidentQueue.Add(DefDatabase<IncidentDef>.GetNamed(questName), Find.TickManager.TicksGame,
                incidentParms);
        }

        if (proj.defName.Equals("DP_ResearchReset"))
        {
            proj.baseCost += 500;
        }
    }
}