using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    //Get array with inventory slots(button)
    [SerializeField] private List<Button> slots = new List<Button>();

    //Размещает присутствующие ключи в инвенторе
    // Places the keys present in the inventor
    public void UpdateUI(Inventory inventory)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (inventory.TryGetItem(i))
            {
                //Set Icon key in inventory UI
                slots[i].GetComponent<SpriteRenderer>().sprite = inventory.GetItem(i).icon;
                Debug.Log(inventory.GetItem(i));
            }
            else
            {
                slots[i].GetComponent<SpriteRenderer>().sprite = null;
                Debug.Log("Delete sprite");
            }
        }
    }


}
