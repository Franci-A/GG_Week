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
    [SerializeField] private Animator playerAnimator;
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

        if(Currentspeed > -.3  && Currentspeed < .3)
            playerAnimator.SetBool("IsWalking", false);
        else
            playerAnimator.SetBool("IsWalking", true);

        if ((Currentspeed > 0 && this.transform.position.x < 0) || Currentspeed < 0)
        {
            transform.Translate(new Vector2(Currentspeed * Time.deltaTime, 0));
            parallaxMove = false;
            
        } else if(Currentspeed > 0 && this.transform.position.x >= 0)
        {
            parallaxMove = true;

        }
        else
        {
            transform.Translate(new Vector2(Currentspeed * Time.deltaTime, 0));
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
