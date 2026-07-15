using Verse;

namespace DungeonPack;

public class RandomPhaseEffect : HediffComp
{
    private readonly int baseTicksUntilNext = 2500;
    private int ticksUntilNextPhase;

    public override void CompPostMake()
    {
        base.CompPostMake();
        ticksUntilNextPhase = baseTicksUntilNext;
    }

    public override void CompPostTick(ref float severityAdjustment)
    {
        base.CompPostTick(ref severityAdjustment);
        if (ticksUntilNextPhase-- > 0)
        {
            return;
        }

        ticksUntilNextPhase = baseTicksUntilNext;

        // Place pawn in a random walkable position
        for (var i = 0; i < 5; i++)
        {
            // Select 10 random spots that are standable
            var cell = CellFinder.RandomCell(parent.pawn.Map);
            if (!cell.Standable(parent.pawn.Map))
            {
                continue;
            }

            parent.pawn.SetPositionDirect(cell);
            break;
        }
    }
}