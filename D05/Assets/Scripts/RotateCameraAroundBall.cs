using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraAroundBall : MonoBehaviour {

	public Ball ball;
	public GameObject arrow;
	public float rotationSpeed;
    public GameManager gameManager;
	
	private Vector3 point;
   
    void Start () {
		ResetPosition();
	}
   
    void Update () {

		if (Input.GetKeyDown(KeyCode.Q)&& !gameManager.cameraIsTravelling)
			ResetPosition();

       	if (Input.GetKey(KeyCode.A) && !gameManager.cameraIsTravelling) 
		{
	   		transform.RotateAround (point,new Vector3(0.0f,-1.0f,0.0f),20 * Time.deltaTime * rotationSpeed);
	   		arrow.transform.RotateAround (point,new Vector3(0.0f,-1.0f,0.0f),20 * Time.deltaTime * rotationSpeed);
		}
	
		if (Input.GetKey(KeyCode.D) && !gameManager.cameraIsTravelling)
		{
			transform.RotateAround (point,new Vector3(0.0f,1.0f,0.0f),20 * Time.deltaTime * rotationSpeed);
			arrow.transform.RotateAround (point,new Vector3(0.0f,1.0f,0.0f),20 * Time.deltaTime * rotationSpeed);
		}
	}

	public void ResetPosition()
	{
		Vector3 hole = gameManager.Holes[gameManager.stage - 1];

		transform.position = ball.transform.position;
		arrow.transform.position = ball.transform.position;
		transform.rotation = Quaternion.identity;
		arrow.transform.rotation = Quaternion.identity;

		transform.Translate((ball.transform.position - hole).normalized * 50f);
		transform.position = new Vector3(transform.position.x, transform.position.y + 10f, transform.transform.position.z);
		
		arrow.transform.Translate((hole - ball.transform.position).normalized * 5f);
		arrow.transform.position = new Vector3(arrow.transform.position.x, arrow.transform.position.y + 10f, arrow.transform.position.z);
        
		point = new Vector3 (ball.transform.position.x, ball.transform.position.y + 5.2f, ball.transform.position.z);
        transform.LookAt(point);
		arrow.transform.LookAt(gameManager.Holes[gameManager.stage - 1]);
		arrow.transform.rotation = transform.rotation * Quaternion.Euler(20,180,0);		
	}
}