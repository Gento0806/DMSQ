using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;


public class BypassButtonEvent : MonoBehaviour, ISelectHandler
{
    public Button target;
    public Slider target2;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference select;


    public void OnSelect(BaseEventData eventData)
    {
        if (target!=null || target2!=null)
        {
            if (target2 == null)
            {
                target.OnSelect(eventData);
            }
            else
            {
                target2.OnSelect(eventData);
            }
            ADXSoundManager.Instance.PlaySound("select", select.AcbAsset.Handle, select.CueId, gameObject.transform, false);
        }
    }


}
