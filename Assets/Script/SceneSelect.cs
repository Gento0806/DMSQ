using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ライブラリの追加
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
        if (SceneManager.GetActiveScene().buildIndex == 17&&this.gameObject.name== "StageButton1")//シーン選択画面のボタン１のみ読み込む
        {
            for (int i = 1; i < StageNumImage.Length; i++)//クリア状況によって画像を入れ替える
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
        if (Input.GetButtonDown("Option") && Input.GetButtonDown("Share"))//クリアデータのリセット
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
    //StartGame関数
    public void StartGame(int stageID)
    {
        // GameSceneをロード
        SceneManager.LoadScene(stageID);
    }

    //
    public static void StageNumGet()
    {
        // 現在読み込んでいるシーンのインデックスを取得
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StageNum = currentSceneIndex;
    }
    public static void StageNumChange()
    {
        // 現在読み込んでいるシーンのインデックスを取得
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        ClearNum[currentSceneIndex] = true;//クリアの設定s
        StageNum = currentSceneIndex + 1;
    }

    public void NextStage()
    {
        SceneManager.LoadScene(StageNum);
    }
}