using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Layer
{
    public GameObject[] image;
    public float speed;
    public float endPosition;
    public float startPosition;
}

public class Parallax : MonoBehaviour
{
    private Transform player;
    [SerializeField] private List<Layer> layers;
    [SerializeField] private bool isMainMenu;

    private void Start()
    {
        if(!isMainMenu)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (isMainMenu)
        {
            foreach (Layer item in layers)
            {
                foreach (GameObject image in item.image)
                {

                    image.transform.Translate(new Vector2(2 * -1, 0) * item.speed * Time.deltaTime);
                    if (image.transform.position.x < item.endPosition)
                    {
                        image.transform.position = new Vector3(item.startPosition, image.transform.position.y, image.transform.position.z);
                    }

                }
            }
        }
        else if (player.GetComponent<movement>().parallaxMove)
        {
            foreach (Layer item in layers)
            {
                foreach (GameObject image in item.image)
                {
                    float speed = player.GetComponent<movement>().Currentspeed / player.GetComponent<movement>().Maxspeed;
                    image.transform.Translate(new Vector2(speed * -1, 0) * item.speed * Time.deltaTime);
                    if(image.transform.position.x < item.endPosition)
                    {
                        image.transform.position = new Vector3(item.startPosition, image.transform.position.y, image.transform.position.z);
                    }

                }
            }
        }
    }
}
