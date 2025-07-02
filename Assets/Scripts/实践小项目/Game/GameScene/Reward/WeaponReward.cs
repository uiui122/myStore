using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReward : MonoBehaviour
{

    public GameObject[] weapenObj;
    //��ȡ��Ч
    public GameObject getEff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            //�л�����
            int index = Random.Range(0, weapenObj.Length);
            PlayerObj player = other.GetComponent<PlayerObj>();
            player.ChangeWeapon(weapenObj[index]);
            //���� ������Ч
            GameObject eff = Instantiate(getEff, this.transform.position, this.transform.rotation);
            //��Ч��С�Ϳ���
            AudioSource audioSource = eff.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;


            //�Ƴ��Լ�
            Destroy(this.gameObject);

        }
    }

}
