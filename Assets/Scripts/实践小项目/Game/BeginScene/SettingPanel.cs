using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>   
{
    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderSound;

    public CustomGUIToggle togMusic;
    public CustomGUIToggle togSound;

    public CustomGUIButton btnClose;

    // Start is called before the first frame update
    void Start()
    {
        //监听事件 处理逻辑
        //处理音乐变化
        sliderMusic.changeValue += (value)=>GameDataMgr.Instance.ChangeBKValue(value);
        //处理音效变化
        sliderSound.changeValue += (value) => GameDataMgr.Instance.ChangeSoundValue(value);
        //处理音乐开关
        togMusic.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseBKMusic(value);
        //处理音效开关
        togSound.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseSound(value);
        btnClose.clickEvent += () =>
        {
            HideMe();

            if (SceneManager.GetActiveScene().name == "BeginScene")
            {
                BeginPanel.Instance.ShowMe();
            }
            else if(SceneManager.GetActiveScene().name == "GameScene")
            {
                //BeginPanel.Instance.ShowMe();
            }
        };
        HideMe();
    }

    public void UpdatePanelInfo()
    {
        MusicData data = GameDataMgr.Instance.musicData;

        sliderMusic.nowValue = data.bkValue;
        sliderSound.nowValue = data.soundValue;

        togMusic.isSel = data.isOpenBK;
        togSound.isSel = data.isOpenBK;

    }
    public override void ShowMe()
    {
        base.ShowMe();
        UpdatePanelInfo();
    }
    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }

}
