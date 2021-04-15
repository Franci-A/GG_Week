using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool IsPaused = false;
    private bool GameOver = false;
    private string currentLevel;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            PauseToggle();

        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    public void PlayerDied()
    {
        if (!GameOver)
        {
            GameOver = true;
            Time.timeScale = 0;
            SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
        }
    }

    public void PauseToggle()
    {
       
        if (!IsPaused)
        {
            IsPaused = true;
            Time.timeScale = 0;
            SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
        }
        else
        {
            IsPaused = false;
            Time.timeScale = 1;
            SceneManager.UnloadSceneAsync("Pause");
        }
    }

    public void ChangeScenes(int i, bool randomInt = false)
    {
        if (randomInt)
        {
            i = Random.Range(0, 5);
        }
        SceneManager.UnloadSceneAsync(currentLevel);
        switch (i)
        {
            case 0:
                SceneManager.LoadScene("Desert1", LoadSceneMode.Additive);
                currentLevel = "Desert1";
                break;
            case 1:
                SceneManager.LoadScene("Desert1", LoadSceneMode.Additive);
                currentLevel = "Desert1";
                break;
            case 2:
                SceneManager.LoadScene("Desert1", LoadSceneMode.Additive);
                currentLevel = "Desert1";
                break;
            case 3:
                SceneManager.LoadScene("Desert1", LoadSceneMode.Additive);
                currentLevel = "Desert1";
                break;
            case 4:
                SceneManager.LoadScene("Desert1", LoadSceneMode.Additive);
                currentLevel = "Desert1";
                break;
        }
    }
}
