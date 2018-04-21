using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float health = 100f;

    private bool isShielded;

    private Animator anim;

    private Image healthImage;

    public bool Shielded {
        get { return isShielded; }
        set { isShielded = value; }
    }

    void Awake () {
        anim = GetComponent<Animator> ();
        healthImage = GameObject.Find ("Health Icon").GetComponent<Image> ();
    }

    public void TakeDamage (float amount) {
        if (!isShielded) {
            health -= amount;

            healthImage.fillAmount = health / 100f;

            //print ("Player took damage! Health is " + health);

            if (health <= 0f) {
                anim.SetBool ("Death", true);

                if (!anim.IsInTransition (0) && anim.GetCurrentAnimatorStateInfo (0).IsName ("Death") && anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 0.95f) {
                    // Player died
                    // Destroy player
                }
            }
        }
    }

    public void HealPlayer (float healAmount) {
        health += healAmount;

        if (health > 100f) {
            health = 100f;
        }

        healthImage.fillAmount = health / 100f;
    }

} // PlayerHealth