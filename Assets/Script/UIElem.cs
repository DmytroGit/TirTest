using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tir
{
    public class UIElem : MonoBehaviour
    {
        /// <summary>
        /// ссылка на очки в интерфейсе игры
        /// </summary>
        [SerializeField]
        Text text;

        void Update()
        {
            //станавливает значение в UI интерфейса игры
            text.text = DataStatic.CountUser.ToString();
        }
    }
}
