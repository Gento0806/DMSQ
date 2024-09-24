using UnityEngine;

public class Key_open : MonoBehaviour
{
    public GameObject[] prefabObjectsToChange; // インスペクターで指定するプレハブ
    private GameObject[] instantiatedObjects; // インスタンス化されたプレハブを保持
    public int requiredTouches = 3; // カギを取る回数
    private static int sharedTouchCount = 0; // すべてのキャラクターで共有されるカウント

    private void Start()
    {
        // プレハブをインスタンス化してシーン上に配置
        instantiatedObjects = new GameObject[prefabObjectsToChange.Length];
        for (int i = 0; i < prefabObjectsToChange.Length; i++)
        {
            instantiatedObjects[i] = Instantiate(prefabObjectsToChange[i]);
            instantiatedObjects[i].SetActive(false); // 初期状態を非アクティブに
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            sharedTouchCount++;

            // カギを取る回数が設定値未満の場合にオブジェクトを変更
            if (sharedTouchCount < requiredTouches && sharedTouchCount - 1 < instantiatedObjects.Length)
            {
                instantiatedObjects[sharedTouchCount - 1].SetActive(true);
            }
            else if (sharedTouchCount == requiredTouches && instantiatedObjects.Length > 0)
            {
                // 指定された回数でオブジェクトを非アクティブにする
                foreach (GameObject obj in instantiatedObjects)
                {
                    obj.SetActive(false);
                }
            }

            // 触れた鍵（Key）オブジェクトを削除
            Destroy(other.gameObject);
        }
    }
}

