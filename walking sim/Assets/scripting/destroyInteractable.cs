using UnityEngine;

public class destroyInteractable : interActable
{
    public bool hasItem = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Interact(playerMovement playermovement)
    {
        Destroy(gameObject);
        Debug.Log("Picked up: " + gameObject.name);
        hasItem = true;

    }
}
