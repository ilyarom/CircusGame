using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Rigidbody2D enemy;
    public float speed = 20;
    public Rigidbody2D player;
    private bool rightOrientation = true;

    // Use this for initialization
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        enemy.velocity = Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyVector = enemy.velocity;
        enemyVector = new Vector2(speed, enemyVector.y);

        int direction = (rightOrientation) ? 1 : -1;


        if ((rightOrientation && enemy.position.x > player.position.x + 1) ||
            (!rightOrientation && enemy.position.x < player.position.y - 1))
        {
            Debug.Log("if");
            rightOrientation = !rightOrientation;
            //enemyVector = new Vector2(-speed, enemy.velocity.y);
            direction = -direction;
        }

        //enemy.velocity = enemyVector;
        enemyVector = new Vector2(direction * speed, enemyVector.y);
    }
}
