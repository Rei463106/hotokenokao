using UnityEngine;
using UnityEngine.UI;

public class ClickObject : MonoBehaviour
{
    public Text resultText;  // ※ GameManagerのresultTextと同じものを使うなら削除してもOK

    void OnMouseDown()
    {
        CircleType ct = GetComponent<CircleType>();
        if (ct != null)
        {
            string type = ct.type;
            JudgeClick(type);
        }
        else
        {
            Debug.LogWarning("CircleType が見つかりません");
        }
    }

    void JudgeClick(string type)
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManagerが見つかりません");
            return;
        }

        if (type == "a")
        {
            GameManager.Instance.resultText.text = "わさび";
            GameManager.Instance.resultText.color = Color.green;
            GameManager.Instance.ChangeLife(-1); // ライフを1減らす
            GameManager.Instance.SwitchWasabiImage(); ; // ← 画像切り替え
        }
        else if (type == "b")
        {
            GameManager.Instance.resultText.text = "しゃけ";
            GameManager.Instance.resultText.color = Color.red;
            GameManager.Instance.AddCount("b");
        }
        else if (type == "c")
        {
            GameManager.Instance.resultText.text = "おかか";
            GameManager.Instance.resultText.color = Color.yellow;
            GameManager.Instance.AddCount("c");
        }
        else if (type == "d")
        {
            GameManager.Instance.resultText.text = "ツナマヨ";
            GameManager.Instance.resultText.color = Color.blue;
            GameManager.Instance.AddCount("d");
        }
        else
        {
            GameManager.Instance.resultText.text = "不明なタイプ";
            GameManager.Instance.resultText.color = Color.white;
        }

        Destroy(gameObject);
    }
}
