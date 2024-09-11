using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_ch : MonoBehaviour
{
    private Tmpg tmpg_;

    public CinemachineVirtualCameraBase vcam1;
    public CinemachineVirtualCameraBase vcam2;
    public CinemachineVirtualCameraBase vcam3;
    public CinemachineVirtualCameraBase vcam4;
    public CinemachineVirtualCameraBase vcam5;

    double a = 0;

    double b = 0;

    double c = 0;

    bool vca5 = false;

    public CameraCon cameracon;

    Sisutemu system;

    //----âπ----
    [SerializeField]
    CriWare.Assets.CriAtomCueReference cueReference;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference cueReference2;
    //----------

    //360ìxÉJÉÅÉâ
    public GameObject Player;
    bool camera90 = true;
    bool camera360 = false;
    //

    void Start()
    {
        tmpg_ = new Tmpg();
        tmpg_.Enable();
        cameracon.GetComponent<CameraCon>();
        system = GameObject.Find("System").GetComponent<Sisutemu>();
    }

    void Update()
    {

        if (camera90)
        {
            if (tmpg_.Player.Houkoukirikaehidari.triggered) // Left click
            {
                a++;

            }
            else if (tmpg_.Player.Houkoukirikaemigi.triggered) // Right click
            {
                a--;

            }

            if (cameracon.Qoshiteru && cameracon.sanji)
            {
                if (tmpg_.Player.Kirikae.triggered)
                {
                    c++;
                }
                if (c % 2 == 1)
                {
                    vca5 = false;
                }
                if (c % 2 == 0)
                {
                    vca5 = true;
                }
            }
            

            if (vca5 == true)
            {

                if (tmpg_.Player.Hukann.triggered)
                {
                    b++;
                    if (b % 2 == 1)
                    {
                        //----âπ----
                        ADXSoundManager.Instance.PlaySound("birdeye", cueReference.AcbAsset.Handle, cueReference.CueId, gameObject.transform, false);
                        //----------
                    }
                    if (b % 2 == 0)
                    {
                        //----âπ----
                        ADXSoundManager.Instance.PlaySound("birdeye", cueReference2.AcbAsset.Handle, cueReference2.CueId, gameObject.transform, false);
                        //----------
                    }
                }

                if (b % 2 == 1)
                {
                    vcam5.Priority = 3;
                    system.bankey = true;


                }
                if (b % 2 == 0)
                {
                    vcam5.Priority = 0;
                    system.bankey = false;
                }


            }
            else if (vca5 == false)
            {

                if (tmpg_.Player.Hukann.triggered)
                {
                    b = 0;

                }
            }

            if (a >= 1)
            {
                vcam1.Priority = 0;
                vcam2.Priority = 0;
                vcam3.Priority = 0;
                vcam4.Priority = 1;

                if (a >= 2)
                {
                    vcam1.Priority = 0;
                    vcam2.Priority = 0;
                    vcam3.Priority = 1;
                    vcam4.Priority = 0;

                    if (a >= 3)
                    {
                        vcam1.Priority = 0;
                        vcam2.Priority = 1;
                        vcam3.Priority = 0;
                        vcam4.Priority = 0;

                        if (a >= 4)
                        {
                            vcam1.Priority = 1;
                            vcam2.Priority = 0;
                            vcam3.Priority = 0;
                            vcam4.Priority = 0;

                            a = 0;
                        }
                    }
                }
            }
            else if (a <= 0)
            {
                vcam1.Priority = 1;
                vcam2.Priority = 0;
                vcam3.Priority = 0;
                vcam4.Priority = 0;

                if (a <= -1)
                {
                    vcam1.Priority = 0;
                    vcam2.Priority = 1;
                    vcam3.Priority = 0;
                    vcam4.Priority = 0;

                    if (a <= -2)
                    {
                        vcam1.Priority = 0;
                        vcam2.Priority = 0;
                        vcam3.Priority = 1;
                        vcam4.Priority = 0;

                        if (a <= -3)
                        {
                            vcam1.Priority = 0;
                            vcam2.Priority = 0;
                            vcam3.Priority = 0;
                            vcam4.Priority = 1;

                            if (a <= -4)
                            {
                                vcam1.Priority = 1;
                                vcam2.Priority = 0;
                                vcam3.Priority = 0;
                                vcam4.Priority = 0;

                                a = 0;
                            }
                        }
                    }
                }
            }

        }
        else if (camera360)
        {
            vcam1.Priority = 1;
            vcam2.Priority = 0;
            vcam3.Priority = 0;
            vcam4.Priority = 0;

            if (Input.GetMouseButton(1))
            {
                vcam1.transform.RotateAround(Player.transform.position, new Vector3(0, 1, 0), 0.5f);
            }
            if (Input.GetMouseButton(0))
            {
                vcam1.transform.RotateAround(Player.transform.position, new Vector3(0, 1, 0), -0.5f);
            }
           
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (camera90)
            {
                camera90 = false;
                camera360 = true;
                Debug.Log("360");
            }
            if (camera360)
            {
                camera90 = true;
                camera360 = false;
                Debug.Log("90");
            }
        }
    }


}
