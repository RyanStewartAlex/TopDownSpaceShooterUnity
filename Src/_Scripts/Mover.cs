using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public const float speed = 20;

	void Start() {
		GetComponent<Rigidbody> ().velocity = transform.forward * speed;
	}

}
