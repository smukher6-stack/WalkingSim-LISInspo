using UnityEngine;

public class puzzleSolver : MonoBehaviour
{
    [SerializeField] private puzzleScript.PuzzleItem puzzleItem;
   
    private playerMovement playermovement;
    
    public puzzleScript.PuzzleItem GetPuzzleItem()
    {
        return puzzleItem;
    }

   


    public bool solvedIt()
    {
        Debug.Log("SOLVED IT");
        
        return true;
    }
}
