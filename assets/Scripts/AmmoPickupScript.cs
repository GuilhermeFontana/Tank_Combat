using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickupScript : MonoBehaviour {

	public int AmmoOnTheBox;

	public Transform cameraPosition;
	public AudioClip reloadSound;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player1"||other.tag == "Player2");  
		{
			int temp = other.GetComponent<TankMovement>().ammo;
			other.GetComponent<TankMovement>().ammo = temp+AmmoOnTheBox;

			Destroy(gameObject);

			AudioSource.PlayClipAtPoint (reloadSound , cameraPosition.transform.position, 0.5f);
		}

		Destroy (gameObject);
	}
}
