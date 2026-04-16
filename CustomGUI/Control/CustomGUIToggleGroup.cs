using UnityEngine;


[ExecuteAlways]
public class CustomGUIToggleGroup : MonoBehaviour
{
    public CustomGUIToggle[] Toggles;

    public CustomGUIToggle LastSelected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var curr_t in Toggles)
        {
            print("1");
            curr_t.EventWhenChange += (value) =>
            {
                if (value == true)
                {
                    foreach (var t in Toggles)
                    {
                        if (t != curr_t)
                        {
                            t.IsSel = false;
                        }
                    }
                    LastSelected = curr_t;
                }
                else if (LastSelected == curr_t)
                {
                    curr_t.IsSel = true;
                }
            };
        }
    }
}


