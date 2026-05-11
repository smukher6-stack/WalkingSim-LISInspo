using System.Collections.Generic;
using Ink.Parsed;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleUI : MonoBehaviour

{
    [SerializeField] private puzzleItems m_items;
    private Transform container;
    private Transform puzzlePiece;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        container = transform.Find("container");
        puzzlePiece = container.Find("puzzle piece");
        puzzlePiece.gameObject.SetActive(false);
    }

    private void Start()
    {
        m_items.OnNewPiece += puzzleItems_OnNewPiece;
    }

    private void puzzleItems_OnNewPiece(object sender, System.EventArgs e)
    {
        PuzzlePicture();
    }
    private void PuzzlePicture()
    {

        foreach(Transform child in container)
        {
            if (child == puzzlePiece) continue;
            Destroy (child.gameObject);
            Debug.Log("used up");
        }
        List<puzzleScript.PuzzleItem> clueList = m_items.GetPuzzleItems();
        for (int i = 0; i < clueList.Count; i++)
        {
            puzzleScript.PuzzleItem clue = clueList[i];
            Transform puzzlePicture = Instantiate(puzzlePiece, container);
            puzzlePiece.gameObject.SetActive(true);
            puzzlePicture.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            Image puzzleImage = puzzlePicture.Find("Image").GetComponent<Image>();
            
            Debug.Log("item got");
            if(puzzleImage != null) Debug.Log("item null");
        }
        // Update is called once per frame




    }
}