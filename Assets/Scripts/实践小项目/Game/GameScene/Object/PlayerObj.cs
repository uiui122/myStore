using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj
{
    //��ǰ����
    public WeaponObj nowWeapon;
    //����������λ��
    public Transform weaponPos;
    void Update()
    {
        //ws ���� ǰ��
        this.transform.Translate(Input.GetAxis("Vertical")* Vector3.forward * moveSpeed * Time.deltaTime);


        //ad ���� ��ת
        this.transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * roundSpeed * Time.deltaTime);
        //��� ���� ��̨��ת �� ����
        //��ת
        tankHead.transform.Rotate(Input.GetAxis("Mouse X") * Vector3.up * headRoundSpeed * Time.deltaTime);
        //����
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    //��д ������Ϊ����ҵ��ض���Ϊ
    public override void Fire()
    {
        if (nowWeapon != null)
        {
            nowWeapon.Fire();
        }
    }
    public override void Dead()
    {
        Time.timeScale = 0;
        LosePanel.Instance.ShowMe();
    }
    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        GamePanel.Instance.UpdateHP(this.maxHp, this.hp);

    }
    /// <summary>
    /// �л�����
    /// </summary>
    /// <param name="weapon"></param>
    public void ChangeWeapon(GameObject weapon)
    {
        if(nowWeapon != null)
        {
            Destroy(nowWeapon.gameObject);
            nowWeapon = null;
        }
        //�������������ø����󣬱��ִ�С����
        GameObject weaponObj = Instantiate(weapon, weaponPos, false);
        nowWeapon = weaponObj.GetComponent<WeaponObj>();

        nowWeapon.SetFather(this);
    }
}
