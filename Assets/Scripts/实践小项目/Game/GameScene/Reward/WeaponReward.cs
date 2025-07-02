using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReward : MonoBehaviour
{

    public GameObject[] weapenObj;
    //获取特效
    public GameObject getEff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            //切换武器
            int index = Random.Range(0, weapenObj.Length);
            PlayerObj player = other.GetComponent<PlayerObj>();
            player.ChangeWeapon(weapenObj[index]);
            //播放 奖励音效
            GameObject eff = Instantiate(getEff, this.transform.position, this.transform.rotation);
            //音效大小和开启
            AudioSource audioSource = eff.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;


            //移除自己
            Destroy(this.gameObject);

        }
    }

}
