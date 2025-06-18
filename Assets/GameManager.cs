using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int life = 3;
    public Text Life_result;
    public Text resultText;
    public Image targetImage;         // �� UI�摜�iImage�j���w��

    public Sprite[] wasabiSprites;
    private int wasabiIndex = 0;



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





    // Update is called once per frame
    void Update()
    {
        
    }
}
