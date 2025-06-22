using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonBinder : MonoBehaviour
{
    public Button endingButton;

    void Start()
    {
        if (endingButton != null && SceneChanger.Instance != null)
        {
            endingButton.onClick.AddListener(SceneChanger.Instance.Ending);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   
   
}


