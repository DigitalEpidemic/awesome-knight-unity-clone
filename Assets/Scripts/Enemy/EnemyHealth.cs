﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float health = 100f;
    
    public void TakeDamage (float amount) {
        health -= amount;

        print ("Enemy took damage! Health is " + health);

        if (health <= 0) {

        }
    }

} // EnemyHealth