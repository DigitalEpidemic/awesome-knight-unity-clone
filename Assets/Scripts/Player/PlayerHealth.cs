﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float health = 100f;

    private bool isShielded;

    public bool Shielded {
        get { return isShielded; }
        set { isShielded = value; }
    }

    void Start () {

    }

    public void TakeDamage (float amount) {
        if (!isShielded) {
            health -= amount;

            if (health <= 0f) {
                // Player dies
            }
        }
    }

} // PlayerHealth