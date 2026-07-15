using RimWorld;
using Verse;

namespace DungeonPack;

public class OrbOfMadnessEffect : CompTargetEffect
{
    public override void DoEffectOn(Pawn user, Thing target)
    {
        var pawn = (Pawn)target;
        if (pawn.Dead)
        {
            return;
        }

        pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.Berserk, forceWake: true);
        Find.BattleLog.Add(new BattleLogEntry_ItemUsed(user, pawn, parent.def, RulePackDefOf.Event_ItemUsed));

        // 1/10
        if (Rand.Range(0, 10) != 0)
        {
            return;
        }

        user.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.Berserk, forceWake: true);
        Find.BattleLog.Add(new BattleLogEntry_ItemUsed(pawn, user, parent.def, RulePackDefOf.Event_ItemUsed));
    }
}