using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tir
{
    /// <summary>
    /// этот скрипт висит на генерируемых объектах (куб/шар...) и отвечает за столкновения и смерть объектов
    /// </summary>
    public class PlayerObject : MonoBehaviour
    {
        /// <summary>
        /// партикл для взрыва
        /// </summary>
        [SerializeField]
        GameObject partile;

        /// <summary>
        /// тип объекта   оно будет меняться из другого скрипта
        /// </summary>
        public EPlayerObject ePlayerObject;

        /// <summary>
        /// флаг , новосоздающийся объект или нет
        /// </summary>
        [HideInInspector]
        public bool isNew = true;

        /// <summary>
        /// для префаба Wow
        /// </summary>
        [SerializeField]
        GameObject textObj;

        /// <summary>
        /// сколько очков за обект  оно будет меняться из другого скрипта
        /// </summary>
        [SerializeField]
        int count = 0;

        /// <summary>
        /// для изменения очков приза
        /// </summary>
        /// <param name="c"></param>
        public void SetCount(int c)
        {
            count = c;
        }

        /// <summary>
        /// отслеживает колизию (триггер)
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            if(isNew == false)
            {
                return;
            }

            if(!other.gameObject.GetComponent<PlayerObject>())
            {
                return;
            }

            if(other.gameObject.GetComponent<PlayerObject>().ePlayerObject == this.ePlayerObject)
            {
                isNew = false;

                if(other.gameObject.GetComponent<PlayerObject>().isNew)
                {
                    return;
                }

                //Destroy(other.gameObject);
                other.gameObject.GetComponent<PlayerObject>().Death();
            }
            if(other.gameObject.GetComponent<PlayerObject>().ePlayerObject != this.ePlayerObject)
            {
                isNew = false;

                if(other.gameObject.GetComponent<PlayerObject>().isNew)
                {
                    return;
                }

                //Destroy(other.gameObject);
                other.gameObject.GetComponent<Animator>().SetBool("fly", true);

                GameObject x = Instantiate(textObj, Vector3.zero, Quaternion.identity) as GameObject;
                x.transform.SetParent(GameObject.Find("Canvas").transform);


                other.gameObject.GetComponent<PlayerObject>().DeathAnimation();
            }
        }

        /// <summary>
        /// установка новизны объекта
        /// </summary>
        public void SetISNew()
        {
            isNew = false;
        }

        /// <summary>
        /// перевызов смерти при вылете объекта
        /// </summary>
        public void DeathAnimation()
        {
            StartCoroutine(IDeathAnimation());
        }

        public IEnumerator IDeathAnimation()
        {
            yield return new WaitForSeconds(2F);

            Destroy(gameObject);
        }

        /// <summary>
        /// перевызов корутины смерти
        /// </summary>
        public void Death()
        {
            StartCoroutine(IDeath());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator IDeath()
        {
            //зачсляем очки
            DataStatic.SetCountUser(count);

            GetComponent<AudioSource>().Play();

            Destroy(GetComponent<Collider>());

            Destroy(GetComponent<MeshRenderer>());


            GameObject particl =
                Instantiate(Resources.Load("BomsbParticleSystem"),
                gameObject.transform.position, Quaternion.identity) as GameObject;



            particl.transform.SetParent(gameObject.transform);

            yield return new WaitForSeconds(/*0.*/5F);

            Destroy(gameObject);
        }
    }

    /// <summary>
    /// типы объектов
    /// </summary>
    public enum EPlayerObject
    {
        Cube = 0,
        Capsule = 1,
        Cylinder = 2,
        Sphere = 3
    }
}