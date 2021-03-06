using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MuevePersonaje : MonoBehaviour
{
	public static MuevePersonaje instance;
	public float velX;

	public Animator animator;
	public float fuerzaSalto = 100f;
	private bool dobleSalto = false;
	private bool corriendo = false;
	public float velocidad = 1f;
	public float velocidadY = 10f;

	public GameObject proyectil;
	public GameObject eliminaBarra;
	public GameObject MuestaCanvas;
	public GameObject MuestraGANASTE;

	public AudioSource audioNivel;


	void Awake()
	{
		instance = this;
		animator = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		if (corriendo)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, GetComponent<Rigidbody2D>().velocity.y);
		}
		animator.SetFloat("velocidad", GetComponent<Rigidbody2D>().velocity.x);

		
		if (PruebaPiso.saltando)
		{
			dobleSalto = false;
		}
		animator.SetBool("saltando", !PruebaPiso.saltando);

	}

	// Update is called once per frame
	void Update()
	{
		if (gameObject.transform.position.y < -6.5f)
        {
			SaludPersonaje.instance.vidas = 0;
        }

		velX = GetComponent<Rigidbody2D>().velocity.x;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (corriendo)
			{
				// Hacemos que salte si puede saltar
				if (PruebaPiso.saltando || !dobleSalto)
				{
					GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, fuerzaSalto);
					//rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
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
		if (Input.GetKeyDown(KeyCode.S))
		{
			GameObject nuevoProyectil = Instantiate(proyectil);
			nuevoProyectil.transform.position = gameObject.transform.position;
			nuevoProyectil.SetActive(true);
		}

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Circulo"))
		{
			velocidad = 0f;
			//Destroy(eliminaBarra);
			eliminaBarra.gameObject.SetActive(false);
			MuestaCanvas.gameObject.SetActive(true);

			// Eliminar notas y ojos restantes
			var clones = GameObject.FindGameObjectsWithTag("bloque");
			foreach (var clone in clones)
			{
				Destroy(clone);
			}
		}

	}
}
