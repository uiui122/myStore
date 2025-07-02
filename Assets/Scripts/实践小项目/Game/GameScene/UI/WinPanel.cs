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
            //将数据记录在排行榜中 并且 回到主场景
            GameDataMgr.Instance.AddRankInfo(inputInfo.content.text,
                                            GamePanel.Instance.nowScore,
                                            GamePanel.Instance.nowTime);
            //接着 返回我们的开始界面
            SceneManager.LoadScene("BeginScene");
        };
        HideMe();
    }
}
