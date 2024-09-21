using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_ch : MonoBehaviour
{

    public CinemachineVirtualCameraBase vcam1;
    public CinemachineVirtualCameraBase vcam2;
    public CinemachineVirtualCameraBase vcam3;
    public CinemachineVirtualCameraBase vcam4;
    public CinemachineVirtualCameraBase vcam5;
    public GameObject Hukan2D;

    Move_Player moveplayer2D;
    Move_Player moveplayer3D;
    Rigidbody sanjiRB;
    Rigidbody nijiRB;

    double a = 0;

    double b = 0;

    double c = 0;

    bool vca5 = true;

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
    bool Nomal = true;
    bool Goal = false;
    //

    void Start()
    {
        cameracon.GetComponent<CameraCon>();
        system = GameObject.Find("System").GetComponent<Sisutemu>();
    }

    void Update()
    {
        if (cameracon.sanji)
        {
            moveplayer3D = GameObject.Find("mashiro_3model").GetComponent<Move_Player>();
            sanjiRB = GameObject.Find("mashiro_3model").GetComponent<Rigidbody>();
        }
        else
        {
            moveplayer2D = GameObject.Find("mashiro_2model").GetComponent<Move_Player>();
            nijiRB = GameObject.Find("mashiro_2model").GetComponent<Rigidbody>();
        }

        if (Nomal)
        {
            if (Input.GetButtonDown("KirikaeLeft")) // Left click
            {
                a++;

            }
            else if (Input.GetButtonDown("KirikaeRight")) // Right click
            {
                a--;

            }

            /*if (cameracon.Qoshiteru && cameracon.sanji)
            {
                if (Input.GetButtonDown("Change"))
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
            }*/
            

            if (vca5 == true)
            {

                if (Input.GetButtonDown("Hukan"))
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
                    if (cameracon.sanji)
                    {
                        vcam5.Priority = 3;
                    }
                    else
                    {
                        Hukan2D.SetActive(true);
                        Hukan2D.GetComponent<CinemachineVirtualCameraBase>().Priority = 3;
                    }
                    
                    system.bankey = true;
                }
                if (b % 2 == 0)
                {
                    if (cameracon.sanji)
                    {
                        vcam5.Priority = 0;
                    }
                    else
                    {
                        Hukan2D.SetActive(false) ;
                        Hukan2D.GetComponent<CinemachineVirtualCameraBase>().Priority = 0;
                    }
                    system.bankey = false;
                }


            }
            else if (vca5 == false)
            {

                if (Input.GetButtonDown("Hukan"))
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
        else if (Goal)
        {
            vcam5.Priority = 3;
        }

        if (cameracon.sanji)
        {
            if (moveplayer3D.SkyBoxChangeBool)
            {
                Nomal = false;
                Goal = true;
            }
        }
        else
        {
            if (moveplayer2D.SkyBoxChangeBool)
            {
                Nomal = false;
                Goal = true;
            }
        }
        

    }


}
