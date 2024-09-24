using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySoundListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 例えばカメラやプレイヤーなどのListenerにしたいTransformを指定すればよい
        ADXSoundManager.Instance.SetListenerTransform(this.gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        // リスナーの座標を更新
        ADXSoundManager.Instance.UpdateListenerPosition();
    }
}
