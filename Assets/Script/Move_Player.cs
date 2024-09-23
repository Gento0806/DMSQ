using CriWare;
using CriWare.Assets;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Move_Player : MonoBehaviour
{
    //アニメーション
    private Animator animator;

    //あたらしい移動に使う
    public GameObject MainCamera;
    float moveX, moveZ;
    public bool noChange = true;

    static float speed = 4f; // 移動速度
    static float speed2d = 4f;
    private int jumpforce = 5000;
    Rigidbody rb;
    bool imputkey = false;
   
    bool jumpsieru = false;
    int dir = 0;
    float LookRotate;

    Vector3 move;

    // 1フレーム前の位置
    private Vector3 _prevPosition;
    float rakka = 0.5f;
    public float initialForce = 10f; // 初期の力の量
    public float maxForce = 50f; // 最大の力の量
    public float forceIncreaseRate = 10f; // 力の増加率
    private float currentForce; // 現在の力の量

    [SerializeField] GameObject cameracon;
    [SerializeField] GameObject system;
    [SerializeField] GameObject Rotation2DPoint;
    public string blockTag = "saka1"; // ブロックのタグ
    public float forceMagnitude = 20f; // 加える力の大きさ
    bool banmove = false;
    public float forceAmount = 10f; // 加える力の量
    public float sakaForce = 0.02f;

    //スカイボックス
    public Material skyboxMaterial;
    public Color startColor = Color.HSVToRGB(82f, 49f, 60f);
    public Color endColor = Color.HSVToRGB(98f, 164f, 209f);
    //public float duration = 5.0f;
    public float tImer = 0;
    public bool SkyBoxChangeBool = false;
    public float t;
    //

    //重力切替
    bool isGravityReversed = false;
    public float rotationDuration = 0.5f; // 回転にかかる時間
    private bool isRotating = false;
    private Quaternion startRotation;
    private Quaternion targetRotation;
    private float elapsedTime = 0.0f;
    //
    bool tyakuchi = false;

    private bool jumpsky = false;

    //----音----
    public enum move_type
    {
        move,
        idle
    }
    [SerializeField]
    CriWare.Assets.CriAtomCueReference cueReference;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference cueReference2;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference cueReference3;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference goal;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference hover;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference clear;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference soner;
    bool ismovestart = true;
    [SerializeField] private move_type moveplayer;
    move_type currentstate = move_type.idle;
    move_type transit = move_type.idle;
    bool first_hover = true;
    Vector3 vec;
    //----------

   
    void Start()
    {
        Time.timeScale = 1.0f;
        
        rb = this.GetComponent<Rigidbody>();
        currentForce = initialForce;
        currentstate = moveplayer;
        transit = moveplayer;
        t = 4;
        skyboxMaterial.SetColor("_Tint", startColor);
        animator = this.gameObject.GetComponent<Animator>();
       
    }
    void Update()
    {

        Rigidbody rb = this.GetComponent<Rigidbody>();
        Vector3 ResetVelocity = new Vector3(0, 0, 0);
        ResetVelocity.y = rb.velocity.y;
        rb.velocity = ResetVelocity;


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            dir = 0;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir = 1;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            dir = 2;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir = 3;
        }

        



        if (system.GetComponent<Sisutemu>().bankey == false && SkyBoxChangeBool == false)
        {
            //あたらしい移動（大地)
            // 移動量
            moveX = Input.GetAxis("Horizontal") * speed; // 左右
            moveZ = Input.GetAxis("Vertical")* speed; // 前後
                                                       // カメラの方向から、X-Z平面の単位ベクトルを取得
            Vector3 cameraForward = Vector3.Scale(MainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 cameraForward2D = Vector3.Scale(MainCamera.transform.right, new Vector3(0, 0, 1)).normalized;
            // 方向キーの入力値とカメラの向きから、移動方向を決定
            Vector3 moveRay = cameraForward * moveZ + MainCamera.transform.right * moveX;
            Vector3 PlayerPosition = this.transform.position;
            PlayerPosition.y += 1.5f;
            Ray ray = new Ray(PlayerPosition, moveRay);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (Vector3.Distance(hit.point, this.transform.position) < 5 && hit.collider.gameObject.tag != "saka1" && hit.collider.gameObject.tag != "Goal" && hit.collider.gameObject.tag != "Floor")
                {
                    Debug.Log(hit.collider.gameObject.name);
                    banmove = true;
                    /*
                    if (cameracon.GetComponent<CameraCon>().sanji && hit.collider.gameObject.tag != "Wall" || cameracon.GetComponent<CameraCon>().sanji == false)
                    {

                    }
                    else
                    {
                        Debug.Log(hit.collider.gameObject.name);
                        banmove = false;
                    }*/
                }
                else
                {
                    banmove = false;
                }
            }
            else
            {
                banmove = false;
            }

            /*重力切替-----------------------------
            // Gキーが押されたかを確認
            if (Input.GetKeyDown(KeyCode.G)&&!cameracon.GetComponent<CameraCon>().sanji)
            {
                // 重力の方向を逆にする
                isGravityReversed = !isGravityReversed;

                if (isGravityReversed)
                {
                    Physics.gravity = new Vector3(0, 40f, 0); // 重力を上方向に
                    isRotating = true;
                    elapsedTime = 0.0f;
                    startRotation = transform.rotation;
                    targetRotation = startRotation * Quaternion.Euler(180f, 0f, 0f); // 180度回転
                }
                else
                {
                    Physics.gravity = new Vector3(0, -40f, 0); // 重力を下方向に戻す
                    isRotating = true;
                    elapsedTime = 0.0f;
                    startRotation = transform.rotation;
                    targetRotation = startRotation * Quaternion.Euler(180f, 0f, 0f); // 180度回転
                }
            }
            // 回転中
            if (isRotating)
            {
                elapsedTime += Time.deltaTime*5;
                float t = Mathf.Clamp01(elapsedTime / rotationDuration);
                transform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);

                // 回転が完了したら終了
                if (t >= 1.0f)
                {
                    isRotating = false;
                }
            }
            */

            if (cameracon.GetComponent<CameraCon>().sanji && banmove == false)
            {
                move = cameraForward * moveZ + MainCamera.transform.right * moveX;
                this.gameObject.transform.position += move * speed * Time.deltaTime;//移動

                if (move != Vector3.zero)
                {
                    //----音----
                    if (ismovestart)
                    {
                        transit = move_type.move;
                        ismovestart = false;
                        //animator.SetBool("Walk", true);
                    }

                    //----------
                }


            }
            else if (cameracon.GetComponent<CameraCon>().sanji == false && banmove == false)
            {
                /*int reverse;
                if (moveX > 0)
                    reverse = 1;
                else
                    reverse = -1;*/
                if (moveX>0.1f || moveZ>0.1f)
                {
                    //----音----
                    if (ismovestart)
                    {
                        transit = move_type.move;
                        ismovestart = false;
                        //animator.SetBool("Walk", true);
                    }

                    //----------
                }

                if (dir == 0 || dir == 2)
                    moveZ = 0;
                else if (dir == 1 || dir == 3)
                    moveX = 0;
                switch (dir)
                {
                    case 0:
                        moveZ = 0;
                        moveX *= -1;
                        break;
                    case 1:
                        moveX = 0;
                        break;
                    case 2:
                        moveZ = 0;
                        break;
                    case 3:
                        moveX = 0;
                        moveZ *= -1;
                        break;
                    default:
                        break;
                }
                move = cameraForward2D * Input.GetAxis("Horizontal") * speed2d;
                this.transform.position+=(move * Time.deltaTime*speed2d); //正面
                                                                                                   //transform.rotation = Quaternion.LookRotation(transform.position +(Vector3.forward * Input.GetAxisRaw("Horizontal") * -1)- transform.position);





            }

            if (move != Vector3.zero )
            {
                    transform.rotation = Quaternion.LookRotation(move);

                animator.SetBool("Walk", true);

            }
            else
            {
                animator.SetBool("Walk", false);
            }


            if (Input.GetButtonDown("Jump"))
            {
                imputkey = false;
            }
            if (((Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical")))
                && !ismovestart
                )
            {
                // Debug.Log("idle!");
                transit = move_type.idle;
                //ADXSoundManager.Instance.StopSound("move");
                ismovestart = true;

            }
            if (currentstate == move_type.idle && first_hover)
            {
                ADXSoundManager.Instance.PlaySound("hover", hover.AcbAsset.Handle, hover.CueId, gameObject.transform, false);
                first_hover = false;
            }
            if (currentstate != transit)
            {
                if (currentstate == move_type.idle && transit == move_type.move)
                {
                    ADXSoundManager.Instance.StopSound("hover");
                    ADXSoundManager.Instance.PlaySound("move", cueReference.AcbAsset.Handle, cueReference.CueId, gameObject.transform, false);
                    ADXSoundManager.Instance.PlaySound("soner", soner.AcbAsset.Handle, soner.CueId, gameObject.transform, false);
                    //Debug.Log("idle");

                }
                if (currentstate == move_type.move && transit == move_type.idle)
                {
                    ADXSoundManager.Instance.StopSound("move");
                    ADXSoundManager.Instance.StopSound("soner");
                    ADXSoundManager.Instance.PlaySound("hover", hover.AcbAsset.Handle, hover.CueId, gameObject.transform, false);
                    //Debug.Log("move");

                }
                currentstate = transit;
            }



        }

        //if (tmpg_.Player.Jump.triggered)
        //{
        //    jumpsieru = true;
        //}

        if (SkyBoxChangeBool)
        {
            // Timerを更新
            tImer += 1 * Time.deltaTime;
            // 色を線形補間して設定
            Color currentColor = Color.Lerp(startColor, endColor, tImer);
            skyboxMaterial.SetColor("_Tint", currentColor);
            if (tImer >= t)
            {
                CriAtomEx.ApplyDspBusSnapshot("Snapshot", 100);
                ADXSoundManager.Instance.StopSound("move");
                ADXSoundManager.Instance.StopSound("hover");
                ADXSoundManager.Instance.StopSound("bgm");
                ADXSoundManager.Instance.StopSound("soner");
                ADXSoundManager.Instance.PlaySound("goal", goal.AcbAsset.Handle, goal.CueId, gameObject.transform, false);
                SceneSelect.StageNumChange();
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
                SceneManager.LoadScene("Next");
            }
        }

      //  空中にいるかのチェック（Y軸の速度がゼロでないとき空中と判定）

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("jumpend"))
        {
            animator.SetBool("Jumpend", false);  // 着地アニメーションが終わったらリセット
        }
    }

    public void FixedUpdate()
    {
        //落下速度上昇
        if (cameracon.GetComponent<CameraCon>().sanji)
        {
            rb.AddForce(0, -50f, 0, ForceMode.Acceleration);
            if (vec.y <= 0.0f)
            {
                rb.AddForce(0f, -30f, 0f, ForceMode.Acceleration);
            }

        }
        else if (cameracon.GetComponent<CameraCon>().sanji == false)
        {
            rb.useGravity = false;
            if (noChange)
            {
                switch (dir)//重力方向の切り替え
                {
                    case 0:
                        rb.AddForce(0, -50f, 0, ForceMode.Acceleration);
                        if (rb.velocity.y < 0)
                        {
                            rb.AddForce(0, -30, 0, ForceMode.Acceleration);
                        }
                        break;
                    case 1:
                        rb.AddForce(0, 0, 10f, ForceMode.Acceleration);
                        if (rb.velocity.y < 0)
                        {
                            rb.AddForce(0, 0, 10, ForceMode.Acceleration);
                        }
                        break;
                    case 2:
                        rb.AddForce(0, 10f, 0, ForceMode.Acceleration);
                        if (rb.velocity.y < 0)
                        {
                            rb.AddForce(0, 10, 0, ForceMode.Acceleration);
                        }
                        break;
                    case 3:
                        rb.AddForce(0, 0, -10f, ForceMode.Acceleration);
                        if (rb.velocity.y < 0)
                        {
                            rb.AddForce(0, 0, -10, ForceMode.Acceleration);
                        }
                        break;
                }
            }
            
        }
    }

    //ジャンプ（そうた）
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Floor") && Input.GetButtonDown("Jump") && system.GetComponent<Sisutemu>().bankey == false && jumpsky == false)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(0, jumpforce, 0);
            animator.SetBool("Jumpstart", true);
            animator.SetBool("Jumploop", true);
            animator.SetBool("Jumpend", false);
            animator.SetBool("Walk", false);
            imputkey = true;
            Debug.Log("Jump");
            jumpsky = true;

            //----音----

            ADXSoundManager.Instance.PlaySound("jump", cueReference2.AcbAsset.Handle, cueReference2.CueId, gameObject.transform, false);
            //----------
        }

       

        // 通過したオブジェクトが指定したタグを持っているか確認
        /*if (other.CompareTag("saka1"))
        {
            /*
            if (velocity.z < 0)
            {
                transform.Translate(0.0f, 0.13f, 0.0f);
            }
            else if (velocity.z > 0)
            {
                transform.Translate(0.0f, 0.17f, 0.0f);
            }
            else if (velocity.z == 0)
            {
                transform.Translate(0.0f, -0.8f, 0.0f);
            }

        }*/

    }

    

    // キャラクターが地面から離れたときに空中状態を設定する
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            animator.SetBool("Walk", false);
            // 空中状態のアニメーション
            animator.SetBool("Jumploop", true);    // 空中状態を開始
            animator.SetBool("Jumpend", false); // 着地をリセット
            
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Goal")
        {
            SkyBoxChangeBool = true;
            ADXSoundManager.Instance.PlaySound("beforeclear", clear.AcbAsset.Handle, clear.CueId, gameObject.transform, false);
        }

        if (other.gameObject.tag == "Floor")
        {
            jumpsky = false;
            // 着地時のアニメーション
            animator.SetBool("Jumploop", false);    // 空中状態を終了
            animator.SetBool("Jumpend", true);   // 着地アニメーション開始
            animator.SetBool("Jumpstart", false); // ジャンプ開始をリセット
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemiy")
        {
            Debug.Log("当たった");
            // Sisutemuクラスのインスタンスを探す
            Sisutemu sisutemuInstance = FindObjectOfType<Sisutemu>();
            if (sisutemuInstance != null)
            {
                sisutemuInstance.DownLife();
            }
            else
            {
                Debug.LogWarning("Sisutemuのインスタンスにアクセスできませんでした。");
            }
        }

      

    }


}
