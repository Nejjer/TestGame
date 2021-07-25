using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpllectableItem : MonoBehaviour
{
    [SerializeField] private Item item;

    private void OnTriggerEnter(Collider other)
    {
        if (!item) return;

        var inventory = other.GetComponent<Inventory>();

        if (inventory)
        {
            inventory.AddItems(item);
            Destroy(gameObject);
        }
    }
}
