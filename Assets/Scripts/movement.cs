using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float Maxspeed;
    public float Currentspeed;
    private SpriteRenderer sR;
    public bool parallaxMove;
    public GameObject FlecheBoussole;
    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // MOUVEMENTS
        Currentspeed = Maxspeed * Mathf.Cos(FlecheBoussole.GetComponent<Boussole>().currentRotation.eulerAngles.z * Mathf.PI / -180);
        transform.Translate(new Vector2(Currentspeed * Time.deltaTime, 0));
        if ((Currentspeed > 0 && this.transform.position.x < 0) || Input.GetAxis("Horizontal") < 0)
        {
            parallaxMove = false;
            
        } else if(Currentspeed > 0 && this.transform.position.x >= 0)
        {
            parallaxMove = true;
        }
        else
        {
            parallaxMove = false;
        }

        if (Currentspeed < 0)
        {
            sR.flipX = true;
        }
        else if(Currentspeed > 0)
        {
            sR.flipX = false;
        }

    }
}
