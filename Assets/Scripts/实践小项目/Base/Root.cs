using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class NewBehaviourScript : MonoBehaviour
{
    //���ڴ洢����GUI�ؼ�������
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
        //��������
        for (int i = 0; i < allControls.Length; i++)
        {
            allControls[i].DrawGUI();
        }

    }
}
