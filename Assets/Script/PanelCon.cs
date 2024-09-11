using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCon : MonoBehaviour
{
    float alfa;//ブラックアウトのパネル透過度
    float speed = 0.05f;
    float red, green, blue;
    bool asi = false;
    bool bsi = false;
    float timerate;
    [SerializeField] GameObject Cameracontroller;

    void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
    }

    void Update()
    {
        GetComponent<Image>().color = new Color(red, green, blue, alfa);

        //暗転
        if (asi == true)
        {
            alfa += Time.deltaTime*timerate;
            if (alfa >= 1.0)//完全に暗くなったら明るくなるようにする
            {
                bsi = true;
                asi = false;
                Cameracontroller.GetComponent<CameraCon>().moveCharacter();
            }
        }

        if (bsi == true)
        {
            alfa -= Time.deltaTime*timerate;
            if (alfa<=0)//完全に明るくなったらリセットする
            {
                bsi = false;
            }

        }
        //ここまで(暗転)
    }
    public void turn(float time)
    {
        timerate = 1/time;
        asi = true; 
    }
}
