using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public string name;
    public int id;

    public PlayerData(int playerID)
    {
        id = playerID;
    }
}

public class MultiplayerDictionary : MonoBehaviour
{
    public Dictionary<int, PlayerData> playerDictionary = new Dictionary<int, PlayerData>();

    [SerializeField] private int _playerID;

    private void Start()
    {
        CreatePlayers();
    }

    private void CreatePlayers()
    {
        PlayerData player1 = new PlayerData(1);
        player1.name = "Link";

        PlayerData player2 = new PlayerData(123);
        player2.name = "Mario";

        PlayerData player3 = new PlayerData(83);
        player3.name = "Alyx";

        playerDictionary.Add(player1.id, player1);
        playerDictionary.Add(player2.id, player2);
        playerDictionary.Add(player3.id, player3);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerDictionary.ContainsKey(_playerID))
        {
            Debug.Log("Player name " + playerDictionary[_playerID].name);
        }
    }
}
