using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {

    public Image fillWaitImage1;
    public Image fillWaitImage2;
    public Image fillWaitImage3;
    public Image fillWaitImage4;
    public Image fillWaitImage5;
    public Image fillWaitImage6;

    private int[] fadeImages = new int[] { 0, 0, 0, 0, 0, 0 };

    private Animator anim;
    private bool canAttack = true;

    private PlayerMove playerMove;

    void Awake () {
        anim = GetComponent<Animator> ();
        playerMove = GetComponent<PlayerMove> ();
    }

    void Update () {
        if (!anim.IsInTransition (0) && anim.GetCurrentAnimatorStateInfo (0).IsName ("Stand")) {
            canAttack = true;
        } else {
            canAttack = false;
        }

        CheckToFade ();
        CheckInput ();
    }

    void CheckInput () {
        if (anim.GetInteger ("Atk") == 0) {
            playerMove.FinishedMovement = false;

            if (!anim.IsInTransition (0) && anim.GetCurrentAnimatorStateInfo (0).IsName ("Stand")) {
                playerMove.FinishedMovement = true;
            }
        }

        if (Input.GetKeyDown (KeyCode.Alpha1)) {

            if (playerMove.FinishedMovement && fadeImages[0] != 1 && canAttack) {
                fadeImages[0] = 1;
                anim.SetInteger ("Atk", 1);

                playerMove.TargetPosition = transform.position;
                RemoveMousePointer ();
            }

        } else if (Input.GetKeyDown (KeyCode.Alpha2)) {

            if (playerMove.FinishedMovement && fadeImages[1] != 1 && canAttack) {
                fadeImages[1] = 1;
                anim.SetInteger ("Atk", 2);

                playerMove.TargetPosition = transform.position;
                RemoveMousePointer ();
            }

        } else if (Input.GetKeyDown (KeyCode.Alpha3)) {

            if (playerMove.FinishedMovement && fadeImages[2] != 1 && canAttack) {
                fadeImages[2] = 1;
                anim.SetInteger ("Atk", 3);

                playerMove.TargetPosition = transform.position;
                RemoveMousePointer ();
            }

        } else if (Input.GetKeyDown (KeyCode.Alpha4)) {

            if (playerMove.FinishedMovement && fadeImages[3] != 1 && canAttack) {
                fadeImages[3] = 1;
                anim.SetInteger ("Atk", 4);

                playerMove.TargetPosition = transform.position;
                RemoveMousePointer ();
            }

        } else if (Input.GetKeyDown (KeyCode.Alpha5)) {

            if (playerMove.FinishedMovement && fadeImages[4] != 1 && canAttack) {
                fadeImages[4] = 1;
                anim.SetInteger ("Atk", 5);

                playerMove.TargetPosition = transform.position;
                RemoveMousePointer ();
            }

        } else if (Input.GetKeyDown (KeyCode.Alpha6)) {

            if (playerMove.FinishedMovement && fadeImages[5] != 1 && canAttack) {
                fadeImages[5] = 1;
                anim.SetInteger ("Atk", 6);

                playerMove.TargetPosition = transform.position;
                RemoveMousePointer ();
            }
        } else {
            anim.SetInteger ("Atk", 0);
        }

        if (Input.GetKey (KeyCode.Space)) {
            Vector3 targetPos = Vector3.zero;

            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast (ray, out hit)) {
                targetPos = new Vector3 (hit.point.x, transform.position.y, hit.point.z);
            }

            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (targetPos - transform.position), 15f * Time.deltaTime);
        }

    } // CheckInput

    void CheckToFade () {
        if (fadeImages[0] == 1) {
            if (FadeAndWait (fillWaitImage1, 1.0f)) {
                fadeImages[0] = 0;
            }
        }

        if (fadeImages[1] == 1) {
            if (FadeAndWait (fillWaitImage2, 0.7f)) {
                fadeImages[1] = 0;
            }
        }

        if (fadeImages[2] == 1) {
            if (FadeAndWait (fillWaitImage3, 0.1f)) {
                fadeImages[2] = 0;
            }
        }

        if (fadeImages[3] == 1) {
            if (FadeAndWait (fillWaitImage4, 0.2f)) {
                fadeImages[3] = 0;
            }
        }

        if (fadeImages[4] == 1) {
            if (FadeAndWait (fillWaitImage5, 0.3f)) {
                fadeImages[4] = 0;
            }
        }

        if (fadeImages[5] == 1) {
            if (FadeAndWait (fillWaitImage6, 0.08f)) {
                fadeImages[5] = 0;
            }
        }

    }

    bool FadeAndWait (Image fadeImg, float fadeTime) {
        bool faded = false;

        if (fadeImg == null) {
            return faded;
        }

        if (!fadeImg.gameObject.activeInHierarchy) {
            fadeImg.gameObject.SetActive (true);
            fadeImg.fillAmount = 1f;
        }

        fadeImg.fillAmount -= fadeTime * Time.deltaTime;

        if (fadeImg.fillAmount <= 0.0f) {
            fadeImg.gameObject.SetActive (false);
            faded = true;
        }

        return faded;
    }

    void RemoveMousePointer () {
        GameObject mousePointerObj = GameObject.FindGameObjectWithTag ("MousePointer");

        if (mousePointerObj) {
            Destroy (mousePointerObj);
        }
    }

} // PlayerAttack