using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 1000f;
	public float speedInJump = 20f;
	public float jumpForce = 150;
	private Rigidbody2D rigidbody;
	public SpriteRenderer sprite;
	private AudioSource source;
	public EnemyController enemy;

	private bool rightOrientation = true;
	private bool isGrounded = false;
	private CharState state = CharState.Run;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		//sprite = GetComponent<SpriteRenderer>();
		source = GetComponent<AudioSource>();
		//Debug.Log("PLAYER: " + rigidbody.velocity.x + " : " + rigidbody.velocity.y);
	}

	private void FixedUpdate()
	{
		CheckGround();
	}

	private void ChangeColor()
	{
		//const float GREEN_COEFFICIENT = 0.05f;
		//const float BLUE_COEFFICIENT = 0.1f;
		Color old = sprite.color;
		sprite.color = new Color(old.r, old.g, old.b, old.a - 0.1f);
	}

	// Update is called once per frame
	void Update () {
		float moveX = Input.GetAxis("Horizontal");
        float playerSpeed = (state == CharState.Jump) ? speedInJump : speed;
		//rigidbody.MovePosition(rigidbody.position + Vector2.right * moveX * playerSpeed * Time.deltaTime);

		//rigidbody.MovePosition(transform.position + Vector3.right * moveX * playerSpeed * Time.deltaTime);
		Vector2 velocity = rigidbody.velocity;
		rigidbody.velocity = new Vector2( moveX * playerSpeed, velocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow) && state == CharState.Run)
		{
			rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}



		if (Input.GetKeyDown(KeyCode.V))
		{
			ChangeColor();
			//sprite.color = Color.Lerp(Color.red	, Color.black, 0.03f);
		}

		if (moveX > 0 && !rightOrientation)
		{
			flip();
		}
		else if (moveX < 0 && rightOrientation)
		{
			flip();
		}
	}

	private void flip()
	{
		rightOrientation = !rightOrientation;
		transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
	}

	private void CheckGround()
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1.2f);

		isGrounded = colliders.Length > 2;
		//Debug.Log(colliders.Length);
		if (!isGrounded)
		{
			state = CharState.Jump;
		}
		else
		{
			state = CharState.Run;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("triiggered");
		if (other.tag == "trampoline")
		{
			rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
		if (other.tag == "bee")
		{
			source.PlayOneShot(source.clip, 99f);
		}
	}
}

public enum CharState
{
	Run,
	Jump
}
