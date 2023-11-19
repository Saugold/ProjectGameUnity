using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;



public class Player : MonoBehaviour
{


	public float velocidadeNormal = 5f;
	public float velocidadeRapida = 10f;
	private bool canDash = true;//pode dar Dash
	private bool isDashing;
	public ParticleSystem poeira;
	[SerializeField] private float dashingPower = 3f;
	[SerializeField] private float dashingTime = 0.5f;
	[SerializeField] private float dashingCooldown = 0.5f;
	[SerializeField] TrailRenderer tr;
	public Animator animator;
	private bool flipX;
	[SerializeField] float jumpForce = 10f;
	private bool segurandoShift = false;
	[SerializeField]
	private int lifePlayer;
	public bool dead = false;

	public Rigidbody2D playerRigidBody;

	private float movimentoHorizontal;
	private SpriteRenderer sprite;
	CapsuleCollider2D playerCollider;
	public bool isjumping = false;

	public float kbForce;
	public float kbCount;
	public float kbTime;
	public bool isKnockRight;
	public static Player playerRef;


	private void Awake()
	{
		playerRef = this;
		playerRigidBody = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		playerCollider = GetComponent<CapsuleCollider2D>();
		animator = GetComponent<Animator>();


	}
	
	private void Update()
	{
		//Jump();
	}

	//Levantar poeira
	private void CriarPoeira()
	{
		poeira.Play();
	}
	private void PlayerMove()
	{
		// Obter entrada horizontal (eixo X) do jogador
		float movimentoHorizontal = Input.GetAxis("Horizontal");

		// Definir velocidade atual com base na tecla Shift
		float velocidadeAtual = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? velocidadeRapida : velocidadeNormal;
		
		
		// Atualizar o Animator para executar a animação correta
		//animator.SetBool("isWalking", Mathf.Abs(movimentoHorizontal) > 0);
		//animator.SetBool("isRunning", Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));

		// Mover o personagem
		Vector3 movimento = new Vector3(movimentoHorizontal, 0f, 0f);
		transform.position += movimento * velocidadeAtual * Time.deltaTime;
		if (flipX == false && movimentoHorizontal < 0)
		{
			

            Flip(); //inverte a sprite
		}
		else if (flipX == true && movimentoHorizontal > 0)
		{
           
            Flip();
		}
	}
	private void Flip()
	{
		if(IsOnGround())
		{
            CriarPoeira();
        }
        
        flipX = !flipX;
		float x = transform.localScale.x;
		x *= -1;
		transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
	}
	private void OnShiftPressed()
	{
		segurandoShift = true;
	}

	private void OnShiftReleased()
	{
		segurandoShift = false;
	}


	private void FixedUpdate()
	{

		KnockLogic();

	}
	void KnockLogic()
	{
		if (kbCount < 0)
		{
			PlayerMove();
		}
		else
		{
			if(isKnockRight == true)
			{
				playerRigidBody.velocity = new Vector2(-kbForce, kbForce);
			}
			if (isKnockRight == false)
			{
				playerRigidBody.velocity = new Vector2(kbForce, kbForce);
			}
		}
		kbCount -= Time.deltaTime;
	}

	void OnDash(InputValue value)
	{
		if (canDash == true)
		{
            CriarPoeira();
            StartCoroutine(Dash());
			if (value.isPressed)
			{
				//animator.SetTrigger("isDashing");
				//StartCoroutine(PlayIdleAnimation());

			}


		}
	}
	IEnumerator PlayIdleAnimation()
	{
		// Aguarde um pequeno atraso antes de iniciar a animação "Player Idlle".
		yield return new WaitForSeconds(0.6f);

		// Inicie a animação "Player Idlle".
		animator.Play("Player Idlle");
	}


	//Metodo para dar Dash

	//Metodo para pular
	void OnJump(InputValue value) //usando inputSystem
	{
		if (!IsOnGround())//se o player não estiver encostando no Ground
		{                                                                  //ele não faz nada
			return;
		}
		if (value.isPressed)
		{
            CriarPoeira();
            playerRigidBody.velocity += new Vector2(0f, jumpForce);

			isjumping = true;
			
		}
	}
		

		 public bool IsOnGround()
		{
			return playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
			
		}

		IEnumerator Dash()
		{

			canDash = false;
			isDashing = true;
        /*if (isDashing == true)
        {
            animator.SetBool("isDashing", true);
            animator.SetBool("isDashing", false);
        }*/


			
			float valorGravidade = playerRigidBody.gravityScale;
			playerRigidBody.gravityScale = 0f;
			playerRigidBody.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
			tr.emitting = true;
			yield return new WaitForSeconds(dashingTime);
			tr.emitting = false;
			playerRigidBody.gravityScale = valorGravidade;
			isDashing = false;
			yield return new WaitForSeconds(dashingTime);
			canDash = true;
		}

}

