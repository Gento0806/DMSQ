using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChan_follow_keigo : MonoBehaviour
{
    public Transform targetObject; // �ǐՑΏۂ̃I�u�W�F�N�g
    void Update()
    {
        if (targetObject != null)
        {
            // �ǐՑΏۂ̍��W���擾���āA���g�̍��W�ɐݒ肷��
            transform.position = targetObject.position;
        }
    }
}
