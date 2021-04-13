using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.UI;

public class Interactables : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject[] inventorySlots;
    [SerializeField] private SpriteLibraryAsset itemAssets;
    public int posInv;
    private bool isUpdatingPos = false;
    public List<Items> items;


    private void Start()
    {
        items = new List<Items>();
        items.Add(new Items(ItemType.Drink, 1));
        items.Add(new Items(ItemType.Food, 1));
        UpdateSelected();
    }

    public void RemoveItem(int i)
    {
        items.RemoveAt(i);
        if (items.Count == 0)
        {
            Destroy(this.gameObject);
        }else
            UpdateUI();
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
                posInv = inventorySlots.Length;
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
        for (int i = 0; i < 2; i++)
        {
            if (i > items.Count)
            {
                inventorySlots[i].GetComponent<Image>().sprite = itemAssets.GetSprite("Consumables", "Empty");
            }
            else
            {
                string str = items[i].type.ToString();
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
                inventorySlots[i].GetComponent<Outline>().effectDistance = new Vector2(3, -3);
            }
            else
            {
                inventorySlots[i].GetComponent<Outline>().effectDistance = new Vector2(0, 0);

            }
        }
    }

    public void OpenUI()
    {
        UI.SetActive(true);
    }

    public void CloseUI()
    {
        UI.SetActive(false);
    }
}
