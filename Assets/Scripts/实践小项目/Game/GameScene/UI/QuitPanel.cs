using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnContinue;
    public CustomGUIButton btnClose;
    // Start is called before the first frame update
    void Start()
    {
        btnQuit.clickEvent += () =>
        {
            //回到主界面
            SceneManager.LoadScene("BeginScene");
            HideMe();
        };
        btnContinue.clickEvent += () =>
        {
            //回到游戏
            HideMe();
        };
        btnClose.clickEvent += () =>
        {
            //回到游戏
            HideMe();
        };
        HideMe();
    }

    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
}
