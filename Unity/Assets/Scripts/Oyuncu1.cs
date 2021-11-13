﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oyuncu1 : MonoBehaviour
{
    [SerializeField]
    float speed = 7f;
    float yPosisyon;
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0f, speed * Time.deltaTime, 0f);
        }
        else if (Input.GetKey(KeyCode.DownArrow)) 
        {
            transform.Translate(0f, -speed * Time.deltaTime, 0f);
        }
        yPosisyon = Mathf.Clamp(transform.position.y, -2.4f, 2.4f);
        transform.position = new Vector2(transform.position.x, yPosisyon);
    }
}
