using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private List<Button> icons = new List<Button>();

    public void UpdateUI(Inventory inventory)
    {
        for (int i = 0; i < icons.Count; i++)
        {

            if (inventory.TryGetItem(i))
            {
                icons[i].GetComponent<SpriteRenderer>().sprite = inventory.GetItem(i).icon;
                Debug.Log(inventory.GetItem(i));
            }
            else
            {
                Debug.Log("Try delete sprite");
                icons[i].GetComponent<SpriteRenderer>().sprite = null;

            }
        }
    }


}
