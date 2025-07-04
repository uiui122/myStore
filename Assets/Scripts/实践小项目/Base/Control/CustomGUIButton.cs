using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomGUIButton : CustomGUIControl
{
    //给外部提供 用于响应事件 的 参数
    public event UnityAction clickEvent;
    protected override void StyleOffDraw()
    {
        if(GUI.Button(guiPos.Pos, content))
        {
            clickEvent?.Invoke();
        }
        
    }

    protected override void StyleOnDraw()
    {
        if(GUI.Button(guiPos.Pos, content, style))
        {
            clickEvent?.Invoke();
        }
    }
}
