using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 clickPos = new Vector2(wp.x, wp.y);

            Collider2D hit = Physics2D.OverlapPoint(clickPos);
            if (hit != null && hit.gameObject == gameObject)
            {
                Debug.Log("クリック強制検知：白丸を削除");
                Destroy(gameObject);
            }
        }
    }

   
   
}


