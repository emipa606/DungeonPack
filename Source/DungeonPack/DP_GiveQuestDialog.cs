using UnityEngine;
using Verse;

namespace DungeonPack;

public class DP_GiveQuestDialog(DiaNode startNode, bool radioMode) : Dialog_NodeTree(startNode, radioMode)
{
    private const float TitleHeight = 70f;

    private const float InfoHeight = 60f;

    public override Vector2 InitialSize => new(720f, 600f);

    public override void DoWindowContents(Rect inRect)
    {
        Widgets.BeginGroup(inRect);
        var rect = new Rect(0f, 0f, inRect.width / 2f, TitleHeight);
        var rect2 = new Rect(0f, rect.yMax, rect.width, InfoHeight);
        Text.Font = GameFont.Medium;
        Widgets.Label(rect, "DuPa.TriggerQuest".Translate());
        Text.Anchor = TextAnchor.UpperRight;
        Text.Anchor = TextAnchor.UpperLeft;
        Text.Font = GameFont.Small;
        GUI.color = new Color(1f, 1f, 1f, 0.7f);
        Widgets.Label(rect2, "DuPa.TriggerQuestInfo".Translate());
        Text.Anchor = TextAnchor.UpperRight;
        Text.Anchor = TextAnchor.UpperLeft;
        GUI.color = Color.white;
        Widgets.EndGroup();
        var num = TitleHeight + InfoHeight + 17f;
        var rect5 = new Rect(0f, num, inRect.width, inRect.height - num);
        DrawNode(rect5);
    }
}