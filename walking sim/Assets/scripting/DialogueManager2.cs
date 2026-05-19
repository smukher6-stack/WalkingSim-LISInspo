using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using Ink.Parsed;


public class DialogueManager2 : interActable
{

    public DialogueStoryAsset storyAsset;
    

    public override void Interact(playerMovement playermovement)
    {
        if (storyAsset == null)
        {
            Debug.Log("so no knot?" + gameObject.name);
        }

        playermovement.RequestDialogue(storyAsset);
        
    }

 

    // Add your interaction logic here (e.g., OnMouseDown or a trigger)
    


}
