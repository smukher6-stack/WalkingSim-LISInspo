using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/NPC Data")]
public class NPCData : ScriptableObject 
{
    [Header("who's talking")]
    public string displayName;
    public string placeHolderOpeningLine;

    

    

    [Header("dialogue")]
    [TextArea(3,10)]
    public string[] lines;

    [Header("no choices? that's cool here's some buttons")]
    public DialogueChoice[] choices;

    [Header("auto continue if no choices")]
    public NPCData nextNode;
}

[System.Serializable]
public class DialogueChoice
{
    public string choiceX;
    public NPCData nextNode;

}
