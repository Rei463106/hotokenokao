using UnityEngine;

public class Circle_controll : MonoBehaviour
{

    //前提となる配列
    string[] circle = { "a", "a", "a", "b", "c", "d" };

    //配列の要素をランダムに画面上のオブジェに割り当てる
    //オブジェの名前を上記のものにランダムに書き換える
    //もしもオブジェの名前がaなら画面にaと表示する。




    void Start()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Maru");

        if (gameObjects.Length != circle.Length)
        {
            Debug.LogWarning("オブジェクト数とcircle配列の数が一致していません");
            return;
        }

        ShuffleArray(circle);

        for (int i = 0; i < gameObjects.Length; i++)
        {
            string type = circle[i];
            gameObjects[i].name = type;

            CircleType ct = gameObjects[i].GetComponent<CircleType>();
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

    // 配列をシャッフルする関数
    void ShuffleArray(string[] array)
    {
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


    void Update()
    {
        //ものの範囲内に入った状態でスペースキーを押すと、画面にその文字が表示される
        //ものごとにアタッチした方が良さそうかも。



        
    }
}
