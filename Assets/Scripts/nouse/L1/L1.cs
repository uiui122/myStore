using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 场景

        #endregion
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //切换场景
            SceneManager.LoadScene("GameScene");
            //注意要先在File->Build Settings中添加Scene
            
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //执行后退出游戏
            //编辑模式没用
            //变为exe文件后会有用
            Application.Quit();
        }
    }
}
