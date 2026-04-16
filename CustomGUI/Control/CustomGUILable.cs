using UnityEngine;

public class CustomGUILable : CustomGUIControl
{
    protected override void Draw()
    {
        GUI.Label(Position.Pos,Content);
    }
    protected override void DrawWithStyle()
    {
        GUI.Label(Position.Pos, Content, Style);
    }
}
