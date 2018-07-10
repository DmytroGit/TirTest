using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tir
{
    public class Spawner : MonoBehaviour
    {
        public void CreateObject(GameObject gameObject/*, GameObject GameObjectff*/)
        {
            Instantiate(gameObject/*, GameObjectff.transform*/);
        }
    }
}