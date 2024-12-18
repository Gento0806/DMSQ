using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // 回転速度を調整できるようにする
    public float rotationSpeed = 100f;

    void Update()
    {
        // Iキーが押されている間
        if (Input.GetKey(KeyCode.I))
        {
            // Y軸で負の方向に回転
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.O))
        {
            // Y軸で負の方向に回転
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }
}
