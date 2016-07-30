using UnityEngine;
using System.Collections;

[System.Serializable] //it's in its own class so it is more tidy in the inspector.
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public Boundary bounds;
	public float tilt;
	public GameObject bolt;

	private const float speed = 10;
	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate(){
		float mHoriz = Input.GetAxis ("Horizontal");
		float mVert = Input.GetAxis ("Vertical");

		rb.velocity = new Vector3 (mHoriz * speed, 0.0f, mVert * speed);

		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, bounds.xMin, bounds.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, bounds.zMin, bounds.zMax));

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);

	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Mouse0)){
			GetComponent<AudioSource> ().Play ();
			GameObject clone = Instantiate (bolt, transform.position + new Vector3 (0, 0, 1), bolt.transform.rotation) as GameObject;
		}
	}

}
