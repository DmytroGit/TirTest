﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElem : MonoBehaviour
{
    [SerializeField]
    Text text;
    

    void Update()
    {
        text.text = 10;
    }
}