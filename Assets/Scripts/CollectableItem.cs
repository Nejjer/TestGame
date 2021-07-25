using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] private Item _item;

    private void OnTriggerEnter(Collider other)
    {
        //Проверка присутствия назначенного предмета
        //Checking for the presence of the assigned item
        if (!_item) return;
        //Checking for the presence Inventory.cs
        if (other.TryGetComponent<Inventory>(out Inventory inventory))
        {
            //Add item in Inventory and destroy
            Debug.Log("Try get item");
            inventory.AddItems(_item);
            Destroy(gameObject);
        }
    }
}
