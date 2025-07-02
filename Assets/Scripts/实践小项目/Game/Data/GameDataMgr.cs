using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class GameDataMgr
{
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance{get => instance;}
    //音效数据对象
    public MusicData musicData;
    //排行榜数据对象
    public RankList rankData;

    private GameDataMgr()
    {
        //可以初始化游戏数据
        musicData = DataManager.Instance.LoadData(typeof(MusicData), "Music") as MusicData;

        if (!musicData.notFirst)
        {
            musicData.isOpenBK = true;
            musicData.isOpenSound = true;
            musicData.bkValue = 1;
            musicData.soundValue = 1;
            musicData.notFirst = true;
            DataManager.Instance.SaveData(musicData, "Music");
        }

        rankData = DataManager.Instance.LoadData(typeof(RankList), "Rank") as RankList;
    }
    #region 排行榜方法
    public void AddRankInfo(string name,int score,float time)
    {
        rankData.list.Add(new RankInfo(name, score, time));
        //排序
        rankData.list.Sort((a, b) => a.time < b.time ? -1 : 1);
        //移除8条之外的数据
        for (int i = rankData.list.Count-1; i >= 8; i--)
        {
            rankData.list.RemoveAt(i);
        }
        DataManager.Instance.SaveData(rankData, "Rank");
    }
    #endregion

    #region 音乐方法
    public void OpenOrCloseBKMusic(bool isOpen)
    {
        musicData.isOpenBK = isOpen;

        BKMusic.Instance.ChangeOpen(isOpen);

        DataManager.Instance.SaveData(musicData, "Music");
    }
    public void OpenOrCloseSound(bool isOpen)
    {
        musicData.isOpenSound = isOpen;



        DataManager.Instance.SaveData(musicData, "Music");
    }
    public void ChangeBKValue(float value)
    {
        musicData.bkValue = value;

        BKMusic.Instance.ChangeValue(value);

        DataManager.Instance.SaveData(musicData, "Music");
    }
    public void ChangeSoundValue(float value)
    {
        musicData.soundValue = value;
        DataManager.Instance.SaveData(musicData, "Music");
    }
    #endregion
    

}
