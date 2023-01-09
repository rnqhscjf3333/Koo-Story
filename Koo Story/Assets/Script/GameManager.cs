using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; //�ó׸���
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour //�ı��Ǹ� �ȵ�
{
    public static GameManager Instance;
    public SoundManager soundmanager;
    public bool[] Chest;//����
    public int[] Key; //����������
    public int[] Quest;

    public int[] Swordhave;
    public int[] Armorhave;
    public int[] Skillhave;
    public int Swordnum;
    public int Armornum;
    public int Gold;

    public int StartPoint;

    public float Soundval1;
    public float Soundval2;

    public Sprite[] ArmorImage;
    public int BlenderDieCount;


    void Awake()
    {
        Chest = new bool[20];
        if (Instance != null) //�ߺ��ı�
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        //Load();
    }

    
    public void Save()
    {
        Soundval1 = soundmanager.val1;
        Soundval2 = soundmanager.val2;

        Debug.Log("Save");
        PlayerPrefs.SetInt("Gold", Gold);
        PlayerPrefs.SetInt("Swordnum", Swordnum);
        PlayerPrefs.SetInt("Armornum", Armornum);

        PlayerPrefs.SetFloat("Soundval1", Soundval1);
        PlayerPrefs.SetFloat("Soundval2", Soundval2);

        string strArr = ""; // ���ڿ� ����
        for (int i = 0; i < Chest.Length; i++) // �迭�� ','�� �����ư��� tempStr�� ����
        {
            strArr = strArr + Chest[i];
            if (i < Chest.Length - 1) // �ִ� ������ -1������ ,�� ����
                strArr = strArr + ",";
        }
        PlayerPrefs.SetString("Chest", strArr);

        strArr = ""; // ���ڿ� ����
        for (int i = 0; i < Key.Length; i++) // �迭�� ','�� �����ư��� tempStr�� ����
        {
            strArr = strArr + Key[i];
            if (i < Key.Length - 1) // �ִ� ������ -1������ ,�� ����
                strArr = strArr + ",";
        }
        PlayerPrefs.SetString("Key", strArr);

        strArr = ""; // ���ڿ� ����
        for (int i = 0; i < Quest.Length; i++) // �迭�� ','�� �����ư��� tempStr�� ����
        {
            strArr = strArr + Quest[i];
            if (i < Quest.Length - 1) // �ִ� ������ -1������ ,�� ����
                strArr = strArr + ",";
        }
        PlayerPrefs.SetString("Quest", strArr);

        strArr = ""; // ���ڿ� ����
        for (int i = 0; i < Swordhave.Length; i++) // �迭�� ','�� �����ư��� tempStr�� ����
        {
            strArr = strArr + Swordhave[i];
            if (i < Swordhave.Length - 1) // �ִ� ������ -1������ ,�� ����
                strArr = strArr + ",";
        }
        PlayerPrefs.SetString("Swordhave", strArr);

        strArr = ""; // ���ڿ� ����
        for (int i = 0; i < Armorhave.Length; i++) // �迭�� ','�� �����ư��� tempStr�� ����
        {
            strArr = strArr + Armorhave[i];
            if (i < Armorhave.Length - 1) // �ִ� ������ -1������ ,�� ����
                strArr = strArr + ",";
        }
        PlayerPrefs.SetString("Armorhave", strArr);

        strArr = ""; // ���ڿ� ����
        for (int i = 0; i < Skillhave.Length; i++) // �迭�� ','�� �����ư��� tempStr�� ����
        {
            strArr = strArr + Skillhave[i];
            if (i < Skillhave.Length - 1) // �ִ� ������ -1������ ,�� ����
                strArr = strArr + ",";
        }
        PlayerPrefs.SetString("Skillhave", strArr);




    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("Gold"))
        {
            Debug.Log("Load");
            Swordnum = PlayerPrefs.GetInt("Swordnum");
            Armornum = PlayerPrefs.GetInt("Armornum");
            if (GameObject.Find("Player") != null)
            {
                Player player = GameObject.Find("Player").GetComponent<Player>();
                player.ArmorInven(Armornum);
                player.Defense = GameObject.Find("Manager").GetComponent<Manager>().ArmorDefense[Armornum];
                player.SwordInven(Swordnum);
                player.Power = GameObject.Find("Manager").GetComponent<Manager>().SwordPower[Swordnum];
            }
            Gold = PlayerPrefs.GetInt("Gold");

            if (GameObject.Find("Manager") != null)
            {
                GameObject.Find("Manager").GetComponent<Manager>().PlayerGold = Gold;
            }

            Soundval1 = PlayerPrefs.GetFloat("Soundval1");
            Soundval2 = PlayerPrefs.GetFloat("Soundval2");

            soundmanager.val1 = Soundval1;
            soundmanager.val2 = Soundval2;


            string[] dataArr = PlayerPrefs.GetString("Chest").Split(','); // PlayerPrefs���� �ҷ��� ���� Split �Լ��� ���� ���ڿ��� ,�� �����Ͽ� �迭�� ����
            for (int i = 0; i < dataArr.Length; i++)
            {
                Chest[i] = System.Convert.ToBoolean(dataArr[i]); // ���ڿ� ���·� ����� ���� ���������� ��ȯ�� ����
            }

            dataArr = PlayerPrefs.GetString("Key").Split(','); // PlayerPrefs���� �ҷ��� ���� Split �Լ��� ���� ���ڿ��� ,�� �����Ͽ� �迭�� ����
            for (int i = 0; i < dataArr.Length; i++)
            {
                Key[i] = System.Convert.ToInt32(dataArr[i]); // ���ڿ� ���·� ����� ���� ���������� ��ȯ�� ����
            }

            dataArr = PlayerPrefs.GetString("Quest").Split(','); // PlayerPrefs���� �ҷ��� ���� Split �Լ��� ���� ���ڿ��� ,�� �����Ͽ� �迭�� ����
            for (int i = 0; i < dataArr.Length; i++)
            {
                Quest[i] = System.Convert.ToInt32(dataArr[i]); // ���ڿ� ���·� ����� ���� ���������� ��ȯ�� ����
            }

            dataArr = PlayerPrefs.GetString("Swordhave").Split(','); // PlayerPrefs���� �ҷ��� ���� Split �Լ��� ���� ���ڿ��� ,�� �����Ͽ� �迭�� ����
            for (int i = 0; i < dataArr.Length; i++)
            {
                Swordhave[i] = System.Convert.ToInt32(dataArr[i]); // ���ڿ� ���·� ����� ���� ���������� ��ȯ�� ����
            }

            dataArr = PlayerPrefs.GetString("Armorhave").Split(','); // PlayerPrefs���� �ҷ��� ���� Split �Լ��� ���� ���ڿ��� ,�� �����Ͽ� �迭�� ����
            for (int i = 0; i < dataArr.Length; i++)
            {
                Armorhave[i] = System.Convert.ToInt32(dataArr[i]); // ���ڿ� ���·� ����� ���� ���������� ��ȯ�� ����
            }

            dataArr = PlayerPrefs.GetString("Skillhave").Split(','); // PlayerPrefs���� �ҷ��� ���� Split �Լ��� ���� ���ڿ��� ,�� �����Ͽ� �迭�� ����
            for (int i = 0; i < dataArr.Length; i++)
            {
                Skillhave[i] = System.Convert.ToInt32(dataArr[i]); // ���ڿ� ���·� ����� ���� ���������� ��ȯ�� ����
            }
        }
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene("Main");
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
