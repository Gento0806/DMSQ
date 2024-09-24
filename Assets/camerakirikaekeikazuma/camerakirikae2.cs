using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerakirikae2 : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    int kirikaesima = 0;
    int jikannkasegi = 0;
    int jikannkasegi2kome = 0;
    bool jikann = false;
    bool cameraTP = false;
    // Start is called before the first frame update
    void Start()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
        camera3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && kirikaesima == 0 && jikannkasegi < 0)
        {

            cameraTP = true;
            kirikaesima++;
            jikann = true;
        }

        if (Input.GetKeyDown(KeyCode.R) && kirikaesima == 1 && jikannkasegi > 10)
        {
            cameraTP = false;
            kirikaesima = 0;
            jikann = false;
        }

        if (jikann == true)
        {
            if (jikannkasegi <= 10)
            {


                jikannkasegi++;
            }
        }
        else
        {
            if (jikannkasegi >= 0)
            {
                jikannkasegi--;

            }
        }
        if (cameraTP == true)
        {
            if (jikannkasegi < 10)
            {
                camera1.SetActive(false);
                camera2.SetActive(true);
            }
            else if (jikannkasegi >= 9)
            {
                camera1.SetActive(false);
                camera2.SetActive(false);
                camera3.SetActive(true);
            }
            jikannkasegi2kome = 0;
        }
        else
        {
            jikannkasegi2kome++;
            if (jikannkasegi2kome < 100)
            {
                camera1.SetActive(false);
                camera2.SetActive(true);
                camera3.SetActive(false);
            }
            else
            {
                camera1.SetActive(true);
                camera2.SetActive(false);
                camera3.SetActive(false);
            }
        }
    }
}
