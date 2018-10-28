using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{

    private List<string> inventory = new List<string>();
    private int lenght = 10;

    private int stoneQuant;
    private int ironQuant;
    private int goldQuant;
    private int total;

    public bool IsFull{ get; set; }

    private void Start()
    {
        UpdateTotal();
        UpdateDisplayedInventory();
    }

    private void UpdateTotal()
    {
        total = 0;
        total = stoneQuant + ironQuant + goldQuant;
        if (total >= lenght)
        {
            GameObject.Find("Total").GetComponentInChildren<Text>().color = Color.red;
            IsFull = true;
        }
    }

    private void UpdateDisplayedInventory()
    {
        GameObject.Find("Stone").GetComponentInChildren<Text>().text = stoneQuant.ToString();
        GameObject.Find("Iron").GetComponentInChildren<Text>().text = ironQuant.ToString();
        GameObject.Find("Gold").GetComponentInChildren<Text>().text = goldQuant.ToString();
        GameObject.Find("Total").GetComponentInChildren<Text>().text = total.ToString() + "/" + lenght;
    }

    public void AddItem(string _item)
    {
        if (!IsFull)
        {
            inventory.Add(_item);

            switch (_item)
            {
                case "Stone":
                    stoneQuant++;
                    break;
                case "Iron":
                    ironQuant++;
                    break;
                case "Gold":
                    goldQuant++;
                    break;
                default:
                    break;
            }

            UpdateTotal();
            UpdateDisplayedInventory();
        }
    }
}
