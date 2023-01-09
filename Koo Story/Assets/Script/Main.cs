using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Main : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] MainObject;
    public GameObject Sword;
    public GameObject Armor;
    public GameObject Boss;
    public GameObject[] back;
    public GameObject Light;
    public Manager manager;
    public ParticleSystem Dust;

    float LightColor;

    public Sprite[] SwordSprite;
    public Sprite[] AromrSprite;

    public GameObject[] GB;
    public GameObject[] NPCButton;
    public GameObject[] BossButton;
    public GameObject[] StaticButton;
    public bool isGo;
    public TextMeshProUGUI[] text;
    public TextMeshProUGUI[] text1;
    public TextMeshProUGUI[] text2;
    public string sentence;
    public Sprite sprite;

    public float position1;
    public float position2;
    public float position3;

    void Awake()
    {
        Invoke("PlayerStart", 2f);
        GameManager.Instance.Load();
    }

    // Update is called once per frame
    void Update()
    {
        Sword.GetComponent<SpriteRenderer>().sprite = SwordSprite[GameManager.Instance.Swordnum];
        if (GameManager.Instance.Quest[0] < 56)
        {
            Armor.GetComponent<SpriteRenderer>().sprite = AromrSprite[GameManager.Instance.Armornum];
        }
        else
        {
            Armor.GetComponent<SpriteRenderer>().sprite = AromrSprite[10];
            Boss.GetComponent<SpriteRenderer>().sprite = AromrSprite[11];
        }

        if (GameManager.Instance.Quest[0] < 56)
            Light.GetComponent<Light2D>().color = new Color(1, LightColor, LightColor);
        else
            Light.GetComponent<Light2D>().color = new Color(LightColor, 1, LightColor);

        LightColor = (Boss.transform.position.x) / 300;
        if(LightColor <= 0.017)
        {
            Player.GetComponent<Animator>().SetBool("isWalk", false);
            Dust.Stop();
        }
    }

    public void NewStart()
    {
        for (int i = 0; i < GameManager.Instance.Chest.Length; i++)
            GameManager.Instance.Chest[i] = false;
        for (int i = 0; i < GameManager.Instance.Key.Length; i++)
            GameManager.Instance.Key[i] = 0;
        for (int i = 0; i < GameManager.Instance.Quest.Length; i++)
            GameManager.Instance.Quest[i] = 0;
        for (int i = 0; i < GameManager.Instance.Swordhave.Length; i++)
            GameManager.Instance.Swordhave[i] = 0;
        for (int i = 0; i < GameManager.Instance.Armorhave.Length; i++)
            GameManager.Instance.Armorhave[i] = 0;
        for (int i = 0; i < GameManager.Instance.Skillhave.Length; i++)
            GameManager.Instance.Skillhave[i] = 0;
        GameManager.Instance.Swordnum = 0;
        GameManager.Instance.Armornum = 0;
        GameManager.Instance.Gold = 0;
        GameManager.Instance.StartPoint = 0;
        GameManager.Instance.Swordhave[0] = 1;
        GameManager.Instance.Armorhave[0] = 1;

        SoundManager.instance.Click();
        manager.Fade = 1;
        Invoke("NewStart1", 1f);
    }
    void NewStart1()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void PlayerStart()
    {
        Player.GetComponent<Animator>().SetBool("isWalk", true);
        Dust.Play();
    }

    public void LoadStart()
    {
        SoundManager.instance.Click();
        GameManager gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gamemanager.Load();
        manager.Fade = 1;
        if (gamemanager.Quest[0] >= 40)
            Invoke("GoToTTS", 2f);
        else if (gamemanager.Quest[0] >= 13)
            Invoke("GoToRobra", 2f);
        else
            Invoke("GoToDne", 2f);
    }

    void GoToTTS()
    {
        SceneManager.LoadScene("ttas");
    }
    void GoToRobra()
    {
        SceneManager.LoadScene("Robrah_Village");
    }

    void GoToDne()
    {
        SceneManager.LoadScene("Dne_Village");
    }

    public void Exit()
    {
        SoundManager.instance.Click();
        Application.Quit();
    }

    public void Collection1()
    {
        foreach (GameObject i in back)
            i.SetActive(true);
        foreach (GameObject i in MainObject)
            i.SetActive(true);
        Player.SetActive(true);
        SoundManager.instance.Click();
        GB[0].SetActive(false);
        Player.GetComponent<Animator>().SetBool("isWalk", true);
        Dust.Play();
    }

    public void Collection()
    {
        foreach (GameObject i in back)
            i.SetActive(false);
        foreach (GameObject i in MainObject)
            i.SetActive(false);
        Player.SetActive(false);
        SoundManager.instance.Click();
        GB[0].SetActive(true);


        //����
        if (GameManager.Instance.Quest[0] >= 4)//��
        {
            BossButton[1].GetComponent<Image>().color = new Color(1, 1, 1);
            BossButton[1].GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.Quest[2] >= 3)//����
        {
            BossButton[2].GetComponent<Image>().color = new Color(1, 1, 1);
            BossButton[2].GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.Quest[0] >= 6)//����
        {
            BossButton[3].GetComponent<Image>().color = new Color(1, 1, 1);
            BossButton[3].GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.Quest[3] >= 3)//�����ΰ�
        {
            BossButton[4].GetComponent<Image>().color = new Color(1, 1, 1);
            BossButton[4].GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.Quest[0] >= 9)//��������
        {
            BossButton[5].GetComponent<Image>().color = new Color(1, 1, 1);
            BossButton[5].GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.Quest[0] >= 11)//��ġ
        {
            BossButton[6].GetComponent<Image>().color = new Color(1, 1, 1);
            BossButton[6].GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.Swordhave[8] ==1)//����
        {
            BossButton[7].GetComponent<Image>().color = new Color(1, 1, 1);
            BossButton[7].GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.Quest[9] >= 1)//�̽õ���
        {
            BossButton[8].GetComponent<Image>().color = new Color(1, 1, 1);
            BossButton[8].GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.Quest[4] >= 2)//����
        {
            BossButton[9].GetComponent<Image>().color = new Color(1, 1, 1);
            BossButton[9].GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.Quest[0] >= 24)//��
        {
            BossButton[10].GetComponent<Image>().color = new Color(1, 1, 1);
            BossButton[10].GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.Quest[0] >= 26)//������
        {
            BossButton[11].GetComponent<Image>().color = new Color(1, 1, 1);
            BossButton[11].GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.Quest[0] >= 35)//��
        {
            BossButton[12].GetComponent<Image>().color = new Color(1, 1, 1);
            BossButton[12].GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.Key[2] == 1)//��뺴��
        {
            BossButton[13].GetComponent<Image>().color = new Color(1, 1, 1);
            BossButton[13].GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.Quest[6] >= 2)//����
        {
            BossButton[14].GetComponent<Image>().color = new Color(1, 1, 1);
            BossButton[14].GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.Quest[0] >= 46)//����
        {
            BossButton[15].GetComponent<Image>().color = new Color(1, 1, 1);
            BossButton[15].GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.Quest[0] >= 48)//����
        {
            BossButton[16].GetComponent<Image>().color = new Color(1, 1, 1);
            BossButton[16].GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.Quest[0] >= 51)//ĳ��Ŀ
        {
            BossButton[17].GetComponent<Image>().color = new Color(1, 1, 1);
            BossButton[17].GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.Quest[0] >= 53)//���¶�
        {
            BossButton[18].GetComponent<Image>().color = new Color(1, 1, 1);
            BossButton[18].GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.Quest[0] >= 56)//����
        {
            BossButton[19].GetComponent<Image>().color = new Color(1, 1, 1);
            BossButton[19].GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.Key[3] >= 1)//����縣
        {
            BossButton[20].GetComponent<Image>().color = new Color(1, 1, 1);
            BossButton[20].GetComponent<Button>().interactable = true;
        }

        if (GameManager.Instance.Quest[5] < 1)
        {
            text2[0].text = "??";
        }
    }

    public void NPC(int num)
    {
        SoundManager.instance.Click();
        if (num == 0)//����
        {
            text[0].text = "����";
            text[1].text = "���̽��� ����.";
            text[2].text = "??";
            text[3].text = "??";
            text[4].text = "??";
            text[5].text = "??";
            if(GameManager.Instance.Quest[0] > 12)
            {
                text[2].text = "�ƹ��� ??�� ���߰� �¾�ϰ� ���� ������ ġ���� ���� ������� ���� ���ƿ��� �ʾҴ�.";
                text[3].text = "��Ӵ� �����ٴ� �� �տ� ������ ���̽��� �ŵּ� ���߿� ���� Ű������ ���۽����� ���� ������ ������.";
                text[4].text = "??";
                text[5].text = "���� ��Ȳ�̿����� ���̽��� �̰ܳ����� ���̽��� �ƹ���ó�� ������� ���� ���ƿ��� ������� �η������� �ϰ� �����ֱ�� �����ߴ�.";
            }
            if (GameManager.Instance.Quest[0] > 50)
            {
                text[2].text = "�ƹ��� ����縣�� ���߰� �¾�ϰ� ���� ������ ġ���� ���� ������� ���� ���ƿ��� �ʾҴ�.";
                text[3].text = "��Ӵ� �����ٴ� �� �տ� ������ ���̽��� �ŵּ� ���߿� ���� Ű������ ���۽����� ���� ������ ������.";
                text[4].text = "��Ӵ��� ���� ���Ŀ� Ʈ��츶�� ���� ���� ���ϰ� �Ǿ���.";
                text[5].text = "���� ��Ȳ�̿����� ���̽��� �̰ܳ����� ���̽��� �ƹ���ó�� ������� ���� ���ƿ��� ������� �η������� �ϰ� �����ֱ�� ����ߴ�.";
            }

        }
        if (num == 1)//����
        {
            text[0].text = "���� ��ź";
            text[1].text = "�忣������ ����.";
            text[2].text = "??";
            text[3].text = "??";
            text[4].text = "";
            text[5].text = "";
            if (GameManager.Instance.Quest[3] > 3)
            {
                text[4].text = "�Ƴ��� ���� �Ʊ⸦ �����꿡 ���Ȱ� �����꿡�� ������̸� ���� �Ƴ��� �ڽ��� �������� �˰� ����� �޾Ƽ� ������ ������.";
            }
            if (GameManager.Instance.Quest[0] > 13)
                text[3].text = "�忣�������� �¾�� �ڶ����� ���￡ ���� �η��� ������ ����縣�� �Բ� ���￡ �������� ���ϰ� ������ ���Ҵ�.";
            if (GameManager.Instance.Quest[0] >= 19)
                text[2].text = "���� �� Ǫ���� ����� ��ڻ�� ������ �ְ������ ģ�������� �� �������� �˰� �� ��ڻ��� �������� ��ȥ�ߴ�.";
        }
        if (num == 2)//�������� �Ƶ�
        {
            text[0].text = "����";
            text[1].text = "���������� �Ƶ�.";
            text[2].text = "??";
            text[3].text = "??";
            text[4].text = "";
            text[5].text = "";
            if (GameManager.Instance.Quest[2] >= 3)
            {
                text[3].text = "��� ���� ����� ����� ģ���� �ƴ�. ������ �ƹ����� ���쿡�� ��ȭ���� �� ���ȴ�.";
            }
            if (GameManager.Instance.Quest[0] >= 12)
            {
                text[2].text = "�ƹ������� ��� ���� �������� ���̽��� �Ѹ𵨷� ��Ҵ�.";
            }
        }
        if (num == 3)//����
        {
            text[0].text = "??";
            text[1].text = "??";
            text[2].text = "??";
            text[3].text = "";
            text[4].text = "";
            text[5].text = "";
            if (GameManager.Instance.Quest[1] >= 1)
            {
                text[0].text = "�� ������";
                text[1].text = "���� ��ɲ�";
            }
            if (GameManager.Instance.Quest[1] >= 6)
            {
                text[2].text = "�� Ʈ���� ��ȸ�� ��ȸ��";
            }
        }
        if (num == 4)//�̽õ���
        {
            text[0].text = "??";
            text[1].text = "??";
            text[2].text = "??";
            text[3].text = "??";
            text[4].text = "??";
            text[5].text = "??";
            if (GameManager.Instance.Quest[9] >= 1)
            {
                text[0].text = "�̽õ���";
                text[1].text = "������ ������";
                text[2].text = "���� ���׶�, ����ƽ, ����縣�� �����Ͽ� ģ���� �ø��ɿ� ���￡ �����ؼ� �¸��� �̲�����.";
                text[3].text = "�쿬�� ã�Ƴ� �ϴü����� �� �� �ִ� ���� �� ��翡�� ���������� ������ �� ���� ���ؼ� �� ���� �п��ϰ� �ȴ�.";
                text[4].text = "�����ϴ� ������ �ڽŶ����� �п��� ���� ���� ��å���� �ߵ� �� ��� ���� ������.";
                text[5].text = "�� ������ �����ٰ� �߰��� �������� ������ �԰� �������� ���� ����� ������ ���� ���� �ִ�.";
            }
        }
        if (num == 5)//���ò�
        {
            text[0].text = "??";
            text[1].text = "??";
            text[2].text = "??";
            text[3].text = "??";
            text[4].text = "??";
            text[5].text = "";
            if (GameManager.Instance.Quest[0] >= 15)
            {
                text[0].text = "���°�";
                text[1].text = "���ò�";
                text[2].text = "Ǫ���� ����� ��� ���ȿ��� �¾���� ���� ���ͼ� �忣������ �Դ�.";
                text[3].text = "���ø� �ٽ� �ϰ� �; �����鿡�� ������ ������ ���� ���ķ� �谡 ��� ������� �� ���� ������.";
                text[4].text = "??";
            }
            if (GameManager.Instance.Quest[0] >= 20)
            {
                text[4].text = "������� �ͼ� ������ �ڽ� ������ �׾��ٴ� ���� ���ݴ´�. ������ �ٴٿ��� ������ ��ȥ�� ���� ����Ѵ�.";
            }
        }
        if(num == 6)//��ڻ�
        {
            text[0].text = "??";
            text[1].text = "??";
            text[2].text = "??";
            text[3].text = "??";
            text[4].text = "??";
            text[5].text = "";
            if (GameManager.Instance.Quest[0] >= 19)
            {
                text[0].text = "��ڻ�";
                text[1].text = "�κ�� ������ ����";
                text[2].text = "ƮŸ�� �������� �¾�� ���彺ź�� ������ ���� ������ �������� ���彺ź�� ��ȥ�ߴ�. ";
                text[3].text = "���� ���� ������ ���ֿ� �Ŵ��� ���� ���ؼ� ƮƼ�� ���� ������� �̲��� �κ�� ������ �����ƴ�.";
                text[4].text = "�κ�� ������ ���ؼ� ����ϰ� �ִ� ���̴�.";
            }
        }
        if (num == 7)//�ø�
        {
            text[0].text = "??";
            text[1].text = "??";
            text[2].text = "??";
            text[3].text = "??";
            text[4].text = "";
            text[5].text = "";
            if (GameManager.Instance.Quest[0] >= 19)
            {
                text[0].text = "�ø�";
                text[1].text = "������";
            }
            if (GameManager.Instance.Quest[0] >= 30)
            {
                text[2].text = "�κ�� �������� �¾���� ���� �Ŵ��� �뿡�� �Ҿ���.";
            }
            if (GameManager.Instance.Quest[0] >= 30)
            {
                text[3].text = "?? �Ŵ��� �뿡�� ���ش��ߴ�.";
            }
            if (GameManager.Instance.Quest[0] >= 54)
            {
                text[3].text = "������ ��ɿ� ���ؼ� ���� �巡�ǿ��� ���ش��ߴ�.";
            }
        }
        if (num == 8)//����
        {
            text[0].text = "??";
            text[1].text = "??";
            text[2].text = "??";
            text[3].text = "??";
            text[4].text = "";
            text[5].text = "";
            if (GameManager.Instance.Quest[0] >= 19)
            {
                text[0].text = "�ø�";
                text[1].text = "����";
                text[2].text = "������ ��ü�����δ� ��Ȯ������ �κ������δ� ����Ȯ�ϴ�.";
                text[3].text = "���ۿ��� ���� ĳ���� ��� �˻��ϴϱ� �� ĳ���Ͱ� ���Խ��ϴ�.";
            }
        }
        if (num == 9)//��������
        {
            text[0].text = "??";
            text[1].text = "??";
            text[2].text = "??";
            text[3].text = "??";
            text[4].text = "";
            text[5].text = "";
            if (GameManager.Instance.Quest[0] >= 19)
            {
                text[0].text = "�������";
                text[1].text = "��������";
                text[2].text = "�߿��� ������ ���ؼ� ���� �ణ �Ҹ����� ĳ�����Դϴ�.";
                text[3].text = "";
            }
        }
        if (num == 10)//�ι�Ʈ
        {
            text[0].text = "??";
            text[1].text = "??";
            text[2].text = "??";
            text[3].text = "??";
            text[4].text = "";
            text[5].text = "";
            if (GameManager.Instance.Quest[0] >= 41)
            {
                text[0].text = "�ι�Ʈ";
                text[1].text = "�������";
                text[2].text = "���� ��ڻ�� �������� ��ڻ�� �ٸ��� ���⿡ ���Ҵ�. ���ָ� ���ϱ� ���ؼ� ���Ͽ� ����������.";
                text[3].text = "�̸��� �� �ι�Ʈ��� ��������...";
            }
        }

        if (num == 100)//���� ����
        {
            text1[0].text = "����";
            text1[1].text = "ü�� : 50";
            text1[2].text = "���ݷ� : 10";
            text1[3].text = "��ų ���ݷ� : ����";
            text1[4].text = "��� : 100";
            text1[5].text = "ó�� ���鶧�� �����µ� ���� ���丮���� �־�� �� �� ���Ƽ� ������ ���߰� ���丮�� ������ �Ӹ�Ǿ����ϴ�.";
        }
        if (num == 101)//�Ŵ��� ��
        {
            text1[0].text = "�Ŵ��� ��";
            text1[1].text = "ü�� : 100";
            text1[2].text = "���ݷ� : 30";
            text1[3].text = "��ų���ݷ� : 10(�˼�)";
            text1[4].text = "��� : 100";
            text1[5].text = "ù ��°�� ���� ����. ���� ù �����θ�ŭ ��ų�� �� ������� �ߴµ� �ǽ��� �帧��� ����� ���ϱ� ��ų�� ������ϴ�.";
        }
        if (num == 102)//����
        {
            text1[0].text = "����";
            text1[1].text = "ü�� : 150/1500";
            text1[2].text = "���ݷ� : 100";
            text1[3].text = "��ų ���ݷ� : ����";
            text1[4].text = "��� : ";
            text1[5].text = "ó������ ���� ����Ʈ ����. �÷��̾��� ���� ������ �ѹ濡 �׾ �÷��̾ ���� �絵�� �����Ϸ��� �߽��ϴ�.";
        }
        if (num == 103)//����
        {
            text1[0].text = "�Ŵ��� ����";
            text1[1].text = "ü�� : 200, 100�Ǹ� ���� 3���� ��ȯ��";
            text1[2].text = "���ݷ� : 40";
            text1[3].text = "��ų ���ݷ� : 30(����)";
            text1[4].text = "��� : 200";
            text1[5].text = "��ų�� ���� �������� ���ư��� ��ġ�� ������ ������� �ߴµ� ����ٺ��ϱ� �׳� ������������ �ٲ���ϴ�.";
        }
        if (num == 104)//�������
        {
            text1[0].text = "���� ����";
            text1[1].text = "ü�� : 300*2";
            text1[2].text = "���ݷ� : 40";
            text1[3].text = "��ų ���ݷ� : 30(�˱�)";
            text1[4].text = "��� : 500";
            text1[5].text = "���ݱ����� �����ʹ� �ٸ��� ���ݼӵ��� ������ ����� �������ϵ� ����� �ý��ϴ�.\n������ �ٸ� �������� ����Ϸ��� �ߴµ� ��¼�� ���ϱ� ���븦 �̿��ؼ� ���� ù ��° �����Դϴ�.";
        }
        if (num == 105)//����
        {
            text1[0].text = "���� ����";
            text1[1].text = "ü�� : 500, 250���� ���� ��";
            text1[2].text = "���ݷ� : 50";
            text1[3].text = "��ų ���ݷ� : 50(ȭ����, ����)";
            text1[4].text = "��� : 500";
            text1[5].text = "��� ���� ������� ��ȹ���� �ʾҴµ� �ױ����� ������ �־�� �� �� ���Ƽ� ���ϰ� ��������ϴ�. \n������ �̸��� ������� �� �� �ְ����� ���ǽ� ĳ���͸� ������� �ߴµ� �ǽ��� �帧���� ����� ���ϱ� �� ĳ���Ͱ� ���͹��Ƚ��ϴ�.";
        }
        if (num == 106)//��ġ
        {
            text1[0].text = "��ġ";
            text1[1].text = "ü�� : 1000";
            text1[2].text = "���ݷ� : 60";
            text1[3].text = "��ų ���ݷ� : 60(�����)";
            text1[4].text = "��� : 500";
            text1[5].text = "���л� �� ���� �� ĳ���͸� ��ġ��� �ҷ��� �״�� �����Խ��ϴ�.\n ���� �� ������ ó������ ���븦 �̿��ؼ� ������� �ߴ� �����Դϴ�.";
        }
        if (num == 107)//����
        {
            text1[0].text = "������ ����";
            text1[1].text = "ü�� : 2000";
            text1[2].text = "���ݷ� : 100";
            text1[3].text = "��ų ���ݷ� : ����";
            text1[4].text = "��� : 0";
            text1[5].text = "1�� ������ ��� ������ �����ߴ� ����. ������ ������ �����꿡 ��� �������� ������ ���� ������ �� ���� ��ٸ��� �־���.\n" +
                "������ ���� ������ó�� �����̰� ������ٰ� ���� ������ ���� �� ���Ƽ� �߾ӿ� ������Ű�� ���ʿ� ������� �߰��߽��ϴ�.";
        }
        if (num == 108)//�̽õ���
        {
            text1[0].text = "�̽õ���";
            text1[1].text = "ü�� : 10000*2";
            text1[2].text = "���ݷ� : 500";
            text1[3].text = "��ų ���ݷ� : 500";
            text1[4].text = "��� : 0";
            text1[5].text = "�ڽ��� ������ �п����״ٴ� ��å���� ���� �����鼭 �ø��ɿ��� �������� ���ָ� ã�Ƽ� ������ �Ŀ� �ݵ�� ���ƿ��ڴٰ� ����ߴ�.\n" +
                "������ �������� ���ָ� ���� �Ŀ� ���ʿ� ������ ���ֿ� �ɷ��� ���Ĺ��� �ٶ��� �ø��ɿ��� ����� �ذ� ������ �ִ�..\n" +
                "�������� ������ ĳ�����Դϴ�. ���� �� ���� �ƽôٽ��� ���� �̸��� ���������� �ø��ɶ� ���̰� ������ �ٲ�鼭 �̽õ����� �ٲ���ϴ�.";
        }
        if (num == 109)//����
        {
            text1[0].text = "���� �޸�ȣ�� ����";
            text1[1].text = "ü�� : 2000";
            text1[2].text = "���ݷ� : 100";
            text1[3].text = "��ų ���ݷ� : ����";
            text1[4].text = "��� : 1000";
            text1[5].text = "�������ڸ� ���� �ֽ��ϴ�. ������ ���ǽ� �������� �����ι� �߿��� ���Ḧ �Ұ� �Ǵ��� �� ĳ���͸� ���� �״�� ���ΰ����� ������ �ý��ϴ�.\n" +
                "���� �������� ĳ������� ������ ��� ���ǽ��� �谡 �� �� �̸��� �޸��� �����Խ��ϴ�.";
        }
        if (num == 110)//��
        {
            text1[0].text = "�Ŵ� ��";
            text1[1].text = "ü�� : 1000";
            text1[2].text = "���ݷ� : 150";
            text1[3].text = "��ų ���ݷ� : 150";
            text1[4].text = "��� : 700";
            text1[5].text = "���� �����θ� ������ ���� �����Դϴ�.\n" +
                "";
        }
        if (num == 111)//������
        {
            text1[0].text = "��� ������";
            text1[1].text = "ü�� : 1500";
            text1[2].text = "���ݷ� : 100";
            text1[3].text = "��ų ���ݷ� : 150";
            text1[4].text = "��� : 800";
            text1[5].text = "��¥�� �ǽ��� �帧��� ���� �����Դϴ�.\n" +
                "ó������ ū ���������� �ҷ��ٰ� �񷽰� ��ġ�� �� ���Ƽ� �۰� ������� ��ų�� ���� ���� �� �׸��ٰ� �ȿ� ���� ������ ������ �� ���Ƽ� ���� �׷� �־����ϴ�.";
        }
        if (num == 112)//��
        {
            text1[0].text = "��";
            text1[1].text = "ü�� : 5000";
            text1[2].text = "���ݷ� : 100";
            text1[3].text = "��ų ���ݷ� : 200";
            text1[4].text = "��� : 1000";
            text1[5].text = "��ġ�� 1������ �������ٸ� ���� 2������ �����Դϴ�.\n" +
                "������ �ٸ� ������� �ٸ��� ó������ ��ȹ�ϰ� �ִ� ������ ��ų��... ���� ���� ���´�� ��������ϴ�.";
        }
        if (num == 113)//��뺴��
        {
            text1[0].text = "��� ����";
            text1[1].text = "ü�� : 10000";
            text1[2].text = "���ݷ� : 100";
            text1[3].text = "��ų ���ݷ� : 100";
            text1[4].text = "��� : 1500";
            text1[5].text = "�� ���ſ� �Ķ� ���� ���� ����ϴ� õ���ΰ� ��� ���� ���� ����ϴ� �������� ���� �븳�ϰ� �ִ� �����Դϴ�.\n" +
                "��� ����� õ������ �������� �����ϱ� ���� �����̰� ��� ���� �ν��ϸ� ���������� �����ؼ� �����ϴ� �̴ϴ�.\n" +
                "���ſ� õ������ �������� �����ϱ� ���ؼ� �뷮���� ��� ���⸦ ���°� �� �� �Ѵ밡 �۵��� ���� ä�� �ִٰ� ��� ���� ���� ���̽��� �����Ѵٴ� ���丰�� ���� ����鼭 ������ �������Դϴ�...\n" +
                "����� ��~���� ���ΰ��� �۾����� ��ٸ� ������ �ߴµ� �� ������ ���� �� �ϳ��� ��￡ ���Ƽ� ����� ���� �׷� �ý��ϴ�.";
        }
        if (num == 114)//������
        {
            text1[0].text = "���� ��";
            text1[1].text = "ü�� : 2000";
            text1[2].text = "���ݷ� : 150";
            text1[3].text = "��ų ���ݷ� : 150";
            text1[4].text = "��� : 800";
            text1[5].text = "������ ���� �˳��� �����Դϴ�.\n" +
                "�ϱ��� �����ð����� ������ �ϴü��� �ִ� ���� ���� �׷Ƚ��ϴ�.";
        }
        if (num == 115)//����
        {
            text1[0].text = "������";
            text1[1].text = "ü�� : 5000";
            text1[2].text = "���ݷ� : 200";
            text1[3].text = "��ų ���ݷ� : 100";
            text1[4].text = "��� : 0";
            text1[5].text = "���� ��Ű��� �ͼ��� �����Դϴ�.\n" +
                "���ֿ� �ɷ����� ���� ���Ѿ� �Ѵٴ� ������ ���Ƽ� ���� ��Ű�� �ҽ��� ������";
        }
        if (num == 116)//����
        {
            text1[0].text = "������ ����ü";
            text1[1].text = "ü�� : 5000";
            text1[2].text = "���ݷ� : 200";
            text1[3].text = "��ų ���ݷ� : 100";
            text1[4].text = "��� : 0";
            text1[5].text = "�� �״�� ���ֵ��� ���� ����ü�Դϴ�.\n" +
                "�� �ϳ��� �⺻���� �����ؼ� 4���� ��ų�� ������ ������� �ߴµ� ���ϰ� ����� ���ϱ� ��ų�� 3���� �ֳ׿�.";
        }
        if (num == 117)//������
        {
            text1[0].text = "�ø���";
            text1[1].text = "ü�� : 5000";
            text1[2].text = "���ݷ� : 0";
            text1[3].text = "��ų ���ݷ� : 100";
            text1[4].text = "��� : 0";
            text1[5].text = "�븶������ ���μ� ���ӿ��� �����ٰ� �쿬�� �̽õ����� ������ ����� ������.\n" +
                "�ο��� �Ⱦ������� �̽õ����� ���￡ �������� �׸� ��Ű�� ���ؼ� ���� �����Ѵ�.\n" +
                "���� ������ ������ ���ͼ� Ȱ���߰� ������ �����ڶ�� ������ ��´�.\n" +
                "���� �Ŀ� ��� ���� �������� �����ϰ� ���¶� �翡 ���Ƽ� �ݵ�� ���ƿ��ڴٴ� �̽õ����� ��ٸ��� �ִ�.";
        }
        if (num == 118)//����
        {
            text1[0].text = "���¶�";
            text1[1].text = "ü�� : 5000*2";
            text1[2].text = "���ݷ� : 100";
            text1[3].text = "��ų ���ݷ� : 100";
            text1[4].text = "��� : 0";
            text1[5].text = "������ ����޴� ���¶��Դϴ�.\n" +
                "����° ������� �� �������� �ö󰡼� �ع�� ���հ� �ο�� �׸��� �����ߴµ� ���� ������ ���� ����� �; ��ŵ�߽��ϴ�.\n" +
                "��Ƽ��� �ʵ��л� �� ���Ϲ������� �޸�����̶�� ��ȭ�� �ôµ� ���������� �ʹ� ���ִ��� ������ ��￡ ���Ƽ� �ű⼭ ���Խ��ϴ�.";
        }
        if (num == 119)//����
        {
            text1[0].text = "����";
            text1[1].text = "ü�� : 5000*4";
            text1[2].text = "���ݷ� : 300";
            text1[3].text = "��ų ���ݷ� : 300~500";
            text1[4].text = "��� : 0";
            text1[5].text = "���������� �ƽþ��Դϴ�.\n" +
                "���� �����ϴ� ĳ������ ǥ���Դϴ�. ���� �޾����� ������� �ؼ� �غ��س��� �پ �γ��� ������ ��ü�� ������ �ֽ��ϴ�.";
        }
        if (num == 120)//���
        {
            text1[0].text = "����縣";
            text1[1].text = "ü�� : 10000";
            text1[2].text = "���ݷ� : 300";
            text1[3].text = "��ų ���ݷ� : 300";
            text1[4].text = "��� : 0";
            text1[5].text = "������ ��� ����縣�Դϴ�..\n" +
                "����縣�� ó������ ���ְ� �����ߴµ� ����� ���ϱ� ���Ǿƴϰ� �̻����� �ι��� �ƴϰ� �ٲ���Ƚ��ϴ�.";
        }
    }
    public void CollectionSellect(int num) //NPC�� boss ����
    {
        if(num == 0)
        {
            GB[1].SetActive(true);
            GB[2].SetActive(false);
            GB[3].SetActive(false);

        }
        if (num == 1)
        {
            GB[1].SetActive(false);
            GB[2].SetActive(true);
            GB[3].SetActive(false);

        }
        if (num == 2)
        {
            GB[1].SetActive(false);
            GB[2].SetActive(false);
            GB[3].SetActive(true);
        }

    }

    public void VillageSellect(float num) //�巡��
    {
        if(position1 != num)
        {
            foreach (GameObject i in NPCButton)
            {
                if(i!=null)
                    i.transform.position = i.transform.position + Vector3.left * (num - position1) * 20;
            }
            position1 = num;
        }
    }
    public void BossSellect(float num) //�巡��
    {
        if (position2 != num)
        {
            foreach (GameObject i in BossButton)
            {
                if (i != null)
                    i.transform.position = i.transform.position + Vector3.left * (num - position2) * 60;
            }
            position2 = num;
        }
    }
    public void StaticSellect(float num) //�巡��
    {
        if (position3 != num)
        {
            foreach (GameObject i in StaticButton)
            {
                if (i != null)
                    i.transform.position = i.transform.position + Vector3.up * (num - position3) * 5;
            }
            position3 = num;
        }
    }


}
