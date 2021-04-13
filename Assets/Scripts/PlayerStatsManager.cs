using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsManager : MonoBehaviour
{
    public int maxValue = 100;

    [Header("Health")]
    [SerializeField] private Slider healthSlider;
    public int currentHealth;

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


    private void Start()
    {
        currentHealth = maxValue;
        currentFood = maxValue;
        currentWater = maxValue;

        healthSlider.maxValue = maxValue;
        foodSlider.maxValue = maxValue;
        waterSlider.maxValue = maxValue;
        UpdateSlider();
        StartCoroutine(FoodDecrease());
        StartCoroutine(WaterDecrease());
    }

    private void Update()
    {
        
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
                if (currentHealth < 0)
                {
                    //Death
                }
                break;
            case 1:
                currentFood -= amount;
                if (currentFood < 0)
                {
                    //Death
                }
                break;
            case 2:
                currentWater -= amount;
                if (currentWater < 0)
                {
                    //Death
                }
                break;
        }
        UpdateSlider();
    }

    private void DecreaseValue(int i)
    {
        switch (i)
        {
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
        yield return new WaitForSecondsRealtime(foodDropInterval);
        DecreaseValue(1);
    }
    
    IEnumerator WaterDecrease()
    {
        yield return new WaitForSecondsRealtime(waterDropInterval);
        DecreaseValue(2);
    }


    private void UpdateSlider()
    {
        healthSlider.value = currentHealth;
        foodSlider.value = currentFood;
        waterSlider.value = currentWater;
    }
}
