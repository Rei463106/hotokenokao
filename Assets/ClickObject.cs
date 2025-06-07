using UnityEngine;

using UnityEngine.UI;


public class ClickObject : MonoBehaviour
{
    public Text resultText;


    // Start is called before the first frame update
    void Start()
    {
        if (resultText != null)
        {
            resultText.text = "";
        }

    }

    // Update is called once per frame
    void Update()
    {

    }



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
        if (type == "a")
        {
            Debug.Log("OK");

            if (resultText != null)
            {
                resultText.text = "わさび";
                resultText.color = Color.green;
                Destroy(gameObject);
            }
        }
        else if (type == "b")
        {

            resultText.text = "しゃけ";
            resultText.color = Color.red;
            Destroy(gameObject);
        }
        else if (type == "c")
        {

            resultText.text = "おかか";
            resultText.color = Color.yellow;
            Destroy(gameObject);
        }
        else if (type == "d") {

            resultText.text = "ツナマヨ";
            resultText.color= Color.blue;
            Destroy(gameObject);
        }

    }
}
