using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tir
{
    public static class DataStatic
    {
        static int countUser = 0;

        public static int CountUser
        {
            get { return countUser; }
        }


        public static void SetCountUser(int count)
        {
            countUser += count;

            Debug.Log(countUser);
        }
    }
}
