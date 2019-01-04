using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour {

    public TestObj testObj;

    public void SaveObj()
    {
        ObjectHandler.WriteObject(testObj, "testObj.json", fileType: FileType.Json);
    }

    public void LoadObj()
    {
        testObj = ObjectHandler.ReadObject<TestObj>("testObj.json", fileType: FileType.Json);
    }
}
