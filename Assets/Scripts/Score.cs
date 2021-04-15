using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    private float currentScore;
    [SerializeField] private float distanceMultiplier;
    private movement player;
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private int ChangeScenesScore;
    private int multiplier = 1;

    private void Start()
    {
        currentScore = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<movement>();
        scoreUI.text = "" + (int)currentScore;
    }

    private void Update()
    {
        if (player.parallaxMove && Time.timeScale != 0)
        {
            currentScore += (player.Currentspeed / player.Maxspeed) * distanceMultiplier;
            scoreUI.text = "" + (int)currentScore;
        }

        if(currentScore > ChangeScenesScore * multiplier)
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().ChangeScenes(0, true);
            multiplier++;
        }
    }
}
