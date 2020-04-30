using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player; // 玉のオブジェクト

    private Vector3 offset; // 玉からカメラまでの距離

    void Start()
    {
        offset = new Vector3(0f, 5.0f, -5.0f);
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
