using UnityEngine;

public class inventoryManager : MonoBehaviour
{

    public GameObject inventoryBar;
    public GameObject slotPrefab;
    public int slotCount;
    public GameObject[] itemPrefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
    
    void Start()
    {
        for (int i = 0; i < slotCount; i++)
        {
           slotScript slot = Instantiate(slotPrefab, inventoryBar.transform).GetComponent<slotScript>();
            if (i < itemPrefabs.Length)
            {
                GameObject item = Instantiate(itemPrefabs[i], slot.transform);
                
                slot.currentItem = item;
            }

        }
    }

    public bool AddItem(GameObject itemPrefabs)
    {
        foreach (Transform slotTransform in inventoryBar.transform)
        {
            slotScript slot = slotTransform.GetComponent<slotScript>();
            if (slot != null && slot.currentItem != null)
            {
                GameObject newItem = Instantiate(itemPrefabs, slotTransform);
                slot.currentItem = newItem;
                return true;
            }
        }

        return false;
    }
    // Update is called once per frame
   
}
