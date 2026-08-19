using cherrydev;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    [SerializeField] private DialogBehaviour dialogBehaviour;
    [SerializeField] private DialogNodeGraph nodeGraph;

    public DialogNodeGraph dialogNodeGraph;

    private void Start()
    {
        dialogBehaviour.StartDialog(nodeGraph);
    }

    private playerMovement playermovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

}
