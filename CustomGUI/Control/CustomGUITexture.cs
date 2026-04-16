using UnityEngine;

public class CustomGUITexture : CustomGUIControl
{
    public ScaleMode Scale_Mode = ScaleMode.ScaleToFit;
    protected override void Draw()
    {
        GUI.DrawTexture(Position.Pos, Content.image, Scale_Mode);
    }

    protected override void DrawWithStyle()
    {
        GUI.DrawTexture(Position.Pos, Content.image, Scale_Mode);
    }
}
