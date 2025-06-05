using UnityEngine;

public class Circle_controll : MonoBehaviour
{

    //�O��ƂȂ�z��
    string[] circle = { "a", "a", "a", "b", "c", "d" };

    //�z��̗v�f�������_���ɉ�ʏ�̃I�u�W�F�Ɋ��蓖�Ă�
    //�I�u�W�F�̖��O����L�̂��̂Ƀ����_���ɏ���������
    //�������I�u�W�F�̖��O��a�Ȃ��ʂ�a�ƕ\������B




    void Start()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Maru");

        if (gameObjects.Length != circle.Length)
        {
            Debug.LogWarning("�I�u�W�F�N�g����circle�z��̐�����v���Ă��܂���");
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
                Debug.LogWarning("CircleType ���A�^�b�`����Ă��Ȃ��I�u�W�F�N�g������܂�");
            }
        }

    }

    // �z����V���b�t������֐�
    void ShuffleArray(string[] array)
    {
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


    void Update()
    {
        //���͈͓̂̔��ɓ�������ԂŃX�y�[�X�L�[�������ƁA��ʂɂ��̕������\�������
        //���̂��ƂɃA�^�b�`���������ǂ����������B



        
    }
}
