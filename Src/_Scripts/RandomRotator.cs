using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	public float speed;
	public float tumble;

	void Start(){
		GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * tumble;
		GetComponent<Rigidbody> ().velocity = -transform.forward * speed;
	}

}
