using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class destroyInteractable : interActable
{
    public bool hasItem;

    public GameObject inventoryBar;
    public GameObject inventoryItem;
    public GameObject diaryPages;
    public Image inventoryImage;
    public Button inventoryButton;
    public puzzleScript script;

    public bool inventoryShow = false;

    private void Awake()
    {
        inventoryBar = GetComponent<GameObject>();
        inventoryItem = GetComponent<GameObject>();
        diaryPages = GetComponent<GameObject>();
        inventoryImage = GetComponent<Image>();
        inventoryButton = GetComponent<Button>();

    }

    public void CallInventory()
    {
        inventoryShow = true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Interact(playerMovement playermovement)
    {
        Debug.Log("Picked up: " + gameObject.name);
        hasItem = true;
        Destroy(gameObject);
        

    }
}
