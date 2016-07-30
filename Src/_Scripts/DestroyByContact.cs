using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject plrExplosion;

	private GameObject gameControllerObject;
	private GameController gameControllerScript;

	void Start(){
		gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		gameControllerScript = gameControllerObject.GetComponent<GameController> ();
	}

	void OnTriggerEnter(Collider other){

		if (other.CompareTag("Boundary")){
			return;
		}

		if (other.CompareTag("Bolt")){
			Destroy (other.gameObject);
			Instantiate (explosion, gameObject.transform.position, gameObject.transform.rotation);
			gameControllerScript.IncreaseScore (1);

			if (GameObject.FindGameObjectsWithTag("Asteroid").Length == 2){
				gameControllerScript.roundGoing = false;
			}

		}else if (other.CompareTag("Player")){
			Destroy (other.gameObject);
			Instantiate (plrExplosion, gameObject.transform.position, gameObject.transform.rotation);
			gameControllerScript.GameOver ();
		}
		Destroy (gameObject);

	}
}
