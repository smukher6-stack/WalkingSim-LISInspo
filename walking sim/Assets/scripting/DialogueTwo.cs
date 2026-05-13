using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using System.Runtime.CompilerServices;

public class DialogueTwo : MonoBehaviour
{
    private static DialogueTwo instance;

    [SerializeField] public GameObject dialoguePanel;
    [SerializeField] public TextMeshProUGUI displayName;
   [SerializeField] public TextMeshProUGUI lineText;

    private Story currentStory;

    private bool dialoguePlaying;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("whoops there's two of them");
        }

        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public static DialogueTwo GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialoguePlaying = false;
        dialoguePanel.SetActive(false);
    }

    public void OnDialogueEnter(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialoguePlaying = true;
        dialoguePanel.SetActive(true);

        if (currentStory.canContinue)
        {
            lineText.text = currentStory.Continue();
        }
        else
        {
            EndOfStatement();
        }

       
    }

    private void EndOfStatement()
    {
        dialoguePlaying = false;
        dialoguePanel.SetActive(false);
        lineText.text = "";
    }
}
