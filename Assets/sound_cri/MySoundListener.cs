using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySoundListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // �Ⴆ�΃J������v���C���[�Ȃǂ�Listener�ɂ�����Transform���w�肷��΂悢
        ADXSoundManager.Instance.SetListenerTransform(this.gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        // ���X�i�[�̍��W���X�V
        ADXSoundManager.Instance.UpdateListenerPosition();
    }
}
