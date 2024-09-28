using CriWare.Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class KeyRock : MonoBehaviour
{
    [SerializeField] int KeyNum;
    [SerializeField] GameObject[] KeyObj;
    [SerializeField] GameObject[] Lock;
    [SerializeField] AudioClip GetKeySound;
    [SerializeField] CriWare.Assets.CriAtomCueReference getkey;
    [SerializeField] CriWare.Assets.CriAtomCueReference key_open;
    [SerializeField] GameObject KeyNumImage;
    [SerializeField] Sprite[] KeyNumSprite;
    [SerializeField] GameObject CameraCon;
    AudioSource audiosource;
    CameraCon cameracon;
    
    int KeyNow;
    int a = 0;
    public bool key0;
    // Start is called before the first frame update
    void Start()
    {
        KeyNow = 0;
        audiosource = GetComponent<AudioSource>();
        key0 = true;
        cameracon = GameObject.Find("CameraCon").GetComponent<CameraCon>();
    }

    // Update is called once per frame
    void Update()
    {
        a = 0;
        for(int i = 0; i < KeyObj.Length; i++)
        {
            if (KeyObj[i].activeSelf==false)
            {
                if (i % 2 == 0)
                {
                    KeyObj[i + 1].SetActive(false);
                }
                else
                {
                    KeyObj[i-1].SetActive(false);
                }
                a++;
            }
        }
        if (KeyNow < a)//Œ®Žæ“¾”XV
        {
            KeyNow = a;
        }

        if(KeyNow == KeyNum)
        {
            int LockNum=Lock.Length;
            for(int i=0;i<LockNum; i++)
            {
                if(cameracon.key0)
                {
                    ADXSoundManager.Instance.PlaySound("key_open", key_open.AcbAsset.Handle, key_open.CueId, gameObject.transform, false);
                }
                cameracon.key0 = false;
                Destroy(Lock[i]);
            }
        }
        Image img=KeyNumImage.GetComponent<Image>();
        img.sprite = KeyNumSprite[(KeyNum - KeyNow) / 2];
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            ADXSoundManager.Instance.PlaySound("KeyRock", getkey.AcbAsset.Handle, getkey.CueId, gameObject.transform, false);
            other.gameObject.SetActive(false);
           // audiosource.PlayOneShot(GetKeySound);
        }
    }
}
