
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class QuestManager : MonoBehaviour
{

    public int[] Quest;//��ȭ 0:���� 1:���� 2:���� 3:�������
    public string[] sentences; //��ȭ��
    public GameObject GameManager;
    public Manager manager;
    GameManager gamemanager;

    public Sprite[] QuestIcon; //0 : !, 1 : ?
    public GameObject[] QuestAlarm; //0:���� 1:���� 2:���� 3:�����Ƶ� 4:���ò� 5:����ƽ�� ���� 6:�������� 7:���� 8:����縣 9:�̽õ���

    public bool isDungeon; //��������


    void Awake()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Quest = gamemanager.Quest; //�Ŵ������� ������

    }


    // �� �� �ȵ�
    void Update()
    {
        if(isDungeon && manager != null && manager.GetComponent<Manager>().PointName == "���� �޸���")
        {

            if (Quest[0] == 0) //����
            {
                QuestAlarm[0].SetActive(true);
                QuestAlarm[0].GetComponent<SpriteRenderer>().sprite = QuestIcon[0];
            }
            else
                QuestAlarm[0].SetActive(false);
            if (Quest[0] == 1) //����
            {
                QuestAlarm[1].SetActive(true);
                QuestAlarm[1].GetComponent<SpriteRenderer>().sprite = QuestIcon[1];
            }
            else
                QuestAlarm[1].SetActive(false);
        }

        
        if (!isDungeon && manager != null && manager.GetComponent<Manager>().PointName == "�忣 ����")
        {
            if (gamemanager.Quest[9] == 2) //�̽õ���
            {
                QuestAlarm[6].SetActive(false);
            }
            if (Quest[0] == 20) //����
            {
                QuestAlarm[5].SetActive(false);
            }

            if (Quest[0] == 0 || Quest[0] == 12) //����
            {
                QuestAlarm[0].SetActive(true);
                QuestAlarm[0].GetComponent<SpriteRenderer>().sprite = QuestIcon[0];
            }//����
            else if (Quest[0] == 4 || Quest[0] == 2 || Quest[0] == 6)
            {
                QuestAlarm[0].SetActive(true);
                QuestAlarm[0].GetComponent<SpriteRenderer>().sprite = QuestIcon[1];
            }
            else
                QuestAlarm[0].SetActive(false);

            if (Quest[0] == 1 || (Quest[3] == 0 && Quest[0] >= 7) || Quest[0] == 13) //����
            {
                QuestAlarm[1].SetActive(true);
                QuestAlarm[1].GetComponent<SpriteRenderer>().sprite = QuestIcon[0];
            }//����
            else if (Quest[3] == 2)
            {
                QuestAlarm[1].SetActive(true);
                QuestAlarm[1].GetComponent<SpriteRenderer>().sprite = QuestIcon[1];
            }
            else
                QuestAlarm[1].SetActive(false);

            if (Quest[1] == 0) //����
            {
                QuestAlarm[2].SetActive(true);
                QuestAlarm[2].GetComponent<SpriteRenderer>().sprite = QuestIcon[0];
            }//����
            else if (Quest[1] == 1 && gamemanager.Chest[5] == true && gamemanager.Chest[1] == true && gamemanager.Chest[2] == true && gamemanager.Chest[3] == true && gamemanager.Chest[4] == true)
            {
                QuestAlarm[2].SetActive(true);
                QuestAlarm[2].GetComponent<SpriteRenderer>().sprite = QuestIcon[1];
            }
            else
                QuestAlarm[2].SetActive(false);

            if (Quest[0] >= 5 && Quest[2] == 0) //�����Ƶ�
            {
                QuestAlarm[3].SetActive(true);
                QuestAlarm[3].GetComponent<SpriteRenderer>().sprite = QuestIcon[0];
            }
            else if (Quest[2] == 2)
            {
                QuestAlarm[3].SetActive(true);
                QuestAlarm[3].GetComponent<SpriteRenderer>().sprite = QuestIcon[1];
            }
            else
                QuestAlarm[3].SetActive(false);

            if (Quest[0] == 7) //���°�
            {
                QuestAlarm[4].SetActive(true);
                QuestAlarm[4].GetComponent<SpriteRenderer>().sprite = QuestIcon[0];
            }
            else if (Quest[0] == 9 || Quest[0] == 14)
            {
                QuestAlarm[4].SetActive(true);
                QuestAlarm[4].GetComponent<SpriteRenderer>().sprite = QuestIcon[1];
            }
            else
                QuestAlarm[4].SetActive(false);
        }
        if (!isDungeon && manager != null && manager.GetComponent<Manager>().PointName == "�κ�� ����")
        {
            if (Quest[1] == 2) //����
            {
                QuestAlarm[15].SetActive(true);
                QuestAlarm[15].GetComponent<SpriteRenderer>().sprite = QuestIcon[0];
            }
            else if (Quest[1] == 3 && gamemanager.Chest[6] == true && gamemanager.Chest[7] == true && gamemanager.Chest[8] == true && gamemanager.Chest[9] == true && gamemanager.Chest[10] == true)
            {
                QuestAlarm[15].SetActive(true);
                QuestAlarm[15].GetComponent<SpriteRenderer>().sprite = QuestIcon[1];
            }
            else
                QuestAlarm[15].SetActive(false);

            if (Quest[0] == 15 || Quest[0] == 19 || Quest[0] == 24 || Quest[0] == 26) //�ø�
            {
                QuestAlarm[10].SetActive(true);
                QuestAlarm[10].GetComponent<SpriteRenderer>().sprite = QuestIcon[0];
            }
            else if (Quest[0] == 22)
            {
                QuestAlarm[10].SetActive(true);
                QuestAlarm[10].GetComponent<SpriteRenderer>().sprite = QuestIcon[1];
            }
            else
                QuestAlarm[10].SetActive(false);

            if (Quest[0] == 17 || Quest[0] == 31 || Quest[0] == 36) //��ڻ�
            {
                QuestAlarm[11].SetActive(true);
                QuestAlarm[11].GetComponent<SpriteRenderer>().sprite = QuestIcon[0];
            }
            else if (Quest[0] == 18 || Quest[7] == 1 || Quest[7] == 3)
            {
                QuestAlarm[11].SetActive(true);
                QuestAlarm[11].GetComponent<SpriteRenderer>().sprite = QuestIcon[1];
            }
            else
                QuestAlarm[11].SetActive(false);

            if (Quest[0] == 16 || Quest[0] ==27 || Quest[0] == 30 || Quest[0] == 37 || Quest[7] == 4) //����
            {
                QuestAlarm[12].SetActive(true);
                QuestAlarm[12].GetComponent<SpriteRenderer>().sprite = QuestIcon[0];
            }
            else
                QuestAlarm[12].SetActive(false);

            if (Quest[0] >= 20 && Quest[4] ==0) //���°�2
            {
                QuestAlarm[13].SetActive(true);
                QuestAlarm[13].GetComponent<SpriteRenderer>().sprite = QuestIcon[0];
            }
            else if (Quest[4] == 2)
            {
                QuestAlarm[13].SetActive(true);
                QuestAlarm[13].GetComponent<SpriteRenderer>().sprite = QuestIcon[1];
            }
            else
                QuestAlarm[13].SetActive(false);

            if (Quest[0] >= 30) //�ø� ��
            {
                QuestAlarm[1].SetActive(false);
                QuestAlarm[0].GetComponent<SpriteRenderer>().sprite = QuestAlarm[0].GetComponent<NPC>().sprites[0];
                QuestAlarm[0].GetComponent<NPC>().sentences[0] = "�ø��� �����.";
                QuestAlarm[0].GetComponent<NPC>().sentences[1] = "������ �Ը�������.";
            }
            if (gamemanager.Key[2] == 1) //����縣
            {
                QuestAlarm[20].SetActive(false);
                QuestAlarm[21].SetActive(true);
            }

            if ((Quest[0] >= 24 && Quest[6] == 0)) //��������
            {
                QuestAlarm[14].SetActive(true);
                QuestAlarm[14].GetComponent<SpriteRenderer>().sprite = QuestIcon[0];
            }
            else if  (Quest[6] == 2 || (gamemanager.Swordhave[8] == 1 && gamemanager.Key[3] == 1 && Quest[6] == 3))
            {
                QuestAlarm[14].SetActive(true);
                QuestAlarm[14].GetComponent<SpriteRenderer>().sprite = QuestIcon[1];
            }
            else
                QuestAlarm[14].SetActive(false);

        }
        if (isDungeon && manager != null && manager.GetComponent<Manager>().PointName == "����")
        {

            if (Quest[0] == 20 || Quest[0] == 21 || Quest[0] == 29 || Quest[0] == 32 || Quest[0] == 35) //����
            {
                QuestAlarm[0].SetActive(true);
                QuestAlarm[0].GetComponent<SpriteRenderer>().sprite = QuestIcon[0];
            }
            else if (Quest[0] == 33 || Quest[0] == 38 || Quest[0] == 39)
            {
                QuestAlarm[0].SetActive(true);
                QuestAlarm[0].GetComponent<SpriteRenderer>().sprite = QuestIcon[1];
            }
            else
                QuestAlarm[0].SetActive(false);

            if (Quest[0] >= 41) //����
            {
                QuestAlarm[1].SetActive(false);
            }
        }
        if (isDungeon && manager != null && manager.GetComponent<Manager>().PointName == "�� �߽ɺ�")
        {

            if (Quest[0] == 20 || Quest[0] == 21 || Quest[0] == 29) //����
            {
                QuestAlarm[0].SetActive(true);
                QuestAlarm[0].GetComponent<SpriteRenderer>().sprite = QuestIcon[0];
            }
            else
                QuestAlarm[0].SetActive(false);

            if (Quest[0] == 28) //���� �ø�
            {
                QuestAlarm[1].SetActive(true);
                QuestAlarm[1].GetComponent<SpriteRenderer>().sprite = QuestIcon[0];
            }
            else
                QuestAlarm[1].SetActive(false);
        }
        if (!isDungeon && manager != null && manager.GetComponent<Manager>().PointName == "ƮŸ�� ����")
        {

            if (Quest[0] == 40 || (Quest[0] >= 43 && Quest[7] == 0 || Quest[7] == 2)) //�ι�Ʈ
            {
                QuestAlarm[0].SetActive(true);
                QuestAlarm[0].GetComponent<SpriteRenderer>().sprite = QuestIcon[0];
            }
            else if (Quest[0] == 41 || Quest[0] == 42 || Quest[7] == 5)
            {
                QuestAlarm[0].SetActive(true);
                QuestAlarm[0].GetComponent<SpriteRenderer>().sprite = QuestIcon[1];
            }
            else
                QuestAlarm[0].SetActive(false);

            if (Quest[0] == 44) //����
            {
                QuestAlarm[1].SetActive(true);
                QuestAlarm[1].GetComponent<SpriteRenderer>().sprite = QuestIcon[0];
            }
            else if (Quest[0] == 46 || Quest[0] == 48 || Quest[0] == 51)
            {
                QuestAlarm[1].SetActive(true);
                QuestAlarm[1].GetComponent<SpriteRenderer>().sprite = QuestIcon[1];
            }
            else
                QuestAlarm[1].SetActive(false);

            if (Quest[1] == 4) //����3
            {
                QuestAlarm[2].SetActive(true);
                QuestAlarm[2].GetComponent<SpriteRenderer>().sprite = QuestIcon[0];
            }
            else if (Quest[1] == 5 && gamemanager.Chest[11] ==true)
            {
                QuestAlarm[2].SetActive(true);
                QuestAlarm[2].GetComponent<SpriteRenderer>().sprite = QuestIcon[1];
            }
            else
                QuestAlarm[2].SetActive(false);
        }
    }

    public string[] QuestCheck(int NPCnum, GameObject NPCManager)
    {
         if (NPCnum == -10) //å���
        {
            if (manager.GetComponent<Manager>().PointName == "�忣 ����")
            {
                if (Quest[3] == 3)
                {
                    System.Array.Resize(ref sentences, 18);
                    sentences[0] = "���� å�� ������� �ϱ����� �ִ�.";
                    sentences[1] = "ù ���� ���ƴ�.";
                    sentences[2] = "�Ƹ� ������ ����ϴ� �Ƴ��� ���̰�  \n�¾ �� ����.";
                    sentences[3] = "�� ���̴� ���� �̾ �忣������       \n������ �� ���̴�.";
                    sentences[4] = "���� ���� ���ƴ�.";
                    sentences[5] = "�������� ���� ������ �����.";
                    sentences[6] = "�Ƶ��� �¾���� �ܸ� ��ġ �Ǹ��� ���ָ� ���� ���� ��Ʋ�� ���� �ƴѰ�.";
                    sentences[7] = "�Ƴ����Դ� �������� ����� ������    \n����� �ȴ�.";
                    sentences[8] = "���� ���� ���ƴ�.";
                    sentences[9] = "������ ���ȴ�. ��������鿡�Դ� ���̰� �¾�ڸ��� �׾��ٰ� �� ��";
                    sentences[10] = "��������� ���� �Ƶ��� ������ �Դ�.";
                    sentences[11] = "�Ƴ��� �ݴ�������... ��¿ �� ������.   \n���� �������� ���ߴ�.";
                    sentences[12] = "�Ƶ��� ��Ƴ��� ���� ���̰� �ƹ�       \n������ ���� ���̴�...";
                    sentences[13] = "... �� �ڷ� �Ѱܼ� ������ ���� ���ƴ�.";
                    sentences[14] = "���õ� ���ó�� �Ƴ��� ���� ������      \n��å�� �������� ��Һ��� �ʰ� �Դ�.";
                    sentences[15] = "�׸��� ���� ������ ���ῡ ��������     \n�ٽ� �Ͼ�� ���ϰ� �ִ�.";
                    sentences[16] = "��ü ���� �ۿ��� ������ �� ���ϱ�...";
                    sentences[17] = " �÷��ǿ� NPC�� ���� ���ο� ������ �߰��Ǿ���.";
                    Quest[3] = 4;
                    return sentences;
                }
                else
                {
                    System.Array.Resize(ref sentences, 17);
                    sentences[0] = "���� å�� ������� �ϱ����� �ִ�.";
                    sentences[1] = "ù ���� ���ƴ�.";
                    sentences[2] = "�Ƹ� ������ ����ϴ� �Ƴ��� ���̰�  \n�¾ �� ����.";
                    sentences[3] = "�� ���̴� ���� �̾ �忣������       \n������ �� ���̴�.";
                    sentences[4] = "���� ���� ���ƴ�.";
                    sentences[5] = "�������� ���� ������ �����.";
                    sentences[6] = "�Ƶ��� �¾���� �ܸ� ��ġ �Ǹ��� ���ָ� ���� ���� ��Ʋ�� ���� �ƴѰ�.";
                    sentences[7] = "�Ƴ����Դ� �������� ����� ������    \n����� �ȴ�.";
                    sentences[8] = "���� ���� ���ƴ�.";
                    sentences[9] = "������ ���ȴ�. ��������鿡�Դ� ���̰� �¾�ڸ��� �׾��ٰ� �� ��";
                    sentences[10] = "��������� ���� �Ƶ��� ������ �Դ�.";
                    sentences[11] = "�Ƴ��� �ݴ�������... ��¿ �� ������.   \n���� �������� ���ߴ�.";
                    sentences[12] = "�Ƶ��� ��Ƴ��� ���� ���̰� �ƹ�       \n������ ���� ���̴�...";
                    sentences[13] = "... �� �ڷ� �Ѱܼ� ������ ���� ���ƴ�.";
                    sentences[14] = "���õ� ���ó�� �Ƴ��� ���� ������      \n��å�� �������� ��Һ��� �ʰ� �Դ�.";
                    sentences[15] = "�׸��� ���� ������ ���ῡ ��������     \n�ٽ� �Ͼ�� ���ϰ� �ִ�.";
                    sentences[16] = "��ü ���� �ۿ��� ������ �� ���ϱ�...";
                    return sentences;
                }
            }
            else if (manager.GetComponent<Manager>().PointName == "����")
            {
                if (Quest[5] == 0)
                {
                    System.Array.Resize(ref sentences, 3);
                    sentences[0] = "���� å�� �������� �� ���� �ִ�.";
                    sentences[1] = "���� ������ �۰� ����ƽ �̶�� \n�����ִ�.";
                    sentences[2] = " �÷����� ����ƽ�� ������ ���ο� ������ �߰��Ǿ���.";
                    Quest[5] = 1;
                    return sentences;
                }
                else
                {
                    System.Array.Resize(ref sentences, 2);
                    sentences[0] = "���� å�� �������� �� ���� �ִ�.";
                    sentences[1] = "���� ������ �۰� ����ƽ �̶�� \n�����ִ�.";
                    return sentences;
                }
            }
            else
                return null;
        }
        else if (NPCnum == 1) //����
        {
            if (Quest[0] == 0) //��������Ʈ�� 0�ϰ��
            {
                System.Array.Resize(ref sentences, 4);
                sentences[0] = "�ȳ�~ ���� ��ħ�̾�";
                sentences[1] = "������ �ʰ� ������ �Ǵ� ���ΰ� ����?";
                sentences[2] = "���� ��� ����Բ� ���� ���Ϸ�";
                sentences[3] = "����Բ��� ���� ������ ���� �� �ְ�\n ����Ͻǰž�";
                Quest[0] = 1;
                return sentences;
            }
            else if (Quest[0] == 1) //��������Ʈ�� 1�ϰ��
            {
                System.Array.Resize(ref sentences, 4);
                sentences[0] = "��?";
                sentences[1] = "������� ���������� ���� ���";
                sentences[2] = "�Ƹ� ���õ� �Ƴ��� �� �տ� ���Ͱ�ǰž�";
                sentences[3] = "����Բ� ���ú��� �����̶�� \n���ϸ� �ɰž�~";
                return sentences;
            }
            else if (Quest[0] == 2)
            {
                System.Array.Resize(ref sentences, 6);
                sentences[0] = "ǥ���� ���� ����� �޾ұ���~";
                sentences[1] = "���������� �����°� ó���̴ϱ�\n �����ؾߵ�";
                sentences[2] = "���� ���� �ɹ���� ��å�ϸ� �����ž�~";
                sentences[3] = "���� ��� �ٲٰ� ������ ���� �ִ�\n �츮 ���� �鷶�� ���� ��~";
                sentences[4] = "������ ESC��ư�� ������ �Ͻ�����\n �޴��� ���� �� �� �־�.";
                sentences[5] = " ���ο� ������ ���ȴ�.[�ɹ�]";
                Quest[0] = 3;
                return sentences;
            }
            else if (Quest[0] == 3)
            {
                System.Array.Resize(ref sentences, 2);
                sentences[0] = "������ ������ ���� ���� ������ \n������ �־�";
                sentences[1] = "�ٽ� �������� �����ؾߵ�~";
                return sentences;
            }
            else if (Quest[0] == 4)
            {
                System.Array.Resize(ref sentences, 7);
                sentences[0] = "��~ ���� �ٳ�Ա���~ \n���������� �����ϱ� ����?";
                sentences[1] = "��尡 ������� ������ \n�������������� �����°� �����ž�";
                sentences[2] = "�ڽ��� ������ ���� ����� ���������� ���� ����. �ٵ� ����� ���δ� ����\n ���밡 ��½ ��������.";
                sentences[3] = "���ڱ� ������� �������� �о����ٴµ�. \n���� ���� �ִ°ɱ�?";
                sentences[4] = " ���ο� ������ ���ȴ�.[������]";
                sentences[5] = "�� ��! ��Ⱑ ���ͼ� \n�׷��� ������������ �Ƶ��� \n����� �ִ°� ����.";
                sentences[6] = "�Ƹ� �ɹ��̶� ���õ� ���ΰ� ������ \n������������ �Ƶ��� ���ų� ��������� ���������� ���ų� ���� �����̾�~";
                Quest[0] = 5;
                return sentences;
            }
            else if (Quest[0] == 5)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "���� ��ҷ� ��������� ����������\n ���� �ǰ� ��������� ���������\n �������� �Ƶ����� ���� ��~";
                return sentences;
            }
            else if (Quest[0] == 6)
            {
                System.Array.Resize(ref sentences, 7);
                sentences[0] = "��! ���� �Ա���~";
                sentences[1] = "Ȥ�� ���� ������ ���µ� ��������\n ����� ������ �Ǹ��ұ� �����ߴµ� \n�� �³� ����~";
                sentences[2] = "������ �Ƹ� �� �̻��� ������ \n�� ���� �ž�.";
                sentences[3] = "�� ������ ������ �ױ��� �־�. ���ſ��� ������� ���� �����µ� ���� ���ķδ� ������ ����� ��� ���ƾ���.";
                sentences[4] = "�ٵ� �ҹ����δ� �������� �꿡 ��ٰ� ���뿡 �з��� �ױ����� �� �迡 �ƿ�\n ������ �ߴٰ� �ϴ����.";
                sentences[5] = "������ �����ؼ� ���� ������� ����� ���ϴµ� �� �ױ��� ���� �ʹٸ�...\n ���� ��� �������� ã�ư��� �� \n�����ž�~";
                sentences[6] = "�׸��� ����Բ��� �ʸ� ã���ô����~";
                Quest[0] = 7;
                return sentences;
            }
            else if (Quest[0] == 7)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "�ױ��� �� ���� �����ؾ� ��~";
                return sentences;
            }
            else if (Quest[0] == 12)
            {
                System.Array.Resize(ref sentences, 11);
                sentences[0] = "���̽�. ������ �ʿ��� ���ؾ� �� �� \n����.";
                sentences[1] = "��� �ʴ� �� �忣 ���� ����� �ƴϾ�.";
                sentences[2] = "�����Ʊ⿴�� �ʰ� ���� �տ� ������\n ���� �� ��Ӵϲ��� �߰��Ͻð�\n Ű��Ű���.";
                sentences[3] = "��Ӵϲ����� �ʸ� ģ�ڽ�ó�� �����߰� �� ���� �ʸ� ģ�������� �����ϰ� �־�.";
                sentences[4] = "�ƹ��������� ���� �¾�� ���� ������ ġ���� ���ؼ� ������� ���� ���ƿ��� \n�����̰� ��Ӵϲ�����... ���� � ��\n ���۽����� ���� ���ư��ż� �������� ���̽�. �ʰ� �־ ���� �� �� �־���..";
                sentences[5] = "�׸�ŭ �ʴ� ���� ������ �����̰�\n �� ���� �־����� �������� ����������\n ����鸶�� ���� �ϴ� ���� ���\n �ٸ��ٰ� ������.";
                sentences[6] = "���� ������ ���������״ϱ�...\n �ʴ� �Ű澲�� ���� ������ ���������� ���ھ�.";
                sentences[7] = "���°� ���������� ���� ���� ����Բ� \n�鸮��. �и� ������ ������ �ֽǰž�.";
                sentences[8] = "�׸��� ����������... ��������.";
                sentences[9] = "�ʴ� ������ �� �����̴ϱ�.";
                sentences[10] = " �÷��ǿ� NPC�� ���� ���ο� ������ �߰��Ǿ���.";
                Quest[0] = 13;
                return sentences;
            }
            else if (Quest[0] >= 13)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "��������.";
                return sentences;
            }
            else
                return null;
        }
        if (NPCnum == 2) //����
        {
            if (Quest[0] == 1) //��������Ʈ�� 1�ϰ��
            {
                System.Array.Resize(ref sentences, 7);
                sentences[0] = "�� �������̱���";
                sentences[1] = "�� �忣�������� �ʸ� ó�� ���������� ������������ ���� ������ �Ǵٴ� \n�������";
                sentences[2] = "�� �� ì������ �Ǵµ�... ";
                sentences[3] = "�Ƴ��� ���ڱ� ������ �����ڷ� \n�� ì������ ���Ѱ� ���Ƽ� �̾��ϱ���";
                sentences[4] = "��¶�� ���� �����̴� ���� ������ \n������ ����!";
                sentences[5] = "�������� �����ϴ� �������� ������ \n�������ϰŶ�";
                sentences[6] = "�� ��! ���߰� �ʿ��� �� ���� �ִٰ� \n�ϴ� ���ư� ����";
                Quest[0] = 2;
                return sentences;
            }
            else if (Quest[0] == 13)
            {
                System.Array.Resize(ref sentences, 18);
                sentences[0] = "���̽�. ���߿��� �밭 �̾߱�� �����?";
                sentences[1] = "����� ���� �߽ɺο� \nƮŸ�� ������ �ִܴ�.";
                sentences[2] = "�׸��� �� �������� ���� ���� \n���� ģ���� �׾Ҵ� \n��ڻ��� ����� �����Դ�.";
                sentences[3] = "�Ƹ� �� �̸��� ��� �� ���� �������ְ� �װ��� ��Ȳ�� �ڼ��� �˷��� �Ŵ�.";
                sentences[4] = "�׸��� �׿��� �� ������ \n�����ָ� ���ڴܴ�.";
                sentences[5] = " ������� ������ �޾Ҵ�.";
                sentences[6] = "�����Դ� ���ﶧ���� \n�ϳ��� �ǹ����� �ִܴ�.";
                sentences[7] = "������ ���õ� ���� ����縣�� ������ ���� �˰�����";
                sentences[8] = "30�� ���� ����縣�� �� �ζ� ������ \n������ ���Ƴ��� Ǫ���� �������\n ���� ��Ը� �ݶ��� �����״ܴ�.";
                sentences[9] = "�� ���� ���󰡰� �;����� ���̵� \n��� �������� ������ ������.";
                sentences[10] = "�׸��� ����縣�� ������� ������ \n������ ������ �¸������μ�";
                sentences[11] = "������ �� ��� �� �Ѹ��� �Ǿ��� \n��������� �������μ� ���� ����鿡�� �߾��� �ް� ����.";
                sentences[12] = "��ÿ� �츮 ���� ���� ������ �� \n����縣�� ������ ����� ���� ������ ��ȯ�� ��ٷȴܴ�.";
                sentences[13] = "������.... �״� ���ƿ��� �ʾҾ�.";
                sentences[14] = "�츮 ������ ��� ��� ���� ������� \n������ ���� Ǫ���� ������� Ÿ���� \n���ƿ��� �ʾұ� ������ Ȯ���� �浵�� �����ܴ�.";
                sentences[15] = "�׷��� ����縣�� �� ���ƿ��� �ʴ��� Ȯ���ؼ� �˷������� ���ڱ���.";
                sentences[16] = "���°����� ���� Ǫ���� ������� �� �� �����Դ�.";
                sentences[17] = " �÷��ǿ� NPC�� ���� ���ο� ������ �߰��Ǿ���.";
                Quest[0] = 14;
                return sentences;
            }
            else if (Quest[0] >= 7 && Quest[3] == 0)
            {
                System.Array.Resize(ref sentences, 11);
                sentences[0] = "�� ���� ���� ���? \n������ŭ ��մ�?";
                sentences[1] = "�װ� ������ �� ���� �� �ȵ����� \n���� �ֹε�� �ٸ��� �������̾ \n���� ���� �� �ٴϴ±���.";
                sentences[2] = "�ֱٿ��� ������� ��� ���������\n ���ٿԴٴµ� �� ��߽�������.";
                sentences[3] = "... �̾������� ��Ź�� ���� �ֱ���.";
                sentences[4] = "�� �Ƴ��� ���� ���� ���� �ֹε����\n �ٸ��� ���� ���� ���� �峪����ܴ�.";
                sentences[5] = "�׷��� ��� �� ���� ���� ������ ������ ���� �̻��ϴ�����.";
                sentences[6] = "���� ������ �״�� ������ \n�Ұ� �������ܴ�.";
                sentences[7] = "�׸��� �ٽ� ������ ������ ���ϰ� \n������ ������ ������...";
                sentences[8] = "���� �Ƴ��� ������ ���� �ٱ������� \n���𰡿� ���谡 ���� ���̶�� \n�����Ѵܴ�.";
                sentences[9] = "�׷��� Ȥ�� ���� �ۿ��� �Ƴ��� ���õ� ���� ���ٸ� �ٸ� ����� ���� �ٷ� \n������ �ͼ� �����ַ�.";
                sentences[10] = " ���ο� ������ ���ȴ�.[������ ����]";
                Quest[3] = 1;
                return sentences;
            }
            else if (Quest[3] == 1)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "������ ��ó���� �Ƴ��� ���õ� ����\n�߰��ϸ� �ٷ� �˷��ٿ�.";
                return sentences;
            }
            else if (Quest[3] == 2)
            {
                System.Array.Resize(ref sentences, 9);
                sentences[0] = "��? ������ ���󿡼� ���� Ż�� ����� �������� �ôٰ�?";
                sentences[1] = "�� ��⸦ �ߴٰ�...?";
                sentences[2] = "...! ����!";
                sentences[3] = "��! ��� �����ߴµ�.";
                sentences[4] = "�� �����... �������� �𸣰ڱ���. \n ������ ������ ����!";
                sentences[5] = " ��Ȳ�� ����� �ʿ��� ���� �ϳ��� ��������.";
                sentences[6] = " ���ο� �������� ȹ���ߴ�.[������ ����]";
                sentences[7] = "�Ƴ��� ������ ���� ������ �𸣰����� ���⼭ �����°� ���ڱ���. \n��¼�� ó������ �� �����̾�������..";
                sentences[8] = " �÷��ǿ� NPC�� ���� ���ο� ������ �߰��Ǿ���.";
                Quest[3] = 3;
                GameObject.Find("GameManager").GetComponent<GameManager>().Key[0] = 1;
                return sentences;
            }
            else if (Quest[3] >= 3 && Quest[0] <= 12)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "����... �� ���̰�... \n�ƴҰž�...";
                return sentences;
            }
            else if (Quest[0] >= 14)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "����縣�� ���ؼ� ���� �˰ԵǸ� \n�� �˷��ٿ�.";
                return sentences;
            }
            else
                return null;
        }
        else if (NPCnum == 3) //��������
        {
            if (GameObject.Find("GameManager").GetComponent<GameManager>().Key[0] == 1) //���踦 ������ ���� ���
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "���� ���ȴ�.";
                NPCManager.GetComponent<SpriteRenderer>().sprite = NPCManager.GetComponent<NPC>().sprites[0];
                NPCManager.layer = 12;
                return sentences;
            }
            else
                return null;
        }
        else if ((NPCnum == 4)) //����
        {
            if (Quest[1] == 0)
            {
                System.Array.Resize(ref sentences, 8);
                sentences[0] = "��... ������ ���� ������ �������ܵ� \n�̰͵� �ƴϾ�...";
                sentences[1] = "��? �ȳ�! ���� ���� ��ɲ� \n�� ��������.";
                sentences[2] = "�������ڿ� ����ִ� �� �������� \n�ǳİ�? ��������!";
                sentences[3] = "�Ƹ��� �忣������ �ִ� ��� \n�������ڸ� ã�� �� ������ ���� ���ϴ� ������ �ȳ��Դ� ���̾�...";
                sentences[4] = "���� ã�� ������ ������ �������ڴ� \n�״�� �����ϱ� �ʰ� �������� ����! \n���� �������ڸ� ���� ���빰�� \n�� �������� �ٸ������ ������ �״ϱ� ������!";
                sentences[5] = "���� �忣�������� ã�� ������\n �� 5���ϱ� �� ã�ƺ���!";
                sentences[6] = "���� 5���� �������ڸ� ��� ã�´ٸ�\n �ʿ��� ������ �ٰ�!";
                sentences[7] = " �÷��ǿ� NPC�� ���� ���ο� ������ �߰��Ǿ���.";
                Quest[1] = 1;
                return sentences;
            }
            if (Quest[1] == 1)
            {
                gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
                if (gamemanager.Chest[5] == true && gamemanager.Chest[1] == true && gamemanager.Chest[2] == true && gamemanager.Chest[3] == true && gamemanager.Chest[4] == true)
                {
                    System.Array.Resize(ref sentences, 5);
                    sentences[0] = "��! �������� �ټ����� ã���ž�??";
                    sentences[1] = "����ѵ�! ��¼�� ������ɲ��� \n����� ��������?";
                    sentences[2] = "�ʸ� �����Ѵٴ� �ǹ̷� ��带 �� \n�����ٰ�.";
                    sentences[3] = " ��带 ȹ���ߴ�.[300���]";
                    sentences[4] = "��¼��... ���߿� ���� ������ �ʿ������� �𸣰ھ�.";
                    GameObject.Find("Player").GetComponent<Player>().PlayerGold += 300;
                    Quest[1] = 2;
                }
                else
                {
                    System.Array.Resize(ref sentences, 1);
                    sentences[0] = "���� �������� �ټ����� �� ��ã�Ҿ�.";
                }
                return sentences;
            }
            if (Quest[1] == 2)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "�����!";
                return sentences;
            }
            else
                return null;
        }
        else if ((NPCnum == 5)) //�����Ƶ�
        {
            if (Quest[2] == 0 && Quest[0] >= 5)
            {
                System.Array.Resize(ref sentences, 11);
                sentences[0] = "...";
                sentences[1] = "�ȳ�. ";
                sentences[2] = "������ �Ǽ� ���� �۱��� �����ٸ�.";
                sentences[3] = "��� �����Դ� ���鿡�� �� ����\n ����� �־�.";
                sentences[4] = "���� ���� ������ �ذ��ϸ� ��������... �׷� �� ������ �ʿ��� ��Ź �� �Ұ�.";
                sentences[5] = "���� ������� ������ �Ƿ� ģ������ ��� ȥ�� ���¾�.";
                sentences[6] = "�׷��ٰ� 5�� �뿡 �쿬�� ���� ������� �� �� �߰�����.";
                sentences[7] = "������� ���÷� �츮 ���� �Ա� ������ ���� �ƹ��� ���� ��������� ���� ��� �̸��� �����ְ� ģ���� �ƾ�.";
                sentences[8] = "�׷��� 6�� ���� ������ �� ������ \n������. ���� ���� �� �ƹ������� ���츦 ���� ��ȭ���� �� �����ž�. ";
                sentences[9] = "�� �ڷ� ���찡 �츮 ���� ���� �ʾƼ� \n�ʹ� ������. Ȥ�� �ɹ� ����� ������ ���� ���찡 �ֳ� ã���� �� �־�??";
                sentences[10] = " ���ο� ������ ���ȴ�.[�ɹ� ����� ��]";
                Quest[2] = 1;
                return sentences;
            }
            else if (Quest[2] == 1)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "��Ź�̾�. �ɹ� ����� ������ ���� \n���츦 ã����.";
                return sentences;
            }
            else if (Quest[2] == 2)
            {
                System.Array.Resize(ref sentences, 8);
                sentences[0] = "...";
                sentences[1] = "�׷�����... ��ȭ�� ������ ���� ���İ��� �־��� ����... �и� ���뿡�� �ع������ �ʿ��� �����Ұž�.";
                sentences[2] = "�� ������... ��¶�� ����... \n�̰� ���� ���� �뵷�ε� �ٰ�.";
                sentences[3] = " 100��带 ȹ���ߴ�.";
                sentences[4] = "��? ���� ������. \n�ٽ� �� ������ �ƽ��� �ѵ� �������� \n������ ���� ������ ������ �ʴٰ�.";
                sentences[5] = "...";
                sentences[6] = "...��½";
                sentences[7] = " �÷��ǿ� NPC�� ���� ���ο� ������ �߰��Ǿ���.";
                Quest[2] = 3;
                GameObject.Find("Player").GetComponent<Player>().PlayerGold += 100;
                return sentences;
            }
            else if (Quest[2] == 3)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "...����";
                return sentences;
            }
            else
                return null;
        }
        else if ((NPCnum == 6)) //�������
        {
            if (Quest[3] == 1)
            {
                System.Array.Resize(ref sentences, 7);
                sentences[0] = "...";
                sentences[1] = "�ʱ��� ���� �� �������  ���δٴ�\n �ΰ���.";
                sentences[2] = "�ϳ� ���� �� ������  ���������.";
                sentences[3] = "���� �ʸ� ���̰� ������ �忣������ ħ���ؼ� ��� ���� ���̴�.";
                sentences[4] = "Ư�� �忣������ ����.. \n���常ŭ�� ����� ���� �ž�.";
                sentences[5] = "����? ������ �˾Ƽ� ���ҷ���.";
                sentences[6] = "������ ���� �༮��.";
                return sentences;
            }
            else
                return null;
        }
        else if ((NPCnum == 7)) //�������2
        {
            if (Quest[3] == 1)
            {
                System.Array.Resize(ref sentences, 13);
                sentences[0] = "...";
                sentences[1] = "���ϱ���.";
                sentences[2] = "���� ������ ���д�.";
                sentences[3] = "...";
                sentences[4] = "�� �����Ϸ��°ųİ�?";
                sentences[5] = "...";
                sentences[6] = "���� �¾�ڸ��� \n�������� ���ؼ� �� �����꿡 ��������.";
                sentences[7] = "�״°� �翬������ ������ \n������� ���� Ű�����.";
                sentences[8] = "����� ���̿����� ���� �翬�� ���� \n�ʾҴ�. ������ ���� ���� Ű���� \n������� �̱�� ��ħ�� ������� ���� \n�ڸ��� �ö���.";
                sentences[9] = "�׸��� ��� �� �쿬�� ��Ӵϸ� ���� \n��ħ�� ������ �˾Ҵ�.";
                sentences[10] = "�׸��� ���� ����� �� �庻�ο��� \n�����ϸ���� �����ߴ�.";
                sentences[11] = "... ���̻� ���� ���� ����... \n�������� �庻���� ���忡�� ����.";
                sentences[12] = " ���ο� ���⸦ ȹ���ߴ�.[��������� â]";
                GameObject.Find("GameManager").GetComponent<GameManager>().Swordhave[3] = 1;
                GameObject.Find("GameManager").GetComponent<GameManager>().Swordnum = 3;
                GameObject.Find("Player").GetComponent<Player>().swordnum = 3;
                GameObject.Find("Player").GetComponent<Player>().SwordInven(3);
                GameObject.Find("Player").GetComponent<Player>().Power = manager.SwordPower[3];

                Quest[3] = 2;
                return sentences;
            }
            else
                return null;
        }
        else if ((NPCnum == 8)) //���ò�
        {
            if (Quest[0] == 7)
            {
                System.Array.Resize(ref sentences, 11);
                sentences[0] = "��~ �����ϰ� �ʹ�~~";
                sentences[1] = "�ȳ�! ���� �� ���� ������ \n���� �ҹ��� �����ϴٰ�!";
                sentences[2] = "��������� �����ߴٸ�!\n �׷��ٸ� ������ ������� �˰� �ְ���?";
                sentences[3] = "�ٷ� ������ ��������� ������ �ױ���!";
                sentences[4] = "���� ��� ���������ؼ� �� ���� ������ ������ ������...";
                sentences[5] = "���ſ��� ���� �ٴٿ��� ������ ���ø� �ϰ� �ٳ�� ������...";
                sentences[6] = "�׷��� ���ε�... ���� �ŷ����� �ʰھ�?";
                sentences[7] = "������ �ž�! �ʰ� �ױ��� ��������\n ���Ƴ��� ������ �踦 ���ش��ָ�";
                sentences[8] = "���� �� �迡 �ʸ� �¿��� ������� \n����������!";
                sentences[9] = "��! �ŷ� �����̴ϱ� ���� �ױ��� \n�����!";
                sentences[10] = " ���ο� ������ ���ȴ�.[�ױ�]";
                Quest[0] = 8;
                return sentences;
            }
            if (Quest[0] == 8)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "�� �ð�����! ���� �ױ���!!";
                return sentences;
            }
            if (Quest[0] == 9)
            {
                System.Array.Resize(ref sentences, 8);
                sentences[0] = "����! �谡 �غ�ƴپ�!";
                sentences[1] = "�ٵ� ���... ���� ������ �ִµ�...";
                sentences[2] = "���������� ����ôµ� ���̾�... \n�³׵鵵 ��� ������ ���ظ� \n�� �����ٰ� �ϳ�.";
                sentences[3] = "�ֳ��ϸ� �츮 ���� ��� ���̿� �Ŵ��� ��ġ�� �ִµ� ���̴� ��� ���\n ħ����Ų�ٰ�...";
                sentences[4] = "�׷��� ������� ���� ���ؼ� ���� �踦 \nŸ�� ��ġ�� ��ƾ� �� �� ����.";
                sentences[5] = "�غ� �Ǹ� ���� �ٴٷ� ���ڰ�! \n�̹����� ���� ���� �ο�ھ�!";
                sentences[6] = "������ ���ò��̶�� �Ŵ��� ��ġ������ ��ƾ���!";
                sentences[7] = " ���ο� ������ ���ȴ�.[�ٴ�]";
                Quest[0] = 10;
                return sentences;
            }
            if (Quest[0] == 10)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "��ġ�� ������ ����!";
                return sentences;
            }
            if (Quest[0] == 14)
            {
                System.Array.Resize(ref sentences, 10);
                sentences[0] = "����! ���� ��� ������ �ذ�Ʊ���.";
                sentences[1] = "���� Ǫ���� ������� �� �� �����ž�. \n�׵��� ������!";
                sentences[2] = "��¥ ������ ���� �����µ�... \n���� �� �̷��� ������� ���� ������\n �ñ��ϳ�?";
                sentences[3] = "��� ���� �������̾�. ";
                sentences[4] = "�츮������ ���� ������̿��µ�\n ���� �װ� �Ⱦ ���� ���԰ŵ�.";
                sentences[5] = "�ٵ� ����� �Ǵ� �� ���̰ڴ��� ����ó�� ����⸦ ��� �;����� ���̾�.";
                sentences[6] = "�ٵ� ���ݱ����� ���ٽ��� �� ���� \n���� ���� ������ ������ �����̶� \n ����� �ִ� �� �����鿡�� ����\n ������� ���� ���� ����\n ����ϰ� �����ž�..";
                sentences[7] = "����ư ���� ����� ���� ���� ���� \n�������� ã�ƺ� �״ϱ� �ð�����\n ���̶� ������ �����!";
                sentences[8] = " ���ο� ������ ���ȴ�.[�κ�� ����]";
                sentences[9] = " �÷��ǿ� NPC�� ���� ���ο� ������ �߰��Ǿ���.";
                Quest[0] = 15;
                return sentences;
            }
            if (Quest[0] > 11)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "����!";
                return sentences;
            }
            else
                return null;
        }
        else if ((NPCnum == 9)) //�������� ���ò�
        {
            if (Quest[0] == 10 && manager.GetComponent<Manager>().PointName == "�ٴ�")
            {
                System.Array.Resize(ref sentences, 6);
                sentences[0] = "��... �踦 Ÿ�� ���ͺ��°� \n�������̶� �� �����±���...";
                sentences[1] = "��? �� ���� ���İ�?";
                sentences[2] = "�׵� �� ����ε� ���� ������� ���� �׷���.";
                sentences[3] = "���� �������ٵ� �Ʒ��� �ִ� �� \n���� ü���̾�.";
                sentences[4] = "��ġ�� �踦 �������ٵ� ���� ü���� \n�ٴڳ��� ���� ��ġ�� ���̸� �Ǵ°���! ����? ���� ���� �帧�� ���� ��ġ�� \n���� �������� �˷��ٰ�!";
                sentences[5] = "�׷��� �����Ѵ�! �и� �ٷ� ������ \n�� �״ϱ� �����϶��!";
                return sentences;
            }
            else if (Quest[4] == 1 && manager.GetComponent<Manager>().PointName == "������ �ٴ�")
            {
                System.Array.Resize(ref sentences,4);
                sentences[0] = "������ �������� �����ϸ� �ٴٿ� �Ȱ��� �ѷ��μ� �ֺ��� �� ���� ���ٰ� �ϳ�.";
                sentences[1] = "���ɼ��� ����ϸ� ���ɼ��� ���� Ÿ����\n ���� ���� ���ɼ� ������ ���� Ÿ���ؾ� �Ѵٴϱ� �����!";
                sentences[2] = "�κ�� �������� ���� ���⸦ �常����? �忣������ ���� �����δ� \n�̱� �� ���� �����!";
                sentences[3] = "�غ� ������... ����!";
                return sentences;
            }
            else
                return null;
        }
        else if ((NPCnum == -2)) //���丮�� ����
        {
            if (Quest[0] == 0)
            {
                System.Array.Resize(ref sentences, 5);
                sentences[0] = "�ȳ� ���̽�~";
                sentences[1] = "�����̸� ���� �ʰ� ������ �Ǵ�\n ���̾�~";
                sentences[2] = "������ �Ǹ� ����Բ��� ������ ���� �� �ְ� ����Ͻǰű�";
                sentences[3] = "������ ���� ���� ������ ���� �Ϳ�\n ����ؼ� �̸� ������ �������� ��.";
                sentences[4] = "���ʿ� �̸� ���͸� ��� �غ��� \n�����ϱ� ��ġ��鼭 ����غ�!";
                Quest[0] = 1;
                return sentences;
            }
            if (Quest[0] == 1)
            {
                System.Array.Resize(ref sentences, 2);
                sentences[0] = "������ z��ư�� ������ �� �� �־�.";
                sentences[1] = "������ ���߽�Ű�� �͸�ŭ \n����� ������ ���ϴ� �� �߿���!";
                return sentences;
            }
            else
                return null;
        }
        else if ((NPCnum == -3)) //���丮�� ����2
        {
            if (Quest[0] == 1)
            {
                System.Array.Resize(ref sentences, 10);
                sentences[0] = "���߾�!";
                sentences[1] = "���͵��� óġ�ϸ� ��带 ���� �� \n�����ϱ� ���� ���� ì�⵵�� ��.";
                sentences[2] = "���δ� ������ �������������� \n�������� ������ �� ����.";
                sentences[3] = "���⸦ �����ؼ� ���ݷ��� ���̰ų� \n���� �����ؼ� ������ \n���� �� �־�.";
                sentences[4] = "���¿� ���� �ۼ�Ʈ������ \n���� ������ ���� �� ����.";
                sentences[5] = "���� ������ 20�̸� 50�� \n�������� 40���� ���̴� ���̾�.\n �˰���?";
                sentences[6] = "���� ���� ü�¹ٿ� ��¹��ε� ������ Ÿ�ݴ��ϸ� ü���� �پ��� \n��ų�� ����ϸ� ����� �پ���.";
                sentences[7] = "���� ����� �� �ִ� ��ų�� �������� \n���� �������������� ������ �� \n�����ž�. �⺻������ ������ ���߽�Ű�� �Ҹ��� ����� ȸ���� �� �־�.";
                sentences[8] = "���� �� ���� �ް����ٰ� �ص� �������. �Ͻ����� �޴����� ������ �����ϸ�\n ���ݱ��� �� ������ �����Ǿ� �����ϱ�. �ް����� ESC�� ������ ��. ";
                sentences[9] = "���������� �� ���Բ��� ���� \n������밡 ���ٰ�. ";
                Quest[0] = 2;
                return sentences;
            }
            if (Quest[0] == 2)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "�տ��� �̸� �غ��Ұ�";
                return sentences;
            }
            else
                return null;
        }
        else if (NPCnum == 10) //������ ��
        {
            if (GameObject.Find("GameManager").GetComponent<GameManager>().Key[1] == 1) //���踦 ������ ���� ���
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "����� ���� ���ٴ��� ���� ���ȴ�.";
                NPCManager.GetComponent<Animator>().SetTrigger("Dooropen");
                NPCManager.layer = 12;
                return sentences;
            }
            else
                return null;
        }
        else if (NPCnum == 21) //����
        {
            if (GameObject.Find("GameManager").GetComponent<GameManager>().Key[4] == 1) //���踦 ������ ���� ���
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "������ ���ٴ��� ��谡 ������� ���� ���ȴ�.";
                NPCManager.GetComponent<Animator>().SetTrigger("Dooropen");
                NPCManager.layer = 0;
                return sentences;
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 44;
                return null;
            }
        }
        else if (NPCnum == 11) //�ø�
        {
            if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 15)
            {
                System.Array.Resize(ref sentences, 5);
                sentences[0] = "�ȳ�! �ʸ� ��ٸ��� �־���.";
                sentences[1] = "��� �˰� ��ٷȳİ�? \n�ֳ��ϸ� ���´Բ��� ������\n ����� ���̶�� ���ϼ̰ŵ�!";
                sentences[2] = "�ʴ� �и� ������ ��� \n����縣�� ���� �ž�! ����?";
                sentences[3] = "���? �ƴ϶��? �̻��ϳ�...";
                sentences[4] = "���´��� ������ �� Ʋ���̳� ����...\n����ư ������ ���� \n���´Բ��� ��ٸ��� ��ǰž�.";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 16;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 16)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "������ ��� ���𰡴Բ� ���� ��";
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 19)
            {
                System.Array.Resize(ref sentences, 6);
                sentences[0] = "��ڻ������ ���� ���� ��� ���ư����� �����?";
                sentences[1] = "�׷��� �Ʊ� ���ò� �������� ������ ã���� �Դٴµ� �ʴ� �� �� �ž�?";
                sentences[2] = "... ������ �Ϸ� �Դٰ�?";
                sentences[3] = "���� �� �� ���� �ϳ�... ���� ���� ������ ������ ������ �׿��޶�� �Ҹ�ġ�°ų� ����������.";
                sentences[4] = "�� �� �ϰ����� �����ٱ��� �꿡�ִ� \n���������� ���ٿͺ��� ���� \n���� �� �����ž�.";
                sentences[5] = " ���ο� ������ ���ȴ�.[����]";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 20;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 20)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "�������� ���� ���� �������� �˰� �� \n�ž�.";
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 22)
            {
                System.Array.Resize(ref sentences, 16);
                sentences[0] = "������ ���� �������� �� �˰���? \n���� ������ ������ �� �ڻ��������!";
                sentences[1] = "...��? �뿡�� ������ ���ߴµ� \n�������� ���ؼ� �������ٰ�???";
                sentences[2] = "�ʵ� ������ ��� �� �Ѹ��� \n����ƽ ���� �����ű���!!!";
                sentences[3] = "��� ������ ���̶� ���� �ۿ� ���� \n������ �� �뿡�� ������ �޾Ҵµ� \n�������� ���� �������κ��� \n�츱 �������!";
                sentences[4] = "�ʹ� ���� ������� ����� ������ \n���ߴµ� ���´Բ� ����ϱ� \n����ƽ ���̷�!";
                sentences[5] = "������ �𸣰����� �������� \n���� �� ���� ������ ����ƽ �Բ���\n ��Ű�� ��� �� Ʋ������!!!";
                sentences[6] = "��? �ƴ϶��? ��.. �ٸ� ����� \n�����ᳪ ������... �� �����ϳ�.";
                sentences[7] = "��¶�� ���� �������� �˾����� \n������ ���� �ȿ��� ��������?";
                sentences[8] = "�ƴ϶��? ��...";
                sentences[9] = "��¿ �� ����. ���´��� ���� \n�ٸ� ��������׵� ����� ���ϸ� �ȵ�!";
                sentences[10] = "����� ���̾�. ���� ���� ����� ���� \n�꿡 ���� �İ� �־�.";
                sentences[11] = "�� ���δ� ���� ���ƴٴϴϱ� ���� �ļ� ����ع����� ����!";
                sentences[12] = "�ٵ� ���̾�. �� �ӿ��� �븸ŭ�� \n�ƴ����� ���ù����� ���͵��� \n���� �ִ����!";
                sentences[13] = "�׷��� ���� �� �̻� ���� ���ϴ� ���¾�. �ʰ� ���͵��� ó���ϸ� ���� ���� ��� �ļ� ���� ����ϰ� �� �ٰ� �˰���?";
                sentences[14] = "�� �̷��� �����ֳİ�? ��...�� ���� \n������ �����ϱ� ��������!\n ����! ������ ������!";
                sentences[15] = " ���ο� ������ ���ȴ�.[����]";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 23;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 23)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "������ ���� ���͸� óġ�ϸ� \n���� �� ���ٰ�.";
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 24)
            {
                System.Array.Resize(ref sentences, 3);
                sentences[0] = "����! ���п� ���� \n��� �� �� �־��µ�...";
                sentences[1] = "�� Ŀ�ٶ� ������ �ϰ� ������ ���͵� ������ �۾��� �ٽ� ������ ���̾�... \n���͵��� óġ����!";
                sentences[2] = " ���ο� ������ ���ȴ�.[�������Ǳ�]";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 25;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 25)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "������ �������� ���̾�!";
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 26)
            {
                System.Array.Resize(ref sentences, 6);
                sentences[0] = "���Ҿ�! ���� �� �߽ɺξ�!";
                sentences[1] = "��� ���� �ʹµ� �߽ɺΰ� \n�̹� �� ���� �ִ����??";
                sentences[2] = "������ �Ŵ��ؼ� ����� �� �� ������ \n������... ��¶�� �츮���״� ���� ������! ";
                sentences[3] = "���͵鵵 �������! ���� �״�� ������ ������ �� �� ����! �׵��� �����߾�!!";
                sentences[4] = "���� ���ο� ������ �Ϸ� ������ �ž�!";
                sentences[5] = "��? ���⼭ ���´Բ��� �츮�� \nó�ٺ��ôµ�?";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 27;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 27)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "����!";
                return sentences;
            }
            else
                return null;
        }
        else if (NPCnum == 12) // ����
        {
            if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 16)
            {
                System.Array.Resize(ref sentences, 6);
                sentences[0] = "�Ա���. ����縣�� ���̿�.";
                sentences[1] = "��?? �ƴ϶��?? �̷�... �� Ʋ�ȱ���...";
                sentences[2] = "�������� ��. ������ ������ �ϵ�\n Ʋ���ϱ� �ͼ������� ������ �ٲٴ� �͵� �������̴ϱ�.";
                sentences[3] = "ƮŸ�� ������ ��ڻ縦 ã�´ٰ�? \n�� ���� �ִ� ����� ��ڻ��.";
                sentences[4] = "�� ƮŸ�� �������� �κ�� ������ \n�Դ����� ���� ����� ��.";
                sentences[5] = "�� ���� ������ �츮�� �ٽ� ���� ���� �����ž�. ���� �� Ʋ������ ������.";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 17;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 17)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "�� ���ʿ� �ִ� ����� ��ڻ����..";
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 27)
            {
                System.Array.Resize(ref sentences, 7);
                sentences[0] = "... �ø��̶� ���� �İ� �ֱ���.";
                sentences[1] = "������ ���� ���� �� ���Ƽ� �ø󿡰Դ� ������ �ʾ����� �ʿ��Դ� ���ؾ߰ڱ���.";
                sentences[2] = "������. �� �̻� �� ������ ���� ����.";
                sentences[3] = "�ȿ� ���𰡰� �־�. \n������ ���� ���� �ž�.";
                sentences[4] = "... ó���� ����縣�� ���̶�� �ؼ� �� ������ ���� ���ϴ°� ������";
                sentences[5] = "��ü���� �ܾ�� Ʋ������ ��ü���� \n�� ������ ��Ȯ��. ���� ����.";
                sentences[6] = " ���ο� ������ ���ȴ�.[���� �߽ɺ�]";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 28;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 28)
            {
                System.Array.Resize(ref sentences, 3);
                sentences[0] = "���� ����.";
                sentences[1] = "���� �ʴ� �� �ž�. �װ͵� \n���� �˰� �־�...";
                sentences[2] = "�׷��� �� ������ �����ܴ�.";
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 30)
            {
                System.Array.Resize(ref sentences,2);
                sentences[0] = "...";
                sentences[1] = "��ڻ翡�� �� ����...";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 31;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 37)
            {
                System.Array.Resize(ref sentences, 4);
                sentences[0] = "...";
                sentences[1] = "... �̻��� ���� ��������.";
                sentences[2] = "�ʴ� �и� �ø�ó�� �巡�￡�� ���� \n����̾��µ�... ���� ����� ��������...";
                sentences[3] = "��� �� ����?? \n����� �ٲ� ���� ���� ���� \n���簡 �ִ°ǰ�?";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 38;
                return sentences;
            }
            else if (Quest[7] == 4)
            {
                System.Array.Resize(ref sentences, 5);
                sentences[0] = "...";
                sentences[1] = "�������̱���.";
                sentences[2] = "��ڻ翡 ���ؼ��� \n���ڰ� �������� ������.";
                sentences[3] = "�װ� �� ������ ��� \n������� ���ֽ�Ű�� �ʾҴ���� \n������ ���� �������� �ž�.";
                sentences[4] = "�ι�Ʈ���Ե� �׷��� \n���� ������ ���ھ�.";
                Quest[7] = 5;
                return sentences;
            }
            else
                return null;
        }
        else if (NPCnum == 13) // ��ڻ�
        {
            if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 17)
            {
                System.Array.Resize(ref sentences, 12);
                sentences[0] = "�ȳ� ���� ��ڻ����.";
                sentences[1] = "�ʵ� �ױ��� �ִ� �迡�� �� ����̱���. ���� �� ����� ������ �����\n ���� �ִ����.";
                sentences[2] = "�� ƮŸ�� ������ �ƴ� �κ�� ������ \n�ֳİ�? ��. �ζ� �������� ���� ���� \n ���� �ƹ��͵� �𸣰ڱ���.";
                sentences[3] = "���� ���� ������ �� ��� �� ����縣�� ����ƽ�� ������� ���� ���׶���\n ���Ϸ� ������ ���� �Ǿ���.";
                sentences[4] = "ó������ �׷����� ���������� �׷κ��� 10���� ���� �ں��� ������ ���۵ƾ�.";
                sentences[5] = "���� ���ְ� ������ ���ְ� ���� �����鼭 �� �ٷ� �տ� �ִ� ƮŸ�� ����������\n ���� ����� ���� �ֹε��� ������ \n���� �� �ۿ� ������.";
                sentences[6] = "���ְ� ���� ������ Ȳ��ȭ�ǰ� �������� ���� ��ü���� �Ͼ��... �� �״�� \n�������� ���� ��Ұ� �ǹ��Ⱦ�.";
                sentences[7] = "������ ���ָ��� ������ �ƴϾ���.";
                sentences[8] = "�ǳ��ϴ� ���߿� ���ڱ� �Ŵ��� ���� \n��Ÿ���� ���̴� ��� ���� \n���¿������� �ž�.";
                sentences[9] = "���� ���� ���ĺ��� �� ���� ���� �� ���� ������ �ɷ� �ִ� ������ �˰� \n�־��µ�... �鼺���� ������ ���� \n�������� �ʰ�... ������ �� ���Ҵܴ�. ";
                sentences[10] = "�׷��� �츮�� ��� �����ļ� �ᱹ �ױ��� �ִ� ���� �����̾��� �κ�� �������� ���� �� ����.";
                sentences[11] = "������ ���������. �ζ� ������ �˷��� �߾����� ���� ������ ������ ����� \n�����鼭 ������ �ʹ� ���� ���ܼ� �ٸ� ������ ���� �Ű澲�� ���ϰ� �ִܴ�. ";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 18;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 18)
            {
                System.Array.Resize(ref sentences, 12);
                sentences[0] = "�� ���彺ź�� ��������.";
                sentences[1] = "ƮŸ�� ������ ���� �� ������ ���� �ְ�޾���. �׶��� ������ ������ �踦 Ÿ�� �忣�������� �����ߴܴ�.";
                sentences[2] = "�׷��� �� �������� �� �ְ�?";
                sentences[3] = "�� ����� �� ���� �ְڱ���. \n���彺ź�� �Ƴ��� �� �������̶���.";
                sentences[4] = "�쿬�� ���� �� ���彺ź�� ������ \n���ĺ��� ����� ������ �ᱹ\n �忣�������� ���� ��ȥ����.";
                sentences[5] = "��? ������ �����ٰ�? \n��... �װ� �� �ȵƱ���...";
                sentences[6] = "�ٺ��� ������ ���� ������ �Բ� \n�־����� ���ϴٴ� �� ���� ��������.";
                sentences[7] = "�װ� �̰��� �� ������ �ְ����� ������ ���� �Ű��� �� �� ���� ���ܴ�.";
                sentences[8] = "�� ��ҵ� �����ϰ� ���ĵ� �����ϰ�... \n�Ű��� ��� �� �� �ʹ� ������.";
                sentences[9] = "�׳��� ���� �츮 ���������� ���� �ʾƼ� �����̶�� �ؾ��ұ�... ";
                sentences[10] = "Ȥ�� ���� �ñ��� ���� ������ �ø����� \n�� ����. ���õ� �ؾ� �� ���� ���ܴ�.";
                sentences[11] = " �÷��ǿ� NPC�� ���� ���ο� ������ �߰��Ǿ���.";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 19;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 19)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "���� �ٻڴ� �ø󿡰� ������.";
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 31)
            {
                System.Array.Resize(ref sentences, 7);
                sentences[0] = "���� ���� �ؾ� ���� �𸣰ڴ�.";
                sentences[1] = "�׷��� ���� ������ ������ ����� \n�ߴµ�... ";
                sentences[2] = "������ �ñ⿡ ������ ������ ������...";
                sentences[3] = "�Դٰ� �ø���� ������̴ٴ�... \n�Ǹ��� ũ��.";
                sentences[4] = "���ʿ� �ø��� �Ұ������� �� �߸��ΰ�... �����δ� ���� ������ ���� ������ ���� ����... �ζ� ������ �ٽ� ���ư����� \n���ڱ���.";
                sentences[5] = "�̾������� �ʸ� ���� \n�ø��� �������±���...";
                sentences[6] = " ������ �ִ� �������� �� ���� ���� ���ڴ�.";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 32;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 36)
            {
                System.Array.Resize(ref sentences, 7);
                sentences[0] = "���̽�! �� ������ ���� \n���Ҹ��� ��ȴܴ�!";
                sentences[1] = "�ʰ� óġ�ߴٰ�? ���� ����!";
                sentences[2] = "�������� ���� �̾��ߴܴ�,,, \n������ �� ���� óġ�ϴٴ�...";
                sentences[3] = "Ȥ�� ���ϴ� �� ������ ������ \n���ص� ���ܴ�. ";
                sentences[4] = "���� ������ ����� \n���� �� �ְ� �Ǵٴ�...!";
                sentences[5] = "�̰� �� ���Ǵϱ� �޾Ƶη�.";
                sentences[6] = " ��带 ȹ���ߴ�.[1000���]";
                GameObject.Find("Player").GetComponent<Player>().PlayerGold += 1000;
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 37;
                return sentences;
            }
            else if (Quest[7] == 1)
            {
                System.Array.Resize(ref sentences, 17);
                sentences[0] = "�� �����Բ��� ���̳�.";
                sentences[1] = "���̽�! \n�ʿ��� ���� �ҽ��� �ִܴ�.";
                sentences[2] = "�������� ������ �������� ���� ����?\n�� ���� ���� ���� �����̶���.";
                sentences[3] = "����� �ʿ� ����. \n�ʶ�� ����� �ڰ��� �����ϱ�.";
                sentences[4] = " �ι�Ʈ�� ������ �ǳ����.";
                sentences[5] = "�̰� ���� �� ������?";
                sentences[6] = "��� �� �۾�ü��?";
                sentences[7] = " ��ڻ�� ������ ������ �ʰ� ������.";
                sentences[8] = "ƮŸ�� �������� ���� ������.";
                sentences[9] = "�ű⿣ �� ���Ű� ����. \n������ �ذ������ŭ �β����� ����...";
                sentences[10] = "���ǿ��� ������ ������ �й����� \n������ ä�� 1�� ������ ����� �������� �����ϰ� �־���.";
                sentences[11] = "���ְ� �������� ��ġ�� ������ \n���� �ؾ� �� ���� ���޾Ҵܴ�.";
                sentences[12] = "���� ������� �����ؼ� ��� \n�� �κ�� ������ ����.";
                sentences[13] = "�ι�Ʈ... �� �༮�� ������ ������ ���ϰ� ȥ�� ƮŸ�� ������ ���Ҵܴ�.";
                sentences[14] = "�ҽ�����... �װ� �� �༮�� �Ѱ���...";
                sentences[15] = "�̾������� ���� ���� ��Ȱ�� ���ܴ�. \n�� �༮���� �״�� �����ַ�. ";
                sentences[16] = "���� ���� ���ϴ� �� ���ǰ�����...\n ���� �ٺ��� ���̾�. �Դٰ� �� �༮�� \n���� �� �ѽ��ߴ� ����� ������ �� ����.";
                Quest[7] = 2;
                return sentences;
            }
            else if (Quest[7] == 3)
            {
                System.Array.Resize(ref sentences, 7);
                sentences[0] = "�̰�...?";
                sentences[1] = "�ι�Ʈ �༮�� �������� ����...";
                sentences[2] = "�ʴ� �������� ���� �ϴ� �� \n�������� �����̱���";
                sentences[3] = "�� �̻� �� ���� ����.";
                sentences[4] = "Ȥ�� ���ϴ°� �̰Ŷ�� �ι�Ʈ���� ���";
                sentences[5] = " 10000��带 �����.";
                sentences[6] = " �����ڰ� �츮�� ���� �ִ�. ���� ���� �ɾ��.";
                GameObject.Find("Player").GetComponent<Player>().PlayerGold += 10000;
                Quest[7] = 4;
                return sentences;
            }
            else
                return null;
        }
        else if (NPCnum == 14) // ����
        {
            if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 20)
            {
                System.Array.Resize(ref sentences, 4);
                sentences[0] = "...";
                sentences[1] = "�����༭ ���ٰ�? ��.";
                sentences[2] = "���� ���Ϸ��� �� �� �ƴϴϱ� \n������ �ʿ�� ����.";
                sentences[3] = "������ �����ϱ� ������ ����� \n�� ��Ű���.";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 21;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 21)
            {
                System.Array.Resize(ref sentences, 4);
                sentences[0] = "���� �����İ�?";
                sentences[1] = "�װ� ���� �� ������ ������� �θ��� ��. ���� �������� �ʸ� ��ٷ��Ծ�.\n ���̽�.";
                sentences[2] = "���� �뿡 ���ϸ� ���� ���ϱ���.";
                sentences[3] = "���� ���̶� �ο� ���� �������� \n������ ���� �Ӹ� �� ������ �� �����ž�.";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 22;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 29)
            {
                System.Array.Resize(ref sentences, 7);
                sentences[0] = "�׾���.";
                sentences[1] = "�� ��... ���ϳ� �ߴ��� \n�꿡 ���� �İ� �־��� �ž�??";
                sentences[2] = "���� �߽ɺο��� \n�� ���� ��� �ִ� ���̾�!";
                sentences[3] = "...���� �����Ǽ� �� ���� �ƴϾ�.";
                sentences[4] = "�װ� �׷��� �� ������ ���ȳ�;";
                sentences[5] = "�� �̻� ������ٰ� ���� ������ �� \n�����ϱ� ��¥�� ������ ����.\n �ٽ� �� �������� ���ڳ�.";
                sentences[6] = "�� �̻� �������� �� ���� ���� ������ \n���ư�.";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 30;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 32)
            {
                System.Array.Resize(ref sentences, 7);
                sentences[0] = "�̹����� ����";
                sentences[1] = "...? �������� �̿�ް� �ִٰ�?";
                sentences[2] = "�׷��� ������ ¡¡�Ÿ����� �� �ž�?";
                sentences[3] = "�ʵ� ��...";
                sentences[4] = "������ �ʿ��ϴٰ�?";
                sentences[5] = "...";
                sentences[6] = "���� �� �������� �ϳ�...";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 33;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 33)
            {
                System.Array.Resize(ref sentences, 8);
                sentences[0] = "���� ���ڰ�?";
                sentences[1] = "...";
                sentences[2] = "�Ʊ� ŻŻ �з����鼭...";
                sentences[3] = "...";
                sentences[4] = "�����ΰ� ����.";
                sentences[5] = "...";
                sentences[6] = "�׷� �������� ���� ��¿ �� ���ݾ�... ����.";
                sentences[7] = "���� �ۿ� �ִ� ���� ������ �� �״ϱ�\n �ʰ� óġ�ؾ� ��. �� ������ �� \n�ű������.";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 34;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 34)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "���� ������ ����.";
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 35)
            {
                System.Array.Resize(ref sentences, 6);
                sentences[0] = "...";
                sentences[1] = "������ �� ������ ���� �׿���.";
                sentences[2] = "�������� ���� �ڻ������ �ؼ� ���� �ߴµ�...";
                sentences[3] = "��¶�� ����, \n�� ���� ��� ������ ���谡 �ֱ� ����.";
                sentences[4] = "������ ���ư��� ���� ������ �˷��ִ� �� �����ž�.";
                sentences[5] = "�׷��� ����... �� �� �� ���� ����";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 36;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 36)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "������ �鷶�ٰ� ����.";
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 38)
            {
                System.Array.Resize(ref sentences, 14);
                sentences[0] = "�ȳ� ���̽�";
                sentences[1] = "���� ǥ���� �����ϳ�. \n���� ������ ���纼��?";
                sentences[2] = "�и� �ʸ� ���ϴ� ������� �µ��� \n�������� ��Ȳ��������.";
                sentences[3] = "����.. ���� ����鿡�� ���� �ø��̶�� ������ �������ٴ� �ʶ�� ���簡 \n�� �߿��� �� ����.";
                sentences[4] = "������ �ִ� �͵� �ƴϰ� ��ڻ簰�� \n����� ���ʿ� �ø󺸴ٴ� ������ ����� �� �߿��Ұ�? ���� ���� ���� �����ϱ� \n�ø��� ������ �����ϴ� ô �ߴ� ����.";
                sentences[5] = "��? ���� ���ؼ� �ñ��ϴٰ�?";
                sentences[6] = "��... ������ ���� �ƴ� �� ����.";
                sentences[7] = "������ �ʰ� ������ �ʴ���� ������ \n��� ���� ���ؾ� �ϴ� ������ �� �ž�.";
                sentences[8] = "����ư! ���ݱ��� ���� �ʸ� �������ݾ�?";
                sentences[9] = "������ �ʰ� ���� ������߰ھ�.";
                sentences[10] = "�ʴ� �ø��̶�� ������ ������ �ϱ� ���� �巡���� ���� ���ݾ�?";
                sentences[11] = "��� �� ��Ӵϴ�... ������ �� ��� �� \n�Ѹ����� �� ���Ϸ� ������ ������ \n���¶����� ���ش��߾�...";
                sentences[12] = "�̹����� �ʰ� �� ������ ���������� \n���ھ�.";
                sentences[13] = "���� �巡����� �񱳰� �� �� ������ \n�����ž�. �����Ѵ� �ص� �����Ұ�.";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 39;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 39)
            {
                System.Array.Resize(ref sentences, 7);
                sentences[0] = "����";
                sentences[1] = "���¶��� ���ֹ��� ���� �־�.";
                sentences[2] = "���ſ��� �ູ���� ���̶�� �ҷ����� \n���¶��� ���� �ǰ� ���ְ� ������ \n�� �ں��� ������ �ٿ����� �� ������.";
                sentences[3] = "���ָ� ������ ��� �Ǵ��� �ñ��ϸ�\n ƮŸ�� ������ �� ���� �� ����.";
                sentences[4] = "���ְ� ������ ���� �ص� ���Ϸ� \n���󿡼� ���� ������ �����̾���";
                sentences[5] = "���� ���� �� ������. õõ�� ��";
                sentences[6] = " ���ο� ������ ���ȴ�. [ƮŸ�� ����]";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 40;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 44)
            {
                System.Array.Resize(ref sentences, 5);
                sentences[0] = "���� ��踦 ������� ���ߴٰ�?";
                sentences[1] = "��... �ʶ�� ����� �� ������ �˾Ҵµ� �������δ� �ȵǴ°ǰ�?";
                sentences[2] = "��¿ �� ����. �̰� �޾�.";
                sentences[3] = " �������� Ư���� ������ ������ ������ �޾Ҵ�.";
                sentences[4] = "���� �������� �ž�. \n���� �ѹ� ������ ���� ���ƿ�.";
                GameObject.Find("GameManager").GetComponent<GameManager>().Key[4] = 1;
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 45;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 45)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "���� ���� ��Ը� ����� �� �����ž�.";
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 46)
            {
                System.Array.Resize(ref sentences, 6);
                sentences[0] = "������ ����� �� �־��ٰ�?";
                sentences[1] = "����... ";
                sentences[2] = "���� ����� ���� ���ֹ޾Ƽ� \n���ΰ���ó�� �����ް� �ִ� ���̾�.";
                sentences[3] = "�� �����ϰ� �׵��� ���� ���� ���شٰ� �ϸ� ������ ��������.";
                sentences[4] = "���� �� ������ �� �� �����ž�.";
                sentences[5] = " ���ο� ������ ���ȴ�. [���ֹ��� �� ����]";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 47;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 48)
            {
                System.Array.Resize(ref sentences, 8);
                sentences[0] = "���ֵ��� ����ü��...";
                sentences[1] = "���� �� �� ������ ���� �� �� �����ž�.";
                sentences[2] = "�̷� ������ ���ִ� �渶���� ���ۿ����� ���ؼ� ����� �ž�.";
                sentences[3] = "�׸��� ���� �� ���� �� ������ ������ �θ� �� �ִ� ������� �Ѹ�ۿ� ����..";
                sentences[4] = "�ʵ� �˰� �ֵ��� ���� ��ÿ� �ΰ��ʿ� �� ���� ���� �� ���� �����ڰ� �־���.";
                sentences[5] = "�׸��� ������ �� �Ѹ��� �ø��ɶ�� \n�����翴��.";
                sentences[6] = "���� ���� �� �����ž�.";
                sentences[7] = " ���ο� ������ ���ȴ�. [���ֹ��� �� ����]";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 49;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 51)
            {
                System.Array.Resize(ref sentences, 5);
                sentences[0] = "���� �������̾�.";
                sentences[1] = "���� ��� ������� ����� ������ ���¶��� óġ�� ����.";
                sentences[2] = "�� ������ �������� ��ٷ��Ծ�.";
                sentences[3] = "����! ������ ������!";
                sentences[4] = " ���ο� ������ ���ȴ�. [���ֹ��� �� ����]";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] = 52;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] == 52)
            {
                System.Array.Resize(ref sentences,1);
                sentences[0] = "�������̾�.";
                return sentences;
            }
            else
                return null;
        }
        else if ((NPCnum == 15)) //����2
        {
            if (Quest[1] < 2)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "��...";
                return sentences;
            }
            else if (Quest[1] == 2)
            {
                System.Array.Resize(ref sentences, 4);
                sentences[0] = "�ȳ�! ���⼭�� �����±���!\n �ʴ� �и� �忣�������� �������ڸ� \n��� ã�Ƽ� ���� ���� �߾���!";
                sentences[1] = "���⼭�� ��� �������ڸ� ã�� �� \n������? �κ�� ������ �������ڴ� ��� 5����.";
                sentences[2] = "�ٵ� ��� �������ڴ� ������ �ֱ� \n�Ⱦ��ϱ⵵ �ϴϱ� ������.";
                sentences[3] = "���� �̹� �̼Ǳ��� �����ϸ� \n�ʸ� ���� �������� ������ �ٰ�!";
                Quest[1] = 3;
                return sentences;
            }
            if (Quest[1] == 3)
            {
                gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
                if (gamemanager.Chest[6] == true && gamemanager.Chest[7] == true && gamemanager.Chest[8] == true && gamemanager.Chest[9] == true && gamemanager.Chest[10] == true)
                {
                    System.Array.Resize(ref sentences, 5);
                    sentences[0] = "��! �� �������� �ټ����� ã���ž�??";
                    sentences[1] = "��¥�� ����ѵ�?";
                    sentences[2] = "�ʸ� �� �������� �����Ѵٴ� \n�ǹ̷� ��带 �� �����ٰ�.";
                    sentences[3] = " ��带 ȹ���ߴ�.[1000���]";
                    sentences[4] = "���� ��¥�� �ʰ� �ʿ���.";
                    GameObject.Find("Player").GetComponent<Player>().PlayerGold += 1000;
                    Quest[1] = 4;
                }
                else
                {
                    System.Array.Resize(ref sentences, 1);
                    sentences[0] = "���� �������� �ټ����� �� ��ã�Ҿ�.";
                }
                return sentences;
            }
            else
                return null;
        }
        else if (NPCnum == 16) // ���ò�2
        {
            if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[0] >= 20 && GameObject.Find("GameManager").GetComponent<GameManager>().Quest[4] == 0)
            {
                System.Array.Resize(ref sentences, 7);
                sentences[0] = "�ȳ�...";
                sentences[1] = "�������� �����İ�? ��ӴϿ� ������ �������� �ƹ����� ������ ���߳�.";
                sentences[2] = "����� ���� ���� ����. \n�ֳ��ϸ� �� ������ �����ôϱ�.";
                sentences[3] = "���� ���� ������... �ƹ������� \n��� ���� ã�ƴٳ�ٰ� �ϳ�.";
                sentences[4] = "�ٴٸ� �����ٰ� ������ �������� ���ٴ� ���� ����� ���ƿ��� �ʾҴٰ�...";
                sentences[5] = "��ӴϿ� ������ �����ٰ� ������ �� \nå���̱⵵ �ϴϱ� �� �ƹ����� \nã�� ������ ��Ź�� �� ������?";
                sentences[6] = "������ ������� ���� ������� \n���� �� �ִٰ� �ؼ� ���ź��� ���� �̸� �׸����ϴ� ���� ������� ������ \n���ƿ��� ����� ������. �ƹ����� ���� �׾��ٰ� �����ϰ� ������ ���� ���̴��� ����.";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[4] = 1;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[4] == 1)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "������ �������� ����.";
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[4] == 2)
            {
                System.Array.Resize(ref sentences, 7);
                sentences[0] = "... �� ������ ������� ���� �ʰ� \n���ư��ڰ� �߳İ�?";
                sentences[1] = "�ڳ׿� �ο� ������ �� ����ϳ�?";
                sentences[2] = "�� �� ����� �˾�. ���ſ� �� �������� ������� ������ �������� �ǰڴٰ� \nū�Ҹ�ġ�� �������.";
                sentences[3] = "�ֺ� ����� ��⿡ ������ ������ \n������� ��� �Ұ� ������ �۽��� ä�� \n�ٴٷ� ���� ���ƿ��� �ʾҴٴ���.";
                sentences[4] = "�� ����� ���鼭 ���޾ҳ�. ������ \n��� �� �ƹ����� ����ִ����� \n�𸣰����� ���� ������ٴ� ���� \n����ִ� ����� �߿��ϴٴ� ���� \n���̾�.";
                sentences[5] = "���� �ƹ����� ã�´ٴ� �������� \n�����ϰ� ������ �������� ������ �ڳ׿� �� ��� �� ����ó�� ������ �ż� ������ ���ϴ� �ż��� �Ǿ��� �ž�.";
                sentences[6] = "�̾��ϳ�. �������� �̷��� ������ ��Ź�� ���� ���� �ž�. ���� ������ �� ��ӴϿ� ������ ��Ű�ڳ�.";
                GameObject.Find("GameManager").GetComponent<GameManager>().Quest[4] = 3;
                return sentences;
            }
            else if (GameObject.Find("GameManager").GetComponent<GameManager>().Quest[4] == 3)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "�������� ������ ���� �˷��༭\n ���� ����!!!";
                return sentences;
            }
            else
                return null;
        }
        else if ((NPCnum == 17)) //�ø�2
        {
            if (Quest[0]  == 28)
            {
                System.Array.Resize(ref sentences, 15);
                sentences[0] = "... ���� ������ �ʳ�...";
                sentences[1] = "�̾�. ���� ��������� ����. ";
                sentences[2] = "... ��Ƽ� �ʶ� ������ ��� ���ڰ�?";
                sentences[3] = "...";
                sentences[4] = "��� �� ���� �� ������.";
                sentences[5] = "�ֳ��ϸ� �� �߳� ������ �ϴٰ� \n���� �Ҿ��ŵ�.";
                sentences[6] = "���� ������ �� �����߾�. \n�� ���� ������ ���ڸ� �� ���� �̲��� \n���� ������ ������.";
                sentences[7] = "... ���� �츮�� �����߰� ���� �״°� \n���տ��� ���Ѻ��� �߾�. ��� �� ������ ���� ��� �˻簡 ���� ��������.";
                sentences[8] = "���� ��Ƴ��Ұ�... ���� �տ����� \n�� ��ó�� ���� ô ������ �� �������� \n�������� ������ �ʾҾ�.";
                sentences[9] = "�ٸ� ������� ���� ���� ������ \n�غ��ߴٰ� ���������� ������ �Ը���\n �� �������� ��å���� ��վ� ������.";
                sentences[10] = "...";
                sentences[11] = "�ᱹ�� ���� ���� ���� ������ ����̶� �ϸ鼭 ��å���� ������ �ߴ� �� ���̾�. �ű⿡ �ʸ� �̿��� �Ű�...";
                sentences[12] = "�̷��� �㹫�� ���� �������� \n���̶�� �̷��� ���� �Ŷ�� �����߾�...";
                sentences[13] = "����...";
                sentences[14] = "������ �����̶�ϱ�";
                Quest[0] = 29;
                return sentences;
            }
            else
                return null;
        }
        else if ((NPCnum == 18)) //����2
        {
            if (Quest[0] == 34)
            {
                System.Array.Resize(ref sentences, 4);
                sentences[0] = "����� ��û �̳߰�.";
                sentences[1] = "���Ѵ�� ���� �ۿ� ���ƴٴϴ� ���� \n����� ������ �״ϱ�";
                sentences[2] = "�ʰ� � ����� �Ἥ�� óġ�ϸ� ��.";
                sentences[3] = "�� ������ �� ������� ����.";
                return sentences;
            }
            else
                return null;
        }
        else if (NPCnum == 19) //��������
        {
            if (Quest[0] >= 24 && Quest[6] == 0)
            {
                System.Array.Resize(ref sentences, 9);
                sentences[0] = "�ڳ�! ��� ���纸�Գ�";
                sentences[1] = "�ø�� ����ϴ� �� ����µ�... \n�꿡 ������ �Ǵٸ鼭?";
                sentences[2] = "����! �׷��ٸ� �� ������ �� �������� \n�ʰڳ�?";
                sentences[3] = "����! �׷��ٸ� �̳��� �ճ⿡�� \n�� ������ �������̿��µ� ���̾�...";
                sentences[4] = "������ ���� �ڷδ� ������� ���⿡ \n������ ��� ��ⱸ�� �������� �ſ� ��ġ���ϸ鼭 �λ��� �����ϰ� �ִٳ�...";
                sentences[5] = "�׷���... �ױ� ������ �λ���ǰ �ϳ��� \n����� �ʹٴ� ���� �ִٳ�. ";
                sentences[6] = "�׷��� �׷���... ���� �Ĵ� ���� ���� \n���� ���� �����ž�. \n�װ��� ���� ������ �ִ� ���ε�";
                sentences[7] = "�� ������ �� �״ϱ� �� �������� ���� \nǮ���� �Ⱑ ���� ���� �� ���ش� ����\n �ʰڳ�?";
                sentences[8] = " ���ο� ������ ���ȴ�.[����]";
                Quest[6] = 1;
                return sentences;
            }
            else if (Quest[6] == 1)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "���꿡�� �Ⱑ ���� ���� �� ���ش�\n �ְԳ�.";
                return sentences;
            }
            else if (Quest[6] == 2)
            {
                System.Array.Resize(ref sentences, 7);
                sentences[0] = "����! ���� ���!";
                sentences[1] = ".";
                sentences[2] = "..";
                sentences[3] = "...";
                sentences[4] = "...?";
                sentences[5] = "�̷�... ��ġ�� �ϴϱ� �ν��� �����ݾ�...";
                sentences[6] = "���߿��� Ȥ!��! �� ȥ�� �������� \n��ǰ�� ������ ������ �ְԳ�";
                Quest[6] = 3;
                return sentences;
            }
            else if (Quest[6] == 3)
            {
                if (gamemanager.Swordhave[8] == 1 && gamemanager.Key[3] == 1)
                {
                    System.Array.Resize(ref sentences, 8);
                    sentences[0] = "���! �ڳװ� ������ �ִ� �װ�,,,";
                    sentences[1] = "���� ���� ������ �˰� ����縣�� \n������... �̰� �����ϰھ�! �̸� �ְԳ�!!";
                    sentences[2] = ".";
                    sentences[3] = "..";
                    sentences[4] = "...";
                    sentences[5] = "...!";
                    sentences[6] = "�����̴�! ���� �׾ ������ ����...";
                    sentences[7] = " ���ο� ���⸦ �����. [��ȭ�� ������ ��]";
                    GameObject.Find("GameManager").GetComponent<GameManager>().Swordhave[9] = 1;
                    GameObject.Find("GameManager").GetComponent<GameManager>().Swordnum = 9;
                    GameObject.Find("Player").GetComponent<Player>().swordnum = 9;
                    GameObject.Find("Player").GetComponent<Player>().SwordInven(9);
                    GameObject.Find("Player").GetComponent<Player>().Power = manager.SwordPower[9];
                    Quest[6] = 4;
                    return sentences;
                }
                else
                {
                    System.Array.Resize(ref sentences, 1);
                    sentences[0] = "�� ȥ�� �������� ��ǰ�� ���� ����. \n���� �� �������ְԳ�.";
                    return sentences;
                }
                
            }
            else if (Quest[6] == 4)
            {
                System.Array.Resize(ref sentences, 3);
                sentences[0] = "�׾ ������ ����...";
                return sentences;
            }
            else
                return null;
        }
        else if (NPCnum == 20) //�ι�Ʈ
        {
            if (Quest[0] == 40)
            {
                System.Array.Resize(ref sentences, 8);
                sentences[0] = "��.. �� ������ ���� ����� \n������ �������� ���±�.";
                sentences[1] = "���ſ��� ������ɲ۵��̳� ���谡���� ������... ������ �ƿ� ���� ����� \n���ٳ�.";
                sentences[2] = "�̰��� ���ſ��� ���� ������ \n�����̾����� ���ְ� ������ �������\n �� �����ƾ�.";
                sentences[3] = "��ڻ�... �׳༮�� �����ؼ� �������\n ��� ������ �� ���Ⱦ�!";
                sentences[4] = "���ְ� ���� �����ٰ� ������ ���� \n�����ٴ� ������";
                sentences[5] = "�������� �濡 ��κ��� ������ \n���ߴٴ���... ������ �������� \n�� ���� ����.";
                sentences[6] = "�츰 �̷��� ���ָ� ���ؼ� ���� ����\n ������ ���� �� �� �ϴٳ�. ������ \n���ֿ� ���� �߸��� �ҹ����� �����鼭 ������ �� ������� �� �ͼ� ������ �ǰ� �ִ� ����.";
                sentences[7] = "�׷��� �ڳ״� �� �Դ°�? \n��? �ƴϸ� ����?";
                Quest[0] = 41;
                return sentences;
            }
            else if (Quest[0] == 41)
            {
                System.Array.Resize(ref sentences, 6);
                sentences[0] = "���ֹ��� ��? ���� ���� �ִ�\n �� ���� ���ϴ� �ǰ�?";
                sentences[1] = "������... ������ �ٿ����� ���� ���� \n���̰ڴ� �̰ǰ�?";
                sentences[2] = "�� ��ϱ� �׷� �Ҹ��� ���� ���� \n�ְڱ�... �ֳ��ϸ� ���� ��ÿ� \n�׸� �� ������� ���� �׷� ����\n �����״ϱ� ���̾�...";
                sentences[3] = "��� �ݶ����� �̲��� ������ ���� \n�θ��� ������,,, �׵��� ������ \n�������̿���.";
                sentences[4] = "������ ��... ������ ���� �����ϱ�. \n���� �� �ٷ� �տ� �־�. \n������ ��谡 ���� �־ \n�ƹ��� ���� ������.";
                sentences[5] = "�� �ñ��� �� �ֳ�?";
                Quest[0] = 42;
                return sentences;
            }
            else if (Quest[0] == 42)
            {
                System.Array.Resize(ref sentences, 8);
                sentences[0] = "��? ���� ��ڻ�� ���� ���� \n����� ������ �����ϴ� ����̳�.";
                sentences[1] = "�������� ����? ��... �� ���� �ְڱ�. \n���ݱ��� �� ���� �������� �־���.";
                sentences[2] = "���� �������� �������� �˰� �ִ� �� \n�� ��° �������̾�. \nù ��° �������� 100���� ���� ������ �ΰ��� �Բ� ������ �¼� �����̾�.";
                sentences[3] = "�������� ���� �����ž�. \n������ �������� �ٵ� �װ� ���� �Ŀ� \n�ΰ��� �����ϴ� ������ ���ſ� �ΰ��� ���� ���ƴٴ� ����� ����� ���ؼ� \n�Ϻη� ������ �������";
                sentences[4] = "����� ���￡�� ���� ���ļ� ������ \n�̱�� ���� ģ���� �ǹ̷� �������� \n���� ���̾�. ������ �ñ��ϸ� �ö󰡼� ���� ��.";
                sentences[5] = "��ڻ�� ���� ����� �������� �ؼ��ؼ� ������ �������� ����.";
                sentences[6] = "������ ���� �� ����. ����ư ������ ���� ������ ���� ��. ������ ��趧���� \n������ ���Ѵٰ�.";
                sentences[7] = " ���ο� ������ ���ȴ�.[���ֹ��� ����]";
                Quest[0] = 43;
                return sentences;
            }
            else if (Quest[0] >= 43 && Quest[7] ==0)
            {
                System.Array.Resize(ref sentences, 4);
                sentences[0] = "�� ���� �������� ������� �ϰ� \n��ڻ� ����? �� ���� �� ������.";
                sentences[1] = "������� ������ ������ ���� �� \n��ڻ��� ������ ���� �˴� ����� \n�ƴϿ���.";
                sentences[2] = "���� �������� �����ϰ�... ������� \n�𸣰� ����� ���ƴ� ������ �����\n ������� �����ڰ� �ǰڴٴ� �߽��� \n��Ÿ�� �־���.";
                sentences[3] = "�׷��� ģ���μ� ������ �Ҳ��� ������� �ʾҴ��� ���������� Ȯ���� ���� �ͱ�";
                Quest[7] = 1;
                return sentences;
            }
            else if (Quest[7] == 2)
            {
                System.Array.Resize(ref sentences, 8);
                sentences[0] = "...";
                sentences[1] = "�׷���...";
                sentences[2] = "�κ�� �������� ���ٿԴµ� \n�ƹ� ������ ������ �̾��ϳ�...";
                sentences[3] = "�׷�... Ȥ�� �װŶ��...";
                sentences[4] = "��Ź �ϳ��� �� ����� �� �ִ°�?";
                sentences[5] = "�� ������ ������ �����ָ� \n��ڻ��� ������ ���� �� �������� ����!";
                sentences[6] = "�� ���� �� ��ڻ翡�� \n���� �� �ְڴ°�?";
                sentences[7] = " ���ο� ���⸦ �����.[�뿹�� ���� ���� ���]";
                GameObject.Find("GameManager").GetComponent<GameManager>().Swordhave[7] = 1;
                GameObject.Find("GameManager").GetComponent<GameManager>().Swordnum = 7;
                GameObject.Find("Player").GetComponent<Player>().swordnum = 7;
                GameObject.Find("Player").GetComponent<Player>().SwordInven(7);
                GameObject.Find("Player").GetComponent<Player>().Power = manager.SwordPower[7];
                Quest[7] = 3;
                return sentences;
            }
            else if (Quest[7] == 5)
            {
                System.Array.Resize(ref sentences, 4);
                sentences[0] = "��...";
                sentences[1] = "�׷�... ��¼�� �ű⿡ �ִ� ������� \n��ڻ簡 �ʿ������� ����...";
                sentences[2] = "�� ���� �ΰ� ���� �� �������� \n��������� ����.";
                sentences[3] = "���� ����... ���̶� ������ ������ \n�������. ������ �ʿ������...";
                Quest[7] = 6;
                return sentences;
            }
            else
                return null;
        }
        else if ((NPCnum == 22)) //�ø���
        {
            if (Quest[0] == 49)
            {
                System.Array.Resize(ref sentences, 12);
                sentences[0] = "...";
                sentences[1] = "������� ���ٴ�... ���� ���ϱ���...";
                sentences[2] = "�� �ۿ� ���ְ� ���ȴٰ�...?\n�װ� �������̾�. ���� �̾���.";
                sentences[3] = "���ִ� �渶���� ���ۿ��̾�. \n������ �渶���� ����� �� �ۿ� ������.";
                sentences[4] = "������ �˿� ��� ������ ����� ���� \n������ �������� �־�.";
                sentences[5] = "���¶� ���մ��� ������ ������ ƴ��\n �İ�� ���� ������ �����Ϸ���\n �ϰ� ����.";
                sentences[6] = "����� �������δ� ���� ������� ���� ������ ������ ��¿ �� ���� �渶����\n ����ؼ� ������ ���� ��ȭ��Ű�� �־�.";
                sentences[7] = "���� ������ ������� ���� ����. \n�� ���� ������ �������� \n�� ���� ���Ұž�...";
                sentences[8] = "���� �״� ���� ������ �վƱͷκ��� \n��� ������ ���� ���մ��� \n������ ���̰�";
                sentences[9] = "���￵���̿��� ������ �ùε��� \n�л��ϴ� �����簡 ������ �ž�.";
                sentences[10] = "������ �������� ���� ������� ���� \n�ʰ��� ���ο� ������ ��Ÿ���� �����縦 �����ֱ⸦ ��ٸ��� �־���.";
                sentences[11] = "���� �̱�ٸ� ���մ��� ���� �� ���� ���ɼ��� �ִٴ� �Ű���.";
                return sentences;
            }
            else
                return null;
        }
        else if ((NPCnum == 23)) //�պ�
        {
            if (Quest[0] == 52)
            {
                System.Array.Resize(ref sentences, 7);
                sentences[0] = "�ʰ� ���̽�����.";
                sentences[1] = "���� ���Ϸ� ������ �պ��� ���νö�� �Ѵܴ�.";
                sentences[2] = "���߶�� ���̰� �ͼ� �˷���� ������ ��� �귯�������� �˰� �ִܴ�.";
                sentences[3] = "������ ���� ���� ���� ���� ����� \n�������鼭 ���� ������ �ſ� ������ \n���¶���.";
                sentences[4] = "������... ���������� �ʾҾ�... \n���ݵ� ������ �˿��� ��� �����ϰ� \n�ִ� ���̶���.";
                sentences[5] = "���� ������ ���̴� �� �ܿ� �ٸ� ����� �ִٰ� �����Ѵܴ�.";
                sentences[6] = "�츮�� ū �߸��� �ϱ�� ������... \n�츮 ������ �ǵ��� ��ȸ�� ���� �ʰڴ�?";
                return sentences;
            }
            else
                return null;
        }
        else if ((NPCnum == 24)) //���¶�1
        {
            if (Quest[0] == 53)
            {
                System.Array.Resize(ref sentences, 5);
                sentences[0] = "...";
                sentences[1] = "���� �ò�������... \n�պ� �׾���?";
                sentences[2] = "...";
                sentences[3] = "�ʵ� ��� ����ϰ� \n���� ������ ���°� ����.";
                sentences[4] = "������.";
                return sentences;
            }
            else
                return null;
        }
        else if ((NPCnum == 25)) //����
        {
            if (Quest[0] == 53)
            {
                System.Array.Resize(ref sentences, 7);
                sentences[0] = "ũũũ... �ܿ� ���¶��� ���� \n�����߾��µ� �ᱹ�� ���зα�...";
                sentences[1] = "��翩 �״뿡�� ���ڴ�. ���� ���Ѱ�? ���� ������ �׷��� ���̰���.";
                sentences[2] = "���� �����ϱ� ���� �ΰ��� õ���ΰ� \n���������� ����� ������ ���� ������ ġ��� �̰��� �����̾���.";
                sentences[3] = "�������� �������� ������ ������ ���� �ʴ�... ���� ��û�� �����̿���. ũũũ";
                sentences[4] = "�׶��κ��� ���� �Ⱓ�� �귶����\n ����� ���ݵ� �Ȱ�����. �ٸ� ������ \n���ΰ��� �븩�̳� �ϰ� �ִٴ�...";
                sentences[5] = "����� ���ϴ�. ��û�ϱ� ��������. \n����� �ΰ��̿�. ������ ����� \n���̴±���...";
                sentences[6] = "�������̴� ��ó�� ���� ��ó�� \n���ΰ��ó����� �غ����� ����.";
                return sentences;
            }
            else
                return null;
        }
        else if ((NPCnum == 30)) //�̽õ���
        {
            if (Quest[0] >= 50)
            {
                System.Array.Resize(ref sentences, 7);
                sentences[0] = "...";
                sentences[1] = "��... ����...";
                sentences[2] = "�׳�... �ø��ɸ� �׿���....??";
                sentences[3] = "����ض�!!!";
                sentences[4] = "...";
                sentences[5] = "��� �� ��ﳵ��...";
                sentences[6] = "����... �ʸ� ���̰ڴ�...";
                Quest[9] = 1;
                return sentences;
            }
            else
                return null;
        }
        else if ((NPCnum == 31)) //����3
        {
            if (Quest[1] < 4)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "��...";
                return sentences;
            }
            else if (Quest[1] == 4)
            {
                System.Array.Resize(ref sentences, 4);
                sentences[0] = "�� ������? �ʰ� �ʿ��ϴٰ� ����!";
                sentences[1] = "����� ƮŸ�� �������� �������ڰ� �ִٰ� ��...";
                sentences[2] = "�׷��� ���������� ã�� ���߾�...";
                sentences[3] = "Ȥ�� �������ڸ� ã���� �� �ִ�??";
                Quest[1] = 5;
                return sentences;
            }
            if (Quest[1] == 5)
            {
                gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
                if (gamemanager.Chest[11] == true)
                {
                    System.Array.Resize(ref sentences, 12);
                    sentences[0] = "��! ����! �� ���� ��Ȯ�߾�!";
                    sentences[1] = "��! �̰� �� ���Ǵϱ� �޾������� ���ھ�.";
                    sentences[2] = " ���ο� ���� ȹ���ߴ�.[Ʈ���� ���� �ֿ�� ȸ����]";
                    sentences[3] = "Ʈ���� ���Ͷ�� �� ������ ���� \n����� ��.";
                    sentences[4] = "Ʈ���� ���� ȸ���� ����̳İ�? \n��... ����... 2��?";
                    sentences[5] = "...";
                    sentences[6] = "������ ���Ұ�... \n��� ���� ���� Ʈ���� ����\n ȸ���� �ƴϾ�.";
                    sentences[7] = "Ʈ���� ���� ȸ���� �ݵ�� ã�� \n���������� ���빰�� ��ȸ�� �����ؾ� \n�Ѵٴ� ��Ģ�� �ִ����.";
                    sentences[8] = "������ ���� ������ ã�� �� ��ü��\n ��ſ� ������ ������ ã�ұ� ������ \n���빰�� �������� �ʾƼ� �߷Ⱦ�.";
                    sentences[9] = "�׷��� �ƿ� �� Ʈ���� ���� \n��ȸ�� �������.";
                    sentences[10] = "�̹����� ���� ã�� �������� \n���� ������ �ݵ�� ���� ã�� ���ھ�!";
                    sentences[11] = "�׷��� �����ڰ�!";
                    Quest[1] = 6;
                    GameObject.Find("GameManager").GetComponent<GameManager>().Armorhave[5] = 1;
                    GameObject.Find("GameManager").GetComponent<GameManager>().Armornum = 5;
                    GameObject.Find("Player").GetComponent<Player>().armornum = 5;
                    GameObject.Find("Player").GetComponent<Player>().ArmorInven(5);
                    GameObject.Find("Player").GetComponent<Player>().Defense = manager.ArmorDefense[5];
                }
                else
                {
                    System.Array.Resize(ref sentences, 1);
                    sentences[0] = "���� �������ڸ� �� ��ã�Ҿ�.";
                }
                return sentences;
            }
            if (Quest[1] == 6)
            {
                System.Array.Resize(ref sentences, 1);
                sentences[0] = "�±±�...!";
                return sentences;
            }
            else
                return null;
        }
        else if ((NPCnum == 100)) //õ��
        {
            if (Quest[0] == 55)
            {
                System.Array.Resize(ref sentences, 16);
                sentences[0] = "...?";
                sentences[1] = "�ȳ��ϼ���. \n���� �� ������ ���� �������Դϴ�. ";
                sentences[2] = "...";
                sentences[3] = "���� ��ȭ���� ����鼭�� \n��� �̰� ���� ����� ������\n �𸣰ڳ׿�...";
                sentences[4] = "������� �Դٴ� ���� �� ��° ������ \n�ôٴ� �ǵ� ��.,.�׷��Ա��� �� ������ \n�ϴ� ����� ��������?";
                sentences[5] = "��� ������� ���� ���� �����μ� \n�ο�� �׸��� ������ ���⵵ �ߴµ� ";
                sentences[6] = "�����ϰ� NPC�� ���Խ��ϴ�.";
                sentences[7] = "����ư ������ �÷������ּż� \n�����մϴ�. ó������ ������ ������µ� ������ ��ƴ�����.";
                sentences[8] = "...";
                sentences[9] = "��¥�� ������� �� ����� ��������...";
                sentences[10] = "���� �� ���Ƽ� ������� �ϰڽ��ϴ�.";
                sentences[11] = "���� ������� �� ����� �ִٸ�";
                sentences[12] = "...";
                sentences[13] = "���� �ְھ�.";
                sentences[14] = "���� �ִٸ� ���� ������ ���ż� \n�����ϰ� �޴��� ���ø� �˴ϴ�.";
                sentences[15] = "���� ���� óġ���� ���� ������ �ִٸ� \nã�ƺ��ô� �͵� �����ϴ�.";

                Quest[0] = 56;
                return sentences;
            }
            else
                return null;
        }
        else
            return null;



    }


        
}
