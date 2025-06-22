using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �V�[�����܂����ŕێ�
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Title()
    {
        SceneManager.LoadScene("playscreen");
    }
   
}
