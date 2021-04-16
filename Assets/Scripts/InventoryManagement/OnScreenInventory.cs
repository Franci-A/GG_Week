using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.UI;

public class OnScreenInventory : MonoBehaviour
{

    [SerializeField] private GameObject[] inventorySlots;
    [SerializeField] private SpriteLibraryAsset itemAssets;
    [SerializeField] private InventoryManager playerInventory;
    public int posInv;
    private bool isUpdatingPos = false;

    private void Start()
    {
        //  playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
        UpdateSelected();
    }

    private void Update()
    {
        if(Input.GetAxis("Horizontal") >0 && !isUpdatingPos)
        {
            isUpdatingPos = true;
            posInv++;
            if (posInv > inventorySlots.Length -1)
            {
                posInv = 0;
            }
            UpdateSelected();
        }
        else if (Input.GetAxis("Horizontal") <0 && !isUpdatingPos)
        {
            isUpdatingPos = true;
            posInv--;
            if (posInv < 0)
            {
                posInv = inventorySlots.Length -1;
            }
            UpdateSelected();
        }

        if (Input.GetAxis("Horizontal") ==0)
        {
            isUpdatingPos = false;
        }
    }

    public void UpdateUI()
    {
        for (int i = 0; i < 5; i++)
        {
            if ( i >= playerInventory.inventory.Count)
            {
                inventorySlots[i].GetComponent<Image>().sprite = itemAssets.GetSprite("Consumables", "Empty");
            }
            else
            {
                string str = playerInventory.inventory[i].type.ToString();
                Debug.Log(str);
                inventorySlots[i].GetComponent<Image>().sprite = itemAssets.GetSprite("Consumables", str);
            }
        }
    }

    private void UpdateSelected()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if(posInv == i)
            {
                inventorySlots[i].GetComponent<Outline>().effectColor = Color.red;
            }
            else
            {
                inventorySlots[i].GetComponent<Outline>().effectColor = Color.clear;

            }
        }
    }
}
