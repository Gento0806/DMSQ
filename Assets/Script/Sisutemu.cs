using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sisutemu : MonoBehaviour
{
    public static Sisutemu Instance;

    private Image image;

    public GameObject[] lifeArray_3d = new GameObject[5];
    //public GameObject[] lifeArray_2d = new GameObject[5];
    //public GameObject[] lifedeath_3d = new GameObject[5];
    //public GameObject[] lifedeath_2d = new GameObject[5];
    private int lifePoint = 5;
    public bool Sanji = true;
    public bool bankey = false;
    public int DeathLine3D, DeathLine2D;


    [SerializeField] GameObject RespawnPoint3D;
    [SerializeField] GameObject RespawnPoint2D;
    [SerializeField] GameObject Player3D;
    [SerializeField] GameObject Player2D;

    [SerializeField] Sprite HPTrue;
    [SerializeField] Sprite HPFalse;
    //----‰¹----
    [SerializeField]
    CriWare.Assets.CriAtomCueReference gameover;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference damage;
    //----------

    void Start()
    {
        Time.timeScale = 1.0f;
        for(int i = 0; i < 5; i++)
        {
            image = lifeArray_3d[i].GetComponent<Image>();
            image.sprite = HPTrue;
        }
    }

    void Update()
    {
        if(Input.GetButtonDown("Change")) 
        {
           Sanji = !Sanji;
            bankey = true;
            Invoke(nameof(DelayMethod), 3.5f);
            //UpdateLifeDisplay();
        }
        if (Player3D.transform.position.y < DeathLine3D)
        {
            DownLife();       
        }
        else if(Player2D.transform.position.y < DeathLine2D)
        {
            DownLife();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene("GameOver");
            //----‰¹----
            ADXSoundManager.Instance.StopSound("hover");
            ADXSoundManager.Instance.StopSound("move");
            ADXSoundManager.Instance.StopSound("soner");
            ADXSoundManager.Instance.StopSound("bgm");
            ADXSoundManager.Instance.PlaySound("gameover", gameover.AcbAsset.Handle, gameover.CueId, gameObject.transform, false);
        }
    }
    void DelayMethod()
    {
        bankey = false;
    }
    public void DownLife()
    {
        image = lifeArray_3d[lifePoint-1].GetComponent<Image>();
        image.sprite = HPFalse;
        //lifedeath_3d[lifePoint - 1].SetActive(true);
        //lifeArray_2d[lifePoint - 1].SetActive(false);
        //lifedeath_2d[lifePoint - 1].SetActive(true);
        lifePoint--;
        ADXSoundManager.Instance.PlaySound("damage", damage.AcbAsset.Handle, damage.CueId, gameObject.transform, false);
        if (lifePoint == 0)
        {
            SceneSelect.StageNumGet();
            SceneManager.LoadScene("GameOver");
            //----‰¹----
            ADXSoundManager.Instance.StopSound("hover");
            ADXSoundManager.Instance.StopSound("move");
            ADXSoundManager.Instance.StopSound("soner");
            ADXSoundManager.Instance.StopSound("bgm");
            ADXSoundManager.Instance.PlaySound("gameover", gameover.AcbAsset.Handle, gameover.CueId, gameObject.transform, false);

        }
        Player3D.gameObject.transform.position = RespawnPoint3D.transform.position;
        Player2D.gameObject.transform.position = RespawnPoint2D.transform.position;
    }
   /* private void UpdateLifeDisplay()
    {
        for (int i = 0; i < lifeArray_3d.Length; i++)
        {
            if (i < lifePoint)
            {
                lifeArray_3d[i].SetActive(Sanji);
                lifeArray_2d[i].SetActive(!Sanji);
            }
            else
            {
                lifeArray_3d[i].SetActive(false);
                lifeArray_2d[i].SetActive(false);
            }
        }
    }*/
}
