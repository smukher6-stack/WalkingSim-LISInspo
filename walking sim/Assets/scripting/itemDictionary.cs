using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class itemDictionary : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<Itema> itemPrefabs;
    private Dictionary<int, GameObject> itemList;

    private void Awake()
    {
        itemList = new Dictionary<int, GameObject>();

        for (int i = 0; i < itemPrefabs.Count; i++)
        {
            if (itemPrefabs[i] != null)
            {
                itemPrefabs[i].Item = i + 1;

            }
        }

        foreach (Itema item in itemPrefabs)
        {
            itemList[item.Item] = item.gameObject;
        }
    }

   
}
