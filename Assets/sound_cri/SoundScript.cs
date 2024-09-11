using CriWare.Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    CriWare.CriAtomExPlayer atomExPlayer;

    [SerializeField]
    CriWare.Assets.CriAtomCueReference cueReference;

    // Start is called before the first frame update
    void Start()
    {
        cueReference.AcbAsset.LoadImmediate();

        atomExPlayer = new CriWare.CriAtomExPlayer();

        atomExPlayer.SetCue(cueReference.AcbAsset.Handle, cueReference.CueId);

        atomExPlayer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
