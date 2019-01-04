using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class FileHandler {

    private static string _defaultPath = Application.persistentDataPath;

    public static void WriteFile(string content, string filename, string path = null)
    {
        path = GetFilePath(path, filename);
        using(StreamWriter streamWriter = new StreamWriter(path))
        {
            streamWriter.Write(content);
        }
    }

    public static string ReadFile(string filename, string path = null)
    {
        path = GetFilePath(path, filename);
        using(StreamReader streamReader = new StreamReader(path))
        {
            return streamReader.ReadToEnd();
        }
    }

    private static string GetFilePath(string path, string fileName)
    {
        if (path == null)
            path = _defaultPath;

        return Path.Combine(path, fileName);
    }
}
