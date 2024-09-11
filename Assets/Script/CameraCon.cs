using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;
using CriWare;
using JetBrains.Annotations;

public class CameraCon : MonoBehaviour
{
    [SerializeField] GameObject nijigen;
    [SerializeField] GameObject sanjigen;
    [SerializeField] GameObject panel;
    [SerializeField] float SwitchTime;
    [SerializeField] float Delay;
    [SerializeField] GameObject Camera3D;
    [SerializeField] GameObject Camera2D;
    // [SerializeField] GameObject VCamera2D;

    Move_Player moveplayer2D;
    Move_Player moveplayer3D;

    //カメラ切り替えのタイムラインのやつ
    public PlayableDirector playableDirector;
    public PlayableDirector playableDirector2;
    public CinemachineVirtualCameraBase VCamera2D;


    Vector3 CameraPos;
    public bool sanji = true;
    bool radflag = false;
    float rad = 0;
    float DelayTimeT;
    float DelayTime;
    public bool Qoshiteru = true;
    private Tmpg tmpg_;

    //ステージごとに変わる変数(2D-3D)
    public float dX; //Pos.x = Pos.y - 493;
    public float dY; //Pos.y = 123f;

    //ステージごとに変わる変数(3D-2D)
    public float dXD; //Pos.y = Pos.x + 493;
    public float dYD; //Pos.x = -3.3f;

    //カメラ遷移の時に真白を隠す球変数(大地)
    public GameObject P_Ball3D; //3Dでの隠す球
    public GameObject P_Ball2D; //2Dでの隠す球
    public bool cameraCh_P;//判定
    public float BallScale = 0;
    public float Max_Scale = 0;
    public float henkaTime = 0;
    Vector3 P_Ball_Scale= new Vector3(0, 0, 0);//スケールを入れておくベクトル
    Vector3 nijigen_Pos = new Vector3();

    Vector3 Origin = new Vector3(0, 0, 0);
    Rigidbody sanjiRB;
    Rigidbody nijiRB;


    //----音----
    [SerializeField]
    CriWare.Assets.CriAtomCueReference cueReference;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference hover;
    //----------

    public void ChangeBusSnapshot(string snapshotName, int fadeTimeMs)
    {
        CriAtomEx.ApplyDspBusSnapshot(snapshotName, fadeTimeMs);
    }

    void Start()
    {
        tmpg_ = new Tmpg();
        tmpg_.Enable();

        sanjigen.gameObject.SetActive(true);
        nijigen.gameObject.SetActive(false);
        DelayTime = SwitchTime + Delay;
        DelayTimeT = DelayTime;


        //moveplayer2D = GameObject.Find("mashiro_2model").GetComponent<Move_Player>();
        //moveplayer3D = GameObject.Find("mashiro_3model").GetComponent<Move_Player>();


        sanjiRB = sanjigen.GetComponent<Rigidbody>();
        nijiRB = nijigen.GetComponent<Rigidbody>();
        CriAtomEx.ApplyDspBusSnapshot("Snapshot", 100);
    }

    void Update()
    {
        /*if(!moveplayer2D.SkyBoxChangeBool || !moveplayer3D.SkyBoxChangeBool)
        {
            //if (Input.GetKeyDown("q"))
            if (tmpg_.Player.Kirikae.triggered)
            {

                if (Qoshiteru)
                {
                    if (sanji)
                    {

                        //平行投影
                        Camera.main.orthographic = true;
                        //

                        DelayTimeT = 0;

                        P_Ball2D.SetActive(true);
                        P_Ball3D.SetActive(true);
                        //----隠す球ｰｰｰｰ
                        cameraCh_P = true;
                        BallScale = 0;
                        //--------------

                        //----音----
                        ADXSoundManager.Instance.PlaySound("dimchange", cueReference.AcbAsset.Handle, cueReference.CueId, gameObject.transform, false);
                        ADXSoundManager.Instance.StopSound("move");
                        ADXSoundManager.Instance.StopSound("soner");
                        ADXSoundManager.Instance.PlaySound("hover", hover.AcbAsset.Handle, hover.CueId, gameObject.transform, false);
                        //----------
                        CriAtomEx.ApplyDspBusSnapshot("Snapshot_0", 100);

                        Qoshiteru = false;
                        panel.GetComponent<PanelCon>().turn(SwitchTime);//ブラックアウト処理　※PanelConスクリプト参照
                        playableDirector.Play();


                    }
                    else if (sanji == false)
                    {
                        DelayTimeT = 0;
                        P_Ball2D.SetActive(true);
                        P_Ball3D.SetActive(true);
                        //----隠す球ｰｰｰｰ
                        cameraCh_P = true;
                        BallScale = 0;
                        //--------------

                        //----音----
                        ADXSoundManager.Instance.PlaySound("dimchange", cueReference.AcbAsset.Handle, cueReference.CueId, gameObject.transform, false);
                        ADXSoundManager.Instance.StopSound("move");
                        ADXSoundManager.Instance.StopSound("soner");
                        ADXSoundManager.Instance.PlaySound("hover", hover.AcbAsset.Handle, hover.CueId, gameObject.transform, false);
                        //----------
                        CriAtomEx.ApplyDspBusSnapshot("Snapshot", 100);


                        Qoshiteru = false;
                        panel.GetComponent<PanelCon>().turn(SwitchTime);
                        playableDirector2.Play();

                    }


                }

            }
        
        }
        */
        //if (Input.GetKeyDown("q"))
        if (tmpg_.Player.Kirikae.triggered)
        {

            if (Qoshiteru)
            {
                if (sanji)
                {


                    //平行投影
                    Camera.main.orthographic = true;
                    //

                    DelayTimeT = 0;

                    P_Ball2D.SetActive(true);
                    P_Ball3D.SetActive(true);
                    //----隠す球ｰｰｰｰ
                    cameraCh_P = true;
                    BallScale = 0;
                    //--------------

                    //----音----
                    ADXSoundManager.Instance.PlaySound("dimchange", cueReference.AcbAsset.Handle, cueReference.CueId, gameObject.transform, false);
                    ADXSoundManager.Instance.StopSound("move");
                    ADXSoundManager.Instance.StopSound("soner");
                    ADXSoundManager.Instance.PlaySound("hover", hover.AcbAsset.Handle, hover.CueId, gameObject.transform, false);
                    //----------
                    CriAtomEx.ApplyDspBusSnapshot("Snapshot_0", 100);

                    Qoshiteru = false;
                    panel.GetComponent<PanelCon>().turn(SwitchTime);//ブラックアウト処理　※PanelConスクリプト参照
                    playableDirector.Play();


                }
                else if (sanji == false)
                {
                    DelayTimeT = 0;
                    P_Ball2D.SetActive(true);
                    P_Ball3D.SetActive(true);
                    //----隠す球ｰｰｰｰ
                    cameraCh_P = true;
                    BallScale = 0;
                    //--------------

                    //----音----
                    ADXSoundManager.Instance.PlaySound("dimchange", cueReference.AcbAsset.Handle, cueReference.CueId, gameObject.transform, false);
                    ADXSoundManager.Instance.StopSound("move");
                    ADXSoundManager.Instance.StopSound("soner");
                    ADXSoundManager.Instance.PlaySound("hover", hover.AcbAsset.Handle, hover.CueId, gameObject.transform, false);
                    //----------
                    CriAtomEx.ApplyDspBusSnapshot("Snapshot", 100);


                    Qoshiteru = false;
                    panel.GetComponent<PanelCon>().turn(SwitchTime);
                    playableDirector2.Play();

                }


            }

        }

        //ディレイタイム
        if (Qoshiteru == false)
        {
            DelayTimeT += Time.deltaTime;
            if (DelayTimeT >= DelayTime)
            {
                Qoshiteru = true;
            }
        }

        

        //隠す球---
        if (cameraCh_P)
        {
            nijigen_Pos = nijigen.transform.position;
            BallScale += 10f*Time.deltaTime;
            //sanjigen_Scale -= 0.4f;
            P_Ball_Scale = new Vector3(BallScale, BallScale, BallScale);
            P_Ball3D.transform.localScale = P_Ball_Scale;
            P_Ball2D.transform.position = new Vector3(nijigen_Pos.x,nijigen_Pos.y+5,nijigen_Pos.z);
            P_Ball2D.transform.localScale = P_Ball_Scale;


            

            if (BallScale >= Max_Scale)
            {
                BallScale = Max_Scale;
                //sanjigen_Scale = 0;
            }

            henkaTime += (SwitchTime / 2)*Time.deltaTime;
            if (henkaTime >= SwitchTime)
            {
                Physics.gravity = new Vector3(0, -40f, 0); // 重力を下方向に戻す
                cameraCh_P = false;
                henkaTime = 0;
                
            }
        }
        else
        {

            nijigen_Pos = nijigen.transform.position;
            BallScale -= 20f * Time.deltaTime;
            P_Ball_Scale = new Vector3(BallScale, BallScale, BallScale);
            P_Ball3D.transform.localScale = P_Ball_Scale;
            P_Ball2D.transform.position = new Vector3(nijigen_Pos.x, nijigen_Pos.y + 5, nijigen_Pos.z);
            P_Ball2D.transform.localScale = P_Ball_Scale;

            if (sanji)
            {
                Camera.main.orthographic = false;
            }

            if (BallScale <= 0)
            {
                BallScale = 0;
                henkaTime = 0;
                P_Ball2D.SetActive(false);
                P_Ball3D.SetActive(false);
            }


        }
        //---------

        //もとのやつ
        /*if (Input.GetKeyDown("q"))
         {
                 if (sanji)
                 {
                     panel.GetComponent<PanelCon>().turn(SwitchTime);//ブラックアウト処理　※PanelConスクリプト参照
                 }
                 else if (sanji == false)
                 {
                     panel.GetComponent<PanelCon>().turn(SwitchTime);
                 }
         }*/
    }
    public void moveCharacter()
    {
        Vector3 Pos;

        //現在位置の取得
        if (sanji)
        {
            Pos = sanjigen.transform.position;//キャラクターのZ軸のz座標取得
        }
        else
        {
            Pos = nijigen.transform.position;
        }
        sanji = !sanji; //次元切り替え
        Debug.Log("切り替えたお");
        if (sanji)//3D
        {
            VCamera2D.Priority = 0;
            sanjigen.gameObject.SetActive(true);
            nijigen.gameObject.SetActive(false);
            Camera3D.SetActive(true);
            Camera2D.SetActive(false);
            Pos.x = Pos.y - dX;
            Pos.y = dY;
            sanjigen.transform.position = Pos;//キャラクターの位置を共有
            Ray ray = new Ray(sanjigen.transform.position, -transform.up);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                sanjigen.transform.position = hit.point;
                Debug.Log(hit.point);
            }
        }
        else//2D
        {
            VCamera2D.Priority = 10;
            sanjigen.gameObject.SetActive(false);
            nijigen.gameObject.SetActive(true);
            Camera3D.SetActive(false);
            Camera2D.SetActive(true);
            Pos.y = Pos.x + dYD;
            Pos.x = dXD;
            nijigen.transform.position = Pos;
        }

    }
}

