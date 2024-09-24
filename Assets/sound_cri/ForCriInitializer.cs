using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MakeCriWareLibraryGod : MonoBehaviour
{
    // MakeCriWareLibraryGod ��1�����ɂȂ�悤�� Instance �Ƃ���
    public static MakeCriWareLibraryGod Instance { get; private set; }
    // Initialize �� PlayMode �ŌĂяo��
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        if (Instance == null)
        {
            // CriWareLibraryInitializer �� Resources �t�H���_�� CRIWARE �t�H���_���ɗp�ӂ���Ă���O��ŁA���O�Ō������ă��[�h
            var prefab = Resources.Load<GameObject>("CRIWARE/CriWareLibraryInitializer");
            if (prefab == null)
            {
                // �����Ɏ��s�����ꍇ( Assets/Resources/CRIWARE/ �� CriWareLibraryInitializer.prefab �����݂��Ȃ��ꍇ) �̓G���[
                Debug.LogError("[MakeCriWareLibraryGod] CriWareLibraryInitializer not found in Editor Default Resources folder.");
                return;
            }
            // CriWareLibraryInitializer �𐶐�
            var criWareLibraryInitializer = Instantiate(prefab);
            criWareLibraryInitializer.AddComponent<MakeCriWareLibraryGod>();
            // �ʒm����
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