﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Player1", 0);
        PlayerPrefs.SetInt("Player2", 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
