using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TrackingTesting : MonoBehaviour
{
    [SerializeField]
    int _markerIndex;

    // Marker Settings
    [SerializeField]
    LineRenderer _marker;

    [SerializeField]
    bool
        _usingMarker,
        _startSavingTracking,
        _loadTrackingInfo;

    bool _creatingNewLine;

    Vector3 _previousPos;

    List<Vector3> _linePositions = new List<Vector3>();

    int _currentLine;

    private async void Start()
    {
        if (_loadTrackingInfo)
            await LoadTrackingData();

        _loadTrackingInfo = false;

        _previousPos = transform.position;
    }

    private void Update()
    {
        if (!_usingMarker && _creatingNewLine)
            CreateNewLine(_linePositions.ToArray());

        if (_startSavingTracking && Vector3.Distance(transform.position, _previousPos) > 0.1f)
            UpdateLine();
    }

    private void UpdateLine()
    {
        if (_usingMarker)
        {
            if (!_creatingNewLine)
            {
                
                _linePositions.Add(transform.position);
                _creatingNewLine = true;
            }

            _marker.positionCount++;
            _marker.SetPosition(_marker.positionCount - 1, transform.position);

            _linePositions.Add(transform.position);

            _previousPos = transform.position;
        }
    }

    void CreateNewLine(Vector3[] linePositions)
    {
        GameObject newObj = new GameObject();
        LineRenderer newLine = newObj.AddComponent<LineRenderer>();

        LineSettings(newLine);

        newLine.positionCount = linePositions.Length;
        newLine.SetPositions(linePositions);

        BinarySaveLoadTracking.SaveData(CreateTrackingDataSave(), _markerIndex.ToString() + _currentLine.ToString());

        _currentLine++;
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

        newData.totalLines = _currentLine;
        newData.lengthOfLine = _linePositions.Count;

        newData.trackedPosX = new float[_linePositions.Count];
        newData.trackedPosY = new float[_linePositions.Count];
        newData.trackedPosZ = new float[_linePositions.Count];

        for (int i = 0; i < _linePositions.Count; i++)
        {
            newData.trackedPosX[i] = _linePositions[i].x;
            newData.trackedPosY[i] = _linePositions[i].y;
            newData.trackedPosZ[i] = _linePositions[i].z;
        }

        return newData;
    }

    private async Task LoadTrackingData()
    {
        int maxLineLimit = 1000000;

        for (int i = 0; i < maxLineLimit; i++)
        {
            if (BinarySaveLoadTracking.LoadData(_markerIndex.ToString() + i.ToString()) != null)
            {
                TrackingInfo loadedData = BinarySaveLoadTracking.LoadData(_markerIndex.ToString() + i.ToString());

                Vector3[] linePoints = new Vector3[loadedData.lengthOfLine];

                for (int i2 = 0; i2 < linePoints.Length; i2++)
                {
                    linePoints[i2].x = loadedData.trackedPosX[i2];
                    linePoints[i2].y = loadedData.trackedPosY[i2];
                    linePoints[i2].z = loadedData.trackedPosZ[i2];
                }

                CreateNewLine(linePoints);
            }

            else
                return;
        }
    }
}
