using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    // �R���g���[���[�Ńf�t�H���g�I�������UI�{�^�����w��
    public GameObject defaultSelectedButton;

    void Update()
    {
        // �R���g���[���[�̓��͂����m���āA�t�H�[�J�X�����Z�b�g
        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            // ���݉����I������Ă��Ȃ��ꍇ�A�f�t�H���g�̃{�^����I������
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                // EventSystem���g���ăf�t�H���g�̃{�^���Ƀt�H�[�J�X���ڂ�
                EventSystem.current.SetSelectedGameObject(defaultSelectedButton);
            }
        }
    }
}

