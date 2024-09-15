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
    [SerializeField] GameObject KeyNumImage;
    [SerializeField] Sprite[] KeyNumSprite;
    AudioSource audiosource;
    int KeyNow;
    int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        KeyNow = 0;
        audiosource = GetComponent<AudioSource>();
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
        if (KeyNow < a)//鍵取得数更新
        {
            KeyNow = a;
        }

        if(KeyNow == KeyNum)
        {
            int LockNum=Lock.Length;
            for(int i=0;i<LockNum; i++)
            {
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
            audiosource.PlayOneShot(GetKeySound);
        }
    }
}
