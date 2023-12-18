using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TrackingTesting : MonoBehaviour
{
    [SerializeField]
    GameObject _trackedObj;

    // Marker Settings
    [SerializeField]
    LineRenderer _marker;

    [SerializeField]
    bool
        _usingMarker,
        _startSavingTracking,
        _finishSave,
        _loadTrackingInfo;

    bool _creatingNewLine;

    Vector3 _previousPos;

    [SerializeField]
    List<Vector3> _linePositions = new List<Vector3>();

    [SerializeField]
    List<LineRenderer> _createdLines = new List<LineRenderer>();

    private void Start()
    {
        _previousPos = _trackedObj.transform.position;
    }

    private async void Update()
    {
        if (!_usingMarker && _creatingNewLine)
            CreateNewLine();

        if (_finishSave)
        {
            Debug.Log("Saving...");

            _loadTrackingInfo = false;
            _startSavingTracking = false;

            await BinarySaveLoadTracking.SaveData(CreateTrackingDataSave());

            Debug.Log("Tracking Saved");
            _finishSave = false;
        }

        if (_startSavingTracking && Vector3.Distance(_trackedObj.transform.position, _previousPos) > 0.1f)
            UpdateLine();

        if (_loadTrackingInfo)
        {
            _loadTrackingInfo = false;
            LoadTrackingData();
        }
    }

    private void UpdateLine()
    {
        if (_usingMarker)
        {
            if (!_creatingNewLine)
            {
                
                _linePositions.Add(_trackedObj.transform.position);
                _creatingNewLine = true;
            }

            _marker.positionCount++;
            _marker.SetPosition(_marker.positionCount - 1, _trackedObj.transform.position);

            _linePositions.Add(_trackedObj.transform.position);

            _previousPos = _trackedObj.transform.position;
        }
    }

    void CreateNewLine()
    {
        GameObject newObj = new GameObject();
        LineRenderer newLine = newObj.AddComponent<LineRenderer>();

        LineSettings(newLine);

        newLine.positionCount = _linePositions.Count;
        newLine.SetPositions(_linePositions.ToArray());

        _createdLines.Add(newLine);

        _marker.positionCount = 0;
        _linePositions.Clear();

        _creatingNewLine = false;
    }

    void LineSettings(LineRenderer newLine)
    {
        newLine.colorGradient = _marker.colorGradient;
        newLine.material = _marker.material;
        newLine.startWidth = _marker.startWidth;
        newLine.endWidth = _marker.endWidth;
    }

    TrackingInfo CreateTrackingDataSave()
    {
        TrackingInfo newData = new TrackingInfo();


        return newData;
    }

    private async Task LoadTrackingData()
    {

    }
}
