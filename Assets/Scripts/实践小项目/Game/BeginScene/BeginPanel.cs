using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{
    public CustomGUIButton btnBegin;
    public CustomGUIButton btnSetting;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnRank;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        //将鼠标锁定在窗口
        Cursor.lockState = CursorLockMode.Confined;
        btnBegin.clickEvent += () =>
        {
            //切换场景
            SceneManager.LoadScene("GameScene");
        };
        btnSetting.clickEvent += () =>
        {
            SettingPanel.Instance.ShowMe();
            HideMe();
            //打开设置面板
        };
        btnQuit.clickEvent += () =>
        {
            //退出游戏
            Application.Quit();
        };
        btnRank.clickEvent += () =>
        {
            RankPanel.Instance.ShowMe();
            HideMe();
            //打开排行榜
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
