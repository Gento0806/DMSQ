using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ���C�u�����̒ǉ�
using UnityEngine.SceneManagement;
using System.Reflection;
using UnityEngine.UI;
using Unity.VisualScripting;

public class SceneSelect : MonoBehaviour
{
    public static int StageNum = 0;
    public static bool[] ClearNum=new bool[20];
    [SerializeField] Sprite[] BeforeImage;
    [SerializeField] Sprite[] AfterImage;
    [SerializeField] Sprite[] SelectedBeforeImage;
    [SerializeField] Sprite[] SelectedAfterImage;
    public GameObject[] StageNumImage;
    
    Image img;
    Button btn;
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 17&&this.gameObject.name== "StageButton1")//�V�[���I����ʂ̃{�^���P�̂ݓǂݍ���
        {
            for (int i = 1; i < StageNumImage.Length; i++)//�N���A�󋵂ɂ���ĉ摜�����ւ���
            {
                img = StageNumImage[i].GetComponent<Image>();

                btn = StageNumImage[i].GetComponent<Button>();
                SpriteState sp= btn.spriteState;

                if (ClearNum[i])
                {
                    img.sprite = AfterImage[i];
                    sp.selectedSprite = SelectedAfterImage[i];
                }
                else
                {
                    img.sprite = BeforeImage[i];
                    sp.selectedSprite = SelectedBeforeImage[i];
                }
                btn.spriteState = sp;
            }
        }

    }
    void Update()
    {
        if (Input.GetButtonDown("Option") && Input.GetButtonDown("Share"))//�N���A�f�[�^�̃��Z�b�g
        {
            for(int i=1;i< StageNumImage.Length; i++)
            {
                img = StageNumImage[i].GetComponent<Image>();
                btn = StageNumImage[i].GetComponent<Button>();
                SpriteState sp = btn.spriteState;

                img.sprite = BeforeImage[i];
                sp.selectedSprite = SelectedBeforeImage[i];
                btn.spriteState = sp;
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