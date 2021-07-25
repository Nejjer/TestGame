using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
    //Key code.
    [SerializeField] int _keyIndex;

    private Color _baseColor;

    private void Start()
    {
        //Get base color to replace 
        _baseColor = gameObject.GetComponent<MeshRenderer>().material.color;
    }

    private void OnTriggerStay(Collider other)
    {
        //true if player stay
        if (other.TryGetComponent<Inventory>(out Inventory inventory) && Input.GetKey(KeyCode.E))
        {
            //if player have active item
            if (inventory.GetActiveItem())
            {
                //Проверяем совпадает ли Key Code двери и Key Code ключа, если совпадает, то красим дверь в зеленый, удаляем ключ из инвенторя и очищаем активный ключ
                // Check if the key code of the door and the key code of the key match, if it does, then paint the door green, remove the key from the inventory and clear the active item
                if (inventory.GetActiveItem().key == _keyIndex)
                {
                    gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                    inventory.DeleteItem(inventory.GetActiveItem());
                    //Remove active item(null)
                    //Убираем активный эелемент(null)
                    inventory.UnSetActiveItem();
                }
                else //Remove active item and paint door in red
                     //Убираем активный эелемент(null)
                {
                    inventory.UnSetActiveItem();
                    StartCoroutine("ErrorKey");
                }
            }
        }
    }

    IEnumerator ErrorKey() //Paint in red for 1 sec
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<MeshRenderer>().material.color = _baseColor;
    }
}
