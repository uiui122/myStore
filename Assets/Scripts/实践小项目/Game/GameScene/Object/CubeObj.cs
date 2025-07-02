using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObj : MonoBehaviour
{
    public GameObject[] rewardObjs;
    //�����ƻ���Ч
    public GameObject breakEff;
    private void OnTriggerEnter(Collider other)
    {

        //���һ���� ����ȡ����
        int rangeInt = Random.Range(0, 100);
        if (rangeInt < 50)
        {
            rangeInt = Random.Range(0, rewardObjs.Length);
            Instantiate(rewardObjs[rangeInt], this.transform.position, this.transform.rotation);
        }
        GameObject eff = Instantiate(breakEff, this.transform.position, this.transform.rotation);
        //��Ч��С�Ϳ���
        AudioSource audioSource = eff.GetComponent<AudioSource>();
        audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
        audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;


        Destroy(this.gameObject);
    }
}
