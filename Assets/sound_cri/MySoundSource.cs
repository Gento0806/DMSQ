using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySoundSource : MonoBehaviour
{
    [SerializeField] CriWare.Assets.CriAtomCueReference cueReference;
    [SerializeField] bool is3dSource;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))       // 1が入力されたら
        {
            // キューを再生
            ADXSoundManager.Instance.PlaySound("MySound", cueReference.AcbAsset.Handle, cueReference.CueId, this.gameObject.transform, is3dSource);
        }

        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ADXSoundManager.Instance.StopSound("MySound");
        }

        if (is3dSource)
        {
            ADXSoundManager.Instance.UpdateSoundPosition("MySound");
        }
    }
}
