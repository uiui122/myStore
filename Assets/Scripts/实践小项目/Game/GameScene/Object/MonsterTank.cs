using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTank : TankBaseObj
{
    //��������֮�������ƶ�
    private Transform targetPos;
    //����ƶ�������
    public Transform[] randomPos;
    //�������
    public Transform lookAtTarget;
    //�����ʱ����Ŀ��
    //������� С�ڸþ��� �ṥ��
    public float fireDis = 5;
    //�������
    public float fireOffsetTime = 1;
    private float nowTime = 0;
    //�����
    public Transform[] shootPos;
    //�ӵ�Ԥ����
    public GameObject bulletObj;
    //��ֹ�ظ��÷�
    private bool isGetScore = false;

    public Texture maxHpBK;
    public Texture HpBK;
    //RectΪ�ṹ�壬���Բ�new������ͱ���new��
    private Rect maxHpRect;
    private Rect hpRect;

    //Ѫ����ʾʱ��
    private float showTime;

    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bulletObj, shootPos[i].position, shootPos[i].rotation);
            //�ӵ�ӵ����
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
        #region �������ƶ�
        this.transform.LookAt(targetPos);
        //��ͣ��λ��
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Vector3.Distance(this.transform.position, targetPos.position) < 0.05f)
        {
            RandomPos();
        }
        #endregion

        #region �������
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

        #region �������

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
    /// Ѫ��UI�Ļ���
    /// </summary>
    private void OnGUI()
    {
        //��ʾʱ�����0ʱ����ʾ����Ѫ��
        if (showTime > 0)
        {
            showTime -= Time.deltaTime;
            //1.����λ�� תΪ ��Ļλ��
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            //2.��Ļλ�� תΪ GUIλ��
            screenPos.y = Screen.height - screenPos.y;

            //�Ȼ�Ѫ��ͼ��ͼ
            maxHpRect.x = screenPos.x-50;
            maxHpRect.y = screenPos.y-20;
            maxHpRect.width = 100;
            maxHpRect.height = 15;
            GUI.DrawTexture(maxHpRect,maxHpBK);
            //��Ѫ��ͼ
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
