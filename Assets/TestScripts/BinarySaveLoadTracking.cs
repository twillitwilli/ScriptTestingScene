using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//Acts in place of how a server would hold the data
public static class BinarySaveLoadTracking
{
    public static void SaveData(TrackingInfo saveData, string lineData)
    {
        // Create a new binary formatter
        BinaryFormatter formatter = new BinaryFormatter();

        // Get the name of the path, the file name
        string fileName = Application.persistentDataPath + "/" + "TrackingData" + lineData;

        // Create a filestream, this allows you to read and write from a file, you pass in the filename and it with
        // either open the file if it exists or create the file if it doesnt exist
        FileStream filestream = new FileStream(fileName, FileMode.OpenOrCreate);

        // Now the formatter can be ran to serialize the data by passing in the filestream, then the data being saved
        formatter.Serialize(filestream, saveData);

        // Finally after the formatter is done, it is always important to then close the filestream
        filestream.Close();
    }

    public static TrackingInfo LoadData(string lineData)
    {
        // When loading a file the first thing you must always do, is check to make sure the file exists
        string fileName = Application.persistentDataPath + "/" + "TrackingData" + lineData;

        if (File.Exists(fileName))
        {
            // If the file exists, then you can start by creating a new formatter
            BinaryFormatter formatter = new BinaryFormatter();

            // Then create a file stream for opening the the file by passing in the file name
            FileStream fileStream = new FileStream(fileName, FileMode.Open);

            // Now I can deserialize the data so it is readable again
            TrackingInfo loadedData = formatter.Deserialize(fileStream) as TrackingInfo;

            // Same as before it is always important to close the file stream after you are done using it
            fileStream.Close();

            // Finally I can just return loaded data
            return loadedData;
        }

        else return null; // File Not Found
    }
}
