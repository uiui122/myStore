using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTank : TankBaseObj
{
    //在两个点之间来回移动
    private Transform targetPos;
    //随机移动的坐标
    public Transform[] randomPos;
    //看向玩家
    public Transform lookAtTarget;
    //距离近时攻击目标
    //开火距离 小于该距离 会攻击
    public float fireDis = 5;
    //攻击间隔
    public float fireOffsetTime = 1;
    private float nowTime = 0;
    //开火点
    public Transform[] shootPos;
    //子弹预设体
    public GameObject bulletObj;
    //防止重复得分
    private bool isGetScore = false;

    public Texture maxHpBK;
    public Texture HpBK;
    //Rect为结构体，可以不new，是类就必须new了
    private Rect maxHpRect;
    private Rect hpRect;

    //血条显示时间
    private float showTime;

    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bulletObj, shootPos[i].position, shootPos[i].rotation);
            //子弹拥有者
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.SetFather(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        #region 多点随机移动
        this.transform.LookAt(targetPos);
        //不停的位移
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Vector3.Distance(this.transform.position, targetPos.position) < 0.05f)
        {
            RandomPos();
        }
        #endregion

        #region 看向玩家
        if (lookAtTarget != null)
        {
            tankHead.LookAt(lookAtTarget);
            if (Vector3.Distance(this.transform.position, lookAtTarget.position) <= fireDis)
            {
                nowTime += Time.deltaTime;
                if(nowTime>= fireOffsetTime)
                {
                    Fire();
                    nowTime = 0;
                }
            }
        }

        #endregion

        #region 攻击玩家

        #endregion
    }
    private void RandomPos()
    {
        if (randomPos.Length == 0)
            return;
        targetPos = randomPos[Random.Range(0, randomPos.Length)];
    }

    public override void Dead()
    {
        if (!isGetScore)
        {
            isGetScore = true;
            GamePanel.Instance.AddScore(10);
        }
            
        base.Dead();
        
    }
    /// <summary>
    /// 血条UI的绘制
    /// </summary>
    private void OnGUI()
    {
        //显示时间大于0时，显示怪物血量
        if (showTime > 0)
        {
            showTime -= Time.deltaTime;
            //1.怪物位置 转为 屏幕位置
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            //2.屏幕位置 转为 GUI位置
            screenPos.y = Screen.height - screenPos.y;

            //先画血量图底图
            maxHpRect.x = screenPos.x-50;
            maxHpRect.y = screenPos.y-20;
            maxHpRect.width = 100;
            maxHpRect.height = 15;
            GUI.DrawTexture(maxHpRect,maxHpBK);
            //画血量图
            hpRect.x = screenPos.x - 50;
            hpRect.y = screenPos.y - 20;
            hpRect.width = (float) hp / maxHp *100f;
            hpRect.height = 15;
            GUI.DrawTexture(hpRect, HpBK);

        }
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        showTime = 3;
    }
}
