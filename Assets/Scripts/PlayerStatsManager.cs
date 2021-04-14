using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsManager : MonoBehaviour
{
    public int maxValue = 100;

    [Header("Health")]
    [SerializeField] private GameObject[] healthUI;
    public int currentHealth;
    [SerializeField] private int healthDropInterval;
    [SerializeField] private int foodHealthImpact;
    [SerializeField] private int waterHealthImpact;

    [Header("Food")]
    [SerializeField] private Slider foodSlider;
    public int currentFood;
    [SerializeField] private int foodDropRate = 5;
    [SerializeField] private float foodDropInterval = 5;

    [Header("Water")]
    [SerializeField] private Slider waterSlider;
    public int currentWater;
    [SerializeField] private int waterDropRate = 5;
    [SerializeField] private float waterDropInterval = 5;

    private bool noWater;
    private bool noFood;



    private void Start()
    {
        currentHealth = maxValue;
        currentFood = maxValue;
        currentWater = maxValue;

        foodSlider.maxValue = maxValue;
        waterSlider.maxValue = maxValue;
        UpdateSlider();
        StartCoroutine(FoodDecrease());
        StartCoroutine(WaterDecrease());
        StartCoroutine(HealthDecrease());
    }
    public void AddValue(int HFW, int amount) // health = 0 , food = 1, water = 2
    {
        switch (HFW)
        {
            case 0:
                currentHealth += amount;
                if (currentHealth > maxValue)
                    currentHealth = maxValue;
                break;
            case 1:
                currentFood += amount;
                if (currentFood > maxValue)
                    currentFood = maxValue;
                break;
            case 2:
                currentWater += amount;
                if (currentWater > maxValue)
                    currentWater = maxValue;
                break;
        }
        UpdateSlider();
    }

    public void RemoveValue(int HFW, int amount)// health = 0 , food = 1, water = 2
    {
        switch (HFW)
        {
            case 0:
                currentHealth -= amount;
                if (currentHealth <= 0)
                {
                    StopAllCoroutines();
                    GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().PlayerDied();
                    
                }
                break;
            case 1:
                currentFood -= amount;
                if (currentFood < 0)
                {
                    noFood = true;
                }
                else
                {
                    noFood = false;
                }
                break;
            case 2:
                currentWater -= amount;
                if (currentWater < 0)
                {
                    noWater = true;
                }
                else
                {
                    noWater = false;
                }
                break;
        }
        UpdateSlider();
    }

    private void DecreaseValue(int i)
    {
        switch (i)
        {
            case 0:
                if(noWater)
                    RemoveValue(0, waterHealthImpact);
                if(noFood)
                    RemoveValue(0, foodHealthImpact);
                UpdateSlider();
                StartCoroutine(HealthDecrease());
                break;
            case 1:
                RemoveValue(i, foodDropRate);
                UpdateSlider();
                StartCoroutine(FoodDecrease());
                break;
            case 2:
                RemoveValue(i, waterDropRate);
                UpdateSlider();
                StartCoroutine(WaterDecrease());
                break;

        }
    }

    IEnumerator FoodDecrease()
    {
        yield return new WaitForSeconds(foodDropInterval);
        DecreaseValue(1);
    }
    
    IEnumerator WaterDecrease()
    {
        yield return new WaitForSeconds(waterDropInterval);
        DecreaseValue(2);
    }
    
    IEnumerator HealthDecrease()
    {
        yield return new WaitForSeconds(healthDropInterval);
        DecreaseValue(0);
    }


    private void UpdateSlider()
    {
        for (int i = 0; i < 10 ; i++)
        {
            healthUI[i].SetActive(false);
        }
        for (int i = 0; i < (int)currentHealth/10 ; i++)
        {
            healthUI[i].SetActive(true);
        }
        foodSlider.value = currentFood;
        waterSlider.value = currentWater;
    }

}
