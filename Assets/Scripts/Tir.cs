using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour
{
    public float MaxBullet;
    public float CurrentBullet;
    public GameObject bullet;
    private GameObject bulletClone;
    public Transform muzzle;
    [SerializeField] float reloadTime;
    [SerializeField] float bulletSpeed;
    private float cooldown;
    private SpriteRenderer sR;
    public GameObject UIBulletContainer;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(UIBulletContainer.transform.GetChild(4));
        cooldown = reloadTime;
        CurrentBullet = MaxBullet;
        sR = GetComponent<SpriteRenderer>();
        UpdateBullet();
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown <= 0 && Input.GetButtonDown("Fire1") && CurrentBullet > 0)
        {
            CurrentBullet--;
            UpdateBullet();
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
    public void UpdateBullet()
    {
        for (int i = 0; i < UIBulletContainer.transform.childCount; i++)
        {
           // Debug.Log(i);
            if (i >= CurrentBullet)
            {
                UIBulletContainer.transform.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                UIBulletContainer.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
