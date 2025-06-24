using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int life = 5;
    public Text Life_result;
    public Text resultText;
    public Image targetImage;

    public Sprite[] wasabiSprites1; // ラウンド1用
    public Sprite[] wasabiSprites2; // ラウンド2用
    private Sprite[] currentWasabiSprites; // 今使っている画像セット

    private int wasabiIndex = 0;

    public AudioSource GetSound;
    public AudioSource DamegeSound;
    public AudioSource ExplosionSound;

    private int countB = 0;
    private int countC = 0;
    private int countD = 0;

    private bool alreadyCleared = false;

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
        Debug.Log($"[GameManager] シーン読み込み完了: {scene.name}");

        // UI関連の再取得
        GameObject rt = GameObject.Find("resultText");
        if (rt != null) resultText = rt.GetComponent<Text>();

        GameObject lt = GameObject.Find("Life_result");
        if (lt != null)
        {
            Life_result = lt.GetComponent<Text>();
            UpdateLifeUI();
        }

        // Audio再取得
        GameObject get = GameObject.Find("GetSound");
        if (get != null) GetSound = get.GetComponent<AudioSource>();

        GameObject dmg = GameObject.Find("DamegeSound");
        if (dmg != null) DamegeSound = dmg.GetComponent<AudioSource>();

        GameObject exp = GameObject.Find("ExplosionSound");
        if (exp != null) ExplosionSound = exp.GetComponent<AudioSource>();

        // シーンごとの画像とスプライトセット切り替え
        if (scene.name == "playscreen")
        {
            GameObject img = GameObject.Find("TargetImage");
            if (img != null) targetImage = img.GetComponent<Image>();

            currentWasabiSprites = wasabiSprites1;
            wasabiIndex = 0;
            if (targetImage != null && currentWasabiSprites.Length > 0)
                targetImage.sprite = currentWasabiSprites[0];
        }
        else if (scene.name == "NextScene")
        {
            GameObject img = GameObject.Find("hotoke");
            if (img != null) targetImage = img.GetComponent<Image>();

            currentWasabiSprites = wasabiSprites2;
            wasabiIndex = 0;
            life = 3; // ライフも初期化
            UpdateLifeUI();

            if (targetImage != null && currentWasabiSprites.Length > 0)
                targetImage.sprite = currentWasabiSprites[0];
        }

        ResetCounts();
        alreadyCleared = false;
    }

    public void SwitchWasabiImage()
    {
        if (currentWasabiSprites == null || currentWasabiSprites.Length == 0 || targetImage == null) return;

        wasabiIndex = (wasabiIndex + 1) % currentWasabiSprites.Length;
        targetImage.sprite = currentWasabiSprites[wasabiIndex];
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
                resultText.text = "ゲームオーバー";
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
            Life_result.text = "仏の顔: " + life;
        }
    }

    public void AddCount(string type)
    {
        if (type == "b") countB++;
        else if (type == "c") countC++;
        else if (type == "d") countD++;

        Debug.Log($"取得数 b:{countB}, c:{countC}, d:{countD}");

        if (!alreadyCleared && countB >= 1 && countC >= 2 && countD >= 1)
        {
            alreadyCleared = true;
            Debug.Log("条件達成！シーン移動します");
            StartCoroutine(DelayToNextScene());
        }
    }

    IEnumerator DelayToNextScene()
    {
        yield return new WaitForSeconds(1f);

        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "playscreen")
        {
            SceneManager.LoadScene("NextScene");
        }
        else if (currentScene == "NextScene")
        {
            SceneManager.LoadScene("ClearScene");
        }
        else
        {
            Debug.LogWarning("想定外のシーン名: " + currentScene);
        }
    }

    public void ResetCounts()
    {
        countB = 0;
        countC = 0;
        countD = 0;
        Debug.Log("カウントをリセットしました");
    }

    public void PlayingSound(string t)
    {
        if (t == "explosion" && ExplosionSound != null) ExplosionSound.Play();
        if (t == "get" && GetSound != null) GetSound.Play();
        if (t == "damage" && DamegeSound != null) DamegeSound.Play();
    }
}
