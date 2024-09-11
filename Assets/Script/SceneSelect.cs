using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ライブラリの追加
using UnityEngine.SceneManagement;
public class SceneSelect : MonoBehaviour
{
    public static int StageNum = 0;

    //StartGame関数
    public void StartGame(int stageID)
    {
        // GameSceneをロード
        SceneManager.LoadScene(stageID);
    }

    public static void StageNumChange()
    {
        // 現在読み込んでいるシーンのインデックスを取得
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StageNum = currentSceneIndex + 1;
    }

    public void NextStage()
    {
        SceneManager.LoadScene(StageNum);
    }
}