using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

namespace Tir
{
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
            Load();
        }

        public void Load()
        {
            XElement root = null;

            if(!File.Exists(path))
            {
                return;
            }
            else
            {
                root = XDocument.Parse(File.ReadAllText(path)).Element("root");

                Debug.Log(root);
            }
        }
    }
}
