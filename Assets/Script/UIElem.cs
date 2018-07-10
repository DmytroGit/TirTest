using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tir
{
    public class UIElem : MonoBehaviour
    {
        [SerializeField]
        Text text;

        void Update()
        {
            text.text = DataStatic.CountUser.ToString();
        }

    }
}
