using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Style_Onoff
{
    On,
    Off,
}

public abstract class CustomGUIControl : MonoBehaviour
{

    //提取控件的共同表现
    //位置信息
    public CustomGUIPos guiPos;
    //显示内容
    public GUIContent content;
    //自定义样式
    public GUIStyle style;
    //自定义样式是否启用的开关
    public E_Style_Onoff style_Onoff = E_Style_Onoff.Off;
    /// <summary>
    /// 提供绘制GUI的方法
    /// </summary>
    public void DrawGUI()
    {
        switch (style_Onoff)
        {
            case E_Style_Onoff.On:
                StyleOnDraw();
                break;
            case E_Style_Onoff.Off:
                StyleOffDraw();
                break;
            default:
                break;
        }

    }

    /// <summary>
    /// 自定义样式开启时的绘制方法
    /// </summary>
    protected abstract void StyleOnDraw();

    /// <summary>
    /// 自定义样式关闭时的绘制方法
    /// </summary>
    protected abstract void StyleOffDraw();

}
