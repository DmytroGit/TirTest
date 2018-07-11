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

        private void Awake()
        {
            button.onClick.AddListener(() => CreateSpawn());
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
        public void CreateSpawn(/*GameObject gameObject*/)
        {
            //GameObject loadGameObject;

            if(ePlayerObject == EPlayerObject.Cube)
            {
                Instantiate(Resources.Load("Cube"), gameObjectTramsform. transform.position, Quaternion.identity);
            }
            if(ePlayerObject == EPlayerObject.Capsule)
            {
                Instantiate(Resources.Load("Capsule"), gameObjectTramsform.transform.position, Quaternion.identity);
            }
            if(ePlayerObject == EPlayerObject.Cylinder)
            {
                Instantiate(Resources.Load("Cylinder"), gameObjectTramsform.transform.position, Quaternion.identity);
            }
            if(ePlayerObject == EPlayerObject.Sphere)
            {
                Instantiate(Resources.Load("Sphere"), gameObjectTramsform.transform.position, Quaternion.identity);
            }
        }
    }
}