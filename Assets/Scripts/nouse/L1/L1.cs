using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ����

        #endregion
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //�л�����
            SceneManager.LoadScene("GameScene");
            //ע��Ҫ����File->Build Settings�����Scene
            
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //ִ�к��˳���Ϸ
            //�༭ģʽû��
            //��Ϊexe�ļ��������
            Application.Quit();
        }
    }
}
