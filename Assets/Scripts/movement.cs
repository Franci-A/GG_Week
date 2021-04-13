using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    private SpriteRenderer sR;
    public bool parallaxMove;
    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // MOUVEMENTS

        if ((Input.GetAxis("Horizontal") > 0 && this.transform.position.x < 0) || Input.GetAxis("Horizontal") < 0)
        {
            parallaxMove = false;
            transform.Translate(new Vector2(Input.GetAxis("Horizontal"), 0) * speed * Time.deltaTime);
        } else if(Input.GetAxis("Horizontal") > 0 && this.transform.position.x >= 0)
        {
            parallaxMove = true;
        }
        else
        {
            parallaxMove = false;
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            sR.flipX = true;
        }
        else if(Input.GetAxis("Horizontal") > 0)
        {
            sR.flipX = false;
        }

    }
}
