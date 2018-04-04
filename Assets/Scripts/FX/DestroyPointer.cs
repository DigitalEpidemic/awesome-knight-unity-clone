using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPointer : MonoBehaviour {

	private Transform player;


	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update () {
		if (Vector3.Distance (transform.position, player.position) <= 1.1f) {
			Destroy (gameObject);
		}
	}

} // DestroyPointer