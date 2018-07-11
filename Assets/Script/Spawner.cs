using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tir
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        public EPlayerObject ePlayerObject;

        [SerializeField]
        GameObject gameObjectTramsform;

        [SerializeField]
        Text text;

        [SerializeField]
        Image image;

        [SerializeField]
        Button button;

        [SerializeField]
        public int count;

        private void Awake()
        {
            gameObjectTramsform = GameObject.Find("CenterPoint");
            button.onClick.AddListener(() => CreateSpawn(count));
        }

        public void SetText(int s)
        {
            text.text = s.ToString();
        }

        public void SetImg()
        {
            // GameObject Panelika = Instantiate(Resources.Load("x"), Vector3.zero, Quaternion.identity) as GameObject;
            //GetComponent<Image>().color =  Color.red;
            image.color = Color.red;
            //image.sprite = image1;
        }

        /// <summary>
        /// Генерит UI 
        /// </summary>
        public void CreateSpawn(int c)
        {
            GameObject loadGameObject;

            if(ePlayerObject == EPlayerObject.Cube)
            {
                loadGameObject = Instantiate(Resources.Load("Cube"), gameObjectTramsform.transform.position, Quaternion.identity) as GameObject;
                loadGameObject.GetComponent<PlayerObject>().SetCount(c);
            }
            if(ePlayerObject == EPlayerObject.Capsule)
            {
                loadGameObject = Instantiate(Resources.Load("Capsule"), gameObjectTramsform.transform.position, Quaternion.identity) as GameObject;
                loadGameObject.GetComponent<PlayerObject>().SetCount(c);
            }
            if(ePlayerObject == EPlayerObject.Cylinder)
            {
                loadGameObject = Instantiate(Resources.Load("Cylinder"), gameObjectTramsform.transform.position, Quaternion.identity) as GameObject;
                loadGameObject.GetComponent<PlayerObject>().SetCount(c);
            }
            if(ePlayerObject == EPlayerObject.Sphere)
            {
                loadGameObject = Instantiate(Resources.Load("Sphere"), gameObjectTramsform.transform.position, Quaternion.identity) as GameObject;
                loadGameObject.GetComponent<PlayerObject>().SetCount(c);
            }
        }
    }
}