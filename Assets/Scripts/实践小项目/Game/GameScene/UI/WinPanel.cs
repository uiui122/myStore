using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : BasePanel<WinPanel>
{
    public CustomGUIInput inputInfo;
    public CustomGUIButton btnSure;
    // Start is called before the first frame update
    void Start()
    {
        btnSure.clickEvent += ()=>
        {
            Time.timeScale = 1;
            //�����ݼ�¼�����а��� ���� �ص�������
            GameDataMgr.Instance.AddRankInfo(inputInfo.content.text,
                                            GamePanel.Instance.nowScore,
                                            GamePanel.Instance.nowTime);
            //���� �������ǵĿ�ʼ����
            SceneManager.LoadScene("BeginScene");
        };
        HideMe();
    }
}
