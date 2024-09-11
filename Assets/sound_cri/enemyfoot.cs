using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyfoot : MonoBehaviour
{

    //---‰¹---
    [SerializeField]
    CriWare.Assets.CriAtomCueReference enemyfoot1;
    //--------
    // Start is called before the first frame update
    void Start()
    {
        ADXSoundManager.Instance.PlaySound("enemyfoot", enemyfoot1.AcbAsset.Handle, enemyfoot1.CueId, gameObject.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
