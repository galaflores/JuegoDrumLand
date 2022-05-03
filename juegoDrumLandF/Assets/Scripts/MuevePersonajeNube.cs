using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuevePersonajeNube : MonoBehaviour
{
	public static MuevePersonajeNube instance;
	public float velX;

	private Animator animator;
	public float fuerzaSalto = 100f;
	private bool dobleSalto = false;
	private bool corriendo = false;
	public float velocidad = 1f;
	public float velocidadY = 10f;

	public GameObject proyectil;

	public GameObject eliminaBarra;
	public GameObject MuestaCanvas;
	public GameObject MuestraGANASTE;

	void Awake()
	{
		instance = this;
		animator = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		if (corriendo)
		{
			animator.SetFloat("velocidad", GetComponent<Rigidbody2D>().velocity.x);
		}


		if (PruebaPiso.saltando)
		{
			dobleSalto = false;
			animator.SetBool("saltando", !PruebaPiso.saltando);
		}

	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetKeyDown(KeyCode.Space))
		{
			velX = 1;
			if (corriendo)
			{
				// Hacemos que salte si puede saltar
				if (PruebaPiso.saltando || !dobleSalto)
				{
					GetComponent<Rigidbody2D>().velocity = new Vector2(0, fuerzaSalto);
					if (!dobleSalto && !PruebaPiso.saltando)
					{
						dobleSalto = true;
					}
				}
			}
			else
			{
				corriendo = true;
			}
		}

		//Disparar
		if (Input.GetKeyDown(KeyCode.D))
		{
			GameObject nuevoProyectil = Instantiate(proyectil);
			nuevoProyectil.transform.position = gameObject.transform.position;
			nuevoProyectil.SetActive(true);
		}

	}
}
