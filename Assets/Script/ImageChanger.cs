using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Button button;           // ボタンをアサイン
    public Image panelImage;        // パネルのImageコンポーネントをアサイン
    public Sprite newSprite;        // 新しく表示したい画像をアサイン

    void Start()
    {
        // ボタンにクリックイベントを追加
        button.onClick.AddListener(ChangeImage);
    }

    // 画像を変更するメソッド
    void ChangeImage()
    {
        if (panelImage != null && newSprite != null)
        {
            panelImage.sprite = newSprite;
        }
        else
        {
            Debug.LogWarning("Panel Image or New Sprite is not assigned.");
        }
    }
}

