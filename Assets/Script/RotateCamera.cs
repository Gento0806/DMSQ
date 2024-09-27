using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // ��]���x�𒲐��ł���悤�ɂ���
    public float rotationSpeed = 100f;

    void Update()
    {
        // I�L�[��������Ă����
        if (Input.GetKey(KeyCode.I))
        {
            // Y���ŕ��̕����ɉ�]
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.O))
        {
            // Y���ŕ��̕����ɉ�]
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }
}
