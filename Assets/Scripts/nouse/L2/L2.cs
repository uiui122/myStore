using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2 : MonoBehaviour
{
    public Texture2D texture;

    // Start is called before the first frame update
    void Start()
    {
        #region 隐藏鼠标
        //Cursor.visible = false;
        #endregion
        #region 锁定鼠标
        //Cursor.lockState= CursorLockMode.None;//不锁定
        //Cursor.lockState = CursorLockMode.Locked;//锁定(还会隐藏)|esc摆脱锁定
        Cursor.lockState = CursorLockMode.Confined;//限制在窗口范围内
        #endregion
        #region 设置鼠标图片
        //参数一：光标图片
        //参数二：偏移位置
        //参数三：平台支持的光标模式（硬件或软件）
        Cursor.SetCursor(texture, Vector2.zero, CursorMode.Auto);

        #endregion


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
