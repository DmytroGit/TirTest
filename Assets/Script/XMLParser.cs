using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

namespace Tir
{
    /// <summary>
    /// Парсит XML файл
    /// </summary>
    public class XMLParser : MonoBehaviour
    {
        /// <summary>
        /// переменная для  пути к файлу
        /// </summary>
        string path;

        private void Awake()
        {
            //инициалзи пути к файлу
            path = Application.dataPath + "/File/DataXML.xml";
        }

        private void Start()
        {
            //Debug.Log(path);
            Load();
        }

        /// <summary>
        /// загрузка файла
        /// </summary>
        public void Load()
        {
            XElement root = null;

            //если нет файла
            if(!File.Exists(path))
            {
                return;
            }
            else
            {
                //взяли корневой елемент
                root = XDocument.Parse(File.ReadAllText(path)).Element("root");

                Generate(root);
                //Debug.Log(root);
            }
        }

        /// <summary>
        /// парсинг корневого элемента
        /// </summary>
        /// <param name="root"></param>
        public void Generate(XElement root)
        {
            foreach(XElement instance in root.Elements("type"))
            {
                int x = int.Parse(instance.Attribute("count").Value);

                string s = instance.Value;

                GenerateSpawn(x, s);

               /// Debug.Log(x + " - " + s + " **** ");
            }
        }

        /// <summary>
        /// генерим "кнопки - спавнер" и вставляем в контент UI
        /// </summary>
        /// <param name="x">значение - приз</param>
        /// <param name="s">тип (куб/сфера/цилиндр ...)</param>
        public void GenerateSpawn(int x, string s)
        {
            //загружаем кнопку - спавнер
            GameObject Spawn = Instantiate(Resources.Load("Spawn"), Vector3.zero, Quaternion.identity) as GameObject;

            //настройка спавнера
            Spawn.GetComponent<Spawner>().SetText(x);

            //выбираем что  будем спавнером генерить
            if(s == EPlayerObject.Cube.ToString())
            {
                Spawn.GetComponent<Spawner>().ePlayerObject = EPlayerObject.Cube;
                Spawn.GetComponent<Spawner>().count = x;
            }
            if(s == EPlayerObject.Capsule.ToString())
            {
                Spawn.GetComponent<Spawner>().ePlayerObject = EPlayerObject.Capsule;
                Spawn.GetComponent<Spawner>().count = x;
            }
            if(s == EPlayerObject.Cylinder.ToString())
            {
                Spawn.GetComponent<Spawner>().ePlayerObject = EPlayerObject.Cylinder;
                Spawn.GetComponent<Spawner>().count = x;
            }
            if(s == EPlayerObject.Sphere.ToString())
            {
                Spawn.GetComponent<Spawner>().ePlayerObject = EPlayerObject.Sphere;
                Spawn.GetComponent<Spawner>().count = x;
            }

            //вставляем в контент UI
            Spawn.transform.SetParent(GameObject.Find("ContentLV").transform);
        }
    }
}
