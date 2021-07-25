using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Inventory : MonoBehaviour
{
    //list с имеющимися предметами
    // list with available items
    [SerializeField] private List<Item> items = new List<Item>();
    //Get UI panel with Inventory icon
    [SerializeField] private GameObject _invenroryUIPanel;

    [SerializeField] public UnityEvent OnInventoryChanged;

    //field for Active Item
    private Item _activeItem;

    //Add item in List and Update UI
    public void AddItems(Item item)
    {
        items.Add(item);
        Debug.Log("Added" + item);
        OnInventoryChanged.Invoke();
    }

    //Remove item from List and Update UI
    public void DeleteItem(Item i)
    {
        items.Remove(i);
        OnInventoryChanged.Invoke();
    }

    public void SetActiveItem(int index)
    {
        _activeItem = items[index];
        Debug.Log("Active Key:" + _activeItem.key);
    }

    
    public void UnSetActiveItem()
    {
        _activeItem = null;
        Debug.Log("Unset active key");
        //Деактивирует все слоты инвенторя
        //Deactivation all slots Inventory UI
        for (int i = 0; i < _invenroryUIPanel.transform.childCount; i++)
        {
            _invenroryUIPanel.transform.GetChild(i).GetComponent<SlotInventoryButton>().DeactivationSlot();
        }
    }

    public Item GetActiveItem()
    {
        return _activeItem;
    }

    //Возвращает true, если элемент существует, false, если его нет
    // Returns true if the element exists, false if it does not exist
    public bool TryGetItem(int i)
    {
        try
        {
            return(items[i]);
        }
        catch
        {
            return false;
        }
    }

    public Item GetItem(int i)
    {
        return items[i];
    }
    //return count items
    public int GetSize()
    {
        return items.Count;
    }

}
