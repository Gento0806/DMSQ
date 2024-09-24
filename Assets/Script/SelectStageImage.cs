using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StageSelect : MonoBehaviour
{
    // �摜��\������UI Image
    public Image displayImage;

    // �e�X�e�[�W�̉摜
    public Sprite[] stageImages;

    // �I�����ꂽ�{�^���ɉ����ĉ摜��\��
    public void OnStageSelected(BaseEventData eventData)
    {
        // �C�x���g�f�[�^����I�����ꂽ�Q�[���I�u�W�F�N�g���擾
        GameObject selectedObject = eventData.selectedObject;

        // �I�����ꂽ�{�^���̖��O�܂��̓C���f�b�N�X�ŃX�e�[�W�𔻒f
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

