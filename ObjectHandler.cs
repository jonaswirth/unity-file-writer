using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class ObjectHandler {

    private static string _defaultPath = Application.persistentDataPath;

    public static void WriteObject<T>(T obj, string fileName, string path = null, FileType fileType = FileType.Json)
    {
        path = GetFilePath(path, fileName);

        switch (fileType)
        {
            case FileType.Binary: WriteBinary(obj, path);break;
            case FileType.Json: WriteJson(obj, path);break;
            case FileType.Xml: WriteXml(obj, path);break;
            default: throw new NotSupportedException("The provided file type is not supported for this operation.");
        }
    }

    public static T ReadObject<T>(string fileName, string path = null, FileType fileType = FileType.Json)
    {
        path = GetFilePath(path, fileName);

        switch (fileType)
        {
            case FileType.Binary: return ReadBinary<T>(path);
            case FileType.Json: return ReadJson<T>(path);
            case FileType.Xml: return ReadXml<T>(path);
            default: throw new NotSupportedException("The provided file type is not supported for this operation.");
        }
    }

    private static void WriteBinary(object obj, string path)
    {
        using(FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, obj);
        }    
    }

    private static T ReadBinary<T>(string path)
    {
        using(FileStream fileStream = new FileStream(path, FileMode.Open))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            return (T)Convert.ChangeType(formatter.Deserialize(fileStream), typeof(T));
        }
    }

    private static void WriteJson(object obj, string path)
    {
        throw new NotImplementedException();
    }

    private static T ReadJson<T>(string path)
    {
        throw new NotImplementedException();
    }

    private static void WriteXml(object obj, string path)
    {
        throw new NotImplementedException();
    }

    private static T ReadXml<T>(string path)
    {
        throw new NotImplementedException();
    }

    private static string GetFilePath(string path, string fileName)
    {
        if (path == null)
            path = _defaultPath;

        return Path.Combine(path, fileName);
    }

}
