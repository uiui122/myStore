using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKMusic : MonoBehaviour
{
    private static BKMusic instance;
    public static BKMusic Instance => instance;

    private AudioSource audioSource;
    private void Awake()
    {
        instance = this;

        audioSource = this.GetComponent<AudioSource>();
        //��ʼ��ʱ�����������ñ�������
        ChangeValue(GameDataMgr.Instance.musicData.bkValue);
        ChangeOpen(GameDataMgr.Instance.musicData.isOpenBK);
    }
    /// <summary>
    /// �ı䱳�����ִ�С
    /// </summary>
    /// <param name="value"></param>
    public void ChangeValue(float value)
    {
        audioSource.volume = value;
    }
    /// <summary>
    /// ���ر�������
    /// </summary>
    /// <param name="isOpen"></param>
    public void ChangeOpen(bool isOpen)
    {
        //������� ���� ������
        //û�п��� ���� ����
        audioSource.mute = !isOpen;
    }
}
