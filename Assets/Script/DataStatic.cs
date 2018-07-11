using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tir
{
    public static class DataStatic
    {
        /// <summary>
        /// текущее значение очков в игре
        /// </summary>
        static int countUser = 0;

        /// <summary>
        /// возвращает сколько очков на данный момент
        /// </summary>
        public static int CountUser
        {
            get { return countUser; }
        }

        /// <summary>
        /// для изменения текущего состояния очков
        /// </summary>
        /// <param name="count"></param>
        public static void SetCountUser(int count)
        {
            countUser += count;

            Debug.Log(countUser);
        }
    }
}
