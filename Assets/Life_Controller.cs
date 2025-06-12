using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//わさびを取ったか否かでライフがそのまま、減ったりする。
//clickobjectの方で、取ったらスコア加算、そのままか…を書く
//こっちの方で取得し、Textで表示する



public class Life_Controller : MonoBehaviour
{
    [SerializeField] int life = 3;
    public Text Life_result;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
