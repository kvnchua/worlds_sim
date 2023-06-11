using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeField]
    private Inventory characterInventory;

    [SerializeField]
    private GameObject objectInteracting;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && objectInteracting != null)
        {
            Item item = objectInteracting.GetComponent<Item>();
            if (item != null)
            {
                characterInventory.AddItem(item);
                objectInteracting = null;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            objectInteracting = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            objectInteracting = null;
        }
    }
}
