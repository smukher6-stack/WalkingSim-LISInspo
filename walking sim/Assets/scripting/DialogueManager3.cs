using Ink.Runtime;
using TMPro;
using UnityEngine;
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

 

    private void Awake()
    {
        if (instance != null) Debug.LogWarning("Found more than one Dialogue Manager.");
        instance = this;

        if (dialoguePanel != null) dialoguePanel.SetActive(false);
        player = FindFirstObjectByType<playerMovement>();
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }


  
    public void StartStorySegment(string knotName)
    {


        // Tell the Ink runtime to jump to the assigned knot
        currentStory.ChoosePathString(knotName);

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
