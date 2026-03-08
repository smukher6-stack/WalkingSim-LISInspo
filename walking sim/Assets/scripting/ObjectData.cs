using UnityEngine;

[CreateAssetMenu(menuName = "Description/Object Data")]

public class ObjectData : ScriptableObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string objectName;
    public string objectDescription;

    [TextArea(3, 10)]

    public string[] lines;

    public ObjectChoice[] choices;


    public ObjectData objectNode;


}


[System.Serializable]
public class ObjectChoice
{
    public string choiceX;
    public ObjectData objectNode;

}
