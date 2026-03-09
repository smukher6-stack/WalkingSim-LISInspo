using UnityEngine;

public class puzzleScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private PuzzleItem puzzleItem;
    public enum PuzzleItem
    {
        Scissors,
        MemorialPhoto,
        EyePhoto,
        PillBottle

    }

    public PuzzleItem GetPuzzleItem () { return puzzleItem; }
}
