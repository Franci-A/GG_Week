using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    private SpriteRenderer sR;
    private bool IsPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // MOUVEMENTS

        transform.Translate(new Vector2(Input.GetAxis("Horizontal"), 0)*speed*Time.deltaTime);

        if (Input.GetAxis("Horizontal") < 0)
        {
            sR.flipX = true;
        }
        else if(Input.GetAxis("Horizontal") > 0)
        {
            sR.flipX = false;
        }

        // PAUSE

        if (Input.GetKeyDown(KeyCode.E))
        {
            IsPaused = !IsPaused;
            if (IsPaused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
            
            
        }
    }
}
