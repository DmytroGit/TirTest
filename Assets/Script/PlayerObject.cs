﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tir
{
    public class PlayerObject : MonoBehaviour
    {
        [SerializeField]
        GameObject partile;

        public EPlayerObject ePlayerObject;

        [HideInInspector]
        public bool isNew = true;


        [SerializeField]
        int count = 0;
        //private void Awake()
        //{
        //    //BroadcastMessage("SetISNew");
        //}

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
        }

        public void SetISNew()
        {
            isNew = false;
        }


        //private void OnCollisionEnter(Collision collision)
        //{

        //}

        //private void OnCollisionStay(Collision collision)
        //{
        //    if(collision.gameObject.GetComponent<PlayerObject>().ePlayerObject == this.ePlayerObject)
        //    {
        //        collision.gameObject.GetComponent<PlayerObject>().Death();
        //    }
        //}
        private void Update()
        {
            //if(Input.GetKeyDown(KeyCode.Space))
            //{
            //   GameObject d =  Resources.Load<>("Cube");
            //}
        }
        public void Death()
        {
            StartCoroutine(IDeath());
        }

        public IEnumerator IDeath()
        {
            DataStatic.SetCountUser(count);

            GetComponent<AudioSource>().Play();

            Destroy(GetComponent<Collider>());
            //Destroy(GetComponent<PlayerObject>());
            Destroy(GetComponent<MeshRenderer>());

            /*if(Input.GetKeyDown(KeyCode.Space))
            {*/
                //Debug.Log("1");

            GameObject  particl=    
                Instantiate(Resources.Load("BomsbParticleSystem"),
                gameObject.transform.position, Quaternion.identity) as GameObject;

            particl.transform.SetParent(gameObject.transform);
                //Debug.Log("2");
           /* }*/

            yield return new WaitForSeconds(/*0.*/5F);

            Destroy(gameObject);
        }
    }

    public enum EPlayerObject
    {
        Cube = 0,
        Capsule = 1,
        Cylinder = 2,
        Sphere = 3
    }
}