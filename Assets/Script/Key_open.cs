using UnityEngine;

public class Key_open : MonoBehaviour
{
    public GameObject[] prefabObjectsToChange; // �C���X�y�N�^�[�Ŏw�肷��v���n�u
    private GameObject[] instantiatedObjects; // �C���X�^���X�����ꂽ�v���n�u��ێ�
    public int requiredTouches = 3; // �J�M������
    private static int sharedTouchCount = 0; // ���ׂẴL�����N�^�[�ŋ��L�����J�E���g

    private void Start()
    {
        // �v���n�u���C���X�^���X�����ăV�[����ɔz�u
        instantiatedObjects = new GameObject[prefabObjectsToChange.Length];
        for (int i = 0; i < prefabObjectsToChange.Length; i++)
        {
            instantiatedObjects[i] = Instantiate(prefabObjectsToChange[i]);
            instantiatedObjects[i].SetActive(false); // ������Ԃ��A�N�e�B�u��
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            sharedTouchCount++;

            // �J�M�����񐔂��ݒ�l�����̏ꍇ�ɃI�u�W�F�N�g��ύX
            if (sharedTouchCount < requiredTouches && sharedTouchCount - 1 < instantiatedObjects.Length)
            {
                instantiatedObjects[sharedTouchCount - 1].SetActive(true);
            }
            else if (sharedTouchCount == requiredTouches && instantiatedObjects.Length > 0)
            {
                // �w�肳�ꂽ�񐔂ŃI�u�W�F�N�g���A�N�e�B�u�ɂ���
                foreach (GameObject obj in instantiatedObjects)
                {
                    obj.SetActive(false);
                }
            }

            // �G�ꂽ���iKey�j�I�u�W�F�N�g���폜
            Destroy(other.gameObject);
        }
    }
}

