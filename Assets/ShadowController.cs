﻿using UnityEngine;
using System.Collections;

public class ShadowController : MonoBehaviour {

    private bool activated = false;
    private PlayerController player;

    void Awake()
    {
        player = GameObject.Find("Stickman").GetComponent<PlayerController>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
        if (!activated)
        {
            activated = player.helperFunctions.UnitWithinScreenSpace( Camera.main.WorldToScreenPoint(transform.position) );
        }
        else
        {
            
        }
	}

    private void Shrink()
    {

    }
}
