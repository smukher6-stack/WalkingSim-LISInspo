using System;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;

public class puzzleItems : MonoBehaviour
{
    public event EventHandler OnNewPiece;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private List<puzzleScript.PuzzleItem> clueList;

    public ObjectGrabber grabber;
    private void Awake()
    {
        clueList = new List<puzzleScript.PuzzleItem>();

    }

    public List<puzzleScript.PuzzleItem> GetPuzzleItems() { return clueList; }


    public void PickUpItem(puzzleScript.PuzzleItem item)
    {
        
        
        Debug.Log("Picked up:" + item);
        clueList.Add(item);
        OnNewPiece?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem(puzzleScript.PuzzleItem item)
    {
        
        clueList.Remove(item);
        OnNewPiece?.Invoke(this, EventArgs.Empty);
        Debug.Log("Solved");
    }



    
    public bool HasPiece(puzzleScript.PuzzleItem item)
    {

        return clueList.Contains(item);

    }

    private void OnCollisionEnter(Collision collision)
    {
        ObjectGrabber grabber = GetComponent<ObjectGrabber>();
        Debug.Log("trigger is working");

       
        {
            puzzleScript item = GetComponent<puzzleScript>();
            Debug.Log("component got");
            if (grabber.isHolding && item != null)
            {
               
                Debug.Log("item acquitere");

                PickUpItem(item.GetPuzzleItem());
              


            }

            if (grabber.isHolding && item == null)
            {
                Debug.Log("item is null");
            }

        }
{
            


        }
       
        

        puzzleSolver puzzlesolver = GetComponent<puzzleSolver>();
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
