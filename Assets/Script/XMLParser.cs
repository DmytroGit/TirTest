using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class XMLParser : MonoBehaviour
{
    string path;

    private void Awake()
    {
        path = Application.dataPath + "/File/DataXML.xml";
    }

    private void Start()
    {
        Debug.Log(path);
    }
}
