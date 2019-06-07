using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Ball ball;
	public Slider slider;
	public Text shotNbr;
	public Text clubText;
	public SoundManager soundManager;
	public List<Vector3> Holes;
	public List<Vector3> StartPoint;
	public Camera cameraBall;
	public Camera cameraTravel;
	public Camera cameraStat;
	public bool cameraIsTravelling = false;
	public bool isMoving = false;
	public bool menu = false;
	public int shotCount = 0;
	public int stage;
	
	private int club = 0;
	private Vector2 forceAndAngle;
	
	private bool readyToShoot;
	private float sliderSpeed = 5;


	void Start () {
		shotNbr.text = "Shot : " + shotCount.ToString();
		Time.timeScale = 2.0f;
		readyToShoot = false;
		stage = 1;
		cameraBall.enabled = true;
		cameraTravel.enabled = false;
		cameraStat.enabled = false;
		clubText.text = "Club : Wood";
		forceAndAngle = new Vector2(1f, 10f);
	}

	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
		if (!menu) {
			if (!cameraIsTravelling)
			{
				shotNbr.text = "Shot : " + shotCount.ToString();
				if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.KeypadPlus)) {
					club++;
					if (club == 4)
						club = 0;
					if (club == 0)
					{
						clubText.text = "Club : Wood";
						forceAndAngle = new Vector2(1f, 10f);
					}
					if (club == 1)
					{
						clubText.text = "Club : Iron";
						forceAndAngle = new Vector2(0.6f, 30f);
					}
					if (club == 2)
					{
						clubText.text = "Club : Wedge";
						forceAndAngle = new Vector2(0.3f, 80f);
					}
					if (club == 3)
					{
						clubText.text = "Club : Putter";
						forceAndAngle = new Vector2(0.5f, 0f);
					}
				}
				if (readyToShoot && !isMoving) {
					if (slider.value >= 10)
						sliderSpeed *= -1;
					if (slider.value <= 1)
						sliderSpeed *= -1;
					slider.value += sliderSpeed * Time.deltaTime;		
				}
				if (Input.GetKeyDown(KeyCode.Space) && readyToShoot && !isMoving) 
				{
					if (club == 0)
						soundManager.PlayWoodShot(ball.transform.position);
					if (club == 1)
						soundManager.PlayIronShot(ball.transform.position);
					if (club == 2)
						soundManager.PlayWedgeShot(ball.transform.position);
					if (club == 3)
						soundManager.PlayPutterShot(ball.transform.position);
					readyToShoot = false;
					isMoving = true;
					shotCount++;
					Debug.Log(forceAndAngle.x);
					Debug.Log(forceAndAngle.y);
					ball.Shoot(slider.value * forceAndAngle.x, forceAndAngle.y);
				} 
				else if (Input.GetKeyDown(KeyCode.Space) && !readyToShoot && !isMoving) 
					readyToShoot = true;

				if (Input.GetKeyDown(KeyCode.E))
				{
					cameraTravel.transform.position = cameraBall.transform.position;
					cameraTravel.transform.rotation = cameraBall.transform.rotation *  Quaternion.Euler(0,0,0);

					cameraIsTravelling = true;
					cameraBall.enabled = false;
					cameraTravel.enabled = true;
				}
			} else if (cameraIsTravelling) {
				if (Input.GetKeyDown(KeyCode.Space)) {
					cameraIsTravelling = false;
					cameraBall.enabled = true;
					cameraTravel.enabled = false;
				}
			}
		} else {
			if (Input.GetKeyDown(KeyCode.Return)) {
				cameraStat.enabled = false;
				cameraBall.enabled = true;
				menu = false;
			}
		}
	}
}