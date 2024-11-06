using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Button leftButton;       // 左ボタン
    public Button rightButton;      // 右ボタン
    public Image panelImage;        // パネルのImageコンポーネントをアサイン
    public Sprite[] pageSprites;    // 各ページに対応する画像を格納

    private int page = 0;           // 現在のページ番号

    void Start()
    {
        // ボタンにクリックイベントを追加
        leftButton.onClick.AddListener(GoToPreviousPage);
        rightButton.onClick.AddListener(GoToNextPage);

        // 初期状態で画像を設定
        UpdateImage();
    }

    // 次のページに進む
    void GoToNextPage()
    {
        if (page < pageSprites.Length - 1)
        {
            page++; // 次のページへ進む
            UpdateImage();
        }
    }

    // 前のページに戻る
    void GoToPreviousPage()
    {
        if (page > 0)
        {
            page--; // 前のページへ戻る
            UpdateImage();
        }
    }

    // 画像を更新する
    void UpdateImage()
    {
        if (panelImage != null && page >= 0 && page < pageSprites.Length)
        {
            panelImage.sprite = pageSprites[page];
        }
        else
        {
            Debug.LogWarning("Panel Image or Sprites are not assigned properly.");
        }
    }
}

