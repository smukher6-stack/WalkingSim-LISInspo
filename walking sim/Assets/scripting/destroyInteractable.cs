using UnityEngine;

public class destroyInteractable : interActable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Interact(playerMovement playermovement)
    {
        Destroy(gameObject);
        Debug.Log("Destroyed: " + gameObject.name);
    }
}
