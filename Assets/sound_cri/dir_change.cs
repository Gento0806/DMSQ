using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dir_change : MonoBehaviour
{
    [SerializeField]
    CriWare.Assets.CriAtomCueReference cueReference;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("KirikaeLeft"))
        {
            //ADXSoundManager.Instance.PlaySound("dirchange", cueReference.AcbAsset.Handle, cueReference.CueId, gameObject.transform, false);
        }
        else if (Input.GetButtonDown("KirikaeRight"))
        {
            //ADXSoundManager.Instance.PlaySound("dirchange", cueReference.AcbAsset.Handle, cueReference.CueId, gameObject.transform, false);
        }
    }
}
