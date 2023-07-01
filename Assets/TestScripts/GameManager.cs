using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _playerIsAlive { get; set; } //this is an auto property
    private bool _gameOver;

    public float speed { get; private set; } //read only property
    public string _name { get; set; }

    public bool IsGameOver
    {
        get { return _gameOver; }
        set
        {
            if (value == true) { Debug.Log("Game Over"); }
            _gameOver = value;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !IsGameOver) // here i can get the bool value
        {
            IsGameOver = true; //here i can set the bool value
        }
    }
}
