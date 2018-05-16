using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 30f;
	public float speedInJump = 20f;
	public float jumpForce = 150;
	private Rigidbody2D rigidbody;

	private bool rightOrientation = true;
	private bool isGrounded = false;
	private CharState state = CharState.Run;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		CheckGround();
	}

	// Update is called once per frame
	void Update () {
		float moveX = Input.GetAxis("Horizontal");
		float playerSpeed = (state == CharState.Jump) ? speedInJump : speed;
		rigidbody.MovePosition(rigidbody.position + Vector2.right * moveX * playerSpeed * Time.deltaTime);
		if (Input.GetKeyDown(KeyCode.UpArrow) && state == CharState.Run)
		{
			rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
	}
}

public enum CharState
{
	Run,
	Jump
}
