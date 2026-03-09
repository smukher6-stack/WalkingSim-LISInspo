using UnityEngine;

public class PlayerItemCollector : MonoBehaviour
{

    private inventoryManager inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory = FindAnyObjectByType<inventoryManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("puzzle piece"))
        {
            slotScript item = collision.GetComponent<slotScript>();
            if (item != null)
            {

                bool itemAdded = inventory.AddItem(collision.gameObject);
                if (itemAdded)
                {
                    Destroy(collision.gameObject);
                }
            }

        }
    }
}
