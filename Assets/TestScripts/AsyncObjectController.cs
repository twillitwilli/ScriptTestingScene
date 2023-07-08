using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncObjectController : MonoBehaviour
{
    [SerializeField] private GameObject rangedAttack, meleeAttack;

    private float _meleeRange;

    public async Task Move(Vector3 newPosition)
    {
        Debug.Log(gameObject.name + " Moving");
        await Task.Delay(1000);

        while (transform.position != newPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, Random.Range(2.5f, 4.5f) * Time.deltaTime);
            await Task.Yield();
        }
    }

    public async Task Attack(Transform target)
    {
        transform.LookAt(target);

        Debug.Log(gameObject.name + " Attacking " + target.gameObject.name);

        _meleeRange = Vector3.Distance(transform.position, target.position);
        Debug.Log(_meleeRange <= 1 ? "Attacking Using Melee" : "Attacking Using Range");

        var attackObject = _meleeRange <= 1 ? Instantiate(meleeAttack, transform.position, transform.rotation) : Instantiate(rangedAttack, transform.position, transform.rotation);
        attackObject.transform.SetParent(null);

        await Task.Yield();
    }
}
