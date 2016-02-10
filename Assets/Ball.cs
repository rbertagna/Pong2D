﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float speed = 30;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.right * speed;
	}

	float hitFactor(Vector2 ballPos, Vector2 racketPos,

		float racketHeight) {

		// ascii art:

		// || 1 <- at the top of the racket

		// ||

		// || 0 <- at the middle of the racket

		// ||

		// || -1 <- at the bottom of the racket

		return (ballPos.y - racketPos.y) / racketHeight;

	}

	void OnCollisionEnter2D (Collider2D col) {
		if (col.gameObject.name == "RacketLeft") {

			// Calculate hit Factor
			float y = hitFactor (transform.position,
				          col.transform.position,
				GetComponent<BoxCollider2D>().size.y);
			// Calculate direction, make length=1 via .normalized
			Vector2 dir = new Vector2 (1, y).normalized;
			// Set Velocity with dir * speed
			GetComponent<Rigidbody2D> ().velocity = dir * speed;
		}
		// Hit the right Racket?

		if (col.gameObject.name == "RacketRight") {
			// Calculate hit Factor
			float y = hitFactor (transform.position,
				          col.transform.position,
				GetComponent<BoxCollider2D>().size.y);
			// Calculate direction, make length=1 via .normalized
			Vector2 dir = new Vector2 (-1, y).normalized;
			// Set Velocity with dir * speed
			GetComponent<Rigidbody2D> ().velocity = dir * speed;
		}
	}
}
