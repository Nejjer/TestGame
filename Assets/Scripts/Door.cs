using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] int _keyIndex;
    private Color _baseColor;

    private void Start()
    {
        _baseColor = gameObject.GetComponent<MeshRenderer>().material.color;
    }

    

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Inventory>(out Inventory inventory) && Input.GetKeyDown(KeyCode.E))
        {
            if (inventory.GetActiveItem())
            {
                if (inventory.GetActiveItem().key == _keyIndex)
                {
                    gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                    inventory.DeleteItem(inventory.GetActiveItem());
                    //Убираем активный эелемент(null)
                    inventory.UnSetActiveItem();

                }
                else
                {
                    //Убираем активный эелемент(null)
                    inventory.UnSetActiveItem();
                    StartCoroutine("ErrorKey");
                }
            }
        }
    }

    


    IEnumerator ErrorKey()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<MeshRenderer>().material.color = _baseColor;


    }
}
