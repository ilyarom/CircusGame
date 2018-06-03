using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	//Скорость нашей пули
	public float Speed;
	//Время, через которое наша пуля
	//уйдет в пул объектов
	//Каждый раз, когда наша пуля активируется
	void Start()
	{
		gameObject.SetActive(false);
	}

	void Shoot()
	{
		gameObject.SetActive(true);
	}

	void Update()
	{
		//Теперь пуля будет лететь вперед до того, пока объект не будет выключен
		//Так как наша пуля уже повернута в нужную сторону, а в 2D пространстве
		//Вперед это направо, то нашей пуле надо просто лететь направо 
		//отностительно своего мирового пространства
		transform.position = transform.position + transform.right * Speed * Time.deltaTime;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			gameObject.SetActive(false);
		}
	}
}
