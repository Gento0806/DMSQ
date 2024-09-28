using UnityEngine;

public class Key_open : MonoBehaviour
{
    public GameObject[] KeyObj; //鍵のオブジェクト (偶数：3次元　奇数:2次元)
    public GameObject[] KeyWallObj; //壁のオブジェクト 
    int KeyNum; // カギを取る回数
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

