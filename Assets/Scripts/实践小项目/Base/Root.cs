using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class NewBehaviourScript : MonoBehaviour
{
    //用于存储所有GUI控件的容器
    private CustomGUIControl[] allControls;
    void Start()
    {
        allControls = this.GetComponentsInChildren<CustomGUIControl>();
    }
    private void OnGUI()
    {
        //if (!Application.isPlaying)
        //{
            allControls = this.GetComponentsInChildren<CustomGUIControl>();
        //}
        //遍历绘制
        for (int i = 0; i < allControls.Length; i++)
        {
            allControls[i].DrawGUI();
        }

    }
}
