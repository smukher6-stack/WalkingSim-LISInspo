using System.Runtime.InteropServices.WindowsRuntime;
using cherrydev;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour
{
    

   

    private DialogNodeGraph currentNode;
    private int lineIndex;
    private bool isTalking;
    public StartDialogue startDialogue;


    private playerMovement playermovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnEnable()
    {
        playerMovement.OnDialogueReqested += StartDialogueFunc;
    }

    public void OnDisable()
    {
        playerMovement.OnDialogueReqested -= StartDialogueFunc;
    }

    private void Awake()
    {

       playermovement = FindFirstObjectByType<playerMovement>();
    }

   

    private void StartDialogueFunc(DialogNodeGraph dialogNodeGraph)
    {
        if (dialogNodeGraph == null)
        {
            Debug.Log("NPC DATA NULL");
            return;
        }

      playermovement.SetControlIsLocked(true);
        currentNode = dialogNodeGraph;
        lineIndex = 0;
        isTalking = true;

       
    }

    
    }


