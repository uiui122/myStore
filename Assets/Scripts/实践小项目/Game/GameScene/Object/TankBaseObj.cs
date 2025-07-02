using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    //攻击力、防御力、最大血量、当前血量
    public int atk;
    public int def;
    public int maxHp;
    public int hp;

    //炮台相关
    public Transform tankHead;

    //移动、旋转速度
    public float moveSpeed = 10;
    public float roundSpeed = 100;
    public float headRoundSpeed = 100;

    //死亡特效 
    public GameObject deadEff;

    /// <summary>
    /// 开火方法
    /// </summary>
    public abstract void Fire();

    /// <summary>
    /// 被他人攻击
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
            //死亡方法
        }
    }
    /// <summary>
    /// 死亡行为 当自己血量小于等于0时 调用此方法
    /// </summary>
    public virtual void Dead()
    {
        //对象死亡，在场景上移除该对象
        Destroy(this.gameObject);
        //再显示死亡特效
        if (deadEff != null)
        {
            GameObject effObj = Instantiate(deadEff, this.transform.position, this.transform.rotation);
            //特效对象身上 直接关联了音效 把音效播放相关也一起控制了
            AudioSource audioSource = effObj.GetComponent<AudioSource>();

            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            audioSource.Play();
        }



    }

}
