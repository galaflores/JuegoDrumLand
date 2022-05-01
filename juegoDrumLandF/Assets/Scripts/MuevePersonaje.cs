using UnityEngine;
using System.Collections;

public class MuevePersonaje : MonoBehaviour
{

	private Animator animator;
	public float fuerzaSalto = 100f;
	//private bool isGrounded = true;
	private bool dobleSalto = false;
	private bool corriendo = false;
	public float velocidad = 1f;
	public float velocidadY = 10f;


    void Awake()
	{
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
		
	}
}
