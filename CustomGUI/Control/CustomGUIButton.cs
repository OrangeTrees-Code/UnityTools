using UnityEngine;
using UnityEngine.Events;

public class CustomGUIBotton : CustomGUIControl
{
    public event UnityAction ClickEvent;
    protected override void Draw()
    {
        if (GUI.Button(Position.Pos, Content))
        {
            ClickEvent?.Invoke();
        }
    }

    protected override void DrawWithStyle()
    {
        if (GUI.Button(Position.Pos, Content, Style))
        {
            ClickEvent?.Invoke();
        }
    }
}
