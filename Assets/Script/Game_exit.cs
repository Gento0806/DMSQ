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

    // ��b��ɃQ�[�����I������R���[�`��
    private IEnumerator QuitAfterDelay()
    {
        // 1�b�҂�
        yield return new WaitForSeconds(0.8f);
        // �Q�[�����I��
        Application.Quit();
    }
}
