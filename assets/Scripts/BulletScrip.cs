using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScrip : MonoBehaviour {

	public float bulletSpeed;
	private Rigidbody rb;	

	public ParticleSystem bulletExplosion;

	public Transform cameraPosition;
	public AudioClip bulletExplosionSound;

	// Use this for initialization
	void Start () {

		rb = GetComponent <Rigidbody> ();
		rb.AddForce (transform.forward * bulletSpeed);
	}	

	void OnTriggerEnter (Collider other)
	{

		if (other.tag == "Player1") 
		{
			other.GetComponent<TankMovement> ().gm.AddPlayer2Score();
		}

		if (other.tag == "Player2") 
		{
			other.GetComponent<TankMovement>().gm.AddPlayer1Score();
		}

		Instantiate (bulletExplosion, transform.position, transform.rotation);

		AudioSource.PlayClipAtPoint (bulletExplosionSound, cameraPosition.transform.position, 0.5f);

		Destroy (gameObject);	
	}
}