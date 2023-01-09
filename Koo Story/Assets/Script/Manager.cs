using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine; //�ó׸���
using TMPro;

public class Manager : MonoBehaviour
{

    public string PointName;
    public string MapName; //�ε��� �� �̸�
    public PolygonCollider2D[] confiner; //�����̳� ����

    public CinemachineConfiner CMconfiner; //�����̳�

    public GameObject Dungeon; //�����Ŵ���

    public GameObject Player;
    public GameManager gamemanager;
    public int PlayerGold;
    public Text GoldText;

    public GameObject Naration;
    public GameObject NPCChat;
    public Text NarationText;

    public int isNar; //�����̼�������

    public GameObject DieNaration;
    public bool isDie = false;

    public int[] Swordhave; //0:������ 1:�콼�� 2:���� 3:â
    public int[] SwordSale; //����
    public int[] SwordPower; //���ݷ�
    public int[] Armorhave; // 0:�������� 1:�콼����
    public int[] ArmorSale; //����
    public int[] ArmorDefense; //����

    public int[] Skillhave; // 0:�˱⳯���� 1:��Ÿ
    public int[] SkillSale; //����
    public int[] Itemhave; // 0:������Ű 1: ���Ͽ���
    public int[] ItemSale; //����

    public string[] SwordText;
    public string[] ArmorText;
    public string[] SkillText;
    public string[] ItemText;
    public Text Itemtext;
    public Text Inventext;
    public int Itemnum;
    public int Swordnum;
    public int Armornum;

    public Image[] SwordSprite;
    public Image[] ArmorSprite;
    public Image[] SkillSprite;
    public Image[] ItemSprite;

    public Image Black;
    public float Fade; //1�̸� ���̵�ƿ�, -1�̸� ��
    public float Fade2; //�� ��

    public GameObject[] NPC;
    public GameObject[] StartPoint;
    public int[] NPCCount;


    public TextMeshPro text;
    public GameObject quad;

    public CinemachineVirtualCamera Follower;

    public GameObject Pause;
    public bool isPause;

    public GameObject[] InvenObject;

    public string sentence1;

    Player player;
    public bool isNotNaration;
    public bool isNotClick;

    public AudioSource[] audiosource;


    private void Awake()
    {
        NPCCount = new int[10];
        SwordPower[0] = 5;
        SwordText[0] = "������ ���(���ݷ�+5)\n" +
            "�ָ����� ġ�� �ͺ��� ���� �� ������";

        SwordPower[1] = 10;
        SwordText[1] = "������(���ݷ�+10)\n" +
            "���������� �̰� ���̾���";
        SwordSale[1] = 300;

        SwordPower[2] = 20;
        SwordText[2] = "������ ����(���ݷ�+20)\n" +
            "������ ���� ���� �� ������ ����";
        SwordSale[2] = 1000;

        SwordPower[3] = 25;//â
        SwordText[3] = "��������� â(���ݷ�+25)\n" +
            "������ ������� �ǰ� ������ �ִ�";//â

        SwordPower[4] = 50;//�̸����� ����� ��
        SwordText[4] = "�̸����� ����� ��(���ݷ�+50)\n" +
            "�������� ���� ��ÿ� ������ ���̴�";
        SwordSale[4] = 3000;

        SwordPower[5] = 75;
        SwordText[5] = "������ ��(���ݷ�+75)\n" +
            "������ ���ϴ� ������� ��õ";
        SwordSale[5] = 5000;

        SwordPower[6] = 200;
        SwordText[6] = "Ȳ���� ��(���ݷ�+200)\n" +
            "������ ������ ������ �ڿ��� ��õ";
        SwordSale[6] = 30000;

        SwordPower[7] = 100;
        SwordText[7] = "����Ʈ �뿹�� ���� ���� ���(���ݷ�+100)" +
            "";

        SwordPower[8] = 100;//����1
        SwordText[8] = "���� ���� ������ ��(���ݷ�+100)\n" +
            "���� �������� �ʴ´�.";

        SwordPower[9] = 150;//����2
        SwordText[9] = "��ȭ�� ������ ��(���ݷ�+150)\n" +
            "������ ���� ��������.";

        ArmorDefense[0] = 5;
        ArmorText[0] = "�Ǹ�(����+0)";

        ArmorDefense[1] = 10;
        ArmorText[1] = "��������(����+10)\n" +
            "���� �ͺ��� ����";
        ArmorSale[1] = 200;

        ArmorDefense[2] = 20;
        ArmorText[2] = "�콼 ����(����+20)";
        ArmorSale[2] = 500;

        ArmorDefense[3] = 40;
        ArmorText[3] = "�̸����� ����� ����(����+40)\n" +
            "�������� ���� ��ÿ� ������ �����̴�.";
        ArmorSale[3] = 2000;

        ArmorDefense[4] = 50;
        ArmorText[4] = "������ ��(����+50)\n" +
            "������ ���ϴ� ������� ��õ";
        ArmorSale[4] = 4000;

        ArmorDefense[5] = 80;
        ArmorText[5] = "Ʈ���� ���� �ֿ�� ȸ����(����+80)\n" +
            "������ Ʈ���� ���Ϳ��� �����մϴ�.-�� Ʈ���� ������ȸ ȸ�� �� ������";

        ArmorDefense[6] = 90;
        ArmorText[6] = "Ȳ���� ����(����+90)\n" +
            "���� �ڶ��ϰ� ���� ������� ��õ";
        ArmorSale[6] = 20000;

        ArmorDefense[7] = 95;
        ArmorText[7] = "�������� ����(����+95)\n" +
            "������ ��������.";
        ArmorDefense[8] = 0;
        ArmorText[8] = "���� ���� ������ ����(����+0)\n" +
            "���� ���� �������� �ʴ´�.";

        ArmorDefense[9] = 80;
        ArmorText[9] = "���� ���� ������ ����(����+80)\n" +
            "���� ��ġ�� ���� ��������.";

        SkillText[1] = "50�̻��� ����� ���, ��¿� ����ؼ� �������� �ش�. �ִ� ������ : ���ݷ��� 2�� (��� : CŰ)";
        SkillSale[1] = 1000;
        SkillText[2] = "��� 100�� ����Ͽ� 2�ʰ� �������� �� ���ݷ��� 5���� �������� �ش�. (��� : VŰ)";
        SkillSale[2] = 3000;

        ItemText[3] = "����縣�� �������̴�.";
        ItemText[4] = "Ư���� ������ ������ �����̴�.";

        GameManager gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();

        Swordnum = gamemanager.Swordnum; //����ȭ
        Armornum = gamemanager.Armornum;
        PlayerGold = gamemanager.Gold;
        if (PointName != "" && !isNotNaration)
            Naration2(PointName);
        Swordhave = gamemanager.Swordhave;
        Armorhave = gamemanager.Armorhave;
        Skillhave = gamemanager.Skillhave;
        Itemhave = gamemanager.Key;

        if (Player != null)
        {
            player = Player.GetComponent<Player>();
            player.ArmorInven(Armornum);
            player.Defense = ArmorDefense[Armornum];
            player.SwordInven(Swordnum);
            player.Power = SwordPower[Swordnum];
        }

        if (gamemanager.Quest[0] == 11 && PointName == "�忣 ����")
        {
            Player.transform.position = StartPoint[0].transform.position;
            player.alive = 0;
            NPCCount[0] = 1;
            CMRA(4);
        }

        if (gamemanager.Quest[0] == 50 && PointName == "ƮŸ�� ����")
        {
            Player.transform.position = StartPoint[0].transform.position;
            player.alive = 0;
            NPCCount[1] = 1;
            CMRA(4);
        }

        if (gamemanager.Quest[0] == 54 && PointName == "������ ž")
        {
            Player.transform.position = StartPoint[0].transform.position;
            player.alive = 0;
            NPCCount[2] = 1;
        }
        else if (PointName == "������ ž")
        {
            NPC[0].SetActive(false);
        }
        if (PointName == "������ ž1" && gamemanager.BlenderDieCount == 3)
        {
            Player.SetActive(false);
            NPCCount[3] = 1;
            Dungeon.GetComponent<DungeonManager>().FakeInven();
        }
        if (PointName == "������ ž1" && gamemanager.BlenderDieCount == 2)
        {
            Player.SetActive(false);
            NPCCount[4] = 1;
            Dungeon.GetComponent<DungeonManager>().FakeInven();
            NPC[0].GetComponent<Animator>().SetTrigger("200");
            Dungeon.GetComponent<DungeonManager>().FakeArmor1();
            Dungeon.GetComponent<DungeonManager>().FakeSworda();
        }
        if (PointName == "õ���� �� �߽�" && gamemanager.Quest[8] == 0)
        {
            NPCCount[5] = 1;
            player.alive = 0;
        }
        if (PointName == "õ���� �� �߽�" && gamemanager.Quest[8] == 1)
        {
            NPC[0].GetComponent<Animator>().SetTrigger("D1");
            Invoke("anyway", 3);
            player.alive = 0;
        }
    }

    void anyway()
    {
        NPCCount[5] = 100;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//�Ͻ�����
        {
            isPause = !isPause;
            Pause.SetActive(isPause);
            if (isPause)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }

        if(NPCCount[0] > 0)
        {
            GameManager gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();

            if (NPCCount[0] == 1)
            {
                Follower.Follow = NPC[0].transform;
                NPCTalking(0, "���̽�!");
            }
            else if (NPCCount[0] == 2)
                NPCTalking(0, "�λ絵 ���ϰ� ������ �ϸ� ���!");
            else if (NPCCount[0] == 3)
                NPCTalking(0, "��� �ʿ��� �λ��ϱ� ���ؼ� ���ΰž�~");
            else if (NPCCount[0] == 4 && gamemanager.Quest[3] >= 3)
            {
                Follower.Follow = NPC[1].transform;
                NPCTalking(1, "���̽�. �����غ��� ������ �ʿ���\n �����λ縦 ���߱���. ����.\n �������μ� �β����� �������� ���\n ����� ���� ����鿡�Ե� ������ܴ�.\n �� �Ƶ鿡�Ե� �̾��ϱ���."); //����
            }
            else if (NPCCount[0] == 4)
            {
                Follower.Follow = NPC[1].transform;
                NPCTalking(1, "���̽�! ��¼�� �ʰ� ����縣�� �̾ �忣 ������ �ڶ��Ÿ��� �� ���� \n�ְڱ���!");
            }
            else if (NPCCount[0] == 5 && gamemanager.Quest[2] == 3)
            {
                Follower.Follow = NPC[2].transform;
                NPCTalking(2, "����... \n���� ������ ��ó�� ������ �� �ְ���?");//�����Ƶ�
            }
            else if (NPCCount[0] == 5)
            {
                Follower.Follow = NPC[2].transform;
                NPCTalking(2, "... ");
            }
            else if (NPCCount[0] == 6 && gamemanager.Quest[2] == 3)
            {
                Follower.Follow = NPC[3].transform;
                NPCTalking(3, "�� �Ƶ��� ������ٸ�? \n�Ƶ��� �� ��������ܴ�. ����!");//����
            }
            else if (NPCCount[0] == 6)
            {
                Follower.Follow = NPC[3].transform;
                NPCTalking(3, "�̷�... �ʰ� ������ ���ִ� ������\n ȣ��... �ƴ� ���̾��µ� ������\n �ȿ��ڱ���. �ƽ���...");
            }
            else if (NPCCount[0] == 7 )
            {
                Follower.Follow = NPC[4].transform;
                NPCTalking(4, "�� ���п� �� ���� �̷� �� �ְ� �Ǿ���! ���� ����!");//���°�
            }
            else if (NPCCount[0] == 8)
            {
                Follower.Follow = NPC[0].transform;
                NPCTalking(0, "������� ���� �츮�� ���� ���� ����\n ������ ���~");
            }
            else if (NPCCount[0] == 9)
                NPCTalking(0, "�׸���.. ���������� �� ���� �����ϱ� \n���� ������� �� �Ŀ� �� ��.");
            if (NPCCount[0] == 10)
            {
                gamemanager.Quest[0] = 12;
                Fade = 1;
                Invoke("PlayerDie1", 1f);
            }
            if (Input.GetButtonDown("Fire1"))
            {
                NPCCount[0] += 1;
                SoundManager.instance.Click();
            }
        }

        if (NPCCount[1] > 0)
        {
            GameManager gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();

            if (NPCCount[1] == 1)
                NPCTalking(1, "���̽�. ���ְ� ������� �־�. \n������ ����̳�?");
            else if (NPCCount[1] == 2)
                NPCTalking(1, "�ʰ� �� ���̿� �մ��� �Ѻ� ���̾�.");
            else if (NPCCount[1] == 3)
                NPCTalking(0, "���̽�! �������̾�!");
            else if (NPCCount[1] == 4)
                NPCTalking(0, "�� �Գİ�?? ... \n�������� �ݰ����� �ʳ� ����.");
            else if (NPCCount[1] == 5)
                NPCTalking(1, "�̾������� ���̽��� �ʺ��� �Ű� ��� �� �� ���Ƽ� ���̾�.");
            else if (NPCCount[1] == 6)
                NPCTalking(1, "���� �� ����� ������ ���̰� ���ο� \n������ �� �����̰ŵ�.");
            else if (NPCCount[1] == 7)
                NPCTalking(0, "... �ұ��� ������ �����߱���... \n����� �װ� ������ ������� �� �ž�.");
            else if (NPCCount[1] == 8)
                NPCTalking(0, "�̹� ���� �������� ���� �˰� �Ծ�. \n���� �����ָ� �ȵɱ�? \n������ ���� ��Ե� �� ����...");
            else if (NPCCount[1] == 9)
                NPCTalking(1, "������.. �� ���� �ϴ� �� �ƴϰ���? \n���̽�?");
            else if (NPCCount[1] == 10)
                NPCTalking(1, "�� ���¶��� ������ ��Ĵ��ؼ� ������ \n���ΰ��ð� �� �ž�. �װ� ���� �� �ִ� \n����� �ʹۿ� ���� ���̽�!");
            else if (NPCCount[1] == 11)
                NPCTalking(0, "���̽�! ģ������ �ƴ����� � ������ �ʿ� ���� �����μ� ��Ź�Ұ�! \n���� �׸���...");
            else if (NPCCount[1] == 12)
                NPCTalking(1, "������,,,");
            else if (NPCCount[1] == 13)
                NPCTalking(1, "�ʴ� ������ ������ ����� �־�. ����.");
            else if (NPCCount[1] == 14)
                NPCTalking(0, "��� �� �̸���...?");
            else if (NPCCount[1] == 15)
                NPCTalking(1, "�� ��� �� �˰� �־�. ����...");
            else if (NPCCount[1] == 16)
                NPCTalking(1, "�ʰ� ����縣�� ���̶�� �ͱ���!");
            else if (NPCCount[1] == 17)
                NPCTalking(0, "!!!!");
            else if (NPCCount[1] == 11)
                NPCTalking(0, "�װ� ���?");
            else if (NPCCount[1] == 18)
                NPCTalking(1, "���̽�! ���ݱ��� �ʿ� �ڶ�鼭 �ڽ��� ��ü������ ������ ���� �����\n ���� ������ �ƴϰ���?");
            else if (NPCCount[1] == 19)
                NPCTalking(1, "����. ���� ������ ����. �ձ����� ���� \n���¶��� ���������̸� ����� ������ \n���� ����� ¡¡�Ÿ��� �� ���� \n�ּ��̰���.");
            else if (NPCCount[1] == 20)
                NPCTalking(1, "���� ���¶��� ���� ���� ��� ������ \n������? ������ ������ �ٸ����� \n����縣�� �ڽ��� �̾߱⸦?");
            else if (NPCCount[1] == 21)
                NPCTalking(1, "���¶��� ��� ����縣���� ����� \n�־���. �׸��� ������ ���������� \n�ᱹ ����縣�� �̱��� ���߾�.");
            else if (NPCCount[1] == 22)
                NPCTalking(1, "����. ���� �ʿ� �޶�. ���� ��� ���� \n�˰� �־�. �׷��� ���� �ٶ��� \n��� ���̶�� �͵� �˰� ����.");
            else if (NPCCount[1] == 23)
                NPCTalking(1, "���̽�! ���� ������ �ð��̾�... ���߸� �ϰ� ��ٸ���...  �ƴϸ� �ʰ� ���� �� \n�� ����� �����θ� ���� ��...");
            else if (NPCCount[1] == 24)
                NPCTalking(1, "���� ���� ������ ���¶��� ���δٸ� \n������ ǥ�÷� �ʿ��� ���� �˰� �ִ� \n��� ���� �˷��ְھ�.");
            else if (NPCCount[1] == 25)
                NPCTalking(0, "���̽�... ����...");
            else if (NPCCount[1] == 26)
                NPCTalking(1, "...");
            else if (NPCCount[1] == 27)
            {
                NPCTalking(0, "...!");
                PlayerMove();
            }
            else if (NPCCount[1] == 28)
                NPCTalking(0, "���̽�!!");
            else if (NPCCount[1] == 29)
            {
                NPCTalking(1, "...");
                NPC[1].transform.localScale = new Vector2(-1,1);
            }

            if (NPCCount[1] == 30)
            {
                gamemanager.Quest[0] = 51;
                Fade = 1;
                Invoke("PlayerDie1", 1f);
            }
            if (Input.GetButtonDown("Fire1"))
            {
                NPCCount[1] += 1;
                SoundManager.instance.Click();
            }
        }

        if (NPCCount[2] > 0)
        {
            GameManager gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();

            if (NPCCount[2] == 1)
            {
                Dungeon.GetComponent<DungeonManager>().audiosource[0].Play();
                NPCTalking(0, "�Ա���..");
            }
            else if (NPCCount[2] == 2)
                NPCTalking(0, "���Ⱑ ����� �˾�?");
            else if (NPCCount[2] == 3)
                NPCTalking(0, "������ ž�̶�� �Ҹ��� ���̾�. \n���ſ��� �ٴ� �ǳ��� �������� ħ���� �����ϴ� ����ž�̿���.");
            else if (NPCCount[2] == 4)
                NPCTalking(0, "���ſ� �������� ������ �ΰ����� \n�ݶ��� �Ͼ�� �й��� ��������\n �ٴ� �ǳ� �ñ׸� ������� ��������.");
            else if (NPCCount[2] == 5)
                NPCTalking(0, "��ų� �λ��� �Ծ��� ������ ������\n �� �� �����⿡ �ٴٸ� �ǳʷ��� \n�ٸ� ������ ������ �޾ƾ� ����.");
            else if (NPCCount[2] == 6)
                NPCTalking(0, "������ ��հ� ���� �δ�� �̿� ���� ä ���� ������ ������... ���� ���ϴ� \n�������� ����ġ�ٰ� �ᱹ �� ����ž���� ���������.");
            else if (NPCCount[2] == 7)
            {
                NPCTalking(0, "...");
                NPC[0].GetComponent<Animator>().SetTrigger("2");
            }
            else if (NPCCount[2] == 8)
                NPCTalking(0, "���� �� �� �Ѹ��̿���.");
            else if (NPCCount[2] == 9)
                NPCTalking(0, "�������� �Ұ��Ұ� ���� ���������� \n��ũ�θ� �ձ��� ���, \n�ƽ��� 3���� ���� �ƽþƾ�.");
            else if (NPCCount[2] == 10)
                NPCTalking(0, "���� �� �������� �����鿡�� ����� \n���� ������ �־���.");
            else if (NPCCount[2] == 11)
                NPCTalking(0, "������ �ΰ����� ȭ�쿡 ���� ����ִ� ������ �¾Ƽ� �״�� \n������ �������� ���Ҿ�.");
            else if (NPCCount[2] == 12)
                NPCTalking(0, "���� �� ���Ҹ��� ���� �ƹ����� ��� ���ߴ��� �״�� ���ư��� �� ����....");
            else if (NPCCount[2] == 13)
                NPCTalking(0, "���� ��⸦ ǰ�� ä ���� �ٰ����� \n�ΰ����� �������� ����ġ�ٰ�\n �ᱹ ����ž���� �Ծ�.");
            else if (NPCCount[2] == 14)
                NPCTalking(0, "�� ž�� ����⿡�� �츮���� ������ \n�� ���� �־����� �� ���� ������.");
            else if (NPCCount[2] == 15)
                NPCTalking(0, "�ᱹ �츮���� �� ž���� \n������ ������ ���̱�� ��������.");
            else if (NPCCount[2] == 16)
                NPCTalking(0, "�ΰ����� ž���� �ٰ��԰�.... \n�� �״�� �л��� ��������.");
            else if (NPCCount[2] == 17)
                NPCTalking(0, "�׵��� �������� �ö�ͼ��� \n��������... �л��� �̾����� ���� �ٷ� �տ� �ִ� ���� ���̱��� �״� �� ���� \n�� ���ʰ� ������ ���޾���.");
            else if (NPCCount[2] == 18)
                NPCTalking(0, "��� �� ������ ���� ��Ӵϲ��� \n���ƿ��ż� ���� �������.");
            else if (NPCCount[2] == 19)
                NPCTalking(0, "����ġ��� �ƹ����� ���� �����ϰ� \n���� ���Ϸ� ���� �ſ���.");
            else if (NPCCount[2] == 20)
                NPCTalking(0, "���� �⻵�� ��Ӵ��� ǰ �ӿ��� ���� \n�����... ������ �귯�����ͼ� \n��Ӵϲ����� ��� ��Ŵٴ� ���� �� �� �־���.");
            else if (NPCCount[2] == 21)
                NPCTalking(0, "�ñ׸� ����� ���� �����ϰ�... \n�������� �� �� �־���.");
            else if (NPCCount[2] == 22)
                NPCTalking(0, "�귯���� �� ������ �ƴ϶�... \n��Ӵ��� �Ƕ�� ����.");
            else if (NPCCount[2] ==23)
                NPCTalking(0, "��Ӵϲ����� ���� ���ϴ� ��������\n �˿� �� ���¿��� �ž�. ���� ���� \n���ϰڴٴ� �ϳ����� ���� ��� �ſ���.");
            else if (NPCCount[2] ==24)
                NPCTalking(0, "���� �����԰�... ��Ӵϲ����� �״�� \n������ �����̾�. ���� �� �Ȱ� ��� \n��Ӵϸ� ����� 10���� �پ \n�ܿ� �������.");
            else if (NPCCount[2] == 25)
                NPCTalking(0, "�ǻ�� ���δ� ���� ���� �� �̹� ������ �����µ� ������� �� �� �����̶�� \n�ϴ����.");
            else if (NPCCount[2] == 26)
                NPCTalking(0, "���� ���� ���ȴ� �ƹ������� ������ \n���ƿ� �� �Ǹ� ���̿���.");
            else if (NPCCount[2] == 27)
                NPCTalking(0, "�й踦 ������ �ƹ����� �̹� �ΰ��� \n�η����� ������ ������ ���ϴ� ���¿���.");
            else if (NPCCount[2] == 28)
                NPCTalking(0, "���� �� �ΰ���� ��ȭ������ �ΰ� \n�籹�� �ִ� ��������� �𿩼� �ñ׸� ����� ǻ���� ��� ���̿� \n�Ŵ��� �����庮�� ������..");
            else if (NPCCount[2] == 29)
                NPCTalking(0, "������ ���� ������ �庮�� \n������ �ձ��� �����ϴ� �� ������ \n�ΰ��� ���� ���� ���ϰ� ������.");
            else if (NPCCount[2] == 30)
                NPCTalking(0, "�� �����庮 ������ ������ �ΰ��鿡�� ������ ���� ������. ���� �̳����� \n�ƹ����� ��������.");
            else if (NPCCount[2] == 31)
                NPCTalking(0, "������ ���ؼ��� ���� ���� ���� ������ ���� Ű���� �ǰڴٰ� �����ؼ� ������ ���ÿ� �����߾�.");
            else if (NPCCount[2] == 32)
                NPCTalking(0, "������ �����ؼ� ��ħ�� ���� \n�����庮���� ������ ������ ���� ã�� ���� ������ �� �� �� ���ֽ����� ���� \n������.");
            else if (NPCCount[2] == 33)
                NPCTalking(0, "������ ������ ������ �� ���� �޸� \n�� ������ ������� �޶���.");
            else if (NPCCount[2] == 34)
                NPCTalking(0, "��� �� ��� �� �Ѹ� �������� �� ���� ��� �ùε��� ���¶��� �����μ� \n�����ϰ� ����� ������ ��ã�� �ڿ���.");
            else if (NPCCount[2] == 35)
                NPCTalking(0, "�� �ȿ����� ���¶��� �Ƴ��� �Ƶ��� \n���� �ڶ� �������� �ູ�� ������ ������ �־���.");
            else if (NPCCount[2] == 36)
                NPCTalking(0, "���� �����߾�. ���� �̷� ��Ȳ���� \n������ �Ѵٰ� �ص� ���¶��� ������\n �ΰ��鿡�� ������ �̸����� ������ \n���̶��.");
            else if (NPCCount[2] == 37)
                NPCTalking(0, "������ ������ ���ؼ���... \n���¶��� �̸��� �������� ��� ������� �׸� �̿��ϴ� ��Ȳ���� ������� ���ĸ� �����ؾ� �ƾ�.");
            else if (NPCCount[2] == 38)
                NPCTalking(0, "����ϴ� ������... �������� �ٰ��Ծ�.");
            else if (NPCCount[2] == 39)
                NPCTalking(0, "������ �˿� �����ִ�... ������ ����� ���� ���� �ɾ���.");
            else if (NPCCount[2] == 40)
                NPCTalking(0, "�״� �� ������ �а� ���¶��� ������ \n���� �ָ� �� ƴ�� ���� ������ \n�ְڴٰ� �߾�.");
            else if (NPCCount[2] == 41)
                NPCTalking(0, "���� �װ� ���� �̿��Ѵٴ� ���� �˰� \n�־����� ���� �㿡 ���¶��� \n���� ����ϴ� �Ƶ��� ��ġ����.");
            else if (NPCCount[2] == 42)
                NPCTalking(0, "�Ƶ��� ������ �� ���� ������ ������ \n���ư��µ� ������ �����.");
            else if (NPCCount[2] == 43)
                NPCTalking(0, "���� �������� �ø��ɶ�� �����簡 \n���� ������ ���縦 �˾�ä�� �� ���Ͽ� ������ ����� ������ �ߵ����Ѽ� \n���� ���� �̿��� ���縦 ���� ��ȣ���� ���� �ž�.");
            else if (NPCCount[2] == 44)
                NPCTalking(0, "�Դٰ� ������ ���� �ﴭ���� \n���¶��� �����ϴ� ���� ������.");
            else if (NPCCount[2] == 45)
                NPCTalking(0, "������ ū ��ŭ ������ ���ۿ��� ������ ����� �渶���� ����߱� ������ ���� �� ��ó�� �������� �� �� ������.");
            else if (NPCCount[2] == 46)
                NPCTalking(0, "���� �������� ���ϸ� ���� ������ \n������ ���� ���� ���̶� ����߸��� ���ؼ� ���ϵ��� �̿��߾�.");
            else if (NPCCount[2] == 47)
                NPCTalking(0, "������... �� �� �ϳ��� ������� \n�Ŵ� ��ġ��� �θ��� ����ε� ����� \n�츮���󿡼� ������ ��󽴶�� \n�ٴٱ����̾�.");
            else if (NPCCount[2] == 48)
                NPCTalking(0, "������ �ϳ���... �ʰ� ���� ���̾�. \n������ ���̿����� ���� �巡���̶�� \n�Ҹ��� ������ ������.");
            else if (NPCCount[2] == 49)
                NPCTalking(0, "�ణ �����ؼ��� �����庮�� ƴ�� \n���� ���� �������� ���̴� �ΰ����� ��� ���̶�� �����߾�. \n�ùε��� �ӻ����� �𸣴� �ڽ��� �������� �ʴ� ���¶��� �����ϰ� �� �Ŷ�� \n��������.");
            else if (NPCCount[2] == 50)
                NPCTalking(0, "��ħ ������ �渶���� ���ۿ����� \n�����Ǵ� ���ְ� �귯���Ա� ������ \n������� ���� �� ����ó�� ���¶��� \n�̿��ϱ� �����߾�.");
            else if (NPCCount[2] == 51)
                NPCTalking(0, "���� �� �� �������� ���� ���ϱ⸦ \n��ٶ�鼭 �� ��ȹ�� ������ ���� \n������� ã�ƴٳ��.");
            else if (NPCCount[2] == 52)
                NPCTalking(0, "�� ����� �� ��� �� ���¶��� ������ \n������ �θ��� ����縣�� ����ƽ, \n�׸��� �����縦 ������ �� ������ �� \n������ �Ѹ��� �̽õ�������.");
            else if (NPCCount[2] == 53)
                NPCTalking(0, "�ᱹ �̽õ����� ã�� ��������\n ����縣�� ����ƽ�� ����� Ȯ���߾�. �׵鿡�� �� ��ȹ�� ��Ű�� �ʰ� \n��������. �� ����ƽ�� ������� \n��ġæ �� ��������.");
            else if (NPCCount[2] == 54)
                NPCTalking(0, "�³װ� ��� �ִ��������� ���� ������ �ʾƵ� �ǰ���.");
            else if (NPCCount[2] == 55)
            {
                NPC[0].GetComponent<Animator>().SetTrigger("3");
                Dungeon.GetComponent<DungeonManager>().audiosource[0].Stop();
                NPCTalking(0, "�ʴ� ���⼭ �������ϱ�.");
            }
            else if (NPCCount[2] == 56)
                NPCTalking(0, "���� �������� ���� ���� ���� ��ٷȾ�. �Ϻ��� ������ ���ؼ��� ����̶� \n��ٸ� �� �־���.");
            else if (NPCCount[2] == 57)
                NPCTalking(0, "�ٵ� ������ �����. \n���� �� �� ���� ���ȴ� ���¶��� �Ƶ��� �ٴٱ��� ��󽴸� ��� \n���� �ִ� ������ �� �ž�.");
            else if (NPCCount[2] == 58)
                NPCTalking(0, "�װ� �������� �˰���? ���� �ʰ� \n����縣�� ���� �ڶ�� ���� �ѵ��� \n���Ѻþ����� ������ �ȵȴٰ� �Ǵ��ؼ� �Ű澲�� �ʰ� �־���.");
            else if (NPCCount[2] == 59)
                NPCTalking(0, "������... �ʴ� �Ǹ���������. �� �뿡�� ������� ���� ���� ������ ������.");
            else if (NPCCount[2] == 60)
                NPCTalking(0, "���� �ʰ� �ø��̶�� ���̿� ���� �İ� �ִٴ� ���� �˰� ��� ��ȹ�� ������.");
            else if (NPCCount[2] == 61)
                NPCTalking(0, "������... �ʴ� ���� �� ��ȹ��� \n������ ���. �뿡�� ���Ѽ� �ø��� \n���̰� �� ������ ���п� �ʴ� ���� \n���� ������ ��������.");
            else if (NPCCount[2] == 62)
                NPCTalking(0, "���� ����� �� ���ϰ� ���� ���� \n������ �������� �����ɿ� �۽��� �ʴ� ������ ������.");
            else if (NPCCount[2] == 63)
                NPCTalking(0, "���� �ʶ�� ���� ��ȣ���� ����� ��\n ���� ���̶�� �����߾�. ���� ������ \n�ʶ��... �� �ʸ� ��ġ�� �� ì�ܵ� \n������ �߰��� �ʿ������� ���̾�.");
            else if (NPCCount[2] == 64)
            {
                NPCTalking(0, "�������� �� �˰� ���� ������ ����. \n�� ���� �ٷ� �츮 ��Ӵ��� ���� \n�����־��� ���̾�. \n�׶��� ���� �ǹ��� ��������... \n���¶��� ������ �ǹ��ϴ� \n�����̴����?");
            }
            else if (NPCCount[2] == 65)
                NPCTalking(0, "���̽�. �ƴ�... ���� ��¥ �̸��� ���¿�. ���� �ʰ� �����縦 �׿��� ��ȣ���� \n������� ���� ���� ������ �Ϸ��� \n������ �Ƶ鿡�� �״� ���� \n�� ���¶����� ��︰�ٰ� �����߾�.");
            else if (NPCCount[2] == 66)
                NPCTalking(0, "�̹� ���Ϸ� �ձ��� �հ� �պ� �׾��� ���� �� �ʻ��̾�. \n�ʸ� ������ ���� ������ ������ �ձ��� ������� ��ȭ������ \n�����庮�� �������.");
            else if (NPCCount[2] == 67)
            {
                NPCTalking(0, "�ƹ������� ���� �����庮�� \n����� �Ŷ�� ���߾�. \n���μ� ó������ ������ ��Ź���� \n���縦 �����޶�� ����.");
            }
            else if (NPCCount[2] == 68)
                NPCTalking(0, "�����庮�� ������ �� �� ������ ž �տ� ����������� ���ִ� �� ������.");
            else if (NPCCount[2] == 68)
                NPCTalking(0, "���⼭�� ������� �����̰� �ǳ����� \n�ñ׸� ����� �� �� ����. �ֳ��ϸ� \n�����庮�� ����鼭 �ǳ����� \n�� �� ���� ���Ұŵ�.");
            else if (NPCCount[2] == 68)
                NPCTalking(0, "���� ���� ���ϸ� ������ ���� �� ���� \n�Ŷ�� �����߳� ����. �� �ѽ���. \n ���⼭ ���̴� �¾�� �ϴ�, �ٴٰ� ��� �������� �׷��� ��¥��.");
            else if (NPCCount[2] == 68)
                NPCTalking(0, "�ʰ� ������ �庮�� �ν����� \n���� ������� ���̴��ļ� \n�ΰ��鿡�� ������ �� �ž�. \n�� ���� �������� ��� �� �ϼ�����.");
            else if (NPCCount[2] == 69)
                NPCTalking(0, "�׷���... �ۺ��̾�...");




            if (NPCCount[2] == 70)
            {
                text.transform.position = new Vector2(1000, 0);

                NPC[0].GetComponent<Animator>().SetTrigger("4");
                gamemanager.Quest[0] = 55;
                Invoke("DungeonStart", 4f);
                NPCCount[2] = 0;
            }
            if (Input.GetButtonDown("Fire1"))
            {
                NPCCount[2] += 1;
                SoundManager.instance.Click();
            }
        }

        if (NPCCount[3] > 0)
        {
            GameManager gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();

            if (NPCCount[3] == 1)
                NPCTalking(0, "ũ... ���� �� ��Ƽ��.");
            else if (NPCCount[3] == 2)
                NPCTalking(0, "�� �Ѹ����� ����� ������ \n�̷��� �����ϴٴ�");
            else if (NPCCount[3] == 3)
                NPCTalking(0, "�����μ� ��ڳ�. ������");
            else if (NPCCount[3] == 4)
                NPCTalking(0, "�װ� �˾�? \n�������� ���ſ��� ��� �ΰ��̿���.");
            else if (NPCCount[3] == 1)
                NPCTalking(0, "�� �߿� ���� �Ǹ� �޾Ƶ��� ���� \n�ΰ����� �ΰ����� ������ ������ \n������ �� ����.");
            else if (NPCCount[3] == 5)
                NPCTalking(0, "��ҿ� ���� �ΰ��� ū ���̰� ������ \n�� �ȿ� �ִ� ���� �ǿ��� ���� ��� \n�� �ִ°���. �׸��� �����߿����� �ؼҼ��� ���ڸ��� ���� ���� 100% ��� \n�� �־�.");
            else if (NPCCount[3] == 6)
                NPCTalking(0, "�츰 �̰� �ع��Ų�ٰ� �ϴµ� \n���� ���� ���� �ع��ų �� �ִ� ������ ���������δ� �ƹ����ۿ� ����. \n�� ���� �ع��ų ���� ������... ");
            else if (NPCCount[3] == 7)
                NPCTalking(0, "�� ����� �ƹ������Ե� ������ ���� \n����. �׸���...");
            else if (NPCCount[3] == 8)
                NPCTalking(0, "�ʿ��Ե� �������� �����ž�.");
            else if (NPCCount[3] == 9)
            {
                NPCTalking(0, "���¿�! ���� ���� ������ �����״ϱ� \n���� ���̰� ������ Į�� ��� ��!");
                NPC[0].GetComponent<Animator>().SetBool("11", true);
            }
            else if (NPCCount[3] == 10)
                NPCTalking(0, "��Ȳ�� �� ������ �������� �� �ƴϾ�.");
            else if (NPCCount[3] == 11)
                NPCTalking(0, "�� ��...  �����̴� �ž�?");
            else if (NPCCount[3] == 12)
                NPCTalking(0, "�����... \n���ݱ��� ������ ������ ������?");
            else if (NPCCount[3] == 13)
                NPCTalking(0, "�ʸ� �忣������ ���Ȱ�... \n�ø��� ���̰�... ���� ������ ���̰�... \n���� ������ �ƺ��� ���̰� ����.");
            else if (NPCCount[3] == 14)
                NPCTalking(0, "��!  �� ���� ���� ���߱���.");
            else if (NPCCount[3] == 15)
                NPCTalking(0, "���� �ʰ� � �� �忣 ������ \n��ȴٰ� �߾���?");
            else if (NPCCount[3] == 16)
                NPCTalking(0, "�� ����� �ʴ� �ʹ� ���ؼ� \nĿ���� �� ��ȹ�� ������ ��ŭ�� ������ ���� ���� ���̶�� �Ǵ��߾���.");
            else if (NPCCount[3] == 17)
                NPCTalking(0, "������... �� ���� �־��� ����縣�� �� ���ߴ� �޶���.");
            else if (NPCCount[3] == 18)
                NPCTalking(0, "������� ���� �ƹ����� ã�����ؼ� \n������ �����ϰ� �־���.");
            else if (NPCCount[3] == 19)
                NPCTalking(0, "���� ���� ���ϸ� �������� ����縣�� �ڽ��� ��ŭ ���߿� ������ �� ���� \n�ִٰ� �Ǵ��߾�.");
            else if (NPCCount[3] == 20)
                NPCTalking(0, "�׷���... �ٸ� �ʿ� �Ű��� ���� ���� ���� ������ �� ���� ����� �Ѵٰ� \n�Ǵ�����.");
            else if (NPCCount[3] == 21)
                NPCTalking(0, "�ʵ� ���� �𸣰����� ������ ��Ӵϴ� ���۽����� '���'�� �׾���. \n ���ߴ� ����� �ް� �ٽô� ���� ���� \n���߾�.");
            else if (NPCCount[3] == 22)
                NPCTalking(0, "������... �װ� ���� �������?");
            else if (NPCCount[3] == 23)
            {
                NPCTalking(0, "...");
                isNotClick = true;
                Invoke("SetisNotClick3", 4);
                Invoke("SwordAttack", 2);
                NPC[0].GetComponent<Animator>().SetBool("12", true);
                NPCCount[3] += 1;
            }
            else if (NPCCount[3] == 25)
                NPCTalking(0, "�װ� ���� �Ѱ��. \n���� �˿��� ���ǰ� ����.\n�̷� ���� �����δ� ���� ���� �� �� ����.");
            else if (NPCCount[3] == 26)
                NPCTalking(0, "���� ���� ��������... �ʸ� ��������.");
            else if (NPCCount[3] == 27)
                NPCTalking(0, "�ʰ� �ø��� ������ ���� ������� \n�ʰ� ���� ������ ������ �������.");
            else if (NPCCount[3] == 28)
                NPCTalking(0, "�� �ʵ� �˵��� �ʸ� �̿��� �ű� ������.");
            else if (NPCCount[3] == 29)
                NPCTalking(0, "���� ���� �ӿ��� ���� �׶��� ���� ���� \n������ �����ִ� �ž�. \n�׷��� ������ ���ϴ� ����.");
            else if (NPCCount[3] == 30)
                NPCTalking(0, "����� ���� ª�� �ð����� �ʿ� \n�����鼭 ���� ��ſ���. �ʰ� �����ϴ� �� ���Ѻ��� ��̵� �־���.");
            else if (NPCCount[3] == 31)
                NPCTalking(0, "��鼭 �̷��� �̾߱⸦ ���� \n���� ����� �ʰ� ó���̾���. \n���ݱ��� ��� �� �� ȥ�� �߰ŵ�.");
            else if (NPCCount[3] == 32)
                NPCTalking(0, "������...",false);
            else if (NPCCount[3] == 33)
            {
                NPC[0].GetComponent<Animator>().SetBool("13", true);
                isNotClick = true;
                Invoke("SetisNotClick3", 3);
                NPCCount[3] += 1;
                NPCFalse();
                Follower.Follow = NPC[1].transform;
            }
            else if (NPCCount[3] == 35)
                NPCTalking(0, "���� �ʸ� ���� �� �־�.");
            else if (NPCCount[3] == 36)
                NPCTalking(0, "�̰� �ʿ� ���� ���̾�. \n���� ��� �� ������ ��ٷ��Ծ�.");
            else if (NPCCount[3] == 37)
                NPCTalking(0, "�ʿ� �� ������ ������ ���̶�� \n�� �� ����.");
            else if (NPCCount[3] == 38)
                NPCTalking(0, "������... �̾���... \n�ʴ� ���� ���� ģ������.");
            else if (NPCCount[3] == 39)
            {
                if(GameManager.Instance.Armornum == 9)
                {
                    NPCCount[3] = 99;
                    NPC[0].GetComponent<Animator>().SetBool("100", true);
                    isNotClick = true;
                    Invoke("SetisNotClick3", 6);
                    Follower.Follow = NPC[1].transform;
                    NPCFalse();
                }
                else
                {
                    NPC[0].GetComponent<Animator>().SetBool("15", true);
                    NPCCount[3] = 40;
                    isNotClick = true;
                    Invoke("SetisNotClick3", 3);
                }
            }

            else if (NPCCount[3] == 41) NPCTalking(0, "���� �Ķ��� �庮�� ����� �巯�³�. \n�ʰ� �׾���� �庮�� ���� ������ \n���̰� �ᱹ�� �ν����ž�.");
            else if (NPCCount[3] == 42) NPCTalking(0, "�׵��� ������.... \n���� �������� ���Ѻ� �ٰ�. ");
            else if (NPCCount[3] == 43) NPCTalking(0, "�� ��... ģ��.");
            else if (NPCCount[3] == 44)
            {
                NPC[0].GetComponent<Animator>().SetBool("14", true);
                text.transform.position = new Vector2(1000, 0);
                isNotClick = true;
                Invoke("Ending1", 38);
                NPCCount[3] += 1;
                NPCFalse();
                Follower.Follow = NPC[1].transform;
            }

            else if (NPCCount[3] == 100)
                NPCTalking(0, "�� ����!!  �ʴ�!!");
            else if (NPCCount[3] == 101)
                NPCTalking(0, "����...");
            else if (NPCCount[3] == 102)
                NPCTalking(2, "ũũũ... �ƽþ� �ٽ� ��������.");
            else if (NPCCount[3] == 103)
                NPCTalking(2, "�ʿ��� �ٽ� ���� �Ŷ�� ����?");
            else if (NPCCount[3] == 104)
                NPCTalking(0, "�̷�... �ʸ� �������� ���ϴٴ�. \n�� �Ǽ���.");
            else if (NPCCount[3] == 105)
                NPCTalking(2, "ũũũ.. �� ���� ���� �������� \n���� �߸��� �ƴ���.");
            else if (NPCCount[3] == 106)
                NPCTalking(2, "������ �ʿ��� ���¶��� ������ ���� �޶�� ��û���� ��  �ʰ� ���� �̿��� �԰� ���� ���̶� ���� �˰� �־��ܴ�.");
            else if (NPCCount[3] == 107)
                NPCTalking(2, "������ �� ���� ��ȹ�� �־���. \n���¶��� ���� �����ϸ� �ٷ� ��𼱰� ���� �θ��� �ִ� �� ���ʿ��� ���� \n�� ���� ������ ȸ���� �����̿���.");
            else if (NPCCount[3] == 108)
                NPCTalking(2, "��.... ��ȹ�� ������ ��������... \n�� ������ �༮�� �� ������ ������ �� �� ���п� �������� ���� �� ���� \nȸ���� �� �־����ϱ� �������.");
            else if (NPCCount[3] == 109)
                NPCTalking(2, "����ư ƴ�� ���� �ִٰ� ���� \n�� �༮�� ������ �� �ְ� �� �Ŵ�.");
            else if (NPCCount[3] == 110)
                NPCTalking(0, "������... �׷��� �ʴ� ����ó�� ������ \n�ΰ��� ������ �����̾�?");
            else if (NPCCount[3] == 111)
                NPCTalking(2, "�ϴ� �ٴ� �ӿ� ó���� �� ������ �ٽ� \n�����߰���. �׷��� ���ε� �� ������� ����� ���� �� ���ϰ��̾�.");
            else if (NPCCount[3] == 112)
                NPCTalking(2, "����... �ʸ� ���̰� ���� ���̾�.");
            else if (NPCCount[3] == 113)
                NPCTalking(0, "...");
            else if (NPCCount[3] == 114)
                NPCTalking(0, "������ �߸��Ƴ�.");
            else if (NPCCount[3] == 115)
                NPCTalking(0, "�ø��ɶ�� �����簡 �׾��� �� \n���� �� ������ ���� �ʰ� ���¶��� �����ϱ� ���� ���� �� �־���.");
            else if (NPCCount[3] == 116)
                NPCTalking(0, "���� �� �ʰ� ���¶��� �����ϱ� ���� \n������ �ʾҴ��� �˾�?");
            else if (NPCCount[3] == 117)
                NPCTalking(0, "�װ� �ʰ� ���¶��� ���� �����ϴ��� \n������ ���ϱ� �����̾�.");
            else if (NPCCount[3] == 118)
            {
                NPC[0].GetComponent<Animator>().SetBool("101", true);
                text.transform.position = new Vector2(1000, 0);
                isNotClick = true;
                Invoke("SetisNotClick3", 6);
                NPCCount[3] += 1;
                NPCFalse();
                text.transform.position = new Vector2(1000, 0);
            }
            else if (NPCCount[3] == 120)
                NPCTalking(2, "�ع��ΰ�...");
            else if (NPCCount[3] == 121)
                NPCTalking(2, "���� �ƹ����� �� ���� �� ���� �ع��� \n����� ���ߴµ�... ����ϱ���. \n�̰� �����̶���.");
            else if (NPCCount[3] == 122)
                NPCTalking(0, "���� ��� �� ������.");
            else if (NPCCount[3] == 123)
                NPCTalking(2, "ũũũ ���� ���ο� ���簡 ����ڱ�.");
            else if (NPCCount[3] == 124)
            {
                GameManager.Instance.StartPoint = 2;
                GameManager.Instance.BlenderDieCount = 2;
                isNotClick = true;
                NPCCount[3] += 1;
                Fade = 1;
                Invoke("GoToBlender", 1f);
            }




            if (Input.GetButtonDown("Fire1") && !isNotClick)
            {
                NPCCount[3] += 1;
                SoundManager.instance.Click();
            }
        }

        if (NPCCount[4] > 0)
        {
            GameManager gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();

            if (NPCCount[4] == 1)
                NPCTalking(0, "...");
            else if (NPCCount[4] == 2)
                NPCTalking(0, "���� ������̳�...");
            else if (NPCCount[4] == 2)
                NPCTalking(0, "��... �Ͼ���� ���ϰھ�...");
            else if (NPCCount[4] == 3)
                NPCTalking(2, "�ع��̶�� ���� ū ���� ��� ��� \n�Ŵ��� �밡�� �䱸�Ѵ�.");
            else if (NPCCount[4] == 4)
                NPCTalking(2, "�ʴ� ���� �ʹ� ���. \n���� �� ���� �ߵ����� ���ϴ� ����.");
            else if (NPCCount[4] == 5)
                NPCTalking(2, "�����ض� �ҳ࿩. \n���� ��� ���������� \n�ʴ� ���� �Ѱ踦 �̹� �Ѿ���.");
            else if (NPCCount[4] == 6)
                NPCTalking(2, "�����̶� �׺��Ѵٸ� �������� \n�����Ŵ�.");
            else if (NPCCount[4] == 7)
                NPCTalking(2, "���� ȥ�������� �� ������ ������ \n�ٽ� �ٷ���ڴ�.");
            else if (NPCCount[4] == 8)
                NPCTalking(0, "...");
            else if (NPCCount[4] == 9)
                NPCTalking(0, "�� ��ȹ�� �Ϻ��߾�...");
            else if (NPCCount[4] == 10)
                NPCTalking(0, "���⼭ ���� ����...");
            else if (NPCCount[4] == 11)
                NPCTalking(0, "���� ���̾�!!!!");
            else if (NPCCount[4] == 12)
            {
                Follower.Follow = NPC[1].transform;
                NPCFalse();
                isNotClick = true;
                Invoke("SetisNotClick4", 6);
                NPC[0].GetComponent<Animator>().SetBool("201", true);
                NPCCount[4] += 1;
            }
            else if (NPCCount[4] == 14)
                NPCTalking(2, "���ŷ� ������ �Ͼ �ǰ�...");
            else if (NPCCount[4] == 15)
                NPCTalking(2, "������ ������ �ʸ� ���� �� �ۿ� ������.");
            else if (NPCCount[4] == 16)
            {
                if (GameManager.Instance.Swordnum == 9)
                {
                    NPCCount[4] = 100;
                    NPC[0].GetComponent<Animator>().SetBool("210", true);
                }
                else
                {
                    NPC[0].GetComponent<Animator>().SetBool("202", true);
                }
                Follower.Follow = NPC[1].transform;
                NPCFalse();
                isNotClick = true;
                Invoke("SetisNotClick4", 4);
                NPCCount[4] += 1;
            }
            else if (NPCCount[4] == 18)
                NPCTalking(2, "�ۺ��̱���.");
            else if (NPCCount[4] == 19)
                NPCTalking(0, "...");
            else if (NPCCount[4] == 20)
            {
                NPC[0].GetComponent<Animator>().SetBool("203", true);
                Follower.Follow = NPC[1].transform;
                NPCFalse();
                isNotClick = true;
                Invoke("SetisNotClick4", 4);
                NPCCount[4] += 1;
            }
            else if (NPCCount[4] == 22)
                NPCTalking(2, "��! �� ����??");
            else if (NPCCount[4] == 23)
                NPCTalking(0, "...");
            else if (NPCCount[4] == 24)
                NPCTalking(0, "�ʴ� �� ���� �߶�¾�.");
            else if (NPCCount[4] == 25)
                NPCTalking(0, "�׷��鼭 ���� �� �ȿ��� \n�� �ǰ� ��������.");
            else if (NPCCount[4] == 26)
                NPCTalking(0, "�츮�� �ǿ��� ���� ���� ���.\n �׸���... ���� �Ҹ��� �� ���� �޸� \n���� �� �ȿ� �ִ� �� �ǿ��� \n���� ���� ���� ��������.");
            else if (NPCCount[4] == 27)
                NPCTalking(2, "ũ����.... �ȵ�...!");
            else if (NPCCount[4] == 28)
                NPCTalking(0, "�����ִ� ��� ������ ���� �� �ȿ� �ִ� ���� ���� ��Ʈ�� �ž�... \n�̰�... �� ������ �߾��̾�...");
            else if (NPCCount[4] == 29)
                NPCTalking(2, "ũ�ƾƾ�!! ");
            else if (NPCCount[4] == 30)
                NPCTalking(0, "...");
            else if (NPCCount[4] == 31)
            {
                Follower.Follow = NPC[1].transform;
                NPCFalse();
                isNotClick = true;
                //Invoke("SetisNotClick4", 45);
                NPC[0].GetComponent<Animator>().SetBool("204", true);
                NPCCount[4] += 1;
                Invoke("Ending1", 47);
            }

            else if (NPCCount[4] == 102)
                NPCTalking(2, "�̰�... ���� ���� ����������?");
            else if (NPCCount[4] == 103)
                NPCTalking(2, "�и� �Ϻ��ϰ� �����ϰ� �ִ� \n�� �༮�� ���� �������� �ʾ�!");
            else if (NPCCount[4] == 103)
                NPCTalking(0, "���� ���� ����������?");
            else if (NPCCount[4] == 103)
                NPCTalking(2, "���ƾƾƾ�!!!");
            else if (NPCCount[4] == 104)
            {
                Follower.Follow = NPC[1].transform;
                NPCFalse();
                isNotClick = true;
                Invoke("SetisNotClick4", 15);
                NPC[0].GetComponent<Animator>().SetBool("211", true);
                NPCCount[4] += 1;
            }
            else if (NPCCount[4] == 106)
                NPCTalking(0, "...");
            else if (NPCCount[4] == 107)
                NPCTalking(0, "���̽�?");
            else if (NPCCount[4] == 108)
                NPCTalking(0, "�� �±���...");
            else if (NPCCount[4] == 109)
                NPCTalking(0, "�� ��... ������ �������� ������ �˿� \n����縣�� ���� ���� ���� �ű���.");
            else if (NPCCount[4] == 110)
                NPCTalking(0, "�ȿ� �ִ� ����縣�� ���� \n������ ���Ƴ� �� ����.");
            else if (NPCCount[4] == 111)
                NPCTalking(0, "�� �༮�� �츮�� ���������� \n�����ϴ±���...");
            else if (NPCCount[4] == 112)
                NPCTalking(0, "�ʰ� ���� ��� ������ ��Ⱦ��µ�... \n���� ���� ������ �̹����� �ʸ� ���߳�.");
            else if (NPCCount[4] == 113)
            {
                Follower.Follow = NPC[1].transform;
                NPCFalse();
                isNotClick = true;
                Invoke("SetisNotClick4", 2);
                NPC[0].GetComponent<Animator>().SetBool("212", true);
                NPCCount[4] += 1;
            }
            else if (NPCCount[4] == 115)
                NPCTalking(0, "�׷��� ��� �� �ž�?");
            else if (NPCCount[4] == 116)
                NPCTalking(0, "...");
            else if (NPCCount[4] == 117)
                NPCTalking(0, "�ƴ�.");
            else if (NPCCount[4] == 118)
                NPCTalking(0, "�ʿ��� ���Ⱦ�... ");
            else if (NPCCount[4] == 119)
                NPCTalking(0, "���� �����߾�. ���̽�.");
            else if (NPCCount[4] == 120)
                NPCTalking(0, "�λ��� ��ȹ��� �귯������ �ʳ�.");
            else if (NPCCount[4] == 121)
                NPCTalking(0, "���� �ḻ�� �����ߴµ� �̷� �ḻ��\n ��� ���� ���߾�.");
            else if (NPCCount[4] == 122)
            {
                Follower.Follow = NPC[1].transform;
                NPCFalse();
                isNotClick = true;
                NPC[0].GetComponent<Animator>().SetBool("213", true);
                NPCCount[4] += 1;
                Invoke("Ending2", 5);
            }

            if(NPCCount[4]>=106)
                Follower.Follow = NPC[1].transform;

            if (Input.GetButtonDown("Fire1") && !isNotClick)
            {
                NPCCount[4] += 1;
                SoundManager.instance.Click();
            }
        }
        if (NPCCount[5] > 0)
        {
            GameManager gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();

            if (NPCCount[5] == 1)
                NPCTalking(0, "...");
            else if (NPCCount[5] == 2)
                NPCTalking(0, "�ʴ� ������?");
            else if (NPCCount[5] == 3)
                NPCTalking(0, "...");
            else if (NPCCount[5] == 4)
                NPCTalking(0, "�ʵ� �� ���� ������ �ֱ���.");
            else if (NPCCount[5] == 5)
                NPCTalking(0, "...");
            else if (NPCCount[5] == 6)
                NPCTalking(0, "�� �̸��� �����߰���.");
            else if (NPCCount[5] == 7)
            {
                NPCFalse();
                isNotClick = true;
                Invoke("SetisNotClick5", 2);
                NPC[0].GetComponent<Animator>().SetBool("0", true);
                NPCCount[5] += 1;
            }
            else if (NPCCount[5] == 9)
                NPCTalking(0, "�� �̸��� ����縣. \n�ʵ� ���� �𸣰ڱ���.");
            else if (NPCCount[5] == 10)
                NPCTalking(0, "���� ���ſ� ������ �ݶ��� �����Ѽ� \n�¸��߾���.");
            else if (NPCCount[5] == 11)
                NPCTalking(0, "������ �̽õ����� �� ���� ���� �Ķ� \n���� ������ ���鼭 �ж��� ���۵���.");
            else if (NPCCount[5] == 12)
                NPCTalking(0, "�� ���� õ���̶�� �Ҹ��� �ϴü����� �� �� �ִ� ���迴��. \n���� ���¶�, ���¸�, �׸��� �̽õ����� �ø��ɰ� ��� �ϴü����� �ö����.");
            else if (NPCCount[5] == 13)
                NPCTalking(0, "�� ���� �� ���� ������ �����ϱ� ��\n ��� �ΰ��� õ���ΰ� ���������� \n����� ������ ������ ġ���� ���� �� õ���ε��� �����ߴ� �Ŵ��� \n�ΰ����̴�.");
            else if (NPCCount[5] == 14)
                NPCTalking(0, "�ϴü����� ���鼭 �ð����� ������ \n������ ���Ⱑ ���� �־���. \n�Ķ� ���� �̿��ؼ� �׵��� ����ٸ� ���� �ϳ� ������ ���� �ı��� �� �ִ� \n�����̾���.");
            else if (NPCCount[5] == 15)
                NPCTalking(0, "�׸��� �ϴü��� �߽��� �̰����� \n������ ���� �񷯼� �ڻ��� ������ \nõ���ε��� ��ü�� �Բ� ������ \n������ �־���.");
            else if (NPCCount[5] == 16)
                NPCTalking(0, "�������� �ڽŵ��� ��� ������ \n������ ��Ȱ�ߴٸ鼭 ������� �ͽ��� \n�ڽŵ��� ��å�ϴ� ������ �־���. ");
            else if (NPCCount[5] == 17)
                NPCTalking(0, "�׸��� ������ ���뿡 ������ ���� \n�ո��� ������ �ϴü��� ������ �� �ִ� �Ķ� ���� ���� ����� ��� �ڻ��ؼ� �ƹ��� �� ���� ��ġ�� �� �� ���� \n���ڴٰ� ������ �־���.");
            else if (NPCCount[5] == 18)
                NPCTalking(0, "���������� �� ������ ���ٸ� \n���ܵ� �Ķ� ���� ã�Ƽ� ���� �״� \n�ڽŵ�� ���� �Ǽ��� ���� ���� \n�Ķ� ���� ���� ��� �ϴü��� ������� �����־���.");
            else if (NPCCount[5] == 19)
                NPCTalking(0, "���¶��� �ϴü��� ������� �̿��ؼ� \n�������� ������ �ñ׸� ����� ���¿� �����ڰ� �����߰� ���� �ݴ��ߴ�.");
            else if (NPCCount[5] == 20)
                NPCTalking(0, "õ���ε��� ��� ���� �ϴü��� \n�����ڰ� ������ �г��� ���¶��� ���� ���� ���̴���.");
            else if (NPCCount[5] == 21)
                NPCTalking(0, "�츮�� �ο��� ������ ���� ���� \n���¶��� ���� ������� ���� \n�̱��� ���� ���� �˱� ������ \n�� �˰� ���� �Ϻη� ���༭ ���¶��� \n����� ƴ�� �¸��ߴ�.");
            else if (NPCCount[5] == 22)
                NPCTalking(0, "�� �տ� �ִ� �������� �� �� \n�ν��� �� ���̴�. \n���� ���� �̰� ���鼭 ������ ������.");
            else if (NPCCount[5] == 23)
                NPCTalking(0, "���� �й��� ���¶����� �ϴü��� \n������� �߰� �� �ķ� �ٸ� ��������\n  �ٸ� �Ķ� ���� ã�Ƽ� �ϴü��� \n�ͼ� ������� ���� ���� �����Ǽ� \n�� ���� ��Ű�� �־���.");
            else if (NPCCount[5] == 24)
                NPCTalking(0, "���� ������ ����? \n�Ķ� ���� ���� �ְ� �� ���� \n���� ���ΰ�?");
            else if (NPCCount[5] == 25)
                NPCTalking(0, "...");
            else if (NPCCount[5] == 26)
                NPCTalking(0, "�׷� ������ ���� �� ����");
            else if (NPCCount[5] == 27)
                NPCTalking(0, "�˽��� ������ �̸� �˻�� ���⿡\n ������� ������ �˱⸦ ������ �� \n�ִٰ� ����.");
            else if (NPCCount[5] == 28)
            {
                NPCFalse();
                isNotClick = true;
                Invoke("SetisNotClick5", 2);
                NPC[0].GetComponent<Animator>().SetBool("1", true);
                NPCCount[5] += 1;
            }
            else if (NPCCount[5] == 30)
                NPCTalking(0, "���� �װ� ���������� ���̾�.");
            else if (NPCCount[5] == 31)
                NPCTalking(0, "������. \n�� �� �����̶�� �ҷȴ� ���̴�.");
            else if (NPCCount[5] == 32)
            {
                Follower.Follow = NPC[1].transform;
                NPCFalse();
                isNotClick = true;
                NPCCount[5] += 1;
                SceneManager.LoadScene("SkyCatle2");
            }

            else if (NPCCount[5] == 100)
                NPCTalking(0, "...");
            else if (NPCCount[5] == 101)
                NPCTalking(0, "���������...");
            else if (NPCCount[5] == 102)
                NPCTalking(0, "�� ������ �ʰ� ���� ������ \nǪ�� ���� ã�� �ΰ�����\n �ϴü����� �Դ�.");
            else if (NPCCount[5] == 103)
                NPCTalking(0, "���� ����� ������ �ϴü��� ������\n ���ƿ��� �ʰڴٴ� ����� �ִٸ� \n���� �̾ �ϴü��� ��Ű�� \n�� �����̾���.");
            else if (NPCCount[5] == 104)
                NPCTalking(0, "������... ������ �׷��� �ʾҴ�. \n�ϳ����� �ϴü��� ���� �̿��ؼ� ������ ������ �̷� �����ۿ� ������.");
            else if (NPCCount[5] == 105)
                NPCTalking(0, "���� �ΰ��� ���ؼ� �ο����� \n�ΰ��� ���������.... \n���� �׵鿡 ���� �Ǹ��� Ŀ������.");
            else if (NPCCount[5] == 106)
                NPCTalking(0, "���� ���̰� ��踦 ���� ���ͼ� \n���� �ٹ̴� �͵� �˰� \n���� ���� ��� ������������ \n�ΰ����� ���ϴ� �͵� ���Ҵ�.");
            else if (NPCCount[5] == 107)
                NPCTalking(0, "���� �Ѹ��̶� ����� ������ �ϴü��� �����ڴٰ� ���ߴٸ�.... �ΰ��� �ٽ� �ϰ� �׵��� �������� �ٵ�\n ������ �׷��� �ʾҾ�...");
            else if (NPCCount[5] == 108)
                NPCTalking(0, "�̷� �̾߱⸦ �ʹ� ���� �����ŷȳ�...\n������ ���� �ľ��� ����...");
            else if (NPCCount[5] == 109)
            {
                Follower.Follow = NPC[1].transform;
                NPCFalse();
                isNotClick = true;
                NPC[0].GetComponent<Animator>().SetBool("D2", true);
                Invoke("SetisNotClick5", 3);
                NPCCount[5] += 1;
            }
            else if (NPCCount[5] == 111)
                NPCTalking(0, "�� ���� �� ���� �� �ִ�.");
            else if (NPCCount[5] == 112)
                NPCTalking(0, "��� ���� ���ʿ� ������ �ϳ� �� �־���.");
            else if (NPCCount[5] == 113)
                NPCTalking(0, "�װ� �ϴü��� ������ �ı��ϴ� �ֹ�����.");
            else if (NPCCount[5] == 114)
                NPCTalking(0, "õ���ε��� �ڽ��� ���� �ϴü��� \n���� �ı��� ���� ������. \n �ϴü��� �� ��ü�� �η��� ��������.");
            else if (NPCCount[5] == 115)
                NPCTalking(0, "�׵��� �ΰ��� �Ͼ��⿡ ������ ���� \n�ΰ����� ������ �ϴü��� ���� �Ŷ�� \n�����ߴ� �Ŵ�.");
            else if (NPCCount[5] == 116)
                NPCTalking(0, "...");
            else if (NPCCount[5] == 117)
                NPCTalking(0, "���� ��� �� ����� �ֹ��� ���ߴ�.");
            else if (NPCCount[5] == 118)
                NPCTalking(0, "... �������� �� �����Ŵ�.");
            else if (NPCCount[5] == 119)
            {
                NPC[0].GetComponent<Animator>().SetBool("D3", true);
                NPCFalse();
                isNotClick = true;
                NPCCount[5] += 1;
                Invoke("Ending3", 3);
                gamemanager.Key[3] = 1;
                gamemanager.StartPoint = 2;
                gamemanager.Quest[8] = 0;
            }


            Follower.Follow = NPC[1].transform;
            if (Input.GetButtonDown("Fire1") && !isNotClick)
            {
                NPCCount[5] += 1;
                SoundManager.instance.Click();
            }
        }

        if (Fade >0 && Fade2 < 1)
        {
            Fade2 += 0.05f* Fade;
        }
        else if (Fade < 0 && Fade2 > 0)
        {
            Fade2 -= 0.05f * Fade*(-1);
        }
        Black.color = new Color(0, 0, 0, Fade2);
        
        if(GoldText != null)
            GoldText.text = PlayerGold + "   Gold";

        if (Input.GetButtonDown("Fire1") && isNar == 1)
        {
            //NPCChat.SetActive(true);
            Naration.SetActive(false);
            isNar = 0;
        }

        if(isDie == true && Input.GetButtonDown("Fire1"))
        {
            SoundManager.instance.Click();
            Fade = -1;
            Invoke("PlayerDie1", 0.5f);
        }
    }
    void GoToBlender()
    {
        SceneManager.LoadScene("LastTower");
    }
    void Ending1()
    {
        Fade = 0.5f;
        Invoke("GotoEnd",2);
    }
    void Ending2()
    {
        Fade = 0.5f;
        Invoke("GotoEnd2", 2);
    }
    void Ending3()
    {
        Fade = 0.5f;
        Invoke("GotoEnd3", 2);
    }
    void GotoEnd()
    {
        SceneManager.LoadScene("LastTowerE");
    }
    void GotoEnd2()
    {
        Player.transform.position = NPC[2].transform.position;
        Fade = -0.5f;
        NPCCount[4] = 0;
        //NPC[0].SetActive(false);
        NPC[3].SetActive(true);
        Player.SetActive(true);
        Follower.Follow = Player.transform;
        Player.GetComponent<Player>().SwordInven(9);
        Player.GetComponent<Player>().ArmorSprite.sprite = GameManager.Instance.ArmorImage[13];
    }
    void GotoEnd3()
    {
        player.alive = 1;
        SceneManager.LoadScene("Robrah_Village");
    }
    void DungeonStart()
    {
        Dungeon.GetComponent<DungeonManager>().DungeonEnter(5);
    }
    void SwordAttack()
    {
        InvenObject[0].GetComponent<Animator>().SetTrigger("isAttack");
    }
    public void NPCTalking(int num, string sentence, bool isTrans = true)
    {
        if(isTrans)
            Follower.Follow = NPC[num].transform;
        text.text = sentence;
        text.transform.position = NPC[num].GetComponent<NPC>().chatTr.transform.position;
        float x = text.preferredWidth;
        x = (x > 7) ? 7 : x + 0.3f; //ũ�⼳��
        quad.transform.localScale = new Vector2(x, text.preferredHeight + 0.3f);//ũ�⼳��
    }
    public void NPCFalse()
    {
        text.transform.position = new Vector2(1000, 1000);
    }

    public void PlayerDie1()
    {
        SceneManager.LoadScene(MapName);
        isDie = false;
    }
    public void GOTOMAP()
    {
        SceneManager.LoadScene("Map");
    }

    public void Naration1(string sentence,GameObject Chat)
    {
        NPCChat = gameObject;
        //gameObject.SetActive(false);
        NarationText.text = sentence;
        Naration.SetActive(true);
        isNar = 1;
    }

    public void Naration2(string sentence)
    {
        NarationText.text = sentence;
        Naration.SetActive(true);
        Invoke("EndNaration", 3);
    }

    public void Naration3(string sentence)
    {
        sentence1 = sentence;
    }

    public void EndNaration()
    {
        if(sentence1 == "")
        {
            if (isNar == 0)
                Naration.SetActive(false);
        }
        else
        {
            Naration2(sentence1);
            sentence1 = "";
        }

    }
    public void PlayerDie()
    {
        DieNaration.SetActive(true);
        isDie = true;
    }


    public void ItemMouse(int num)
    {
        SoundManager.instance.Click();
        Itemnum = num;
        if (num >= 300)
        {
            int nnum = num - 300;
            Itemtext.text = ItemText[nnum];
        }
        else if (300>num && num >= 200)
        {
            int nnum = num - 200;
            Itemtext.text = SkillText[nnum];
        }
        else if (200>num && num >= 100)
        {
            int nnum = num - 100;
            Itemtext.text = ArmorText[nnum];
        }
        else
            Itemtext.text = SwordText[num];
    }


    public void BuyItem()
    {
        GameManager gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (Itemnum >= 300)
        {
            int num = Itemnum - 300;
            if (PlayerGold >= ItemSale[num] && Itemhave[num] == 0)
            {
                PlayerGold -= ItemSale[num];
                Itemhave[num] = 1;
                gamemanager.Key[num] = 1;
                SoundManager.instance.Click2();
            }
        }
        else if (Itemnum >= 200 && Itemnum<300)
        {
            int num = Itemnum - 200;
            if (PlayerGold >= SkillSale[num] && Skillhave[num] == 0)
            {
                PlayerGold -= SkillSale[num];
                Skillhave[num] = 1;
                gamemanager.Skillhave[num] = 1;
                SoundManager.instance.Click2();
            }
        }
        else if (Itemnum >= 100 && Itemnum<200)
        {
            int num = Itemnum - 100;
            if (PlayerGold >= ArmorSale[num] && Armorhave[num] == 0)
            {
                PlayerGold -= ArmorSale[num];
                Armorhave[num] = 1;
                player.ArmorInven(num);
                player.Defense = ArmorDefense[num];
                Armornum = num;
                gamemanager.Armornum = Armornum;
                SoundManager.instance.Click2();
            }
        }
        else
        {
            if (PlayerGold >= SwordSale[Itemnum] && Swordhave[Itemnum] == 0)
            {
                PlayerGold -= SwordSale[Itemnum];
                Swordhave[Itemnum] = 1;
                player.SwordInven(Itemnum);
                player.Power = SwordPower[Itemnum];
                Swordnum = Itemnum;
                gamemanager.Swordnum = Swordnum;
                SoundManager.instance.Click2();
            }
        }
        gamemanager.Gold = PlayerGold;
            
    }

    public void Inven()
    {
        SoundManager.instance.Click();
        for(int i = 0; i<Swordhave.Length; i++)
        {
            if (Swordhave[i] == 0)
                SwordSprite[i].color = new Color(0, 0, 0);
            else
                SwordSprite[i].color = new Color(1, 1, 1);
        }

        for (int i = 0; i < Skillhave.Length; i++)
        {
            if (Skillhave[i] == 0)
                SkillSprite[i].color = new Color(0, 0, 0);
            else
                SkillSprite[i].color = new Color(1, 1, 1);
        }
        for (int i = 0; i < Armorhave.Length; i++)
        {
            if (Armorhave[i] == 0)
                ArmorSprite[i].color = new Color(0, 0, 0);
            else
                ArmorSprite[i].color = new Color(1, 1, 1);
        }
        for (int i = 0; i < Itemhave.Length; i++)
        {
            if (Itemhave[i] == 0)
                ItemSprite[i].color = new Color(0, 0, 0);
            else
                ItemSprite[i].color = new Color(1, 1, 1);
        }
    }

    public void CheckInven(int num)
    {
        SoundManager.instance.Click();
        Itemnum = num;

        if (num >= 300 && Itemhave[num - 300] == 1)
        {
            int nnum = num - 300;
            Inventext.text = ItemText[nnum];
        }
        else if (num >= 200 && num < 300 && Skillhave[num - 200] == 1)
        {
            int nnum = num - 200;
            Inventext.text = SkillText[nnum];
        }
        else if (num >= 100 && num < 200 && Armorhave[num - 100] == 1)
        {
            int nnum = num - 100;
            Inventext.text = ArmorText[nnum];
        }
        else if(num < 100 && Swordhave[num] == 1)
        {
            Itemnum = num;
            Inventext.text = SwordText[num];
        }
    }

    public void WearInven() //����
    {
        SoundManager.instance.Click();
        GameManager gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (Itemnum >= 100)
        {
            int num = Itemnum - 100;
            if (Armorhave[num] == 1)
            {
                player.ArmorInven(num);
                player.Defense = ArmorDefense[num];
                Armornum = num;
                gamemanager.Armornum = Armornum;
            }
        }
        else
        {
            if ( Swordhave[Itemnum] == 1)
            {
                player.SwordInven(Itemnum);
                player.Power = SwordPower[Itemnum];
                Swordnum = Itemnum;
                gamemanager.Swordnum = Swordnum;
            }
        }
    }
    public void CMRA(int num)
    {
        CMconfiner.m_BoundingShape2D = confiner[num];
        if (Dungeon != null)
            Dungeon.GetComponent<DungeonManager>().DungeonEnter(num);
    }

    public void OpneInven(int num)
    {
        SoundManager.instance.Click();
        for (int i = 0; i< InvenObject.Length; i++)
        {
            if (i == num)
                InvenObject[i].SetActive(true);
            else
                InvenObject[i].SetActive(false);
        }
    }

    void PlayerMove()
    {
        Player.GetComponent<Animator>().SetBool("isWalk", true);
        Player.GetComponent<Rigidbody2D>().velocity = new Vector2(7, Player.GetComponent<Rigidbody2D>().velocity.y);
        Invoke("PlayerStop", 1f);
    }
    void PlayerStop()
    {
        Player.GetComponent<Animator>().SetBool("isWalk", false);
        Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, Player.GetComponent<Rigidbody2D>().velocity.y);
    }
    void SetisNotClick3()
    {
        isNotClick = false;
        NPCCount[3] += 1;
        SoundManager.instance.Click();
    }
    void SetisNotClick4()
    {
        isNotClick = false;
        NPCCount[4] += 1;
        SoundManager.instance.Click();
    }
    void SetisNotClick5()
    {
        isNotClick = false;
        NPCCount[5] += 1;
        SoundManager.instance.Click();
    }
    public void IsidorGo()
    {
        NPC[5].SetActive(false);
        NPC[6].SetActive(true);
        NPC[6].GetComponent<Boss1>().Angry();
        NPC[7].SetActive(true);
        NPC[8].SetActive(true);
        Naration2("�̽õ���");
        audiosource[0].Stop();
        audiosource[1].Play();
    }
}
