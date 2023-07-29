using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinqExamples : MonoBehaviour
{
    public bool usingLinq;

    public enum LinqType { Any, Contains, Distinct, Where }
    public LinqType useLinqKeyword;

    public List<string> playerNames;

    public List<string> updatedList = new List<string>();

    private void Start()
    {
        if (!usingLinq)
        {
            foreach (string names in playerNames)
            {
                if (names == "Zelda")
                {
                    Debug.Log("Found Zelda");
                }
            }
        }
        else
        {
            switch (useLinqKeyword)
            {
                case LinqType.Any:
                    /// Using Linq Any keyword to find any reference you are looking for
                    /// 
                    var playerFound = playerNames.Any(nameFound => nameFound == "Zelda");
                    Debug.Log("Found Zelda = " + playerFound);
                    break;

                case LinqType.Contains:
                    /// Using Linq Contains keyword will allow you to return a bool if what your looking for exists
                    /// 
                    var playerFound1 = playerNames.Contains("Zelda");
                    Debug.Log("Player has been found = " + playerFound1);
                    break;

                case LinqType.Distinct:
                    /// Using Linq Distinct keyword will allow you to check to see if duplicates in a list or array
                    /// exist, and if so it will remove the duplicates and print out a new collection without the
                    /// duplicates
                    /// 
                    var newCollectionOfNames = playerNames.Distinct();
                    foreach (var name in newCollectionOfNames)
                    {
                        updatedList.Add(name);
                    }
                    break;

                case LinqType.Where:
                    /// Using Linq Where keyword allows you to check a list of array for a feature you want it to
                    /// return from items that exist in that list. Here I am just checking the length of the names
                    /// to determine a new collect
                    /// 
                    var result = playerNames.Where(names => names.Length > 4);
                    foreach (var name in result)
                    {
                        updatedList.Add(name);
                    }
                    break;
            }
        }
    }
}
