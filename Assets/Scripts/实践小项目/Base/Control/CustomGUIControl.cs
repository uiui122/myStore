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

    //��ȡ�ؼ��Ĺ�ͬ����
    //λ����Ϣ
    public CustomGUIPos guiPos;
    //��ʾ����
    public GUIContent content;
    //�Զ�����ʽ
    public GUIStyle style;
    //�Զ�����ʽ�Ƿ����õĿ���
    public E_Style_Onoff style_Onoff = E_Style_Onoff.Off;
    /// <summary>
    /// �ṩ����GUI�ķ���
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
    /// �Զ�����ʽ����ʱ�Ļ��Ʒ���
    /// </summary>
    protected abstract void StyleOnDraw();

    /// <summary>
    /// �Զ�����ʽ�ر�ʱ�Ļ��Ʒ���
    /// </summary>
    protected abstract void StyleOffDraw();

}
