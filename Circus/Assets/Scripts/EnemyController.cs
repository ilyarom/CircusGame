using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Rigidbody2D enemy;
    public float speed = 20;
    public Rigidbody2D player;
	public GameObject bullet;
	public GameObject respawn;

	private bool rightOrientation = true;

    // Use this for initialization
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        enemy.velocity = Vector2.right;
    }

	public void Shoot()
	{
		Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 1)));
	}

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyVector = enemy.velocity;
        enemyVector = new Vector2(speed, enemyVector.y);

        int direction = (rightOrientation) ? 1 : -1;


        if ((rightOrientation && enemy.position.x > player.position.x + 4) ||
            (!rightOrientation && enemy.position.x < player.position.x - 4))
        {
            Debug.Log("if");
            rightOrientation = !rightOrientation;
            //enemyVector = new Vector2(-speed, enemy.velocity.y);
            direction = -direction;
        }

		//enemy.velocity = enemyVector;
		enemyVector = new Vector2(direction * speed, enemyVector.y);
		enemy.velocity = enemyVector;

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//Тут должна быть ваша обработка попадания
		//Вместо этого условия необходимо ваше, которое определит, что
		//в Collision находится именно тот объект, который вам нужен
		if (collision.tag == "Player")
		{
			//collision.GetComponent<PlayerController>().
			collision.transform.position = respawn.transform.position;
			Debug.Log("PLAYER DIED");
		}
	}

}
