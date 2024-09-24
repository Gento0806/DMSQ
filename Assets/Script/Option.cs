using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Option : MonoBehaviour
{
    bool option = false;
    public GameObject[] GameObjectsTohidden;
   

    [SerializeField]
    CriWare.Assets.CriAtomCueReference inopt;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference outopt;

    // Use this for initialization
    void Start()
    {
        //�V�[�����j�����ꂽ�Ƃ��ɌĂяo�����悤�ɂ���
        SceneManager.sceneUnloaded += OnSceneUnloaded;
       
    }

    //�T�u�{�^���������ꂽ
    void Update()
    {
        if (Input.GetButtonDown("Option"))
        {
            if (option == false)
            {
                foreach (GameObject obj in GameObjectsTohidden)
                {
                    obj.SetActive(false);
                }
                //���C���V�[���ɃT�u�V�[����ǉ��\������
                Application.LoadLevelAdditive("Option");
                option = true;
                Time.timeScale = 0.0f;
                ADXSoundManager.Instance.PlaySound("inopt", inopt.AcbAsset.Handle, inopt.CueId, gameObject.transform, false);
            }
            else if (option == true)
            {
                SceneManager.UnloadScene("Option");
                //�T�u�V�[�����Ăяo���Ă���Ƃ��ɔ�\���ɂ���Q�[���I�u�W�F�N�g
                option = false;
                Time.timeScale = 1.0f;
                ADXSoundManager.Instance.PlaySound("outopt", outopt.AcbAsset.Handle, outopt.CueId, gameObject.transform, false);
            }
        }
    }

    private void OnSceneUnloaded(Scene current)
    {
        //�V�[�����j�����ꂽ�Ƃ��ɌĂяo�����
        //����̗�ł́A�T�u�V�[�����j�����ꂽ��Ăяo�����悤�ɂȂ��Ă��܂�
        Debug.Log("OnSceneUnloaded: " + current.name);

        //�{���́A�ǂ̃V�[�����j�����ꂽ�̂��m�F���Ă��珈�����������ǂ���������Ȃ�

        //�Q�[���I�u�W�F�N�g��\������
        foreach (GameObject obj in GameObjectsTohidden)
        {
            obj.SetActive(true);
        }
    }

}