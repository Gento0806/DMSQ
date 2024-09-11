using CriWare;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class se_volume_UI : MonoBehaviour
{
    [SerializeField]
    CriWare.Assets.CriAtomCueReference clup;



    public void Clickup()
    {
        if(Input.GetMouseButtonUp(0))
        {
            ADXSoundManager.Instance.PlaySound("cliup",clup.AcbAsset.Handle, clup.CueId, gameObject.transform, false);
        }
    }
}
