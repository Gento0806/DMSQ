using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Button leftButton;       // ���{�^��
    public Button rightButton;      // �E�{�^��
    public Image panelImage;        // �p�l����Image�R���|�[�l���g���A�T�C��
    public Sprite[] pageSprites;    // �e�y�[�W�ɑΉ�����摜���i�[

    private int page = 0;           // ���݂̃y�[�W�ԍ�

    void Start()
    {
        // �{�^���ɃN���b�N�C�x���g��ǉ�
        leftButton.onClick.AddListener(GoToPreviousPage);
        rightButton.onClick.AddListener(GoToNextPage);

        // ������Ԃŉ摜��ݒ�
        UpdateImage();
    }

    // ���̃y�[�W�ɐi��
    void GoToNextPage()
    {
        if (page < pageSprites.Length - 1)
        {
            page++; // ���̃y�[�W�֐i��
            UpdateImage();
        }
    }

    // �O�̃y�[�W�ɖ߂�
    void GoToPreviousPage()
    {
        if (page > 0)
        {
            page--; // �O�̃y�[�W�֖߂�
            UpdateImage();
        }
    }

    // �摜���X�V����
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

