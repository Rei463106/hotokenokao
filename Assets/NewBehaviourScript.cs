using UnityEngine;

using UnityEngine.UI;


public class NewBehaviourScript : MonoBehaviour
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
            Debug.LogWarning("CircleType ‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ");
        }
    }

    void JudgeClick(string type)
    {
        if (type == "a")
        {
            Debug.Log("OK");

            if (resultText != null)
            {
                resultText.text = "‚í‚³‚Ñ";
                resultText.color = Color.green;
            }
        }
        else if (type == "b")
        {

            resultText.text = "‚µ‚á‚¯";
            resultText.color = Color.red;
        }
        else if (type == "c")
        {

            resultText.text = "‚¨‚©‚©";
            resultText.color = Color.yellow;
        }
        else if (type == "d") {

            resultText.text = "ƒcƒiƒ}ƒˆ";
            resultText.color= Color.white;
        }

    }
}
