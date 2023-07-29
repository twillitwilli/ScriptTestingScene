using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncTakingTurns : MonoBehaviour
{
    [SerializeField] private AsyncObjectController[] _movableEntities;
    private bool _turnInProgress;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_turnInProgress)
        {
            BeginTurn();
        }
    }

    private async void BeginTurn()
    {
        _turnInProgress = true;
        Debug.Log("Start Turn");

        await Task.Delay(3000);
        await BeginMovement();

        

        await Task.Delay(1000);
        await BeginAttacks();


        await Task.Delay(3000);
        Debug.Log("End Turn");
        _turnInProgress = false;
    }

    private async Task BeginMovement()
    {
        for (int i = 0; i < _movableEntities.Length; i++)
        {
            var randomPosition = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));

            await _movableEntities[i].Move(randomPosition);
        }
    }

    private async Task BeginAttacks()
    {
        //Player Attacking
        var randomEnemyTarget = Random.Range(1, _movableEntities.Length);
        await _movableEntities[0].Attack(_movableEntities[randomEnemyTarget].transform);

        await Task.Delay(3000);

        //Enemies Attacking
        for (int i = 1; i < _movableEntities.Length; i++)
        {
            await _movableEntities[i].Attack(_movableEntities[0].transform);
        }
    }
}
