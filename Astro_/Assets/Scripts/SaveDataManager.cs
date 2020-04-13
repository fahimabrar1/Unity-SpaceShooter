using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveDataManager 
{
    public static void SaveOptions(OptionManager option)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Options.data";
        
        FileStream stream = new FileStream(path, FileMode.Create);

        OptionData optiondata= new OptionData(option);

        formatter.Serialize(stream, optiondata );
        Debug.Log("Saved Data to SaveDatamanager");

        stream.Close();
    }

    public static OptionData LoadData()
    {
        string path = Application.persistentDataPath + "/Options.data";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);

            OptionData  option = binaryFormatter.Deserialize(stream) as OptionData;
            stream.Close();
            Debug.Log("Loaded from  Data");

            return option;

        }
        else
        {
            Debug.LogError("File Not Found");
            return null;
        }
    }

}
