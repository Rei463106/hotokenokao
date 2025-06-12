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





    // Update is called once per frame
    void Update()
    {
        
    }
}
