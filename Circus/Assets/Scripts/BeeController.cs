using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour {
	public float speed;
	private Rigidbody2D rigidBody;
	private Vector2 startPosition;
	private bool rightOrientation = true;

	public float angle = 0;
	public float radius = 1.5f;

	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
		startPosition = rigidBody.position;
	}
	
	void Update () {
		angle += Time.deltaTime;

		var x = Mathf.Cos(angle * speed) * radius;
		var y = Mathf.Sin(angle * speed) * radius;
		rigidBody.position = new Vector2(startPosition.x + x, startPosition.y + y);
		/*
		int direction = (rightOrientation) ? 1 : -1;
		Vector2 position = rigidBody.position;


		if (position.x > startPosition.x + 5 || position.x < startPosition.x -5)
		{
			rightOrientation = !rightOrientation;
			direction = -direction;
		}

		rigidBody.velocity = new Vector2(direction * speed, rigidBody.velocity.y);
		*/

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//Тут должна быть ваша обработка попадания
		//Вместо этого условия необходимо ваше, которое определит, что
		//в Collision находится именно тот объект, который вам нужен
		if (collision.tag == "Player")
		{
			gameObject.SetActive(false);
		}
	}

}
