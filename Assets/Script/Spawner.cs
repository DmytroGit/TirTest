using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tir
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        Transform transformGameObj;

        public void CreateObject(GameObject gameObject)
        {
            Instantiate(gameObject, transformGameObj.transform.position, Quaternion.identity);
        }
    }
}