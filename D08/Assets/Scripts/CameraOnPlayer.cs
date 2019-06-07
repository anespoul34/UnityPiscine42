using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraOnPlayer : MonoBehaviour {

	public Player player;
	public Vector3 pos;
	
	void Start () {
	
	}
	
	void Update () {
		transform.position = player.transform.position;
		transform.position = new Vector3(transform.position.x + pos.x, transform.position.y + pos.y, transform.position.z + pos.z);
		transform.LookAt(player.transform);
	}

	public void ReloadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Quit() 
	{
		Application.Quit();
	}

}
