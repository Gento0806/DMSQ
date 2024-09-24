using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MakeCriWareLibraryGod : MonoBehaviour
{
    // MakeCriWareLibraryGod が1つだけになるように Instance とする
    public static MakeCriWareLibraryGod Instance { get; private set; }
    // Initialize を PlayMode で呼び出す
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        if (Instance == null)
        {
            // CriWareLibraryInitializer が Resources フォルダの CRIWARE フォルダ内に用意されている前提で、名前で検索してロード
            var prefab = Resources.Load<GameObject>("CRIWARE/CriWareLibraryInitializer");
            if (prefab == null)
            {
                // 検索に失敗した場合( Assets/Resources/CRIWARE/ に CriWareLibraryInitializer.prefab が存在しない場合) はエラー
                Debug.LogError("[MakeCriWareLibraryGod] CriWareLibraryInitializer not found in Editor Default Resources folder.");
                return;
            }
            // CriWareLibraryInitializer を生成
            var criWareLibraryInitializer = Instantiate(prefab);
            criWareLibraryInitializer.AddComponent<MakeCriWareLibraryGod>();
            // 通知する
            Debug.Log("[MakeCriWareLibraryGod] have Instantiated!");
        }
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}