using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_exit : MonoBehaviour
{
    // Start is called before the first frame update
    public void Quit()
    {
        StartCoroutine(QuitAfterDelay());
    }

    // 一秒後にゲームを終了するコルーチン
    private IEnumerator QuitAfterDelay()
    {
        // 1秒待つ
        yield return new WaitForSeconds(0.8f);
        // ゲームを終了
        Application.Quit();
    }
}
