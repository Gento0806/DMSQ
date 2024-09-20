using UnityEngine;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    // �R���g���[���[�Ńf�t�H���g�I�������UI�{�^�����w��
    public GameObject defaultSelectedButton;
    private bool connected;

    void Update()
    {
        var controllers = Input.GetJoystickNames();

        if (!connected && controllers.Length > 0)
        {
            connected = true;
            Debug.Log("Connected");

        }
        else if (connected && controllers.Length == 0)
        {
            connected = false;
            Debug.Log("Disconnected");
        }

        // �R���g���[���[�̓��͂����m���āA�t�H�[�J�X�����Z�b�g
        if (connected)
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

