﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUI : MonoBehaviour {
    // Start is called before the first frame update
    public int second = 1;
    void Start() {
        Destroy(gameObject,1);
        
    }

    // Update is called once per frame
    void Update() {

        gameObject.transform.position += new Vector3(0, 3f, 0); ;
    }
}