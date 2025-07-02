using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    //�÷�
    public CustomGUILabel labelScore;
    //ʱ��
    public CustomGUILabel labTime;
    //�˳���ť
    public CustomGUIButton btnQuit;
    //���ð�ť
    public CustomGUIButton btnSetting;
    //Ѫ��ͼ
    public CustomGUITexture texHP;
    //Ѫ�����
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
            //����������Ĳ���
            SettingPanel.Instance.ShowMe();

            Time.timeScale = 0;
        };
        btnQuit.clickEvent += () =>
        {
            //����һ��ȷ���˳��İ�ť
            //����󷵻ؿ�ʼ���棻
            QuitPanel.Instance.ShowMe();
            Time.timeScale = 0;
        };




    }

    // Update is called once per frame
    void Update()
    {
        //ͨ��֡���ʱ�����ۼ�ʱ��
        nowTime += Time.deltaTime;
        time = (int)nowTime;
        //����ת��Ϊʱ����
        labTime.content.text = "";
        if (time / 3600 > 0)
        {
            labTime.content.text += time / 3600 + "ʱ";
        }
        if (time % 3600 / 60 > 0 || labTime.content.text != "")
        {
            labTime.content.text += time % 3600 / 60 + "��";
        }
        labTime.content.text += time % 60 + "��";


    }
    /// <summary>
    /// �ṩ���ⲿ�ļӷַ��� 
    /// </summary>
    /// <param name="score"></param>
    public void AddScore(int score)
    {
        nowScore += score;
        labelScore.content.text = nowScore.ToString();
    }
    /// <summary>
    /// ����Ѫ���ķ���
    /// </summary>
    /// <param name="maxHP"></param>
    /// <param name="HP"></param>
    public void UpdateHP(int maxHP,int HP)
    {
        texHP.guiPos.width = (float)HP / maxHP * hpw;
    }
}
