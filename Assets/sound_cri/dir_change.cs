using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dir_change : MonoBehaviour
{
    [SerializeField]
    CriWare.Assets.CriAtomCueReference cueReference;
    private Tmpg tmpg_;
    // Start is called before the first frame update
    void Start()
    {
        tmpg_ = new Tmpg();
        tmpg_.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if(tmpg_.Player.Houkoukirikaehidari.triggered)
        {
            ADXSoundManager.Instance.PlaySound("dirchange", cueReference.AcbAsset.Handle, cueReference.CueId, gameObject.transform, false);
        }
        else if (tmpg_.Player.Houkoukirikaemigi.triggered)
        {
            ADXSoundManager.Instance.PlaySound("dirchange", cueReference.AcbAsset.Handle, cueReference.CueId, gameObject.transform, false);
        }
    }
}
