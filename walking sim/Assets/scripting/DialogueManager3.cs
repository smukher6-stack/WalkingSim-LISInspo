using System;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public GameObject dialoguePanel;
    public TextMeshProUGUI displayName;
    public TextMeshProUGUI lineText;
    public Transform choicesContainer;//parent object where choice buttons will spawn
    public Button choiceButtonPrefab;
    private Story currentStory;
    private static DialogueManager instance;
    private playerMovement player;
    
    private DialogueStoryAsset assetStuff;
   
    private bool isActive;

    [SerializeField] private TextAsset inkJsonAsset;

    private void OnEnable()
    {
        playerMovement.OnDialogueRequested += StartStorySegment;
    }

    private void OnDisable()
    {
        playerMovement.OnDialogueRequested -= StartStorySegment;
    }



    private void Awake()
    {
        if (instance != null) Debug.LogWarning("Found more than one Dialogue Manager.");
        instance = this;

        isActive = false;

        if (dialoguePanel != null) dialoguePanel.SetActive(false);
       
        player = FindFirstObjectByType<playerMovement>();

       if(inkJsonAsset != null) currentStory = new Story(inkJsonAsset.text);

    }


    private void Update()
    {
        if (!isActive) return;
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (ChoicesAreShowing()) return; //block only when buttons exist
            ContinueStory();
        }
    }


    bool ChoicesAreShowing()
    {
        return choicesContainer != null && choicesContainer.childCount > 0;

        /*bool showing = choicesContainer != null && choicesContainer.childCount > 0;
        Debug.Log(showing);
        return;*/
    }

    public void StartStorySegment(DialogueStoryAsset asset)
    {
       

        if (asset.knotName != null)
        {

            isActive = true;
            if (dialoguePanel != null) dialoguePanel.SetActive(true);
            currentStory.ChoosePathString(asset.knotName);
        }
        else
        {
            Debug.Log("whoops no dialogue");
        }

      



        // Continue the story to get the first block of text
        ContinueStory();
    }

 
    

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            string text = currentStory.Continue();
            Debug.Log(text);
        }
    }


}
