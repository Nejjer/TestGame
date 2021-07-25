using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventorySlot
{
    public Item item;

    public InventorySlot(Item item)
    {
        this.item = item;
    }
}

public class Inventory : MonoBehaviour
{
    //list с имеющимися предметами
    [SerializeField] private List<Item> items = new List<Item>();
    [SerializeField] private GameObject _invenroryUIPanel;
    [SerializeField] public UnityEvent OnInventoryChanged;

    private Item _activeItem;

    public void AddItems(Item item)
    {
        items.Add(item);
        OnInventoryChanged.Invoke();
    }

    public void DeleteItem(Item i)
    {
        items.Remove(i);
        OnInventoryChanged.Invoke();
    }

    public void SetActiveItem(int index)
    {
        _activeItem = items[index];
        Debug.Log("Active Key" + _activeItem.key);
    }

    public void UnSetActiveItem()
    {
        _activeItem = null;
        Debug.Log("Unset active key");
        for (int i = 0; i < _invenroryUIPanel.transform.childCount; i++)
        {
            _invenroryUIPanel.transform.GetChild(i).GetComponent<SlotInventoryButton>().DeactivationSlot();
        }
    }

    public Item GetActiveItem()
    {
        return _activeItem;
    }


    //Возвращает true, если предмет существует, false, если его нет
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
    public int GetSize()
    {
        return items.Count;
    }

}
