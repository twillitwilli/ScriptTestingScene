using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityObjectSpawner : MonoBehaviour
{
    [SerializeField] private PrimitiveType _objectType;
    [SerializeField] private bool _randomizeColor;

    private GameObject _newObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && _newObject == null)
        {
            _newObject = UtilityHelper.CreateObject(_objectType);
            _newObject.transform.position = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f));
        }

        if (Input.GetKeyDown(KeyCode.R) && _newObject != null)
        {
            UtilityHelper.ResetTransform(_newObject);
        }

        if (Input.GetKeyDown(KeyCode.C) && _newObject != null)
        {
            UtilityHelper.ChangeColor(_newObject.GetComponent<MeshRenderer>().material, Color.red, _randomizeColor);
        }
    }
}
