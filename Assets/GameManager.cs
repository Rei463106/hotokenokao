using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int life = 3;
    public Text Life_result;
    public Text resultText;
    public Image targetImage;
    public Sprite[] wasabiSprites;
    private int wasabiIndex = 0;

    public AudioSource GetSound;
    public AudioSource DamegeSound;
    public AudioSource ExplosionSound;

    private int countB = 0;
    private int countC = 0;
    private int countD = 0;

    private bool alreadyCleared = false; // �� �V�[���ēǂݍ��ݖh�~�p

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateLifeUI();
        ResetCounts();
        alreadyCleared = false;

        if (resultText != null)
            resultText.text = "";
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"[GameManager] �V�[���ǂݍ��݊���: {scene.name}");

        GameObject rt = GameObject.Find("resultText");
        if (rt != null)
        {
            resultText = rt.GetComponent<Text>();
        }

        GameObject lt = GameObject.Find("Life_result");
        if (lt != null)
        {
            Life_result = lt.GetComponent<Text>();
            UpdateLifeUI();
        }

        ResetCounts();
        alreadyCleared = false;

        // ... ������UI�擾�̂��Ƃɒǉ�
        GameObject get = GameObject.Find("GetSound");
        if (get != null)
            GetSound = get.GetComponent<AudioSource>();

        GameObject dmg = GameObject.Find("DamegeSound");
        if (dmg != null)
            DamegeSound = dmg.GetComponent<AudioSource>();

        GameObject exp = GameObject.Find("ExplosionSound");
        if (exp != null)
            ExplosionSound = exp.GetComponent<AudioSource>();
    }

    public void ChangeLife(int delta)
    {
        life = Mathf.Clamp(life + delta, 0, 3);
        UpdateLifeUI();

        if (life <= 0)
        {
            PlayingSound("explosion");

            if (resultText != null)
            {
                resultText.text = "�Q�[���I�[�o�[";
                resultText.color = Color.black;
            }

            StartCoroutine(DelayedGameOver());
        }
    }

    IEnumerator DelayedGameOver()
    {
        yield return new WaitForSeconds(1.5f);

        if (SceneChanger.Instance != null)
        {
            SceneChanger.Instance.ChangeScene("GameOverScreen");
        }
        else
        {
            SceneManager.LoadScene("GameOverScreen");
        }
    }

    void UpdateLifeUI()
    {
        if (Life_result != null)
        {
            Life_result.text = "���C�t: " + life;
        }
    }

    public void AddCount(string type)
    {
        if (type == "b") countB++;
        else if (type == "c") countC++;
        else if (type == "d") countD++;

        Debug.Log($"�擾�� b:{countB}, c:{countC}, d:{countD}");

        // �����B���`�F�b�N�i�Ď��s�h�~�t���j
        if (!alreadyCleared && countB >= 1 && countC >= 2 && countD >= 1)
        {
            alreadyCleared = true;
            Debug.Log("�����B���I�V�[���ړ����܂�");
            StartCoroutine(DelayToNextScene());
        }
    }

    IEnumerator DelayToNextScene()
    {
        yield return new WaitForSeconds(1f);

        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "playscreen")
        {
            SceneManager.LoadScene("NextScene"); // Round2 ��
        }
        else if (currentScene == "NextScene")
        {
            SceneManager.LoadScene("ClearScene"); // �N���A��ʂ�
        }
        else
        {
            Debug.LogWarning("�z��O�̃V�[����: " + currentScene);
        }
    }
    public void ResetCounts()
    {
        countB = 0;
        countC = 0;
        countD = 0;
        Debug.Log("�J�E���g�����Z�b�g���܂���");
    }

    public void SwitchWasabiImage()
    {
        if (wasabiSprites.Length == 0 || targetImage == null) return;

        wasabiIndex = (wasabiIndex + 1) % wasabiSprites.Length;
        targetImage.sprite = wasabiSprites[wasabiIndex];
    }

    public void PlayingSound(string t)
    {
        if (t == "explosion" && ExplosionSound != null) ExplosionSound.Play();
        if (t == "get" && GetSound != null) GetSound.Play();
        if (t == "damage" && DamegeSound != null) DamegeSound.Play();
    }
}
