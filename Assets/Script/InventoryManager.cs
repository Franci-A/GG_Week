using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{

    public List<Items> inventory;
    [SerializeField] private int invSize;
    [SerializeField] private GameObject InvUI;
    private bool isInventoryOpen;

    void Start()
    {
        inventory = new List<Items>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E)) //Open / close inventory
        {
            if (!isInventoryOpen)
            {
                InvUI.SetActive(true);
                InvUI.GetComponent<OnScreenInventory>().UpdateUI();
                isInventoryOpen = true;
            }
            else
            {
                InvUI.SetActive(false);
                isInventoryOpen = false;
            }
            
        }

        
        if (Input.GetKeyDown(KeyCode.I) && !isInventoryOpen)
        {
            Debug.Log("pickup");
            Items test = new Items(ItemType.Drink, 1);
            PickUp(test);
            test = new Items(ItemType.Bullets, 1);
            PickUp(test);
            test = new Items(ItemType.Food, 1);
            PickUp(test);
            test = new Items(ItemType.Heal, 1);
            PickUp(test);
        }else if (Input.GetKeyDown(KeyCode.I) && isInventoryOpen)
        {
            UseItem(InvUI.GetComponent<OnScreenInventory>().posInv);
        }
    }

    public void PickUp(Items items)
    {
        if (inventory.Count < invSize)
        {
            inventory.Add(items);
        }
    }

    public void UseItem(int i)
    {
        switch (inventory[i].type)
        {
            case ItemType.Heal:
                inventory.Remove(inventory[i]);
                Debug.Log("<3 <3");
                break;
            case ItemType.Food:
                inventory.Remove(inventory[i]);
                Debug.Log("Miam miam");
                break;
            case ItemType.Drink:
                inventory.Remove(inventory[i]);
                Debug.Log("Glu glu");
                break;
            case ItemType.Bullets:
                inventory.Remove(inventory[i]);
                Debug.Log("pew pew");
                break;
            default:
                Debug.Log("you have nothing...");
                break;
        }
        InvUI.GetComponent<OnScreenInventory>().UpdateUI();

    }
}
