using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Layer
{
    public GameObject image;
    public GameObject imageLoop;
    public float speed;
    public float endPosition;
    public float startPosition;
}

public class Parallax : MonoBehaviour
{
    private Transform player;
    [SerializeField] private List<Layer> layers;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (player.GetComponent<movement>().parallaxMove)
        {
            foreach (Layer item in layers)
            {
                item.image.transform.Translate(new Vector2(Input.GetAxis("Horizontal") *-1, 0) * item.speed * Time.deltaTime);
                item.imageLoop.transform.Translate(new Vector2(Input.GetAxis("Horizontal") *-1, 0) * item.speed * Time.deltaTime);
                if(item.image.transform.position.x < item.endPosition)
                {
                    item.image.transform.position = new Vector3(item.startPosition, item.image.transform.position.y, item.image.transform.position.z);
                }
                
                if(item.imageLoop.transform.position.x < item.endPosition)
                {
                    item.imageLoop.transform.position = new Vector3(item.startPosition, item.imageLoop.transform.position.y, item.imageLoop.transform.position.z);
                }
            }
        }
    }
}
