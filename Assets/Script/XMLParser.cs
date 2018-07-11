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

            //при билде комментим предыдущий путь и разкомментим 
            //этот но нужно забрасить файл в папке по этому пути

            //path = Application.persistentDataPath + "/File/DataXML.xml";
        }

        private void Start()
        {
            //Debug.Log(path);
            Load();
        }

        /// <summary>
        /// Если нет файла
        /// </summary>
        public void CreaterNewFile()
        {
            //переназначаем путь (этот код выполниться скорее всего из - того что
            //игра первый раз запустилась не в юнити а первый раз из билда)
            path = Application.persistentDataPath + "/DataXML.xml";

            XElement root = new XElement("root");

            XAttribute attrib = new XAttribute("count", 100);
            XElement element = new XElement("type", "Cube", attrib);
            root.Add(element);

            XAttribute attrib1 = new XAttribute("count", 500);
            XElement element1 = new XElement("type", "Sphere", attrib1);
            root.Add(element1);

            XDocument saveDoc = new XDocument(root);

            File.WriteAllText(path, saveDoc.ToString());

        }

        /// <summary>
        /// загрузка файла
        /// </summary>
        public void Load()
        {
            XElement root = null;

            //если нет файла (это скорее всего будет запуск игры не в юнити а билда)
            if(!File.Exists(path))
            {
                CreaterNewFile();

                //взяли корневой елемент
                root = XDocument.Parse(File.ReadAllText(path)).Element("root");

                Generate(root);

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
                Spawn.GetComponent<Spawner>().SetImg(EPlayerObject.Cube);
            }
            if(s == EPlayerObject.Capsule.ToString())
            {
                Spawn.GetComponent<Spawner>().ePlayerObject = EPlayerObject.Capsule;
                Spawn.GetComponent<Spawner>().count = x;
                Spawn.GetComponent<Spawner>().SetImg(EPlayerObject.Capsule);
            }
            if(s == EPlayerObject.Cylinder.ToString())
            {
                Spawn.GetComponent<Spawner>().ePlayerObject = EPlayerObject.Cylinder;
                Spawn.GetComponent<Spawner>().count = x;
                Spawn.GetComponent<Spawner>().SetImg(EPlayerObject.Cylinder);

            }
            if(s == EPlayerObject.Sphere.ToString())
            {
                Spawn.GetComponent<Spawner>().ePlayerObject = EPlayerObject.Sphere;
                Spawn.GetComponent<Spawner>().count = x;
                Spawn.GetComponent<Spawner>().SetImg(EPlayerObject.Sphere);
            }

            //вставляем в контент UI
            Spawn.transform.SetParent(GameObject.Find("ContentLV").transform);
        }
    }
}
