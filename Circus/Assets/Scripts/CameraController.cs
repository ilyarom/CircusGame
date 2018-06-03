using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player.transform.position.x, transform.position.y, -1);
	}
}
