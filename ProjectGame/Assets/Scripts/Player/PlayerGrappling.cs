using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGrappling : MonoBehaviour
{
	// Start is called before the first frame update
	private Transform positionAgarrar;		
	[SerializeField] private Collider2D playerCol;
	[SerializeField] private Rigidbody2D playerRig;
	[SerializeField] private GameObject alvo;
	[SerializeField] private DistanceJoint2D grap;
	public LineRenderer line;
	public bool onArea;
	public bool isGround = false;
	public bool isGrap = false;
	public	Vector2 agarrar;
	private Vector2 posicao;
	private Vector2 resetPosicao;
	public static PlayerGrappling playerGrap;
	

	void Start()
	{
		playerGrap = this;
		resetPosicao = grap.connectedAnchor;
		line.enabled = false;
	}


	// Update is called once per frame
	void Update()
	{

		Grap();

		if (grap.enabled == true)
		{
			line.SetPosition(0, agarrar);
			line.SetPosition(1, transform.position);
			line.enabled = true;
			isGrap = true;
			if(isGrap == true)
			{
				onArea = true;
			}
			
		}
		if(IsOnGround())
		{
			isGrap = false;
		}
		
	}
	
	

	private void OnTriggerEnter2D(Collider2D other)
	{
		alvo = other.gameObject;
		if (other.CompareTag("GrappleObject"))
		{
			if(!IsOnGround())
			{
				onArea = true;
			}
			posicao = other.transform.position;
		}
	}
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("GrappleObject"))
		{
			onArea = false;
		}
	}
	bool IsOnGround()
	{
		
		return playerCol.IsTouchingLayers(LayerMask.GetMask("Ground"));

	}
	
	void Grap()
	{
		if (onArea == true)
		{
			if (Input.GetKeyDown("q"))
			{
				line.enabled = true;
				// Começa a agarrar quando o botão é pressionado
				agarrar = alvo.transform.position;
				grap.enabled = true;
				grap.connectedAnchor = posicao;
				line.SetPosition(1, agarrar);
				line.SetPosition(0, this.transform.position);

			}
			if (Input.GetKeyDown("space") && isGrap == true)
			{
				line.enabled = false;
				// Encerra o agarrar quando o botão é solto
				isGrap = false;
				grap.enabled = false;
				grap.connectedAnchor = resetPosicao;

				if (Input.GetKey("d"))
				{
					playerRig.velocity += new Vector2(0f, 15f);
				}
				if (Input.GetKey("a"))
				{
					playerRig.velocity += new Vector2(0f, 15f);
				}
				// Outras ações quando o botão é solto, se necessário
			}

		}
		

	}
	

}
