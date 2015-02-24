using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;

	public GUIText countText;

	public GUIText winText;

	private int count;

	void Start()
	{
		count = 0;
		refreshCountText ();
		winText.text = "";
	}

	// Update before physics calculation
	void FixedUpdate () 
	{
		float horizontalMove = Input.GetAxis ("Horizontal");
		float verticalMove = Input.GetAxis ("Vertical");

		Vector3 force = new Vector3 (horizontalMove, 0.0f, verticalMove);
		rigidbody.AddForce(force * speed * Time.deltaTime);
	}

	//On collision with other objects
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive(false);
			count++;
			refreshCountText ();
			if (count == 12) {
				winText.text = "You won!";
			}
		}
	}

	private void refreshCountText()
	{
		countText.text = "Counter: " + count.ToString ();
	}

}
