﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour {

    public float healAmount = 20f;

    void Start () {
        GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ().HealPlayer (healAmount);
    }

} // Heal