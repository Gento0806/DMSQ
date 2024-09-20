using UnityEngine;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    // コントローラーでデフォルト選択されるUIボタンを指定
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

        // コントローラーの入力を検知して、フォーカスをリセット
        if (connected)
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

