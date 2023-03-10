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

    public int time; //제한시간
    public int Time1;

    public float turnSpeed;
    public bool isGoToPlayer; //유도되는지안되면 긔냥 x축으로 이동


    public bool ishit; //타격체크
    public bool isBomb; //시간있다 폭발하는지
    public bool ishitBomb; //플레이어한테 부딫히면 폭발하는지
    public bool isTargetRotation; //플레이어 방향을 향하는지
    public GameObject Trans;

    public float XForce;
    public float YForce;

    public bool isNotBerk; //벽에맞는지

    public Vector2 boxSize; //공격박스

    public bool isBeam; //각도유도하는지
    public bool isHitE; //맞ㅇ면 사라진ㄴ지

    public bool isLine;
    public bool isRotationTarget; //방향에 맞게 회전

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
            Vector2 len = GameObject.Find("Player").transform.position - transform.position; //방향 유도
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

    public void Udo() //유도
    {
        if(clip != null && clip.Length>0)
            SoundManager.instance.SFXPlay("BossHit", clip[0]);
        RB.velocity = new Vector2(0, 0);
        Vector3 dirVec = GameObject.Find("Player").transform.position - transform.position;
        RB.AddForce(dirVec.normalized * speed, ForceMode2D.Impulse);
        Vector2 len = GameObject.Find("Player").transform.position - transform.position; //방향 유도
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
    public void Udo1(int num) //유도
    {
        Vector3 dirVec = LineTarget[num].transform.position - transform.position;
        RB.AddForce(dirVec.normalized * speed, ForceMode2D.Impulse);
        Vector2 len = transform.position - LineTarget[num].transform.position; //방향 유도
        float z = Mathf.Atan2(len.x, len.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
    public void Udo2(int num) //유도
    {
        Vector2 len = GameObject.Find("Player").transform.position - transform.position; //방향 유도
        float z = Mathf.Atan2(len.x, len.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, -z+num);
        Quaternion v3Rotation = Quaternion.Euler(0f, -z + num, 0);  // 회전각

        RB.AddForce(transform.up.normalized * speed, ForceMode2D.Impulse);
    }
    public void RandomGo() //랜덤
    {
        Vector3 renVec = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10),0);
        RB.AddForce(renVec.normalized * speed, ForceMode2D.Impulse);
        Vector2 len = renVec; //방향 유도
        float z = Mathf.Atan2(len.x, len.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
    public void RandomGo2() //아래로 랜덤
    {
        Vector3 renVec = new Vector3(Random.Range(-10, 10), Random.Range(-10, 0), 0);
        RB.AddForce(renVec.normalized * speed, ForceMode2D.Impulse);
        Vector2 len = renVec; //방향 유도
        float z = Mathf.Atan2(len.x, len.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
    public void RandomGo3() //위로 랜덤
    {
        Vector3 renVec = new Vector3(Random.Range(-10, 10), Random.Range(0, 10), 0);
        RB.AddForce(renVec.normalized * speed, ForceMode2D.Impulse);
        Vector2 len = renVec; //방향 유도
        float z = Mathf.Atan2(len.x, len.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
    public void Go(int z) //각도
    {
        transform.rotation = Quaternion.Euler(0, 0, z);
        Quaternion v3Rotation = Quaternion.Euler(0f, z, 0);  // 회전각

        RB.AddForce(transform.up.normalized*speed, ForceMode2D.Impulse);

        //Vector3 v3Direction = Vector3.up; // 회전시킬 벡터(테스트용으로 world forward 썼음)
        //Vector3 v3RotatedDirection = v3Rotation * v3Direction;
        //RB.AddForce(v3RotatedDirection.normalized * speed, ForceMode2D.Impulse);

    }



    void Update()
    {
        if (isRotationTarget)
        {
            Vector2 len = RB.velocity; //방향 유도
            float z = Mathf.Atan2(len.x, len.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, -z);
        }
        if (isBeam)
        {
            Vector2 len = GameObject.Find("Player").transform.position- transform.position ; //방향 유도
            float z = Mathf.Atan2(len.x, len.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, -z);
        }
        transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);//회전
        if(!isGoToPlayer)
            RB.velocity = new Vector2(speed*transform.localScale.x, RB.velocity.y);
        Time1 -= 1;

        if (Time1 <= 0)
        {
            if (isBomb)//폭탄일경우
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
        if (collision.gameObject.layer == 8 && ishit == false && !ishitBomb) //플레이어한테 맞췃을때
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
        if (collision.gameObject.layer == 8  && isHitE) //플레이어한테 맞췃을때
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

    void OnDrawGizmos() //타격박스
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(Trans.transform.position, boxSize); //타격박스 있을때만 씀
    }

    public void RePlay() //다시 부활
    {

    }
}
