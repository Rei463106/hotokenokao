using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        // ������ GameManager ��j���i����ꍇ�j
        if (GameManager.Instance != null)
        {
            Destroy(GameManager.Instance.gameObject);
        }

        // SceneChanger ��ʂ��ăv���C��ʂ�
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
        // ������ GameManager ��j���i����ꍇ�j
        if (GameManager.Instance != null)
        {
            Destroy(GameManager.Instance.gameObject);
        }

        // SceneChanger ��ʂ��ăv���C��ʂ�
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
        // ������ GameManager ��j���i����ꍇ�j
        if (GameManager.Instance != null)
        {
            Destroy(GameManager.Instance.gameObject);
        }

        // SceneChanger ��ʂ��ăv���C��ʂ�
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
