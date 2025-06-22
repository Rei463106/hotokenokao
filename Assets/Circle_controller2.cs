using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_controller2 : MonoBehaviour
{
    [Header("���ނ��т̖��O")]
    public string[] omusubi_name;

    [Header("�Ή�����Q�[���I�u�W�F�N�g")]
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
                Debug.LogWarning("CircleType ���A�^�b�`����Ă��Ȃ��I�u�W�F�N�g������܂�");
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShuffleArray(string[] array)
    {
        //unity��Random�̓C���X�^���X�������Ɏg���i��������unity�ŃC���X�^���X���͂قƂ�ǂ��Ȃ��j
        System.Random rng = new System.Random();
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            // �v�f�����ւ�
            string temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

    }


}
