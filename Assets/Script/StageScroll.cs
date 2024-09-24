using UnityEngine;
using UnityEngine.UI;

public class StageScroll : MonoBehaviour
{

    public RectTransform[] ScrollPanel;
    public Vector2[] AfterTransform;
    public float moveSpeed; // �ړ��X�s�[�h

    private int count = 0;   // �J�E���g��ێ�����ϐ�
    private bool shouldMove = false;
    private bool clicked = false;

    public Button[] buttons;
    //---��---
    [SerializeField]
    CriWare.Assets.CriAtomCueReference page;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference cansp;
    //--------
    void Start()
    {
        Time.timeScale = 1.0f;
        count = 0;
        shouldMove = false;
        clicked = false;
    }

    // +1�{�^���������ꂽ�Ƃ��ɌĂяo�����
    public void Increment()
    {
        
        if (!clicked)
        {
            clicked = true;
            if(count < (ScrollPanel.Length / 3)-1)
            {
                count++;
                Debug.Log(count);
                for (int i = 0; i < ScrollPanel.Length; i++)
                {
                    AfterTransform[i] = ScrollPanel[i].anchoredPosition - new Vector2(1900, 0);
                }
                CheckAndMoveObjects(); // �J�E���g���`�F�b�N���ăI�u�W�F�N�g���ړ�
                ADXSoundManager.Instance.PlaySound("page", page.AcbAsset.Handle, page.CueId,gameObject.transform, false);
            }
            else
            {
                clicked = false;
                ADXSoundManager.Instance.PlaySound("cans", cansp.AcbAsset.Handle, cansp.CueId, gameObject.transform, false);
            }
            
        }
        
    }

    // -1�{�^���������ꂽ�Ƃ��ɌĂяo�����
    public void Decrement()
    {
      
        if (!clicked)
        {
            clicked = true;
            if (count > 0)
            {
                
                count --;
                Debug.Log(count);
                for (int i = 0; i < ScrollPanel.Length; i++)
                {
                    AfterTransform[i] = ScrollPanel[i].anchoredPosition + new Vector2(1900, 0);
                }
                CheckAndMoveObjectsMainas(); // �J�E���g���`�F�b�N���ăI�u�W�F�N�g���ړ�
                ADXSoundManager.Instance.PlaySound("page", page.AcbAsset.Handle, page.CueId, gameObject.transform, false);
            }
            else
            {
                clicked = false;
                ADXSoundManager.Instance.PlaySound("cans", cansp.AcbAsset.Handle, cansp.CueId, gameObject.transform, false);
            }

        }
    }


    // �J�E���g��1�Ȃ�I�u�W�F�N�g���ړ�������
    private void CheckAndMoveObjects()
    {
        if (count<=(ScrollPanel.Length/3)-1 && !shouldMove)
        {
            shouldMove = true;
        }

        if (shouldMove)
        {
            for(int i = 0; i < ScrollPanel.Length; i++)
            {
                ScrollPanel[i].anchoredPosition = Vector3.MoveTowards(ScrollPanel[i].anchoredPosition, AfterTransform[i], moveSpeed * Time.deltaTime);
            }
            if(ScrollPanel[ScrollPanel.Length-1].anchoredPosition == AfterTransform[ScrollPanel.Length - 1])
            {
                shouldMove = false;
                clicked = false;
            }
        }
    }

    private void CheckAndMoveObjectsMainas()
    {
        if (count >= 0 && !shouldMove)
        {
            shouldMove = true;
        }

        if (shouldMove)
        {
            for (int i = 0; i < ScrollPanel.Length; i++)
            {
                ScrollPanel[i].anchoredPosition = Vector3.MoveTowards(ScrollPanel[i].anchoredPosition, AfterTransform[i], moveSpeed * Time.deltaTime);
            }
            if (ScrollPanel[ScrollPanel.Length - 1].anchoredPosition == AfterTransform[ScrollPanel.Length - 1])
            {
                shouldMove = false;
                clicked = false;
            }
        }
    }

    void Update()
    {
        // �I�u�W�F�N�g�̈ړ����t���[�����ƂɍX�V
        if (shouldMove)
        {
            CheckAndMoveObjects();
            CheckAndMoveObjectsMainas();
        }

        for(int i = 0; i< buttons.Length;i++)
        {
            if(i >= (count*3) && i < (count * 3) + 3)
            {
                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].interactable = false;
            }
        }
    }
}