using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ���C�u�����̒ǉ�
using UnityEngine.SceneManagement;
using System.Reflection;
using UnityEngine.UI;
public class SceneSelect : MonoBehaviour
{
    public static int StageNum = 0;
    public static bool[] ClearNum=new bool[20];
    [SerializeField] Sprite[] BeforeImage;
    [SerializeField] Sprite[] AfterImage;
    public GameObject[] StageNumImage;
    Image img;
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 17&&this.gameObject.name== "StageButton1")//�V�[���I����ʂ̃{�^���P�̂ݓǂݍ���
        {
            for (int i = 1; i < StageNumImage.Length; i++)//�N���A�󋵂ɂ���ĉ摜�����ւ���
            {
                img = StageNumImage[i].GetComponent<Image>();
                if (ClearNum[i])
                    img.sprite = AfterImage[i];
                else
                    img.sprite = BeforeImage[i];
            }
        }

    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))//�N���A�f�[�^�̃��Z�b�g
        {
            for(int i=1;i< StageNumImage.Length; i++)
            {
                img = StageNumImage[i].GetComponent<Image>();
                img.sprite = BeforeImage[i];
                ClearNum[i] = false;
            }
        }
            
    }
    //StartGame�֐�
    public void StartGame(int stageID)
    {
        // GameScene�����[�h
        SceneManager.LoadScene(stageID);
    }

    //
    public static void StageNumGet()
    {
        // ���ݓǂݍ���ł���V�[���̃C���f�b�N�X���擾
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StageNum = currentSceneIndex;
    }
    public static void StageNumChange()
    {
        // ���ݓǂݍ���ł���V�[���̃C���f�b�N�X���擾
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        ClearNum[currentSceneIndex] = true;//�N���A�̐ݒ�s
        StageNum = currentSceneIndex + 1;
    }

    public void NextStage()
    {
        SceneManager.LoadScene(StageNum);
    }
}