using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boussole : MonoBehaviour
{
    Vector3 currentEulerAngles;
    public Quaternion currentRotation;
    private void Start()
    {
        currentEulerAngles = new Vector3(0, 0, 90);
        currentRotation.eulerAngles = currentEulerAngles;
        transform.rotation = currentRotation;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            currentEulerAngles += new Vector3(0, 0, 10);

            //moving the value of the Vector3 into Quanternion.eulerAngle format
            currentRotation.eulerAngles = currentEulerAngles;

            //apply the Quaternion.eulerAngles change to the gameObject
            transform.rotation = currentRotation;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            currentEulerAngles -= new Vector3(0, 0, 10);

            //moving the value of the Vector3 into Quanternion.eulerAngle format
            currentRotation.eulerAngles = currentEulerAngles;

            //apply the Quaternion.eulerAngles change to the gameObject
            transform.rotation = currentRotation;
        }
        Debug.Log(Mathf.Cos(currentRotation.eulerAngles.z * Mathf.PI / -180));
    }
}
