using UnityEngine;



abstract public class CustomGUIControl : MonoBehaviour
{
    public CustomGUIPos Position;
    public GUIContent Content;
    public GUIStyle Style;
    public bool EnableStyle;

    public void Show()
    {
        if (EnableStyle == true)
        {
            DrawWithStyle();
        }
        else
        {
            Draw();
        }
    }

    protected abstract void Draw();
    protected abstract void DrawWithStyle();
}
