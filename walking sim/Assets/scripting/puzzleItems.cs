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

    public void PickUpItem (puzzleScript.PuzzleItem item)
    {

        Debug.Log("Picked up:" + item);
        clueList.Add(item);
    }

    public void UseItem(puzzleScript.PuzzleItem item) {

        clueList.Remove(item);
    
    }

    public bool HasPiece(puzzleScript.PuzzleItem piece) { 

        return clueList.Contains(piece);
   
    }

    private void OnTriggerEnter(Collider collider)
    { if (Input.GetKeyDown(KeyCode.R)) {

            puzzleScript piece = collider.GetComponent<puzzleScript>();
            if (piece != null)
            {

                PickUpItem(piece.GetPuzzleItem());
                Destroy(piece.gameObject);


            }


        }
        
    }

}
