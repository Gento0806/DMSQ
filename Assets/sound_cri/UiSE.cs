using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiSE : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    CriWare.Assets.CriAtomCueReference cursorOn;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference click;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ADXSoundManager.Instance.PlaySound("cursor", cursorOn.AcbAsset.Handle, cursorOn.CueId, gameObject.transform, false);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Test()
    {
        ADXSoundManager.Instance.PlaySound("click", click.AcbAsset.Handle, click.CueId, gameObject.transform, false);
    }
    public void stopbgm()
    {
        ADXSoundManager.Instance.StopSound("bgm");
        ADXSoundManager.Instance.StopSound("soner");
        ADXSoundManager.Instance.StopSound("move");
        ADXSoundManager.Instance.StopSound("hover");
    }
}
