using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tir
{

    public class TextWow : MonoBehaviour
    {
        /// <summary>
        /// Отвечает за уничтожение WoW (вызывается в собитии анимации)
        /// </summary>
        public void _Destroy()
        {
            Destroy(gameObject);
        }
    }
}
