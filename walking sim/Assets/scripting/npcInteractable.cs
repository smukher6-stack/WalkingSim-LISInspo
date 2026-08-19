using cherrydev;
using UnityEngine;

public class npcInteractable : interActable
{
    public DialogNodeGraph dialogNodeGraph;
    public override void Interact(playerMovement playermovement)
    {

        if (dialogNodeGraph == null)
        {

            Debug.Log("npc has no data" + gameObject.name);
        }
<<<<<<< Updated upstream
        playermovement.RequestDialogue(nPCData);
=======
        playermovement.RequestDialogue(dialogNodeGraph);
>>>>>>> Stashed changes
    }
}

        
