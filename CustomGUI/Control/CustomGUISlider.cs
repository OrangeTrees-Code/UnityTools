using UnityEngine;
using UnityEngine.Assemblies;
using UnityEngine.Events;

public enum E_Slider_type
{
    Horizontal,
    Vertical,
}
public class CustomGUISlider : CustomGUIControl
{
    public float Low = 0;
    public float High = 1;
    public float Curr = 0;
    public E_Slider_type Slider_type;
    public event UnityAction<float> EventWhenChange;
    public GUIStyle Thumb_style;
    private float lastValue_;
    protected override void Draw()
    {
        switch (Slider_type)
        {
            case E_Slider_type.Horizontal:
                Curr = GUI.HorizontalSlider(Position.Pos, Curr, Low, High);
                break;
            case E_Slider_type.Vertical:
                Curr = GUI.VerticalSlider(Position.Pos, Curr, Low, High);
                break;
            default:
                break;
        }
        if (lastValue_ != Curr)
        {
            EventWhenChange?.Invoke(Curr);
            lastValue_ = Curr;
        }

    }

    protected override void DrawWithStyle()
    {
        switch (Slider_type)
        {
            case E_Slider_type.Horizontal:
                Curr = GUI.HorizontalSlider(Position.Pos, Curr, Low, High, Style, Thumb_style);
                break;
            case E_Slider_type.Vertical:
                Curr = GUI.VerticalSlider(Position.Pos, Curr, Low, High, Style, Thumb_style);
                break;
            default:
                break;
        }
        if (lastValue_ != Curr)
        {
            EventWhenChange?.Invoke(Curr);
            lastValue_ = Curr;
        }
    }
}
