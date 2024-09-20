using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    // コントローラーでデフォルト選択されるUIボタンを指定
    public GameObject defaultSelectedButton;

    void Update()
    {
        // コントローラーの入力を検知して、フォーカスをリセット
        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            // 現在何も選択されていない場合、デフォルトのボタンを選択する
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                // EventSystemを使ってデフォルトのボタンにフォーカスを移す
                EventSystem.current.SetSelectedGameObject(defaultSelectedButton);
            }
        }
    }
}

