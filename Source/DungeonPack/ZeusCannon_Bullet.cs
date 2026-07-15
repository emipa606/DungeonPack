using RimWorld;
using Verse;

namespace DungeonPack;

public class ZeusCannon_Bullet : Bullet
{
    protected override void Impact(Thing hitThing, bool blockedByShield = false)
    {
        base.Impact(hitThing, blockedByShield);
        if (hitThing == null)
        {
            return;
        }

        var map = hitThing.Map;
        var pos = hitThing.Position;
        map.weatherManager.eventHandler.AddEvent(new WeatherEvent_LightningStrike(map, pos));
    }
}