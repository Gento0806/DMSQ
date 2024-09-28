using UnityEngine;

public class Key_open : MonoBehaviour
{
    public GameObject[] KeyObj; //���̃I�u�W�F�N�g (�����F3�����@�:2����)
    public GameObject[] KeyWallObj; //�ǂ̃I�u�W�F�N�g 
    int KeyNum; // �J�M������
    int GetKeyNum=0;
    private void Start()
    {
        KeyNum = KeyObj.Length;
    }

    void Update()
    {
        GetKeyNum = 0;
        for(int i=0; i<KeyNum; i++)
        {
            if (KeyObj[i].activeSelf == false)
            {
                GetKeyNum++;
            }
        }
        if( KeyNum == GetKeyNum)
        {
            for(int i=0;i<KeyWallObj.Length;i++)
            {
                if(this.gameObject.name== "mashiro_3model")
                {
                    Destroy(KeyWallObj[i]);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            
            for(int i = 0; i < KeyNum; i++)
            {
                if (other.gameObject == KeyObj[i])
                {
                    other.gameObject.SetActive(false);
                    if (i % 2 == 0)
                    {
                        KeyObj[i+1].SetActive(false);
                    }
                    else
                    {
                        KeyObj[i-1].SetActive(false);
                    }
                    break;
                }
            }
        }
    }
}

