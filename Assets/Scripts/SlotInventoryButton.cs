using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotInventoryButton : MonoBehaviour
{
    [SerializeField] GameObject _player;


    public void OnClick() //Set active Item in Inventory and fill center button
    {
        //Проверяет наличие предмета
        //Check if the item is present
        if (_player.GetComponent<Inventory>().TryGetItem(transform.GetSiblingIndex()))
        {
            if (!gameObject.GetComponent<Image>().fillCenter)
            {
                //Деактивация всех siblink слотов в UI инвенторя
                //Deactivation ALL siblink slots in Inventory UI
                for (int i = 0; i < transform.parent.transform.childCount; i++)
                {
                    transform.parent.transform.GetChild(i).GetComponent<SlotInventoryButton>().DeactivationSlot();
                }
                //Set active item in Inventory
                gameObject.GetComponent<Image>().fillCenter = true;
                _player.GetComponent<Inventory>().SetActiveItem(transform.GetSiblingIndex());
            }
            else
            {
                //Remove active item
                _player.GetComponent<Inventory>().UnSetActiveItem();
                gameObject.GetComponent<Image>().fillCenter = false;
            }



        }
        
    }

    public void DeactivationSlot()
    {
        gameObject.GetComponent<Image>().fillCenter = false;
    }
}
