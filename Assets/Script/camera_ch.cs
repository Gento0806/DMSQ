using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_ch : MonoBehaviour
{

    CinemachineVirtualCameraBase vcam1;
    CinemachineVirtualCameraBase vcam2;
    CinemachineVirtualCameraBase vcam3;
    CinemachineVirtualCameraBase vcam4;
    CinemachineVirtualCameraBase vcam5;
    CinemachineVirtualCameraBase vcam6;
    CinemachineVirtualCameraBase vcam7;
    CinemachineVirtualCameraBase vcam8;
    CinemachineVirtualCameraBase vcam9;

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

    //----âπ----
    [SerializeField]
    CriWare.Assets.CriAtomCueReference cueReference;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference cueReference2;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference near_dir;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference far_dir;
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
        Hukan = false;
        GameObject  d3camera1= GameObject.Find("3DCamera1");
        vcam1 = d3camera1.GetComponent<CinemachineVirtualCameraBase>();
        GameObject d3camera2 = GameObject.Find("3DCamera2");
        vcam2 = d3camera2.GetComponent<CinemachineVirtualCameraBase>();
        GameObject d3camera3 = GameObject.Find("3DCamera3");
        vcam3 = d3camera3.GetComponent<CinemachineVirtualCameraBase>();
        GameObject d3camera4 = GameObject.Find("3DCamera4");
        vcam4 = d3camera4.GetComponent<CinemachineVirtualCameraBase>();
        GameObject d3camera5 = GameObject.Find("3DCamera5");
        vcam5 = d3camera5.GetComponent<CinemachineVirtualCameraBase>();
        GameObject d2fukan = GameObject.Find("2Dhukann");
        vcam6 = d2fukan.GetComponent<CinemachineVirtualCameraBase>();
        GameObject d3camera7 = GameObject.Find("3DCamera6");
        vcam7 = d3camera7.GetComponent<CinemachineVirtualCameraBase>();
        GameObject d3camera8 = GameObject.Find("3DCamera7");
        vcam8 = d3camera8.GetComponent<CinemachineVirtualCameraBase>();
        GameObject d3camera9 = GameObject.Find("3DCamera8");
        vcam9 = d3camera9.GetComponent<CinemachineVirtualCameraBase>();
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
                //--sound--
                ADXSoundManager.Instance.PlaySound("neardir", near_dir.AcbAsset.Handle, near_dir.CueId, gameObject.transform, false);
            }
            else if (Input.GetButtonDown("KirikaeRight")) // Right click
            {
                a--;
                //--sound--
                ADXSoundManager.Instance.PlaySound("neardir", near_dir.AcbAsset.Handle, near_dir.CueId, gameObject.transform, false);
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
                        //----âπ----
                        ADXSoundManager.Instance.PlaySound("birdeye", cueReference.AcbAsset.Handle, cueReference.CueId, gameObject.transform, false);
                        //----------
                    }
                    if (b % 2 == 0)
                    {
                        Hukan = false;
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
                        vcam7.Priority = 3;
                        vcam8.Priority = 3;
                        vcam9.Priority = 3;
                        //vcam5.Priority = 3;
                        if (Input.GetButtonDown("KirikaeLeft")) // Left click
                        {
                            d++;
                            //--sound--
                            ADXSoundManager.Instance.PlaySound("fardir", far_dir.AcbAsset.Handle, far_dir.CueId, gameObject.transform, false);
                        }
                        else if (Input.GetButtonDown("KirikaeRight")) // Right click
                        {
                            d--;
                            //--sound--
                            ADXSoundManager.Instance.PlaySound("fardir", far_dir.AcbAsset.Handle, far_dir.CueId, gameObject.transform, false);
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
                        //----âπ----
                        ADXSoundManager.Instance.PlaySound("birdeye", cueReference.AcbAsset.Handle, cueReference.CueId, gameObject.transform, false);
                        //----------
                    }
                    if (Db % 2 == 0)
                    {
                        Hukan = false;
                        //----âπ----
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
                vcam2.Priority = 1;
                vcam3.Priority = 0;
                vcam4.Priority = 0;

                if (a >= 2)
                {
                    vcam1.Priority = 0;
                    vcam2.Priority = 0;
                    vcam3.Priority = 1;
                    vcam4.Priority = 0;

                    if (a >= 3)
                    {
                        vcam1.Priority = 0;
                        vcam2.Priority = 0;
                        vcam3.Priority = 0;
                        vcam4.Priority = 1;

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
                    vcam2.Priority = 0;
                    vcam3.Priority = 0;
                    vcam4.Priority = 1;

                    if (a <= -2)
                    {
                        vcam1.Priority = 0;
                        vcam2.Priority = 0;
                        vcam3.Priority = 1;
                        vcam4.Priority = 0;

                        if (a <= -3)
                        {
                            vcam1.Priority = 0;
                            vcam2.Priority = 1;
                            vcam3.Priority = 0;
                            vcam4.Priority = 0;

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
