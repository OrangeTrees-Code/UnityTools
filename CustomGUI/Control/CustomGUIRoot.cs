using UnityEngine;

[ExecuteAlways]
public class CustomGUIRoot : MonoBehaviour
{
    public CustomGUIControl[] customGUIControl;
    void Start()
    {
        customGUIControl = this.GetComponentsInChildren<CustomGUIControl>();
    }

    void OnGUI()
    {
        if (Application.isPlaying == false)
        {
            customGUIControl = this.GetComponentsInChildren<CustomGUIControl>();
        }
        foreach (CustomGUIControl control in customGUIControl)
        {
            control.Show();
        }
    }
}
