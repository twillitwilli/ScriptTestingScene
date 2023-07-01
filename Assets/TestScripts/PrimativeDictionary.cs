using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimativeDictionary : MonoBehaviour
{
    public Dictionary<string, int> people = new Dictionary<string, int>();

    [SerializeField] private string nameOfPerson;

    private void Start()
    {
        people.Add("Mike", 38);
        people.Add("John", 26);
        people.Add("Ash", 34);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && people.ContainsKey(nameOfPerson))
        {
            Debug.Log("Name: " + nameOfPerson + " Age: " + people[nameOfPerson]);
        }
    }
}
