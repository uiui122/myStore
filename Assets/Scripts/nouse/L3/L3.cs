using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class L3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region �����
        //Random r = new Random();
        int randomNum = Random.Range(0, 100);//������Ҳ�����
        print(randomNum);
        //float���أ����Ҷ�����
        float randomNumf = Random.Range(1.1f, 99.9f);

        //System.Random r = new System.Random();

        #endregion

        #region ί��
        //c#�Դ���ί��
        System.Action ac = () =>
        {
            print("123");
        };
        System.Action<int, float> ac2 = (i, f) =>
        {

        };
        System.Func<int> fun = () =>
        {
            return 1;
        };

        UnityAction<string> uac1  = (s)=>{

        };
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
