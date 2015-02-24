using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;

	// Update before physics calculation
	void FixedUpdate () {
		float horizontalMove = Input.GetAxis ("Horizontal");
		float verticalMove = Input.GetAxis ("Vertical");

		Vector3 force = new Vector3 (horizontalMove, 0.0f, verticalMove);
		rigidbody.AddForce(force * speed * Time.deltaTime);
	}
}
