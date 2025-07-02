using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    //得分
    public CustomGUILabel labelScore;
    //时间
    public CustomGUILabel labTime;
    //退出按钮
    public CustomGUIButton btnQuit;
    //设置按钮
    public CustomGUIButton btnSetting;
    //血量图
    public CustomGUITexture texHP;
    //血条宽度
    public float hpw = 350;

    [HideInInspector]
    public int nowScore = 0;
    [HideInInspector]
    public float nowTime = 0;
    private int time;
    // Start is called before the first frame update
    void Start()
    {
        btnSetting.clickEvent += () =>
        {
            //点设置面板后的操作
            SettingPanel.Instance.ShowMe();

            Time.timeScale = 0;
        };
        btnQuit.clickEvent += () =>
        {
            //弹出一个确定退出的按钮
            //点击后返回开始界面；
            QuitPanel.Instance.ShowMe();
            Time.timeScale = 0;
        };




    }

    // Update is called once per frame
    void Update()
    {
        //通过帧间隔时间来累加时间
        nowTime += Time.deltaTime;
        time = (int)nowTime;
        //把秒转换为时分秒
        labTime.content.text = "";
        if (time / 3600 > 0)
        {
            labTime.content.text += time / 3600 + "时";
        }
        if (time % 3600 / 60 > 0 || labTime.content.text != "")
        {
            labTime.content.text += time % 3600 / 60 + "分";
        }
        labTime.content.text += time % 60 + "秒";


    }
    /// <summary>
    /// 提供给外部的加分方法 
    /// </summary>
    /// <param name="score"></param>
    public void AddScore(int score)
    {
        nowScore += score;
        labelScore.content.text = nowScore.ToString();
    }
    /// <summary>
    /// 更新血条的方法
    /// </summary>
    /// <param name="maxHP"></param>
    /// <param name="HP"></param>
    public void UpdateHP(int maxHP,int HP)
    {
        texHP.guiPos.width = (float)HP / maxHP * hpw;
    }
}
