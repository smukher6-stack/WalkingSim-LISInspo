using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class descriptionManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject descriptionPanel;
    public TextMeshProUGUI objectName;
    public TextMeshProUGUI objectDescription;
    private playerMovement playermovement;
    public Transform inventoryCheck; // choice button spawn parent
    public Button objectButtonPrefab;
    private ObjectData currentNode;
    private int lineSort;
    private bool isLooking;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnEnable()
    {
        playerMovement.OnObjectDescripton += DescribeObject;
    }

    public void OnDisable()
    {
        playerMovement.OnObjectDescripton -= DescribeObject;
    }

    
    private void Awake()
    {

        ClearChoices();

        if (descriptionPanel != null) descriptionPanel.SetActive(false);

        playermovement = FindFirstObjectByType<playerMovement>();
    }

    private void Update()
    {
        if (!isLooking) return;
        if (Keyboard.current != null && Keyboard.current.qKey.wasPressedThisFrame)
        {
            if (ChoicesAreShowing()) return;
            Advance();

        }
    }

    public void DescribeObject(ObjectData data)
    {
        if (data == null)
        {
            Debug.Log("NPC DATA NULL");
            return;
        }

        if (playermovement != null) playermovement.SetControlIsLocked(true);
        currentNode = data;
        lineSort = 0;
        isLooking = true;
        if (descriptionPanel != null)
        {

            descriptionPanel.SetActive(true);

        }
        ShowLine();
    }

    bool hasChoices(ObjectData node)
    {
        return node != null && node.choices != null && node.choices.Length > 0;
    }

    void Advance()
    {
        if (currentNode == null)
        {
            EndDialogue();
            return;
        }

        lineSort++;
        if (currentNode.lines != null && lineSort < currentNode.lines.Length)
        {
            if (objectDescription != null)
            {

                objectDescription.text = currentNode.lines[lineSort];
                return;

            }
        }

        FinishNode();
    }



    public void ShowChoices(ObjectChoice[] choices)
    {

        ClearChoices();
        if (inventoryCheck == null || objectButtonPrefab == null)
        {

            Debug.Log("choices are not wired");
            return;
        }

        foreach (ObjectChoice choice in choices)
        {

            Button button = Instantiate(objectButtonPrefab, inventoryCheck);
            Debug.Log("button");

            TextMeshProUGUI tmp = button.GetComponentInChildren<TextMeshProUGUI>();

            if (tmp != null) tmp.text = choice.choiceX;

            ObjectData next = choice.objectNode;
            button.onClick.AddListener(() =>
            {

                Choose(next);
            });

            Debug.Log("choices ");
        }
    }
    void FinishNode()
    {

        if (hasChoices(currentNode))
        {
            ShowChoices(currentNode.choices);
            return;

        }

        if (currentNode.objectNode != null)
        {

            currentNode = currentNode.objectNode;
            lineSort = 0;
            ShowLine();
            return;
        }

        EndDialogue();
        
    }

    void Choose(ObjectData objectNode)
    {
        ClearChoices();

        if (objectNode == null)
        {

            EndDialogue();
            return;

        }

        currentNode = objectNode;
        lineSort = 0;
        ShowLine();

    }

    void ShowLine()
    {

        ClearChoices();
        if (currentNode == null)
        {
            EndDialogue();
        }

        if (objectName != null) objectName.text = currentNode.objectName;
        if (currentNode.lines == null || currentNode.lines.Length == 0)
        {

            FinishNode();
            return;
        }

        lineSort = Mathf.Clamp(lineSort, 0, currentNode.lines.Length - 1);
        if (objectDescription != null) objectDescription.text = currentNode.lines[lineSort];

    }


    bool ChoicesAreShowing()
    {
        return inventoryCheck != null && inventoryCheck.childCount > 0;


    }

    void ClearChoices()
    {

        if (inventoryCheck == null) return;

        for (int i = inventoryCheck.childCount - 1; i >= 0; i--)
        {

            Destroy(inventoryCheck.GetChild(i).gameObject);
        }


    }
    void EndDialogue()
    {

        if (playermovement != null) playermovement.SetControlIsLocked(false);

        isLooking = false;
        currentNode = null;
        lineSort = 0;

        ClearChoices();

        if (descriptionPanel != null) descriptionPanel.SetActive(false);
    }
}
