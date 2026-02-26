using TMPro;
using UnityEngine;

public class dialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI displayName;
    public TextMeshProUGUI placeholderOpeningLine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnEnable()
    {
        playerMovement.OnDialogueReqested += StartDialogue;
    }

    public void OnDisable()
    {
        playerMovement.OnDialogueReqested -= StartDialogue;
    }

    void StartDialogue(NPCData nPCData)
    {
        if(nPCData == null)
        {
            Debug.Log("NPC DATA NULL");
        }

        if(dialoguePanel != null) dialoguePanel.SetActive(true);
        if (displayName != null) displayName.text = nPCData.displayName;
        if(placeholderOpeningLine != null) placeholderOpeningLine.text = nPCData.placeHolderOpeningLine;

        Debug.Log($"Dialogue start with {nPCData.displayName}: {nPCData.placeHolderOpeningLine}");
    }
}
