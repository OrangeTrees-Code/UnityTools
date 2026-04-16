using UnityEngine;
using UnityEngine.Events;

public class CustomGUITextBox : CustomGUIControl
{
    public event UnityAction<string> EventWhenChange;
    private string lastInput_;
    protected override void Draw()
    {
        Content.text = GUI.TextField(Position.Pos, Content.text);
        if(lastInput_ != Content.text)
        {
            EventWhenChange?.Invoke(Content.text);
            lastInput_ = Content.text;
        }
    }

    protected override void DrawWithStyle()
    {
        Content.text = GUI.TextField(Position.Pos, Content.text, Style);
        if (lastInput_ != Content.text)
        {
            EventWhenChange?.Invoke(Content.text);
            lastInput_ = Content.text;
        }
    }
}
