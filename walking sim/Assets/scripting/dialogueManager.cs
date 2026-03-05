using TMPro;
using UnityEditor.VisionOS;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI displayName;
    public TextMeshProUGUI lineText;

    public Transform choicesContainer; // choice button spawn parent
    public Button choiceButtonPrefab;//prefabs yayyyy

    private NPCData currentNode;
    private int lineIndex;
    private bool isTalking;

    private playerMovement playermovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnEnable()
    {
        playerMovement.OnDialogueReqested += StartDialogue;
    }

    public void OnDisable()
    {
        playerMovement.OnDialogueReqested -= StartDialogue;
    }

    private void Awake()
    {

        ClearChoices();

        if (dialoguePanel != null) dialoguePanel.SetActive(false);

        playermovement = FindFirstObjectByType<playerMovement>();
    }

    private void Update()
    {
        if (!isTalking) return;
        if(Keyboard.current != null && Keyboard.current.qKey.wasPressedThisFrame)
        {
            if (ChoicesAreShowing()) return;
            Advance();

        }
    }

    void StartDialogue(NPCData nPCData)
    {
        if (nPCData == null)
        {
            Debug.Log("NPC DATA NULL");
        }

        currentNode = nPCData;
        lineIndex = 0;
        isTalking = true;
        if (dialoguePanel != null)
        {

            dialoguePanel.SetActive(true);

        }

    }

    bool hasChoices(NPCData node)
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

        lineIndex++;
        if (currentNode.lines != null && lineIndex < currentNode.lines.Length)
        {
            if (lineText != null)
            {

                lineText.text = currentNode.lines[lineIndex];
                return;

            }
        }

        FinishNode();
    }



    void ShowChoices(DialogueChoice[] choices)
    {

        ClearChoices();
        if(choicesContainer == null || choiceButtonPrefab == null)
        {

            Debug.Log("choices are not wired");
            return;
        }

        foreach (DialogueChoice choice in choices)
        {

            Button button = Instantiate(choiceButtonPrefab, choicesContainer);

            TextMeshProUGUI tmp = button.GetComponentInChildren<TextMeshProUGUI>();

            if (tmp != null) tmp.text = choice.choiceX;

            NPCData next = choice.nextNode;
            button.onClick.AddListener(() =>
            {

                Choose(next);
            } );

            Debug.Log("choices are showing");
        }
    }
    void FinishNode()
    {

        if (hasChoices(currentNode))
        {
            ShowChoices(currentNode.choices);
            return;
            
        }

        if (currentNode.nextNode != null)
        {

            currentNode = currentNode.nextNode;
            lineIndex = 0;
            ShowLine();
            return;
        }

        EndDialogue();
    }

    void Choose(NPCData nextNode)
    {
        ClearChoices();

        if (nextNode == null)
        {

            EndDialogue();
            return;

        }

        currentNode = nextNode;
        lineIndex = 0;

    }

    void ShowLine()
    {

        ClearChoices();
        if (currentNode == null)
        {
            EndDialogue();
        }

        if (displayName != null) displayName.text = currentNode.displayName;
        if (currentNode.lines == null || currentNode.lines.Length == 0)
        {

            FinishNode();
            return;
        }

        lineIndex = Mathf.Clamp(lineIndex, 0, currentNode.lines.Length - 1);
        if(lineText != null) lineText.text = currentNode.lines[lineIndex];

    }
       
        
        bool ChoicesAreShowing()
        {
            return choicesContainer != null && choicesContainer.childCount > 0;

            //bool showing = choicesContainer != null && choicesContainer.childCount > 0;
            //Debug.Log(showing);
            //return;*
        }

        void ClearChoices()
        {

            if (choicesContainer == null) return;

            for (int i = choicesContainer.childCount - 1; i >= 0; i--)
            {

                Destroy(choicesContainer.GetChild(i).gameObject);
            }


        }
        void EndDialogue()
        {

            isTalking = false;
            currentNode = null;
            lineIndex = 0;

            ClearChoices();

            if (dialoguePanel != null) dialoguePanel.SetActive(false);
        }
    }


