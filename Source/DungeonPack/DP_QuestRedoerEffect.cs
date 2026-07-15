using RimWorld;
using Verse;

namespace DungeonPack;

public class DP_QuestRedoerEffect : CompUseEffect
{
    public override void DoEffect(Pawn usedBy)
    {
        base.DoEffect(usedBy);
        var root = new DiaNode(new TaggedString(""));

        var DPProjs =
            DefDatabase<ResearchProjectDef>.AllDefsListForReading.FindAll(proj => proj.defName.StartsWith("DP_RGive"));
        var DPIGivers =
            DefDatabase<IncidentDef>.AllDefsListForReading.FindAll(incid => incid.defName.StartsWith("DP_IGive"));

        foreach (var proj in DPProjs)
        {
            if (!proj.IsFinished)
            {
                continue;
            }

            var questN = proj.defName["DP_RGive".Length..];
            var diaOption = new DiaOption("DuPa.TriggerStart".Translate(questN))
            {
                action = delegate
                {
                    var quest = DPIGivers.Find(incid => incid.defName.Equals($"DP_IGive{questN}"));
                    var incidentParms = StorytellerUtility.DefaultParmsNow(IncidentCategoryDefOf.GiveQuest, usedBy.Map);
                    Find.Storyteller.incidentQueue.Add(quest, Find.TickManager.TicksGame, incidentParms);
                },
                resolveTree = true
            };
            root.options.Add(diaOption);
        }


        root.options.Add(new DiaOption("(" + "Cancel".Translate() + ")") { resolveTree = true });
        Find.WindowStack.Add(new DP_GiveQuestDialog(root, true));
    }
}