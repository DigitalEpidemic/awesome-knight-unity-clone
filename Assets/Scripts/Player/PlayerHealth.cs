using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float health = 100f;

    private bool isShielded;

    private Animator anim;

    public bool Shielded {
        get { return isShielded; }
        set { isShielded = value; }
    }

    void Awake () {
        anim = GetComponent<Animator> ();
    }

    public void TakeDamage (float amount) {
        if (!isShielded) {
            health -= amount;

            //print ("Player took damage! Health is " + health);

            if (health <= 0f) {
                anim.SetBool ("Death", true);

                if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Death") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f) {
                    // Player died
                    // Destroy player
                }
            }
        }
    }

} // PlayerHealth