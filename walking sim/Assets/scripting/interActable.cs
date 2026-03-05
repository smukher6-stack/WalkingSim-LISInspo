using UnityEngine;

public abstract class interActable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public abstract void Interact(playerMovement playermovement);
}
