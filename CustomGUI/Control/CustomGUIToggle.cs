using UnityEngine;
using UnityEngine.Events;

public class CustomGUIToggle : CustomGUIControl
{
    public bool IsSel;
    private bool lastSel_;
    public event UnityAction<bool> EventWhenChange; 
    protected override void Draw()
    {
        IsSel = GUI.Toggle(Position.Pos, IsSel, Content);
        if(lastSel_ != IsSel)
        {
            EventWhenChange?.Invoke(IsSel);
            lastSel_ = IsSel;
        }
    }

    protected override void DrawWithStyle()
    {
        IsSel = GUI.Toggle(Position.Pos, IsSel, Content, Style);
        if (lastSel_ != IsSel)
        {
            EventWhenChange?.Invoke(IsSel);
            lastSel_ = IsSel;
        }
    }
}
