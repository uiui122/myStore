using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class L3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 随机数
        //Random r = new Random();
        int randomNum = Random.Range(0, 100);//左包含右不包含
        print(randomNum);
        //float重载，左右都包含
        float randomNumf = Random.Range(1.1f, 99.9f);

        //System.Random r = new System.Random();

        #endregion

        #region 委托
        //c#自带的委托
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
