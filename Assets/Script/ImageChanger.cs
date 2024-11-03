using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Button button;           // �{�^�����A�T�C��
    public Image panelImage;        // �p�l����Image�R���|�[�l���g���A�T�C��
    public Sprite newSprite;        // �V�����\���������摜���A�T�C��

    void Start()
    {
        // �{�^���ɃN���b�N�C�x���g��ǉ�
        button.onClick.AddListener(ChangeImage);
    }

    // �摜��ύX���郁�\�b�h
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

