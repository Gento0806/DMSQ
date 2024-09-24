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
        //シーンが破棄されたときに呼び出されるようにする
        SceneManager.sceneUnloaded += OnSceneUnloaded;
       
    }

    //サブボタンが押された
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
                //メインシーンにサブシーンを追加表示する
                Application.LoadLevelAdditive("Option");
                option = true;
                Time.timeScale = 0.0f;
                ADXSoundManager.Instance.PlaySound("inopt", inopt.AcbAsset.Handle, inopt.CueId, gameObject.transform, false);
            }
            else if (option == true)
            {
                SceneManager.UnloadScene("Option");
                //サブシーンを呼び出しているときに非表示にするゲームオブジェクト
                option = false;
                Time.timeScale = 1.0f;
                ADXSoundManager.Instance.PlaySound("outopt", outopt.AcbAsset.Handle, outopt.CueId, gameObject.transform, false);
            }
        }
    }

    private void OnSceneUnloaded(Scene current)
    {
        //シーンが破棄されたときに呼び出される
        //今回の例では、サブシーンが破棄されたら呼び出されるようになっています
        Debug.Log("OnSceneUnloaded: " + current.name);

        //本当は、どのシーンが破棄されたのか確認してから処理した方が良いかもしれない

        //ゲームオブジェクトを表示する
        foreach (GameObject obj in GameObjectsTohidden)
        {
            obj.SetActive(true);
        }
    }

}