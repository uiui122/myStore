using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    public float moveSpeed = 50;
    
    public TankBaseObj fatherObj;

    public GameObject effObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * moveSpeed*Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        //子弹射击到立方体和不同阵营的对象都会爆炸
        if(other.CompareTag("Cube")||
           other.CompareTag("Player")  && fatherObj.CompareTag("Monster")||
           other.CompareTag("Monster") && fatherObj.CompareTag("Player"))
        {
            //判断是否受伤，检测有坦克脚本的对象
            TankBaseObj obj = other.GetComponent<TankBaseObj>();
            if (obj != null)
                obj.Wound(fatherObj);





            if (effObj!=null)
            {
                GameObject eff = Instantiate(effObj, this.transform.position, this.transform.rotation);
                //改音效的音量和开启状态
                AudioSource audioSource = eff.GetComponent<AudioSource>();
                //设置音效大小
                audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
                //设置有无
                audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;


            }
            //子弹销毁
            Destroy(this.gameObject);
            
        }
            
    }
    public void SetFather(TankBaseObj obj)
    {
        fatherObj = obj;
    }
}
