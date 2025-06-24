using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        // 既存の GameManager を破棄（ある場合）
        if (GameManager.Instance != null)
        {
            Destroy(GameManager.Instance.gameObject);
        }

        // SceneChanger を通してプレイ画面へ
        if (SceneChanger.Instance != null)
        {
            SceneChanger.Instance.ChangeScene("playscreen");
        }
        else
        {
            SceneManager.LoadScene("playscreen");
        }
    }
    public void OnChartButtonClicked()
    {
        // 既存の GameManager を破棄（ある場合）
        if (GameManager.Instance != null)
        {
            Destroy(GameManager.Instance.gameObject);
        }

        // SceneChanger を通してプレイ画面へ
        if (SceneChanger.Instance != null)
        {
            SceneChanger.Instance.ChangeScene("Chartscreen");
        }
        else
        {
            SceneManager.LoadScene("Chartscreen");
        }
    }

    public void OnStartingButtonClicked()
    {
        // 既存の GameManager を破棄（ある場合）
        if (GameManager.Instance != null)
        {
            Destroy(GameManager.Instance.gameObject);
        }

        // SceneChanger を通してプレイ画面へ
        if (SceneChanger.Instance != null)
        {
            SceneChanger.Instance.ChangeScene("TitleScreen");
        }
        else
        {
            SceneManager.LoadScene("TitleScreen");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
