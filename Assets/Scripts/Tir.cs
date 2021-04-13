using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour
{
    public GameObject bullet;
    private GameObject bulletClone;
    public Transform muzzle;
    [SerializeField] float reloadTime;
    [SerializeField] float bulletSpeed;
    private float cooldown;
    private SpriteRenderer sR;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = reloadTime;
        sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown <= 0 && Input.GetButtonDown("Fire1"))
        {
            bulletClone = Instantiate(bullet, muzzle.position, Quaternion.identity);
            if (sR.flipX)
            {
                bulletClone.GetComponent<SpriteRenderer>().flipX = true;
                bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0);
            }
            else
            {
                bulletClone.GetComponent<SpriteRenderer>().flipX = false;
                bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
            }
            Destroy(bulletClone, 1.0f);
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }
}
