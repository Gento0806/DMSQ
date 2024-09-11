using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ���C�u�����̒ǉ�
using UnityEngine.SceneManagement;
public class SceneSelect : MonoBehaviour
{
    public static int StageNum = 0;

    //StartGame�֐�
    public void StartGame(int stageID)
    {
        // GameScene�����[�h
        SceneManager.LoadScene(stageID);
    }

    public static void StageNumChange()
    {
        // ���ݓǂݍ���ł���V�[���̃C���f�b�N�X���擾
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StageNum = currentSceneIndex + 1;
    }

    public void NextStage()
    {
        SceneManager.LoadScene(StageNum);
    }
}