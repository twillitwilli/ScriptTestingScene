using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncTakingTurns : MonoBehaviour
{
    [SerializeField] private AsyncMovement[] _movableEntities;
    private bool isMoving;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            BeginMovement();
        }
    }

    private async void BeginMovement()
    {
        isMoving = true;
        Debug.Log("Start Turn");

        await Task.Delay(3000);
        for (int i = 0; i < _movableEntities.Length; i++)
        {
            var randomPosition = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));

            await _movableEntities[i].Move(randomPosition);
        }

        await Task.Delay(3000);
        Debug.Log("End Turn");
        isMoving = false;
    }
}
