using CriWare;
using CriWare.Assets;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class Move_Player : MonoBehaviour
{
    //�A�j���[�V����
    private Animator animator;

    //�����炵���ړ��Ɏg��
    public GameObject MainCamera;
    float moveX, moveZ;

    static float speed = 4f; // �ړ����x
    static float speed2d = 4f;
    int jumpforce = 3500;
    Rigidbody rb;
    bool imputkey = false;
    private Tmpg tmpg_;
    bool jumpsieru = false;
    int dir = 0;
    float LookRotate;
    // 1�t���[���O�̈ʒu
    private Vector3 _prevPosition;
    float rakka = 0.5f;
    public float initialForce = 10f; // �����̗̗͂�
    public float maxForce = 50f; // �ő�̗̗͂�
    public float forceIncreaseRate = 10f; // �͂̑�����
    private float currentForce; // ���݂̗̗͂�

    [SerializeField] GameObject cameracon;
    [SerializeField] GameObject system;
    [SerializeField] GameObject Rotation2DPoint;
    public string blockTag = "saka1"; // �u���b�N�̃^�O
    public float forceMagnitude = 20f; // ������͂̑傫��
    bool banmove = false;
    public float forceAmount = 10f; // ������̗͂�
    public float sakaForce = 0.02f;

    //�X�J�C�{�b�N�X
    public Material skyboxMaterial;
    public Color startColor = Color.HSVToRGB(82f, 49f, 60f);
    public Color endColor = Color.HSVToRGB(98f, 164f, 209f);
    //public float duration = 5.0f;
    public float tImer = 0;
    public bool SkyBoxChangeBool = false;
    public float t;
    //

    //�d�͐ؑ�
    bool isGravityReversed = false;
    public float rotationDuration = 0.5f; // ��]�ɂ����鎞��
    private bool isRotating = false;
    private Quaternion startRotation;
    private Quaternion targetRotation;
    private float elapsedTime = 0.0f;
    //

    

    //----��----
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
        tmpg_ = new Tmpg();
        tmpg_.Enable();
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
        // �Q�[���p�b�h�i�f�o�C�X�擾�j
        var gamepad = Gamepad.current;
        if (gamepad == null) return;

        Rigidbody rb = this.transform.GetComponent<Rigidbody>();
        vec = rb.velocity;
        //Debug.Log(vec.y);


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
            //�����炵���ړ��i��n)
            // �ړ���
            moveX = gamepad.leftStick.x.ReadValue() * speed; // ���E
            moveZ = gamepad.leftStick.y.ReadValue() * speed; // �O��
                                                       // �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
            Vector3 cameraForward = Vector3.Scale(MainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
            // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
            Vector3 move = cameraForward * moveZ + MainCamera.transform.right * moveX;
            Vector3 PlayerPosition = this.transform.position;
            PlayerPosition.y += 1.5f;
            Ray ray = new Ray(PlayerPosition, move);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (Vector3.Distance(hit.point, this.transform.position) < 2 && hit.collider.gameObject.tag != "saka1" && hit.collider.gameObject.tag != "Goal")
                {
                    if (cameracon.GetComponent<CameraCon>().sanji && hit.collider.gameObject.tag != "Wall" || cameracon.GetComponent<CameraCon>().sanji == false)
                    {
                        Debug.Log(hit.collider.gameObject.name);
                        banmove = true;
                    }
                    else
                    {
                        Debug.Log(hit.collider.gameObject.name);
                        banmove = false;
                    }
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

            /*�d�͐ؑ�-----------------------------
            // G�L�[�������ꂽ�����m�F
            if (Input.GetKeyDown(KeyCode.G)&&!cameracon.GetComponent<CameraCon>().sanji)
            {
                // �d�͂̕������t�ɂ���
                isGravityReversed = !isGravityReversed;

                if (isGravityReversed)
                {
                    Physics.gravity = new Vector3(0, 40f, 0); // �d�͂��������
                    isRotating = true;
                    elapsedTime = 0.0f;
                    startRotation = transform.rotation;
                    targetRotation = startRotation * Quaternion.Euler(180f, 0f, 0f); // 180�x��]
                }
                else
                {
                    Physics.gravity = new Vector3(0, -40f, 0); // �d�͂��������ɖ߂�
                    isRotating = true;
                    elapsedTime = 0.0f;
                    startRotation = transform.rotation;
                    targetRotation = startRotation * Quaternion.Euler(180f, 0f, 0f); // 180�x��]
                }
            }
            // ��]��
            if (isRotating)
            {
                elapsedTime += Time.deltaTime*5;
                float t = Mathf.Clamp01(elapsedTime / rotationDuration);
                transform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);

                // ��]������������I��
                if (t >= 1.0f)
                {
                    isRotating = false;
                }
            }
            */

            if (cameracon.GetComponent<CameraCon>().sanji && banmove == false)
            {

                this.gameObject.transform.position += move * speed * Time.deltaTime;//�ړ�

                if (move != Vector3.zero)
                {
                    //----��----
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
                if (tmpg_.Player.MoveButton.triggered || tmpg_.Player.Move.triggered)
                {
                    //----��----
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
                move = new Vector3(0, moveZ, moveX);
                this.transform.position+=(move * Time.deltaTime*speed2d); //����
                                                                                                   //transform.rotation = Quaternion.LookRotation(transform.position +(Vector3.forward * Input.GetAxisRaw("Horizontal") * -1)- transform.position);





            }

            if (move != Vector3.zero)
            {
                    transform.rotation = Quaternion.LookRotation(move);

                animator.SetBool("Walk", true);

            }
            else
            {
                animator.SetBool("Walk", false);
            }


            if (tmpg_.Player.Jump.triggered)
            {
                imputkey = false;
            }
            if (((Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical")) || tmpg_.Player.MoveCancelStick.triggered)
                && !ismovestart
                && !Input.GetKey("w")
                && !Input.GetKey("a")
                && !Input.GetKey("s")
                && !Input.GetKey("d")
                && !Input.GetKey(KeyCode.LeftArrow)
                && !Input.GetKey(KeyCode.UpArrow)
                && !Input.GetKey(KeyCode.DownArrow)
                && !Input.GetKey(KeyCode.RightArrow)
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
            // Timer���X�V
            tImer += 1 * Time.deltaTime;
            // �F����`��Ԃ��Đݒ�
            Color currentColor = Color.Lerp(startColor, endColor, tImer);
            skyboxMaterial.SetColor("_Tint", currentColor);

            Debug.Log(tImer);
            if (tImer >= t)
            {
                CriAtomEx.ApplyDspBusSnapshot("Snapshot", 100);
                ADXSoundManager.Instance.StopSound("move");
                ADXSoundManager.Instance.StopSound("hover");
                ADXSoundManager.Instance.StopSound("soner");
                ADXSoundManager.Instance.StopSound("bgm");
                ADXSoundManager.Instance.PlaySound("goal", goal.AcbAsset.Handle, goal.CueId, gameObject.transform, false);
                SceneSelect.StageNumChange();
                SceneManager.LoadScene("Next");
            }
        }

    }

    public void FixedUpdate()
    {
        //�������x�㏸
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
            switch (dir)//�d�͕����̐؂�ւ�
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

    //�W�����v�i�������j
    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Floor") && (tmpg_.Player.Jump.triggered || Input.GetKeyDown(KeyCode.Space))&& system.GetComponent<Sisutemu>().bankey == false)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(0, jumpforce, 0);
            imputkey = true;
            Debug.Log("Jump");

            //----��----

            ADXSoundManager.Instance.PlaySound("jump", cueReference2.AcbAsset.Handle, cueReference2.CueId, gameObject.transform, false);
            //----------
        }
        // �ʉ߂����I�u�W�F�N�g���w�肵���^�O�������Ă��邩�m�F
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


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Goal")
        {
            SkyBoxChangeBool = true;
            ADXSoundManager.Instance.PlaySound("beforeclear", clear.AcbAsset.Handle, clear.CueId, gameObject.transform, false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemiy")
        {
            Debug.Log("��������");
            // Sisutemu�N���X�̃C���X�^���X��T��
            Sisutemu sisutemuInstance = FindObjectOfType<Sisutemu>();
            if (sisutemuInstance != null)
            {
                sisutemuInstance.DownLife();
            }
            else
            {
                Debug.LogWarning("Sisutemu�̃C���X�^���X�ɃA�N�Z�X�ł��܂���ł����B");
            }
        }
    }


}
