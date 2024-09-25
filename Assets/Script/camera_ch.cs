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
    public CinemachineVirtualCameraBase vcam6;
    public CinemachineVirtualCameraBase vcam7;
    public CinemachineVirtualCameraBase vcam8;
    public CinemachineVirtualCameraBase vcam9;
    public GameObject Hukan2D;

    Move_Player moveplayer2D;
    Move_Player moveplayer3D;
    Rigidbody sanjiRB;
    Rigidbody nijiRB;

    public bool Hukan;

    double a = 0;

    double b = 0;
    double Db = 0;

    double c = 0;

    double d = 0;

    bool vca5 = true;

    public CameraCon cameracon;

    Sisutemu system;

    //----音----
    [SerializeField]
    CriWare.Assets.CriAtomCueReference cueReference;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference cueReference2;
    //----------

    //360度カメラ
    public GameObject Player;
    bool Nomal = true;
    bool Goal = false;
    //

    void Start()
    {
        cameracon.GetComponent<CameraCon>();
        system = GameObject.Find("System").GetComponent<Sisutemu>();
        Hukan = false;
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

            if (cameracon.sanji)
            {
                vca5 = true;
            }
            else
            {
                vca5 = false;
            }

            if (vca5 == true)
            {

                if (Input.GetButtonDown("Hukan"))
                {
                    Db = 0;
                    b++;
                    if (b % 2 == 1)
                    {
                        Hukan = true;
                        //----音----
                        ADXSoundManager.Instance.PlaySound("birdeye", cueReference.AcbAsset.Handle, cueReference.CueId, gameObject.transform, false);
                        //----------
                    }
                    if (b % 2 == 0)
                    {
                        Hukan = false;
                        //----音----
                        ADXSoundManager.Instance.PlaySound("birdeye", cueReference2.AcbAsset.Handle, cueReference2.CueId, gameObject.transform, false);
                        //----------
                    }
                }

                if (b % 2 == 1)
                {
                    if (cameracon.sanji)
                    {
                        vcam5.Priority = 3;
                        vcam7.Priority = 3;
                        vcam8.Priority = 3;
                        vcam9.Priority = 3;
                        //vcam5.Priority = 3;
                        if (Input.GetButtonDown("KirikaeLeft")) // Left click
                        {
                            d++;

                        }
                        else if (Input.GetButtonDown("KirikaeRight")) // Right click
                        {
                            d--;

                        }

                        if (d >= 1)
                        {
                            vcam5.Priority = 3;
                            vcam7.Priority = 3;
                            vcam8.Priority = 3;
                            vcam9.Priority = 4;

                            if (d >= 2)
                            {
                                vcam5.Priority = 3;
                                vcam7.Priority = 3;
                                vcam8.Priority = 4;
                                vcam9.Priority = 3;

                                if (d >= 3)
                                {
                                    vcam5.Priority = 3;
                                    vcam7.Priority = 4;
                                    vcam8.Priority = 3;
                                    vcam9.Priority = 3;
                                    if (d >= 4)
                                    {
                                        vcam5.Priority = 4;
                                        vcam7.Priority = 3;
                                        vcam8.Priority = 3;
                                        vcam9.Priority = 3;
                                        d = 0;
                                    }
                                }
                            }
                        }
                        else if (d <= 0)
                        {
                            vcam5.Priority = 4;
                            vcam7.Priority = 3;
                            vcam8.Priority = 3;
                            vcam9.Priority = 3;

                            if (d <= -1)
                            {
                                vcam5.Priority = 3;
                                vcam7.Priority = 4;
                                vcam8.Priority = 3;
                                vcam9.Priority = 3;

                                if (d <= -2)
                                {
                                    vcam5.Priority = 3;
                                    vcam7.Priority = 3;
                                    vcam8.Priority = 4;
                                    vcam9.Priority = 3;

                                    if (d <= -3)
                                    {
                                        vcam5.Priority = 3;
                                        vcam7.Priority = 3;
                                        vcam8.Priority = 3;
                                        vcam9.Priority = 4;

                                        if (d <= -4)
                                        {
                                            vcam5.Priority = 4;
                                            vcam7.Priority = 3;
                                            vcam8.Priority = 3;
                                            vcam9.Priority = 3;

                                            d = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //else
                    //{
                    //    Hukan2D.SetActive(true);
                    //    Hukan2D.GetComponent<CinemachineVirtualCameraBase>().Priority = 3;
                    //}

                    system.bankey = true;
                }
                if (b % 2 == 0)
                {
                    if (cameracon.sanji)
                    {
                        vcam5.Priority = 0;
                        vcam7.Priority = 0;
                        vcam8.Priority = 0;
                        vcam9.Priority = 0;
                    }
                    //else
                    //{
                    //    Hukan2D.SetActive(false) ;
                    //    Hukan2D.GetComponent<CinemachineVirtualCameraBase>().Priority = 0;
                    //}
                    system.bankey = false;
                }


            }
            else if (vca5 == false)
            {

                if (Input.GetButtonDown("Hukan"))
                {
                    b = 0;
                    Db++;
                    if (Db % 2 == 1)
                    {
                        Hukan = true;
                        //----音----
                        ADXSoundManager.Instance.PlaySound("birdeye", cueReference.AcbAsset.Handle, cueReference.CueId, gameObject.transform, false);
                        //----------
                    }
                    if (Db % 2 == 0)
                    {
                        Hukan = false;
                        //----音----
                        ADXSoundManager.Instance.PlaySound("birdeye", cueReference2.AcbAsset.Handle, cueReference2.CueId, gameObject.transform, false);
                        //----------
                    }

                }

                if (Db % 2 == 1)
                {
                   
                    vcam6.Priority = 3;
                    


                    Hukan2D.SetActive(false);
                    Hukan2D.GetComponent<CinemachineVirtualCameraBase>().Priority = 0;


                    system.bankey = true;
                }
                if (Db % 2 == 0)
                {

                    vcam6.Priority = 0;


                    Hukan2D.SetActive(true);
                    Hukan2D.GetComponent<CinemachineVirtualCameraBase>().Priority = 3;

                    system.bankey = false;
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
            if (cameracon.sanji)
            {
                vcam5.Priority = 3;
            }
            else
            {
                vcam6.Priority = 3;
            }
            
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
