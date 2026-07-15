using System;
using System.Collections.Generic;
using Verse;

namespace DungeonPack;

public class HediffOnEquip : ThingComp
{
    private readonly List<HediffDef> realHediff = [];
    private HediffOnEquipComp data => (HediffOnEquipComp)props;


    public override void PostPostMake()
    {
        base.PostPostMake();
        foreach (var hediffN in data.hediffs)
        {
            // A hediff with foo_REQDLC tags will require the DLC to work, and will try a version, foo, if there isn't
            // otherwise: proceed as normal
            var loc = hediffN.IndexOf("_REQ", StringComparison.Ordinal);
            var require = loc == -1 ? "" : hediffN[(loc + 4)..];
            if (loc != -1 && !ModLister.HasActiveModWithName(require))
            {
                var adjusted = DefDatabase<HediffDef>.GetNamed(hediffN[..loc]);
                if (adjusted != null)
                {
                    realHediff.Add(adjusted);
                }
            }
            else
            {
                realHediff.Add(DefDatabase<HediffDef>.GetNamed(hediffN));
            }
        }
    }

    public override void Notify_Equipped(Pawn pawn)
    {
        base.Notify_Equipped(pawn);
        foreach (var def in realHediff)
        {
            var hediff = HediffMaker.MakeHediff(def, pawn);
            pawn.health.AddHediff(hediff);
        }
    }

    public override void Notify_Unequipped(Pawn pawn)
    {
        base.Notify_Unequipped(pawn);
        foreach (var def in realHediff)
        {
            var firstHediffOfDef = pawn.health.hediffSet.GetFirstHediffOfDef(def);
            if (firstHediffOfDef != null)
            {
                pawn.health.RemoveHediff(firstHediffOfDef);
            }
        }
    }
}