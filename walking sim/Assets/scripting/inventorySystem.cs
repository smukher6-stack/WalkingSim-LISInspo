using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class inventorySystem : MonoBehaviour
{
    public GameObject inventoryBar;
    public GameObject inventoryItem;
    public GameObject diaryPages;
    public Image inventoryImage;
    public Button inventoryButton;
    public puzzleScript script;

    
    void Awake()
    {
        inventoryBar = GetComponent<GameObject>();
        inventoryItem = GetComponent<GameObject>();
        diaryPages = GetComponent<GameObject>();
        inventoryImage = GetComponent<Image>();
        inventoryButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void InventoryTab()
    {

    }
}
