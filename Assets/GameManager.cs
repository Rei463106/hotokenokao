using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int life = 3;
    public Text Life_result;
    public Text resultText;
    public Image targetImage;         // �� UI�摜�iImage�j���w��

    public Sprite[] wasabiSprites;
    private int wasabiIndex = 0;


    // �擾���J�E���g�p
    private int countB = 0;
    private int countC = 0;
    private int countD = 0;




    //public Sprite wasabiReactionSprite; // �� �؂�ւ�����Sprite��Inspector�ŃZ�b�g

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �V�[���؂�ւ������Ă������Ȃ�
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SwitchWasabiImage()
    {
        if (wasabiSprites.Length == 0 || targetImage == null) return;

        wasabiIndex = (wasabiIndex + 1) % wasabiSprites.Length;
        targetImage.sprite = wasabiSprites[wasabiIndex];
    }



    // Start is called before the first frame update
    void Start()
    {
        UpdateLifeUI();
        if (resultText != null)
            resultText.text = "";
    }

    public void ChangeLife(int delta)
    {
        life = Mathf.Clamp(life + delta, 0, 3);
        UpdateLifeUI();

        if (life <= 0)
        {
            if (resultText != null)
            {
                resultText.text = "�Q�[���I�[�o�[";
                resultText.color = Color.black;
                SceneManager.LoadScene("GameOverScreen");
            }
        }
    }

    void UpdateLifeUI()
    {
        if (Life_result != null)
        {
            Life_result.text = "���C�t: " + life;
        }
    }
    //b1c2d1������玩���I�ɃV�[�����ړ�����B




    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCount(string type)
    {
        if (type == "b")
        {
            countB++;
        }
        else if (type == "c")
        {
            countC++;
        }
        else if (type == "d")
        {
            countD++;
        }

        Debug.Log($"�擾�� b:{countB}, c:{countC}, d:{countD}");

        if (countB >= 1 && countC >= 2 && countD >= 1)
        {
            Debug.Log("�����B���I�V�[���ړ����܂�");
            UnityEngine.SceneManagement.SceneManager.LoadScene("NextScene");
        }
    }

}
