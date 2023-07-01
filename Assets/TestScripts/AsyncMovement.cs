using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncMovement : MonoBehaviour
{
    [SerializeField] private bool isPlayer;

    public async Task Move(Vector3 newPosition)
    {
        Debug.Log(gameObject.name + " Turn");
        await Task.Delay(1000);

        while (transform.position != newPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, Random.Range(2.5f, 4.5f) * Time.deltaTime);
            await Task.Yield();
        }
    }
}
