using UnityEngine;
using Ink.Runtime; // Ensure you have the Ink Unity Integration installed

[CreateAssetMenu(fileName = "NewDialogueStory", menuName = "ScriptableObjects/DialogueStory")]
public class DialogueStoryAsset : ScriptableObject
{
    [Header("Ink Configuration")]
    [Tooltip("The compiled Ink JSON file.")]
    public TextAsset inkJSONAsset;

    public string knotName;

    [Header("Metadata")]
    public string storyTitle;

  

}
