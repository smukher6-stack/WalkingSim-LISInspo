using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class puzzleItems : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private List<puzzleScript.PuzzleItem> clueList;

    private void Awake()
    {
        clueList = new List<puzzleScript.PuzzleItem>();
    }

    public void PickUpItem(puzzleScript.PuzzleItem item)
    {

        Debug.Log("Picked up:" + item);
        clueList.Add(item);
    }

    public void UseItem(puzzleScript.PuzzleItem item)
    {

        clueList.Remove(item);
        Debug.Log("Solved");
    }

    public bool HasPiece(puzzleScript.PuzzleItem item)
    {

        return clueList.Contains(item);

    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("trigger is working");
        //if(collider.)
        puzzleScript item = collider.GetComponent<puzzleScript>();
        Debug.Log("component got");
        if (item != null)
        {
            Debug.Log("item acquitere");
            PickUpItem(item.GetPuzzleItem());
            Destroy(item.gameObject);


        }

        if (item == null)
        {
            Debug.Log("item is null");
        }

        puzzleSolver puzzlesolver = collider.GetComponent<puzzleSolver>();
        if (puzzlesolver != null)
        {

            if (HasPiece(puzzlesolver.GetPuzzleItem()))
            {
                UseItem(puzzlesolver.GetPuzzleItem());
                puzzlesolver.solvedIt();
                
            }
        }



    }

}
