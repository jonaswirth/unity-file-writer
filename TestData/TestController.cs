using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour {

    public TestObj testObj;

    public void SaveObj()
    {
        ObjectHandler.WriteObject<TestObj>(testObj, "testObj.xyz", fileType: FileTypes.Binary);
    }

    public void LoadObj()
    {
        testObj = ObjectHandler.ReadObject<TestObj>("testObj.xyz", fileType: FileTypes.Binary);
    }
}
