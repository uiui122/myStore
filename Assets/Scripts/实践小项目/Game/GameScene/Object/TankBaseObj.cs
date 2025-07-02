using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    //�������������������Ѫ������ǰѪ��
    public int atk;
    public int def;
    public int maxHp;
    public int hp;

    //��̨���
    public Transform tankHead;

    //�ƶ�����ת�ٶ�
    public float moveSpeed = 10;
    public float roundSpeed = 100;
    public float headRoundSpeed = 100;

    //������Ч 
    public GameObject deadEff;

    /// <summary>
    /// ���𷽷�
    /// </summary>
    public abstract void Fire();

    /// <summary>
    /// �����˹���
    /// </summary>
    /// <param name="other"></param>
    public virtual void Wound(TankBaseObj other)
    {
        int damage = other.atk - this.def;
        if (damage <= 0)
            return;
        this.hp -= damage;
        if(this.hp <= 0)
        {
            this.hp = 0;
            this.Dead();
            //��������
        }
    }
    /// <summary>
    /// ������Ϊ ���Լ�Ѫ��С�ڵ���0ʱ ���ô˷���
    /// </summary>
    public virtual void Dead()
    {
        //�����������ڳ������Ƴ��ö���
        Destroy(this.gameObject);
        //����ʾ������Ч
        if (deadEff != null)
        {
            GameObject effObj = Instantiate(deadEff, this.transform.position, this.transform.rotation);
            //��Ч�������� ֱ�ӹ�������Ч ����Ч�������Ҳһ�������
            AudioSource audioSource = effObj.GetComponent<AudioSource>();

            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            audioSource.Play();
        }



    }

}
