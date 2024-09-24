using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fade : MonoBehaviour
{
    public Image image;           // �t�F�[�h�Ώۂ�Image
    public float fadeInTime = 1.0f;  // �t�F�[�h�C���ɂ����鎞��
    public float fadeOutTime = 1.0f;  // �t�F�[�h�A�E�g�ɂ����鎞��
    public float waitTime = 6.0f;      // �t�F�[�h�C����̑ҋ@����
    public float waitTime2 = 0.0f;      // �t�F�[�h�C����̑ҋ@����

    private void Start()
    {
        // �X�^�[�g���ɃA���t�@�l��0�ɂ���i�����j
        Color color = image.color;
        color.a = 0f;
        image.color = color;

        // �t�F�[�h�C�����J�n
        StartCoroutine(FadeInAndOut());
    }

    private IEnumerator FadeInAndOut()
    {
        yield return new WaitForSeconds(waitTime2);

        // �t�F�[�h�C��
        yield return StartCoroutine(FadeIn());

        // �t�F�[�h�C��������A�ҋ@����
        yield return new WaitForSeconds(waitTime);

        // �t�F�[�h�A�E�g
        yield return StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeInTime)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeInTime);

            // �A���t�@�l���X�V
            Color color = image.color;
            color.a = alpha;
            image.color = color;

            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeOutTime)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(1 - (elapsedTime / fadeOutTime));

            // �A���t�@�l���X�V
            Color color = image.color;
            color.a = alpha;
            image.color = color;

            yield return null;
        }
    }
}