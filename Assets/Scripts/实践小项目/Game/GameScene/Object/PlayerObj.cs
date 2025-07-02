using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj
{
    //当前武器
    public WeaponObj nowWeapon;
    //武器父对象位置
    public Transform weaponPos;
    void Update()
    {
        //ws 控制 前进
        this.transform.Translate(Input.GetAxis("Vertical")* Vector3.forward * moveSpeed * Time.deltaTime);


        //ad 控制 旋转
        this.transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * roundSpeed * Time.deltaTime);
        //鼠标 控制 炮台旋转 和 开火
        //旋转
        tankHead.transform.Rotate(Input.GetAxis("Mouse X") * Vector3.up * headRoundSpeed * Time.deltaTime);
        //开火
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    //重写 父类行为中玩家的特定行为
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
    /// 切换武器
    /// </summary>
    /// <param name="weapon"></param>
    public void ChangeWeapon(GameObject weapon)
    {
        if(nowWeapon != null)
        {
            Destroy(nowWeapon.gameObject);
            nowWeapon = null;
        }
        //创建武器，设置父对象，保持大小不变
        GameObject weaponObj = Instantiate(weapon, weaponPos, false);
        nowWeapon = weaponObj.GetComponent<WeaponObj>();

        nowWeapon.SetFather(this);
    }
}
