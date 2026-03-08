using UnityEngine;

public class objectInteract : interActable
{
    public ObjectData data;

    public override void Interact(playerMovement playermovement)
    {
        if (data != null) {

            Debug.Log("object has no data" + gameObject.name);

        }

        playermovement.ObjectDescription(data);
    }


}


