using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyAgro : MonoBehaviour
{
    public int vie = 4;
    float direction = 1;
    public int degats = 10;
    private float lastdamage;
    public float delaybtwdamage = 0.5f;
    private float cooldown = 0.5f;
    //SpriteRenderer skin;
    [SerializeField] Animator animatotor;
    Transform player;
    [SerializeField] float agroRangeIn;
    [SerializeField] float agroRangeOut;
    [SerializeField] float moveSpeed;
    Rigidbody2D rb;
    public bool chase = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        //animatotor = GetComponent<Animator>();
        //skin = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (lastdamage < delaybtwdamage)
        {
            lastdamage += Time.deltaTime;
        }

        if (vie > 0)
        {

            float disToPLayer = Vector2.Distance(transform.position, player.position);
            if (disToPLayer < agroRangeIn && player.GetComponent<movement>().Currentspeed > 3.0f)
            {
                chase = true;
            }
            if (chase)
            {
                ChasePlayer();
            }
            if(disToPLayer > agroRangeOut)
            {
                StopChasingPlayer();
                chase = false;
            }

        }
        if (vie <= 0)
        {
            gameObject.tag = "Untagged";
            animatotor.SetTrigger("dead");
            rb.mass = 1000f;
            GetComponent<CapsuleCollider2D>().size = new Vector2(1f, 2f);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //skin.color = new Color(1, 0, 0, 1);
            Debug.Log("touché");
            vie -= 1;
            StartCoroutine("attendre");
        }
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" &&  lastdamage > delaybtwdamage)
        {
            Debug.Log("attaque!");
            player.GetComponent<PlayerStatsManager>().RemoveValue(0, degats);
            animatotor.SetTrigger("attack");
            lastdamage = 0;
        }
    }
    void ChasePlayer()
    {
        if (transform.position.x < player.position.x - 1)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            //animatotor.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
        }
        else if (transform.position.x > player.position.x + 1)
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            //animatotor.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
        }
        else
        {
            transform.localScale = transform.localScale;
            rb.velocity = new Vector2(0, 0);
            /*if(transform.position.x == player.position.x - 1)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }*/
            
            //animatotor.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
        }

    }
    void StopChasingPlayer()
    {
        rb.velocity = new Vector2(0, 0);
        animatotor.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
    }
    void detruire()
    {
        gameObject.SetActive(false);
    }
    IEnumerator attendre()
    {
        yield return new WaitForSeconds(0.05f);
        //skin.color = new Color(1, 1, 1, 1);
    }
}
