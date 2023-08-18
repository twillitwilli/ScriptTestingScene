using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSaveData : MonoBehaviour
{
    [SerializeField] private bool _saveData, _loadData;

    // Basic Save Data //

    [SerializeField] private string _playerName;

    [SerializeField] private float _attackDamage, _attackCooldown;

    [SerializeField] private int _health, _shield;

    private void Update()
    {
        if (_saveData)
        {
            SaveData();
            _saveData = false;
        }

        if (_loadData)
        {
            LoadData();
            _loadData = false;
        }
    }

    private void SaveData()
    {
        // Saving Strings
        PlayerPrefs.SetString("PlayerName", _playerName);

        // Saving Floats
        PlayerPrefs.SetFloat("AttackDamage", _attackDamage);
        PlayerPrefs.SetFloat("AttackCooldown", _attackCooldown);

        // Saving Ints
        PlayerPrefs.SetInt("Health", _health);
        PlayerPrefs.SetInt("Shield", _shield);
    }

    private void LoadData()
    {
        // Loading Strings
        _playerName = FileExists("PlayerName") ? PlayerPrefs.GetString("PlayerName") : "Player Has No Name";

        // Loading Floats
        _attackDamage = FileExists("AttackDamage") ? PlayerPrefs.GetFloat("AttackDamage") : 5;
        _attackCooldown = FileExists("AttackCooldown") ? PlayerPrefs.GetFloat("AttackCooldown") : 0.5f;

        // Loading Ints
        _health = FileExists("Health") ? PlayerPrefs.GetInt("Health") : 100;
        _shield = FileExists("Shield") ? PlayerPrefs.GetInt("Shield") : 100;
    }

    private bool FileExists(string fileName)
    {
        return PlayerPrefs.HasKey(fileName);
    }
}
