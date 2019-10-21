using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankMovement : MonoBehaviour {

	public float Speed;								//var p/ controlar a velocidade do Tank
	public float turnSpeed;							//var p/ controlar a velocidade de rotaçao do Tank
	public int playerNumber;						//var quedefine player 1 ou 2
	public int ammo;

	public Text ammoText;

	public GameObject bullet;						//var prefab da bullet
	public Transform bulletPosition;				//var posiçao da instanciaçao da bullet
	public GameObject gameMenager;
	[HideInInspector]
	public GameMenagerScript gm;
			
	private Rigidbody rb;							//var que recebe o rigidBody do Tank
	private float horizontalAxisInput;				//var que recebe a leitura do eixo horizontal
	private float verticalAxisInput;				//var que recebe a leitura do eixo vertical 
	private string axisHorizontalName;				//var que guarda o eixo de movimentação horizontal do player
	private string axisVerticalName;				//var que huarda o eixo vertical do player
	private string fireButtonName;					//var que guarda o botão de tiro do player

	public ParticleSystem dust;

	public AudioClip cannonFireAudio;
	public Transform cameraPosition;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();							//rb recebe rigidBody do objrto Tank	
		gm = gameMenager.GetComponent<GameMenagerScript> ();		//gm recebe o componente gameMenageScript do objeto gameMenage
		axisHorizontalName=("Horizontal"+playerNumber.ToString()); 	//var que recebe o nome do eixo horizontal do player
		axisVerticalName = ("Vertical" + playerNumber.ToString ());	//var que recebe o nome do eixo vertical do palyer
		fireButtonName = ("Fire" + playerNumber.ToString ());		//var que recebe o tiro do player
		ammoText.text="Ammo"+ammo.ToString();
	}

	// Update is called once per frame
	void Update () {

		//leitura dosd eixo na funçao update
		horizontalAxisInput = Input.GetAxis (axisHorizontalName);
		verticalAxisInput = Input.GetAxis (axisVerticalName);

		if (Input.GetButtonDown (fireButtonName)&&ammo>=1) 
		{
			//Instancia o gameObject bullet na posiçao e rotaççao do objeto bulletPositions
			Instantiate(bullet, bulletPosition.transform.position, bulletPosition.transform.rotation);
			ammo--;

			ammoText.text = "Ammo" + ammo.ToString();

			AudioSource.PlayClipAtPoint (cannonFireAudio, cameraPosition.transform.position, 0.2f);
		}
		ammoText.text="Ammo"+ammo.ToString();
		
	}

	//funçao (FixedUpdate) utilizada para simulaçoes fisicas
	void FixedUpdate ()
	{
		Move ();
		Turn ();
	}

	//funçao p/ mover o Tank
	private void Move ()
	{
		//vetor na direçao para qual o Tank esta virado multiplicado pelos valores do eixo e pela velocidade
		Vector3 movement = (transform.forward * verticalAxisInput * Speed * Time.deltaTime);
		
		//aplicaçao do movomento, somando o vetor criado com a posiçao do rb
		rb.MovePosition (rb.position + movement);

		//instancia poeira
		Instantiate (dust, transform.position, transform.rotation);

	}

	//funçaop p/ girar o Tank
	private void Turn ()
	{
		//determina o numero, em graus, da rotaçao baseada no input
		float turn = (horizontalAxisInput * turnSpeed * Time.deltaTime);

		//cria var p/ rotaçao no eixo Y
		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

		//aplica a rotaçao no rigidBody
		rb.MoveRotation (rb.rotation * turnRotation);
	}
}


