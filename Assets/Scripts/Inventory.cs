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
    //list � ���������� ����������
    [SerializeField] private List<Item> items = new List<Item>();

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
        Debug.Log(_activeItem.key);
    }
    public void UnSetActiveItem()
    {
        _activeItem = null;
    }
    public Item GetActiveItem()
    {
        return _activeItem;
    }


    //���������� true, ���� ������� ����������, false, ���� ��� ���
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
