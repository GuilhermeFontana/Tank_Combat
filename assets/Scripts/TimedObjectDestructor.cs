using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObjectDestructor : MonoBehaviour {

	public float timeToDestroy;

	// Use this for initialization
	void Start () {

		Invoke ("DestroyGameObject", timeToDestroy);
	}

	//função p/ destruir o GameObject ao qual o script esta aplicado
	public void DestroyGameObject()
	{
		Destroy (gameObject);
	}

}