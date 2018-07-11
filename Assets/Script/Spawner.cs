using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tir
{
    public class Spawner : MonoBehaviour
    {
        /// <summary>
        /// тип что будем генерить
        /// </summary>
        [SerializeField]
        public EPlayerObject ePlayerObject;

        /// <summary>
        /// координаты для генерации
        /// </summary>
        [SerializeField]
        GameObject gameObjectTramsform;

        /// <summary>
        /// подпись величины приза
        /// </summary>
        [SerializeField]
        Text countText;

        /// <summary>
        /// картинка
        /// </summary>
        [SerializeField]
        Image image;

        /// <summary>
        /// ссылка на кнопку генерации
        /// </summary>
        [SerializeField]
        Button button;

        /// <summary>
        /// величина приза (очки)
        /// </summary>
        [SerializeField]
        public int count;

        private void Awake()
        {
            //находим координаты для генерации
            gameObjectTramsform = GameObject.Find("CenterPoint");

            //назначаем "слушателя" на  нажатие
            button.onClick.AddListener(() => CreateSpawn(count));
        }

        /// <summary>
        /// установка значения надписи на спавнере
        /// </summary>
        /// <param name="s"></param>
        public void SetText(int s)
        {
            countText.text = s.ToString();
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
        /// <param name="c">значение приз</param>
        public void CreateSpawn(int c)
        {
            GameObject loadGameObject;

            //выбираем что за объект генерить
            if(ePlayerObject == EPlayerObject.Cube)
            {
                //загркжаем объект и инстниэйтим
                loadGameObject = Instantiate(Resources.Load("Cube"), gameObjectTramsform.transform.position, Quaternion.identity) as GameObject;

                //устанавливаем приз-значение (когда объект взорвется то это значение нам зачислится)
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