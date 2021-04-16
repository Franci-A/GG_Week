using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();   
    }



    public void Resume()
    {
        gameManager.PauseToggle();
    }

    public void LoadMainMenu(string str)
    {
        gameManager.LoadScene(str);
    }
}
