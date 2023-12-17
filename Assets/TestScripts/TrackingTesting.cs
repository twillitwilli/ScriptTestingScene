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

    float minDistance = 0.1f;


    [SerializeField]
    bool
        _usingMarker,
        _startSavingTracking,
        _finishSave,
        _loadTrackingInfo;

    int _savedFrames;
    Vector3 _previousPos;
    [SerializeField]
    List<Vector3> _savedPositions = new List<Vector3>();
    [SerializeField]
    List<bool> _markerInUse = new List<bool>();

    private void Start()
    {
        _previousPos = _trackedObj.transform.position;
    }

    private async void Update()
    {
        if (_finishSave)
        {
            Debug.Log("Saving...");

            _loadTrackingInfo = false;
            _startSavingTracking = false;

            await BinarySaveLoadTracking.SaveData(CreateTrackingDataSave());

            Debug.Log("Tracking Saved");
            _finishSave = false;
        }

        if (_startSavingTracking && Vector3.Distance(_trackedObj.transform.position, _previousPos) > minDistance)
            SaveTrackingData();

        if (_loadTrackingInfo)
        {
            _loadTrackingInfo = false;
            LoadTrackingData();
        }
    }

    private void SaveTrackingData()
    {
        _savedFrames++;

        _savedPositions.Add(_previousPos);

        UpdateLine();
    }

    private void UpdateLine()
    {
        _marker.positionCount++;
        _marker.SetPosition(_marker.positionCount - 1, _trackedObj.transform.position);
        _previousPos = _trackedObj.transform.position;
    }

    TrackingInfo CreateTrackingDataSave()
    {
        TrackingInfo newData = new TrackingInfo();

        newData.savedFrames = _savedFrames;

        newData.markerInUseDuringFrame = new bool[_savedFrames];

        newData.trackedPosX = new float[_savedFrames];
        newData.trackedPosY = new float[_savedFrames];
        newData.trackedPosZ = new float[_savedFrames];

        for (int i = 0; i < _savedFrames; i++)
        {
            newData.markerInUseDuringFrame[i] = _markerInUse[i];

            newData.trackedPosX[i] = _savedPositions[i].x;
            newData.trackedPosY[i] = _savedPositions[i].y;
            newData.trackedPosZ[i] = _savedPositions[i].z;
        }


        return newData;
    }

    private async Task LoadTrackingData()
    {
        TrackingInfo loadedData = BinarySaveLoadTracking.LoadData();

        _savedFrames = loadedData.savedFrames;
        
        // Load all the data
        for (int i = 0; i < _savedFrames; i++)
        {
            _markerInUse.Add(loadedData.markerInUseDuringFrame[i]);

            Vector3 newPosition = new Vector3(loadedData.trackedPosX[i], loadedData.trackedPosY[i], loadedData.trackedPosZ[i]);
            _savedPositions.Add(newPosition);
        }

        for (int i = 0; i < _savedFrames; i++)
        {
            UpdateLine();

            await Move(_savedPositions[i]);
        }

        _loadTrackingInfo = false;
    }

    public async Task Move(Vector3 newPosition)
    {
        while (_trackedObj.transform.position != newPosition)
        {
            _trackedObj.transform.position = Vector3.MoveTowards(_trackedObj.transform.position, newPosition, 3 * Time.deltaTime);

            await Task.Yield();
        }
    }
}
