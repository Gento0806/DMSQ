using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCon : MonoBehaviour
{
    float alfa;//�u���b�N�A�E�g�̃p�l�����ߓx
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

        //�Ó]
        if (asi == true)
        {
            alfa += Time.deltaTime*timerate;
            if (alfa >= 1.0)//���S�ɈÂ��Ȃ����疾�邭�Ȃ�悤�ɂ���
            {
                bsi = true;
                asi = false;
                Cameracontroller.GetComponent<CameraCon>().moveCharacter();
            }
        }

        if (bsi == true)
        {
            alfa -= Time.deltaTime*timerate;
            if (alfa<=0)//���S�ɖ��邭�Ȃ����烊�Z�b�g����
            {
                bsi = false;
            }

        }
        //�����܂�(�Ó])
    }
    public void turn(float time)
    {
        timerate = 1/time;
        asi = true; 
    }
}
