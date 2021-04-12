using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    private SpriteRenderer sR;
    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(Input.GetAxis("Horizontal"), 0)*speed*Time.deltaTime);

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
