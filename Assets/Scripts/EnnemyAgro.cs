using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyAgro : MonoBehaviour
{
    public int vie = 4;
    private float direction = 1;
    private SpriteRenderer skin;
    private Animator animatotor;
    [SerializeField]
    Transform player;
    [SerializeField]
    float agroRange;
    [SerializeField]
    float moveSpeed;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animatotor = GetComponent<Animator>();
        skin = GetComponent<SpriteRenderer>();
    }
    void Update()
    {

        if (vie > 0)
        {

            float disToPLayer = Vector2.Distance(transform.position, player.position);
            if (disToPLayer < agroRange)
            {
                ChasePlayer();
            }
            else
            {
                StopChasingPlayer();
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
        if (collision.gameObject.tag == "NormalBullet")
        {
            skin.color = new Color(1, 0, 0, 1);
            Debug.Log("touché");
            vie -= 1;
            StartCoroutine("attendre");

        }
        if (collision.gameObject.tag == "BigBullet")
        {
            skin.color = new Color(1, 0, 0, 1);
            vie -= 10;
            StartCoroutine("attendre");
        }
    }
    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
            skin.flipX = false;
            animatotor.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
        }
        else if (transform.position.x > player.position.x)
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
            skin.flipX = true;
            animatotor.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
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
        skin.color = new Color(1, 1, 1, 1);
    }
}
