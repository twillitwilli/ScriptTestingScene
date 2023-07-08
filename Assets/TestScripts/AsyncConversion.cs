using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncConversion : MonoBehaviour
{
    [SerializeField] private bool _asyncOn;
    [SerializeField] private GameObject _sphere;

    private List<GameObject> _spawnedSpheres = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_asyncOn) { StartCoroutine("SpawnSpheres"); }
            else { SpawnAsyncSpheres(); }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            foreach (var spheres in _spawnedSpheres)
            {
                Destroy(spheres);
            }

            _spawnedSpheres.Clear();
        }
    }

    private IEnumerator SpawnSpheres()
    {
        while (_spawnedSpheres.Count < 10)
        {
            var randomPos = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
            var newSphere = Instantiate(_sphere, randomPos, transform.rotation);
            _spawnedSpheres.Add(newSphere);
            yield return null;
        }

        Debug.Log("Spheres Spawned = " + _spawnedSpheres.Count);
    }

    private async void SpawnAsyncSpheres()
    {
        while (_spawnedSpheres.Count < 10)
        {
            var randomPos = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
            var newSphere = Instantiate(_sphere, randomPos, transform.rotation);
            _spawnedSpheres.Add(newSphere);
            await Task.Yield();
        }

        Debug.Log("Spheres Spawned = " + _spawnedSpheres.Count);   
    }
}


