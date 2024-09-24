using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMscript : MonoBehaviour
{
    [SerializeField]
    CriWare.Assets.CriAtomCueReference BGM;
    bool bgm = true;
    void Start()
    {
        if(bgm)
        {
            ADXSoundManager.Instance.PlaySound("bgm", BGM.AcbAsset.Handle, BGM.CueId, gameObject.transform, false);
            bgm = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
