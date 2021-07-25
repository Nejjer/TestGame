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
