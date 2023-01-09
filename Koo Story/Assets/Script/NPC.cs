using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject Inven;
    public bool isInven;
    public GameObject Player; //�÷��̾���ġ
    public string[] sentences;//��ȭ
    public string[] Newsentences;
    public Sprite[] sprites;
    public Transform chatTr; //NPC ��ġ
    public GameObject chatBoxPrefab;
    public int NPCNum; //-1:�κ� 1:����, 2:���� 3:��������
    public GameObject QuestManager;
    public GameObject GameManager;
    public GameObject NPCManager;

    public GameObject Naration;
    public Text NarationText;


    void Awake()
    {
        NPCManager = gameObject;
    }

    void Update()
    {

        if (isInven == true && (Input.GetButtonUp("Horizontal")|| Input.GetButtonDown("Jump")))
        {
            Player player = Player.GetComponent<Player>();
            player.NPCA = 0;
            player.move = 1;
            player.jump = 1;
            isInven = false;
            Inven.SetActive(false);
        }
    }

    public void TalkNPC()
    {


        if (NPCNum == 0) //����Ʈ���� �ΰ�
        {
            GameObject go = Instantiate(chatBoxPrefab); //����
            go.GetComponent<ChatSystem>().Ondialogue(sentences, chatTr);
        }
        else if (NPCNum == -1) //����/�κ�
        {
            Manager manager = GameManager.GetComponent<Manager>();
            Inven.SetActive(true);
            manager.Inven();
            isInven = true;
        }
        else //���ִ��ΰ�
        {
            QuestManager questmanager = QuestManager.GetComponent<QuestManager>();
            Newsentences = questmanager.QuestCheck(NPCNum, NPCManager);
            GameObject go = Instantiate(chatBoxPrefab); //����

            if (Newsentences == null)
                go.GetComponent<ChatSystem>().Ondialogue(sentences, chatTr);
            else
                go.GetComponent<ChatSystem>().Ondialogue(Newsentences, chatTr);
        }


    }

    public void TalkingNPC(string sentence, int i)
    {
        NarationText.text = sentence;
        Naration.SetActive(true);
        Invoke("EndNaration", i);
    }

    public void EndNaration()
    {
            Naration.SetActive(false);

    }
}
