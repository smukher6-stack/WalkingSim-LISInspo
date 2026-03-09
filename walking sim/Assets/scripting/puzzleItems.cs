using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class puzzleItems : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private List<puzzleScript.PuzzleItem> clueList;

    private void Awake()
    {
        clueList = new List<puzzleScript.PuzzleItem>();
    }

    public void PickUpItem (puzzleScript.PuzzleItem item)
    {
        clueList.Add(item);
    }

    public void UseItem(puzzleScript.PuzzleItem item) {

        clueList.Remove(item);
    
    }



}
