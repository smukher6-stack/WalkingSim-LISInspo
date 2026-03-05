using UnityEngine;

public class npcInteractable : interActable
{
    public NPCData nPCData;
    public override void Interact(playerMovement playermovement)
    {

        if (nPCData == null)
        {

            Debug.Log("npc has no data" + gameObject.name);
        }
        playermovement.RequestDialoge(nPCData);
    }
}

        
