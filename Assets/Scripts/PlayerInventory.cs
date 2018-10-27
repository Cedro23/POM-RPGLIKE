using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {

    private List<string> inventory = new List<string>();
    private int lenght = 10;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddItem(string _item)
    {
        if (inventory.Count < lenght)
        {
            inventory.Add(_item);
        }
        else
        {
            Debug.Log("Inventory is full");
        }
    }


}
