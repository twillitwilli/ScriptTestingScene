using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReturnDelegate : MonoBehaviour
{
    public delegate int PlayerID(string playerName); //instead of returning void, this delegate will return an int and require a string input
    public PlayerID playerIDs;

    private List<string> _playerNames = new List<string>();

    public Func<string, int> playerSerialNumber;

    private void Start()
    {
        playerIDs = GetPlayerID;

        //here i am adding the player names to the list and returning their index id
        Debug.Log("Link ID: " + playerIDs("Link"));
        Debug.Log("Mario ID: " + playerIDs("Mario"));
        Debug.Log("Alyx ID: " + playerIDs("Alyx"));

        //playerSerialNumber = GetPlayerSerialNumber;
        playerSerialNumber = (string name) => _playerNames.IndexOf(name) + UnityEngine.Random.Range(50, 25000); //using lambda expression, "=>", I can write the same method as below in a single line

        //here i am doing the same thing but using the function instead of the delegate system
        Debug.Log("Mario Serial #" + playerSerialNumber("Mario"));
        Debug.Log("Alyx Serial #" + playerSerialNumber("Alyx"));
        Debug.Log("Link Serial #" + playerSerialNumber("Link"));
    }

    public int GetPlayerID(string name)
    {
        _playerNames.Add(name);

        return _playerNames.IndexOf(name);
    }

    //public int GetPlayerSerialNumber(string name)
    //{
    //    return _playerNames.IndexOf(name) + UnityEngine.Random.Range(50, 25000);
    //}
}
