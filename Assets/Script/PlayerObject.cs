using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tir
{
    public class PlayerObject : MonoBehaviour
    {
        public EPlayerObject ePlayerObject;

      public  bool isNew = true;

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
            if(other.gameObject.GetComponent<PlayerObject>().ePlayerObject == this.ePlayerObject)
            {
                isNew = false;

                if(other.gameObject.GetComponent<PlayerObject>().isNew)
                {
                    return;
                }

                Destroy(other.gameObject);
                //other.gameObject.GetComponent<PlayerObject>().Death();
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

        public void Death()
        {
            //Destroy(other.gameObject);
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