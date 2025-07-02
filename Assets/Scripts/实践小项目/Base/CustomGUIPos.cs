using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 对齐方式的枚举
/// </summary>
public enum E_Alignment_Type
{
    Up,
    Down,
    Left,
    Right,
    Center,
    LeftUP,
    LeftDown,
    RightUp,
    RightDown,
}

/// <summary>
/// 该类 用于表示位置 计算位置相关的信息 不继承mono
/// </summary>
[System.Serializable]
public class CustomGUIPos
{
    private Rect rPos = new Rect(0, 0, 100, 100);
    /// <summary>
    /// 屏幕九宫格的位置
    /// </summary>
    public E_Alignment_Type Screen_Alignment_Type = E_Alignment_Type.Center;
    /// <summary>
    /// 控件中心对齐方式
    /// </summary>
    public E_Alignment_Type control_Alignment_Type = E_Alignment_Type.Center;

    public Vector2 pos;

    public float width = 100;
    public float height = 50;


    private Vector2 centerPos;
    /// <summary>
    /// 计算中心点偏移位置的函数
    /// </summary>
    private void CalcCenterPos()
    {
        switch (control_Alignment_Type)
        {
            case E_Alignment_Type.Up:
                centerPos.x = -width / 2;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.Down:
                centerPos.x = -width / 2;
                centerPos.y = -height;
                break;
            case E_Alignment_Type.Left:
                centerPos.x = 0;
                centerPos.y = -height/2;
                break;
            case E_Alignment_Type.Right:
                centerPos.x = -width;
                centerPos.y = -height/2;
                break;
            case E_Alignment_Type.Center:
                centerPos.x = -width / 2;
                centerPos.y = -height/2;
                break;
            case E_Alignment_Type.LeftUP:
                centerPos.x = 0;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.LeftDown:
                centerPos.x = 0;
                centerPos.y = -height;
                break;
            case E_Alignment_Type.RightUp:
                centerPos.x = -width;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.RightDown:
                centerPos.x = -width;
                centerPos.y = -height;
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 计算实际位置
    /// </summary>
    private void CalcPos()
    {
        switch (Screen_Alignment_Type)
        {
            case E_Alignment_Type.Up:
                rPos.x = Screen.width/2 + centerPos.x + pos.x;
                rPos.y = 0 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Down:
                rPos.x = Screen.width / 2 + centerPos.x + pos.x;
                rPos.y = Screen.height + centerPos.y - pos.y;
                break;
            case E_Alignment_Type.Left:
                rPos.x = 0 + centerPos.x + pos.x;
                rPos.y = Screen.height/2 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Right:
                rPos.x = Screen.width+ centerPos.x - pos.x;
                rPos.y = Screen.height/2 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Center:
                rPos.x = Screen.width / 2 + centerPos.x + pos.x;
                rPos.y = Screen.height/2 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.LeftUP:
                rPos.x = 0 + centerPos.x + pos.x;
                rPos.y = 0 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.LeftDown:
                rPos.x = 0 + centerPos.x + pos.x;
                rPos.y = Screen.height + centerPos.y - pos.y;
                break;
            case E_Alignment_Type.RightUp:
                rPos.x = Screen.width + centerPos.x - pos.x;
                rPos.y = 0 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.RightDown:
                rPos.x = Screen.width + centerPos.x - pos.x;
                rPos.y = Screen.height + centerPos.y - pos.y;
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 得到 最终的位置的 宽高
    /// </summary>
    public Rect Pos
    {
        get
        {



            //计算位置
            CalcCenterPos();
            CalcPos();
            //位置赋值
            rPos.width = width;
            rPos.height = height;
            return rPos;
        }
    }


}
