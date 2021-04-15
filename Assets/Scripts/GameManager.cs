using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool IsPaused = false;
    private bool GameOver = false;
    private string currentLevel;
    private string lastLevel;
    [SerializeField] private Animator myAnimation;

    private void Start()
    {
        ChangeScenes(0);
    }

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
        myAnimation.SetTrigger("Transition");
        Time.timeScale = 0;
        if (randomInt)
        {
            i = Random.Range(0, 5);
        }
        lastLevel = currentLevel;

        switch (i)
        {
            case 0:
                currentLevel = "Desert1";
                break;
            case 1:
                currentLevel = "Desert2";
                break;
            case 2:
                currentLevel = "DesertCity2";
                break;
            case 3:
                currentLevel = "DesertCity1";
                break;
            case 4:
                currentLevel = "SuperMarcher";
                break;
        }
    }

    public void LoadNewLevel()
    {
        if (lastLevel != null)
            SceneManager.UnloadSceneAsync(lastLevel);


        SceneManager.LoadScene(currentLevel, LoadSceneMode.Additive);
        Time.timeScale = 1;
    }
}
