using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotInventoryButton : MonoBehaviour
{
    [SerializeField] GameObject _player;
    private bool _clicked = false;

    public void OnClick()
    {
        //Проверяет наличие предмета
        if (_player.GetComponent<Inventory>().TryGetItem(transform.GetSiblingIndex()))
        {


            if (!gameObject.GetComponent<Image>().fillCenter)
            {
                //Устанавливаем активный ITEM
                gameObject.GetComponent<Image>().fillCenter = true;
                _player.GetComponent<Inventory>().SetActiveItem(transform.GetSiblingIndex());

                _clicked = true;
            }
            else
            {
                gameObject.GetComponent<Image>().fillCenter = false;
                _player.GetComponent<Inventory>().UnSetActiveItem();

                _clicked = false;

            }



        }
        
    }

    public void DeactivationSlot()
    {
        gameObject.GetComponent<Image>().fillCenter = false;
    }
}
