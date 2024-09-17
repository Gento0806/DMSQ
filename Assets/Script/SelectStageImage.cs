using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StageSelect : MonoBehaviour
{
    // 画像を表示するUI Image
    public Image displayImage;

    // 各ステージの画像
    public Sprite[] stageImages;

    // 選択されたボタンに応じて画像を表示
    public void OnStageSelected(BaseEventData eventData)
    {
        // イベントデータから選択されたゲームオブジェクトを取得
        GameObject selectedObject = eventData.selectedObject;

        // 選択されたボタンの名前またはインデックスでステージを判断
        int stageIndex = int.Parse(selectedObject.name.Replace("StageButton","")) - 1;

        if (stageIndex >= 0 && stageIndex < stageImages.Length)
        {
            displayImage.sprite = stageImages[stageIndex];
        }
        else
        {
            Debug.LogError("Invalid stage index");
        }
    }
}

