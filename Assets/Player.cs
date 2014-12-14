using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

		public float speed = 6;

		// Use this for initialization
		void Start ()
		{

	
		}
	
		// Update is called once per frame
		void Update ()
		{
				rigidbody.MovePosition (transform.position + transform.forward * Time.deltaTime * speed);
				if (Input.GetButtonDown ("Fire1")) {
						GetComponent<Animator> ().SetTrigger ("JUMP");
				}
				if (Input.GetButtonDown ("Fire2")) {
						GetComponent<Animator> ().SetTrigger ("SLIDE");
				}

		}
}
