using RimWorld;
using Verse;

namespace DungeonPack;

public class ThorHammerEffect : DamageWorker_Blunt
{
    protected override void ApplySpecialEffectsToPart(Pawn pawn, float totalDamage, DamageInfo dinfo,
        DamageResult result)
    {
        base.ApplySpecialEffectsToPart(pawn, totalDamage, dinfo, result);

        // Add lightning strike!
        var map = pawn.Map;
        map.weatherManager.eventHandler.AddEvent(new WeatherEvent_LightningStrike(map, pawn.Position));
    }
}