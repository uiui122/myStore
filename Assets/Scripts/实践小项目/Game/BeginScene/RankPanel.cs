using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    public CustomGUIButton btnClose;

    private List<CustomGUILabel> labRank = new List<CustomGUILabel>();
    private List<CustomGUILabel> labName = new List<CustomGUILabel>();
    private List<CustomGUILabel> labScore = new List<CustomGUILabel>();
    private List<CustomGUILabel> labTime = new List<CustomGUILabel>();
    // Start is called before the first frame update
    void Start()
    {
        //��ȡ���а�����б�
        for (int i = 1; i <= 8; i++)
        {
            //labRank.Add(this.transform.Find("labRank/labRank" + i).GetComponent<CustomGUILabel>());
            labName.Add(this.transform.Find("labName/labName" + i).GetComponent<CustomGUILabel>());
            labScore.Add(this.transform.Find("labScore/labScore" + i).GetComponent<CustomGUILabel>());
            labTime.Add(this.transform.Find("labTime/labTime" + i).GetComponent<CustomGUILabel>());
        }
        //����
        btnClose.clickEvent += () =>
        {
            
            BeginPanel.Instance.ShowMe();
            HideMe();
        };
        HideMe();
    }

    public override void ShowMe()
    {
        base.ShowMe();
        UpdatePanelInfo();
    }
    public void UpdatePanelInfo()
    {
        //�������
        List<RankInfo> list = GameDataMgr.Instance.rankData.list;
        for (int i = 0; i < list.Count; i++)
        {
            //����
            labName[i].content.text = list[i].name;
            labScore[i].content.text = list[i].score.ToString();

            int time = (int)list[i].time;
            labTime[i].content.text = "";
            if (time / 3600 > 0)
            {
                labTime[i].content.text += time / 3600 + "ʱ";
            }
            if (time%3600 /60 > 0 || labTime[i].content.text !="")
            {
                labTime[i].content.text += time % 3600 / 60 + "��";
            }
            labTime[i].content.text += time % 60 + "��";
        }
    }
}
