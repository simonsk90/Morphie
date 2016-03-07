﻿using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class GroundController : MonoBehaviour
    {

        PlayerController player;

        void OnTriggerStay2D(Collider2D coll)
        {
            if (coll.tag == "Player" && !player.invulnerable)
            {
                player.StartCoroutine(player.Die2());
            }
        }

        void Start()
        {
            player = HelperFunctions.player;
        }

    }
}