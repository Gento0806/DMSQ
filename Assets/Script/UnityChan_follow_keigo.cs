using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChan_follow_keigo : MonoBehaviour
{
    public Transform targetObject; // 追跡対象のオブジェクト
    void Update()
    {
        if (targetObject != null)
        {
            // 追跡対象の座標を取得して、自身の座標に設定する
            transform.position = targetObject.position;
        }
    }
}
