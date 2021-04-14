using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{

    public List<Items> inventory;
    [SerializeField] private int invSize;
    [SerializeField] private GameObject InvUI;
    private bool isInventoryOpen;
    private bool interactableInRange;
    private Interactables interactableObject;
    private bool interactableOpen;
    private PlayerStatsManager statsManager;
    private Tir playerTir;
    

    void Start()
    {
        inventory = new List<Items>();
        statsManager = this.GetComponent<PlayerStatsManager>();
        playerTir = this.GetComponent<Tir>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && interactableOpen && interactableInRange)
        {
            interactableOpen = false;
            interactableObject.CloseUI();
            
        }
        else if (Input.GetKeyDown(KeyCode.E)) //Open / close inventory
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


        if (Input.GetKeyDown(KeyCode.I) && isInventoryOpen)
        {
            if(inventory.Count > InvUI.GetComponent<OnScreenInventory>().posInv)
                UseItem(InvUI.GetComponent<OnScreenInventory>().posInv);
        }
        else if (Input.GetKeyDown(KeyCode.I) && interactableOpen)
        {
            if (inventory.Count < invSize && interactableObject.posInv < interactableObject.items.Count)
            {
                if (interactableObject.items[interactableObject.posInv].type != ItemType.Bullets && interactableObject.items[interactableObject.posInv] != null) {
                    inventory.Add(interactableObject.items[interactableObject.posInv]);
                    interactableObject.RemoveItem(interactableObject.posInv);
                }
                else if (playerTir.CurrentBullet < playerTir.MaxBullet && interactableObject.items[interactableObject.posInv] != null)
                {
                    playerTir.CurrentBullet += interactableObject.items[interactableObject.posInv].amount;
                    if (playerTir.CurrentBullet > playerTir.MaxBullet)
                        playerTir.CurrentBullet = playerTir.MaxBullet;
                    interactableObject.RemoveItem(interactableObject.posInv);
                    playerTir.UpdateBullet();
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.I) && interactableInRange)
        {
            interactableObject.OpenUI();
            interactableObject.UpdateUI();
            interactableOpen = true;

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
                statsManager.AddValue(0, inventory[i].amount);
                inventory.RemoveAt(i);
                Debug.Log("<3 <3");
                break;
            case ItemType.Food:
                statsManager.AddValue(1, inventory[i].amount);
                inventory.RemoveAt(i);
                Debug.Log("Miam miam");
                break;
            case ItemType.Drink:
                statsManager.AddValue(2, inventory[i].amount);
                inventory.RemoveAt(i);
                Debug.Log("Glu glu");
                break;
            case ItemType.Bullets:
                Debug.Log("pew pew");
                break;
            default:
                Debug.Log("you have nothing...");
                break;
        }
        InvUI.GetComponent<OnScreenInventory>().UpdateUI();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            interactableObject = collision.gameObject.GetComponent<Interactables>();
            interactableInRange = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            interactableInRange = false;
            interactableObject = null;
        }
    }
}
