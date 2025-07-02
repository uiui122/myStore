using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum E_Slider_Type
{
    Horizontal,
    Vertial
    
}
public class CustomGUISlider : CustomGUIControl
{
    //最小值
    public float minValue = 0;
    public float maxValue = 1;
    public float nowValue = 0;
    private E_Slider_Type type = E_Slider_Type.Horizontal;
    /// <summary>
    /// 小按钮的style
    /// </summary>
    public GUIStyle styleThumb;
    public event UnityAction<float> changeValue;
    private float oldValue;
    protected override void StyleOffDraw()
    {
        switch (type)
        {
            case E_Slider_Type.Horizontal:
                nowValue = GUI.HorizontalSlider(guiPos.Pos, nowValue, minValue, maxValue);
                break;
            case E_Slider_Type.Vertial:
                nowValue = GUI.VerticalSlider(guiPos.Pos, nowValue, minValue, maxValue);
                break;
            default:
                break;
        }
        if(oldValue != nowValue)
        {
            changeValue?.Invoke(nowValue);
            oldValue = nowValue;
        }
        
        
    }

    protected override void StyleOnDraw()
    {
        switch (type)
        {
            case E_Slider_Type.Horizontal:
                nowValue = GUI.HorizontalSlider(guiPos.Pos, nowValue, minValue, maxValue,style,styleThumb);
                break;
            case E_Slider_Type.Vertial:
                nowValue = GUI.VerticalSlider(guiPos.Pos, nowValue, minValue, maxValue,style, styleThumb);
                break;
            default:
                break;
        }
    }
}
