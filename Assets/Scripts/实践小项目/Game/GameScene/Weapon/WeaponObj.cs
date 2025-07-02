using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    //����ʵ�������ӵ�����
    public GameObject bullet;
    //����λ��
    public Transform[] shootPos;
    //����ӵ����
    public TankBaseObj fatherObj;

    public void SetFather(TankBaseObj obj)
    {
        fatherObj = obj;
    }
    public void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            //�����ӵ�Ԥ����
            GameObject obj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
            //����ӵ�
            BulletObj bulletObj = obj.GetComponent<BulletObj>();
            bulletObj.SetFather(fatherObj);
        }
    }

}
