using System;
using UnityEngine;

public class DestroyBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other){
		if (other.CompareTag("Asteroid")){
			return;
		}
		Destroy (other.gameObject);
	}

}

