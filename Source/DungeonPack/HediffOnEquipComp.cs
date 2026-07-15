using System.Collections.Generic;
using Verse;

namespace DungeonPack;

public class HediffOnEquipComp : CompProperties
{
    public List<string> hediffs;

    public HediffOnEquipComp()
    {
        compClass = typeof(HediffOnEquip);
    }
}