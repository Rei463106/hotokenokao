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
    public Image targetImage;         // ← UI画像（Image）を指定

    public Sprite[] wasabiSprites;
    private int wasabiIndex = 0;


    // 取得数カウント用
    private int countB = 0;
    private int countC = 0;
    private int countD = 0;




    //public Sprite wasabiReactionSprite; // ← 切り替えたいSpriteをInspectorでセット

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーン切り替えあっても消えない
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
                resultText.text = "ゲームオーバー";
                resultText.color = Color.black;
                SceneManager.LoadScene("GameOverScreen");
            }
        }
    }

    void UpdateLifeUI()
    {
        if (Life_result != null)
        {
            Life_result.text = "ライフ: " + life;
        }
    }
    //b1c2d1取ったら自動的にシーンを移動する。




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

        Debug.Log($"取得数 b:{countB}, c:{countC}, d:{countD}");

        if (countB >= 1 && countC >= 2 && countD >= 1)
        {
            Debug.Log("条件達成！シーン移動します");
            UnityEngine.SceneManagement.SceneManager.LoadScene("NextScene");
        }
    }

}
