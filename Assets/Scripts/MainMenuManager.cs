using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] MainMenuUI;

    [Serializable]
    public enum UI
    {
        MainMenu,
        Option,
        Credits
    }
    public void ActivateMainMenuUI(int i)
    {
        switch (i) { 
            case 0:
                MainMenuUI[0].SetActive(true);
                MainMenuUI[1].SetActive(false);
                MainMenuUI[2].SetActive(false);
                break;
            case 1:
                MainMenuUI[0].SetActive(false);
                MainMenuUI[1].SetActive(true);
                MainMenuUI[2].SetActive(false);
                break;
            case 2:
                MainMenuUI[0].SetActive(false);
                MainMenuUI[1].SetActive(false);
                MainMenuUI[2].SetActive(true) ;
                break;
        }
    }
}
