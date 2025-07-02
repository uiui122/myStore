using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform targePlayer;
    private Vector3 pos;
    public float H = 10;
    private void LateUpdate()
    {
        if (targePlayer == null)
            return;
        pos.x = targePlayer.position.x;
        pos.z = targePlayer.position.z;
        pos.y = H;
        this.transform.position = pos;
    }
}
