using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2 : MonoBehaviour
{
    public Texture2D texture;

    // Start is called before the first frame update
    void Start()
    {
        #region �������
        //Cursor.visible = false;
        #endregion
        #region �������
        //Cursor.lockState= CursorLockMode.None;//������
        //Cursor.lockState = CursorLockMode.Locked;//����(��������)|esc��������
        Cursor.lockState = CursorLockMode.Confined;//�����ڴ��ڷ�Χ��
        #endregion
        #region �������ͼƬ
        //����һ�����ͼƬ
        //��������ƫ��λ��
        //��������ƽ̨֧�ֵĹ��ģʽ��Ӳ���������
        Cursor.SetCursor(texture, Vector2.zero, CursorMode.Auto);

        #endregion


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
