using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryPlayerSaveLoad : MonoBehaviour
{
    [SerializeField] private bool _saveData, _loadData, _deleteData;

    // Basic Save Data //

    [SerializeField] private string[] _playerName;

    [SerializeField] private bool[] _playerCanFly;

    [SerializeField] private float[] _attackDamage, _attackCooldown;

    [SerializeField] private int[] _health, _shield;

    private void Update()
    {
        if (_saveData)
        {
            BinarySaveSystem.SaveData(CreateSaveData());

            _saveData = false;
        }

        if (_loadData)
        {
            BinarySaveData loadedData = BinarySaveSystem.LoadData();

            if (loadedData != null) { LoadSavedData(loadedData); }
            else { Debug.Log("No Save File Found"); }

            _loadData = false;
        }

        if (_deleteData)
        {
            BinarySaveSystem.DeleteFileSave();

            _deleteData = false;
        }
    }

    private BinarySaveData CreateSaveData()
    {
        BinarySaveData newData = new BinarySaveData();

        newData.playerName = _playerName;

        newData.playerCanFly = _playerCanFly;

        newData.attackDamage = _attackDamage;
        newData.attackCooldown = _attackCooldown;

        newData.health = _health;
        newData.shield = _shield;

        return newData;
    }

    private void LoadSavedData(BinarySaveData loadedData)
    {
        _playerName = loadedData.playerName;

        _playerCanFly = loadedData.playerCanFly;

        _attackDamage = loadedData.attackDamage;
        _attackCooldown = loadedData.attackCooldown;

        _health = loadedData.health;
        _shield = loadedData.shield;
    }
}
