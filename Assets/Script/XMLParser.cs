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
            //Debug.Log(path);
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
                Generate(root);
                //Debug.Log(root);
            }
        }

        public void Generate(XElement root)
        {

            foreach(XElement instance in root.Elements("type"))
            {
                int x = int.Parse(instance.Attribute("count").Value);

                string s = instance.Value;

                TestImg(x, s);

                Debug.Log(x + " - " + s + " **** ");
            }
        }

        //////////////////////////
        public void TestImg(int x, string s)
        {
            GameObject Spawn = Instantiate(Resources.Load("Spawn"), Vector3.zero, Quaternion.identity) as GameObject;

            Spawn.GetComponent<Spawner>().SetText(x);

            if(s == "Cube")
            {
                Spawn.GetComponent<Spawner>().ePlayerObject = EPlayerObject.Cube;
                Spawn.GetComponent<Spawner>().count = x;
            }
            if(s == "Capsule")
            {
                Spawn.GetComponent<Spawner>().ePlayerObject = EPlayerObject.Capsule;
                Spawn.GetComponent<Spawner>().count = x;
            }
            if(s == "Cylinder")
            {
                Spawn.GetComponent<Spawner>().ePlayerObject = EPlayerObject.Cylinder;
                Spawn.GetComponent<Spawner>().count = x;
            }
            if(s == "Sphere")
            {
                Spawn.GetComponent<Spawner>().ePlayerObject = EPlayerObject.Sphere;
                Spawn.GetComponent<Spawner>().count = x;
            }

            Spawn.transform.SetParent(GameObject.Find("Canvas").transform);
        }
    }
}
