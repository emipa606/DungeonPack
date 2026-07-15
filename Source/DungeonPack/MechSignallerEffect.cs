using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;
using Verse.AI.Group;

namespace DungeonPack;

public class MechSignallerEffect : CompTargetEffect
{
    public override void DoEffectOn(Pawn user, Thing target)
    {
        var possibleMech = DefDatabase<PawnKindDef>.AllDefsListForReading
            .Where(MechClusterGenerator.MechKindSuitableForCluster).ToList();

        // To prevent this from being resource broken, spawn "Ancients"
        // Generate a random group of mechanoids, 2-5 base mechanoids, with the potential for more
        var numSpawn = Rand.Range(2, 5);
        var mechs = new List<Pawn>();
        for (var i = 0; i < numSpawn || Rand.Range(0, 2) == 0; i++)
        {
            var mechToSpawn = PawnGenerator.GeneratePawn(possibleMech.RandomElement(), Faction.OfAncients);
            var refPoint = user.DutyLocation();
            if (target != null)
            {
                refPoint = target.Position;
            }

            if (!DropCellFinder.TryFindDropSpotNear(refPoint, user.Map, out var res, true, true))
            {
                continue;
            }

            var activeDropPodInfo = new ActiveTransporterInfo();
            activeDropPodInfo.innerContainer.TryAdd(mechToSpawn, 1);
            activeDropPodInfo.openDelay = 100;
            activeDropPodInfo.leaveSlag = false;
            activeDropPodInfo.despawnPodBeforeSpawningThing = true;
            activeDropPodInfo.spawnWipeMode = WipeMode.Vanish;
            DropPodUtility.MakeDropPodAt(res, user.Map, activeDropPodInfo, user.Faction);

            mechs.Add(mechToSpawn);
        }

        // Give the mech a job. Everyone needs jobs
        var lord = new LordJob_AssistColony(user.Faction, user.DutyLocation());
        LordMaker.MakeNewLord(user.Faction, lord, user.Map, mechs);
    }
}