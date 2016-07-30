using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	/*what to do:
	 *  spawn hazards
	 *  keep score
	 */

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float startWait;
	public Text textL;
	public int score;
	public bool roundGoing = false;
	public GameObject gameOverText;
	public GameObject gameOverSubText;

	private bool gOver = false;

	void Start(){
		StartCoroutine (SpawnWaves());
		score = 0;
		UpdateScoreText ();
	}

	void Update(){

		if (!roundGoing){
			StartCoroutine (SpawnWaves());
		}
	}

	public void IncreaseScore(int amount){
		score += amount;
		UpdateScoreText ();
	}

	IEnumerator SpawnWaves(){
		roundGoing = true;
		yield return new WaitForSeconds (startWait);
		for (int i = 0; i < hazardCount; i++) {
			Vector3 spawnPos = new Vector3 (Random.Range (-6.5f, 6.5f), spawnValues.y, spawnValues.z);
			Quaternion spawnRot = Quaternion.identity;

			GameObject made = Instantiate (hazard, spawnPos, spawnRot) as GameObject;
			made.tag = "Asteroid";
			yield return new WaitForSeconds (startWait);
		}
	}

	void UpdateScoreText(){
		textL.text = "Points: " + score;
	}

	public void GameOver(){
		gOver = true;
		roundGoing = true;

		foreach (GameObject g in GameObject.FindGameObjectsWithTag("Asteroid")){
			Destroy (g);
		}
		gameOverText.SetActive (true);
	}

}
