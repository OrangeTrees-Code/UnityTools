using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public enum E_Alignment_Type
{
    Up,
    Down,
    Left,
    Right,
    Centre,
    Left_up,
    Left_down,
    Right_up,
    Right_down,
}
[System.Serializable]
public class CustomGUIPos
{
    private Rect realPos_ = new Rect();
    public E_Alignment_Type Screen_Alienment_Type = E_Alignment_Type.Centre;
    public E_Alignment_Type Control_Centre_Alignment_Type = E_Alignment_Type.Centre;
    public Vector2 Offset;
    public float Width = 100;
    public float Height = 50;
    private Vector2 centrePos_;
    private void CalcCentrePos()
    {
        switch (Control_Centre_Alignment_Type)
        {
            case E_Alignment_Type.Up:
                centrePos_.x = Width / 2;
                centrePos_.y = 0;
                break;
            case E_Alignment_Type.Down:
                centrePos_.x = Width / 2;
                centrePos_.y = Height;
                break;
            case E_Alignment_Type.Left:
                centrePos_.x = 0;
                centrePos_.y = Height / 2;
                break;
            case E_Alignment_Type.Right:
                centrePos_.x = Width;
                centrePos_.y = Height / 2;
                break;
            case E_Alignment_Type.Centre:
                centrePos_.x = Width / 2;
                centrePos_.y = Height / 2;
                break;
            case E_Alignment_Type.Left_up:
                centrePos_.x = 0;
                centrePos_.y = 0;
                break;
            case E_Alignment_Type.Left_down:
                centrePos_.x = 0;
                centrePos_.y = Height;
                break;
            case E_Alignment_Type.Right_up:
                centrePos_.x = Width;
                centrePos_.y = 0;
                break;
            case E_Alignment_Type.Right_down:
                centrePos_.x = Width;
                centrePos_.y = Height;
                break;
            default:
                break;
        }



    }
    private void CalcPos()
    {
        switch (Screen_Alienment_Type)
        {
            case E_Alignment_Type.Up:
                realPos_.x = Screen.width / 2;
                realPos_.y = 0;
                break;
            case E_Alignment_Type.Down:
                realPos_.x = Screen.width / 2;
                realPos_.y = Screen.height;
                break;
            case E_Alignment_Type.Left:
                realPos_.x = 0;
                realPos_.y = Screen.height / 2;
                break;
            case E_Alignment_Type.Right:
                realPos_.x = Screen.width;
                realPos_.y = Screen.height / 2;
                break;
            case E_Alignment_Type.Centre:
                realPos_.x = Screen.width / 2;
                realPos_.y = Screen.height / 2;
                break;
            case E_Alignment_Type.Left_up:
                realPos_.x = 0;
                realPos_.y = 0;
                break;
            case E_Alignment_Type.Left_down:
                realPos_.x = 0;
                realPos_.y = Screen.height;
                break;
            case E_Alignment_Type.Right_up:
                realPos_.x = Screen.width;
                realPos_.y = 0;
                break;
            case E_Alignment_Type.Right_down:
                realPos_.x = Screen.width;
                realPos_.y = Screen.height;
                break;
            default:
                break;
        }
        realPos_.position += (Offset - centrePos_);
    }
    public Rect Pos
    {
        get
        {
            realPos_.width = Width;
            realPos_.height = Height;
            CalcCentrePos();
            CalcPos();
            return realPos_;
        }
    }

}
