using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkill : MonoBehaviour
{
    public float speed;
    public float speedgo;
    Rigidbody2D RB;
    public AudioClip[] clip;
    public GameObject circle;

    public int damage;

    public int time; //���ѽð�
    public int Time1;

    public float turnSpeed;
    public bool isGoToPlayer; //�����Ǵ����ȵǸ� ��� x������ �̵�


    public bool ishit; //Ÿ��üũ
    public bool isBomb; //�ð��ִ� �����ϴ���
    public bool ishitBomb; //�÷��̾����� �΋H���� �����ϴ���
    public bool isTargetRotation; //�÷��̾� ������ ���ϴ���
    public GameObject Trans;

    public float XForce;
    public float YForce;

    public bool isNotBerk; //�����´���

    public Vector2 boxSize; //���ݹڽ�

    public bool isBeam; //���������ϴ���
    public bool isHitE; //�¤��� ���������

    public bool isLine;
    public bool isRotationTarget; //���⿡ �°� ȸ��

    LineRenderer lr;
    public Vector3 cube1Pos, cube2Pos;
    public GameObject[] LineTarget;



    void OnEnable()
    {
        if(circle != null)
        {
            circle.GetComponent<TrailRenderer>().enabled = false;
            Invoke("SetCircle", circle.GetComponent<TrailRenderer>().time+0.5f);
        }
        RB = GetComponent<Rigidbody2D>();
        RB.velocity = new Vector2(0, 0);
        Time1 = time;
        RB.AddForce(new Vector2(XForce, YForce));
        if (isTargetRotation)
        {
            Vector2 len = GameObject.Find("Player").transform.position - transform.position; //���� ����
            float z = Mathf.Atan2(len.x, len.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, -z);
        }
        if (isLine)
        {
            lr = GetComponent<LineRenderer>();
            lr.startWidth = 0.5f;
            lr.endWidth = 0.5f;
        }


    }
    public void SetForce()
    {
        RB.AddForce(new Vector2(XForce, YForce));
    }
    void SetCircle()
    {
        circle.GetComponent<TrailRenderer>().enabled = true;
    }

    public void Udo() //����
    {
        if(clip != null && clip.Length>0)
            SoundManager.instance.SFXPlay("BossHit", clip[0]);
        RB.velocity = new Vector2(0, 0);
        Vector3 dirVec = GameObject.Find("Player").transform.position - transform.position;
        RB.AddForce(dirVec.normalized * speed, ForceMode2D.Impulse);
        Vector2 len = GameObject.Find("Player").transform.position - transform.position; //���� ����
        float z = Mathf.Atan2(len.x, len.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, -z);
    }
    public void InvokeUdo(float time,float speed1,bool isRotation)
    {
        Invoke("SetSpeed", time);
        Invoke("Udo", time);
        speedgo = speed1;
        if (!isRotation)
            Invoke("SetNotTurn", time);

    }
    public void SetNotTurn()
    {
        turnSpeed = 0;
    }

    public void SetSpeed()
    {
        speed = speedgo;
    }
    public void Udo1(int num) //����
    {
        Vector3 dirVec = LineTarget[num].transform.position - transform.position;
        RB.AddForce(dirVec.normalized * speed, ForceMode2D.Impulse);
        Vector2 len = transform.position - LineTarget[num].transform.position; //���� ����
        float z = Mathf.Atan2(len.x, len.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
    public void Udo2(int num) //����
    {
        Vector2 len = GameObject.Find("Player").transform.position - transform.position; //���� ����
        float z = Mathf.Atan2(len.x, len.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, -z+num);
        Quaternion v3Rotation = Quaternion.Euler(0f, -z + num, 0);  // ȸ����

        RB.AddForce(transform.up.normalized * speed, ForceMode2D.Impulse);
    }
    public void RandomGo() //����
    {
        Vector3 renVec = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10),0);
        RB.AddForce(renVec.normalized * speed, ForceMode2D.Impulse);
        Vector2 len = renVec; //���� ����
        float z = Mathf.Atan2(len.x, len.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
    public void RandomGo2() //�Ʒ��� ����
    {
        Vector3 renVec = new Vector3(Random.Range(-10, 10), Random.Range(-10, 0), 0);
        RB.AddForce(renVec.normalized * speed, ForceMode2D.Impulse);
        Vector2 len = renVec; //���� ����
        float z = Mathf.Atan2(len.x, len.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
    public void RandomGo3() //���� ����
    {
        Vector3 renVec = new Vector3(Random.Range(-10, 10), Random.Range(0, 10), 0);
        RB.AddForce(renVec.normalized * speed, ForceMode2D.Impulse);
        Vector2 len = renVec; //���� ����
        float z = Mathf.Atan2(len.x, len.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
    public void Go(int z) //����
    {
        transform.rotation = Quaternion.Euler(0, 0, z);
        Quaternion v3Rotation = Quaternion.Euler(0f, z, 0);  // ȸ����

        RB.AddForce(transform.up.normalized*speed, ForceMode2D.Impulse);

        //Vector3 v3Direction = Vector3.up; // ȸ����ų ����(�׽�Ʈ������ world forward ����)
        //Vector3 v3RotatedDirection = v3Rotation * v3Direction;
        //RB.AddForce(v3RotatedDirection.normalized * speed, ForceMode2D.Impulse);

    }



    void Update()
    {
        if (isRotationTarget)
        {
            Vector2 len = RB.velocity; //���� ����
            float z = Mathf.Atan2(len.x, len.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, -z);
        }
        if (isBeam)
        {
            Vector2 len = GameObject.Find("Player").transform.position- transform.position ; //���� ����
            float z = Mathf.Atan2(len.x, len.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, -z);
        }
        transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);//ȸ��
        if(!isGoToPlayer)
            RB.velocity = new Vector2(speed*transform.localScale.x, RB.velocity.y);
        Time1 -= 1;

        if (Time1 <= 0)
        {
            if (isBomb)//��ź�ϰ��
            {
                GetComponent<Animator>().SetBool("isBomb",true);
                Invoke("SetFalse", 1f);
                RB.velocity = new Vector2(0, 0);

                Time1 = 110;
                iBomb();
            }
            else
                gameObject.SetActive(false);
        }

        if (isLine)
        {
            lr.SetPosition(0, gameObject.GetComponent<Transform>().position);
            lr.SetPosition(1, LineTarget[0].transform.position);
        }
    }
    void iBomb()
    {
        if (Time1 > 50)
        {
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(Trans.transform.position, boxSize, 0);
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.gameObject.layer == 8)
                {
                    Player player = collider.GetComponent<Player>();
                    player.onDamaged(Trans.transform.position);
                    player.PlayerHp -= damage * 0.01f * (100 - player.Defense);
                }
            }

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && ishit == false && !ishitBomb) //�÷��̾����� �­�����
        {
            Player player = collision.GetComponent<Player>();
            player.onDamaged(transform.position);
            player.PlayerHp -= damage * 0.01f * (100 - player.Defense);
            gameObject.SetActive(false);
        }

        if(ishitBomb && ishit == false && (collision.gameObject.layer == 8 || ((collision.gameObject.layer == 6 || collision.gameObject.layer == 4) && !isNotBerk)))
        {
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(Trans.transform.position, boxSize, 0);
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.gameObject.layer == 8)
                {
                    Player player = collider.GetComponent<Player>();
                    player.onDamaged(Trans.transform.position);
                    player.PlayerHp -= damage * 0.01f * (100 - player.Defense);
                }
            }
            ishit = true;
            Invoke("SetFalse", 1f);
            GetComponent<Animator>().SetTrigger("isBomb");
            RB.velocity = new Vector2(0,0);
        }
        if (collision.gameObject.layer == 8  && isHitE) //�÷��̾����� �­�����
        {
            Player player = collision.GetComponent<Player>();
            player.onDamaged(transform.position);
            player.PlayerHp -= damage * 0.01f * (100 - player.Defense);
        }
    }
    void SetFalse()
    {
        ishit = false;
        gameObject.transform.position = GameObject.Find("Player").transform.position;
        gameObject.SetActive(false);
    }

    void OnDrawGizmos() //Ÿ�ݹڽ�
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(Trans.transform.position, boxSize); //Ÿ�ݹڽ� �������� ��
    }

    public void RePlay() //�ٽ� ��Ȱ
    {

    }
}
