using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_controller2 : MonoBehaviour
{
    [Header("おむすびの名前")]
    public string[] omusubi_name;

    [Header("対応するゲームオブジェクト")]
    public GameObject[] omusubi_object;



    // Start is called before the first frame update
    void Start()
    {
        ShuffleArray(omusubi_name);

        for (int i = 0; i < omusubi_object.Length; i++)
        {
            string type = omusubi_name[i];
            omusubi_object[i].name = type;

            CircleType ct = omusubi_object[i].GetComponent<CircleType>();
            if (ct != null)
            {
                ct.SetType(type);
            }
            else
            {
                Debug.LogWarning("CircleType がアタッチされていないオブジェクトがあります");
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShuffleArray(string[] array)
    {
        //unityのRandomはインスタンス化せずに使う（そもそもunityでインスタンス化はほとんどやらない）
        System.Random rng = new System.Random();
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            // 要素を入れ替え
            string temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

    }


}
