using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fade : MonoBehaviour
{
    public Image image;           // フェード対象のImage
    public float fadeInTime = 1.0f;  // フェードインにかかる時間
    public float fadeOutTime = 1.0f;  // フェードアウトにかかる時間
    public float waitTime = 6.0f;      // フェードイン後の待機時間
    public float waitTime2 = 0.0f;      // フェードイン後の待機時間

    private void Start()
    {
        // スタート時にアルファ値を0にする（透明）
        Color color = image.color;
        color.a = 0f;
        image.color = color;

        // フェードインを開始
        StartCoroutine(FadeInAndOut());
    }

    private IEnumerator FadeInAndOut()
    {
        yield return new WaitForSeconds(waitTime2);

        // フェードイン
        yield return StartCoroutine(FadeIn());

        // フェードイン完了後、待機時間
        yield return new WaitForSeconds(waitTime);

        // フェードアウト
        yield return StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeInTime)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeInTime);

            // アルファ値を更新
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

            // アルファ値を更新
            Color color = image.color;
            color.a = alpha;
            image.color = color;

            yield return null;
        }
    }
}