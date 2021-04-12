using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzle;
    [SerializeField] float reloadTime;
    private float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = reloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown <= 0 && Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, muzzle.position, Quaternion.identity);
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }
}
