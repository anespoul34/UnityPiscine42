using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ball : MonoBehaviour {

	public RotateCameraAroundBall cam;
	public SoundManager soundManager;
	public GameManager gameManager;
	public Text penality;
	public Text hole;
	public Text hole2;
	public Text par;
	public Text par2;
	public Text rank;
	public Text shot;
	public Text rank1;
	public Text rank2;
	public Text rank3;
	public Text rankFinal;
	public Canvas menu;

	private Vector3 tmpPosition;
	private bool end = false;
	private Rigidbody rb;
	private int penalityCount = 0;
	private int finalScore = -12;

	void Start () {
		rb = GetComponent<Rigidbody>();
		transform.position = gameManager.StartPoint[gameManager.stage - 1];
		cam.ResetPosition();
		hole.text = "Stage 1";
		par.text = "(par 3)";
		hole2.text = "Stage 1";
		par2.text = "(par3)";
		menu.GetComponent<Canvas>();
	}
	
	void Update () {
		
		if (gameManager.isMoving && rb.velocity.x < 0.07f && rb.velocity.x > -0.07f && rb.velocity.y < 0.07f && rb.velocity.y > -0.07f)
		{
			tmpPosition = transform.position;
			gameManager.isMoving = false;
			gameManager.slider.value = 1;
			rb.velocity = new Vector2(0f, 0f);
			cam.ResetPosition();
		}
		if (Input.GetKey(KeyCode.Tab) || end) {
			menu.enabled = true;
		} else {
			menu.enabled = false;
		}
	}

	public void Shoot(float force, float putter)
	{
		tmpPosition = transform.position;
		Vector3 shotPos = new Vector3(cam.transform.position.x, transform.position.y - putter, cam.transform.position.z);
		Vector3 direction = (shotPos - transform.position).normalized;
		rb.AddForce(-direction * force, ForceMode.Impulse);
	}

	void OnTriggerEnter (Collider collider) {

		if (collider.gameObject.layer == 4)
		{
			soundManager.PlayWaterSplash(cam.transform.position);
			transform.position = tmpPosition;
			rb.velocity = new Vector2(0f, 0f);
			cam.ResetPosition();
			penalityCount++;
			penality.text = "Penality : +" + penalityCount.ToString(); 
		}
		if (gameManager.stage == 1 && collider.gameObject.name == "Hole1")
		{
			par.text = "(par 5)";
			hole.text = "Stage 2";
			shot.text = "Shot : " + gameManager.shotCount;
			rank1.text = (-3 + gameManager.shotCount + penalityCount).ToString();
			finalScore += (gameManager.shotCount + penalityCount);
			CheckRank(3);
			Stage(2);
		}
		if (gameManager.stage == 2 && collider.gameObject.name == "Hole2")
		{
			hole.text = "Stage 3";
			par.text = "(par 4)";
			hole2.text = "Stage 2";
			par2.text = "(par 5)";
			shot.text = "Shot : " + gameManager.shotCount;
			rank2.text = (-5 + gameManager.shotCount + penalityCount).ToString();
			finalScore += (gameManager.shotCount + penalityCount);
			CheckRank(5);
			Stage(3);
		} 
		if (gameManager.stage == 3 && collider.gameObject.name == "Hole3")
		{
			transform.position = gameManager.StartPoint[0];
			cam.ResetPosition();
			hole2.text = "Stage3";
			par2.text = "(par 4)";
			soundManager.PlayBallInHole(cam.transform.position);
			soundManager.PlayApplause(cam.transform.position);
			soundManager.PlayVictory(cam.transform.position);
			shot.text = "Shot : " + gameManager.shotCount;
			CheckRank(4);		
			rank3.text = (-4 + gameManager.shotCount + penalityCount).ToString();
			finalScore += (gameManager.shotCount + penalityCount - 3);
			rankFinal.text = "SCORE FINAL : " + finalScore.ToString();
			end = true;
			menu.enabled = true;			
		} 
	}

	void Stage (int stage) 
	{
		rb.velocity = new Vector2(0f, 0f);		
		gameManager.stage = stage;
		soundManager.PlayBallInHole(cam.transform.position);
		soundManager.PlayApplause(cam.transform.position);
		transform.position = gameManager.StartPoint[gameManager.stage - 1];
		cam.ResetPosition();
		gameManager.shotCount = 0;
		penalityCount = 0;
		gameManager.cameraStat.enabled = true;
		gameManager.cameraBall.enabled = false;
		gameManager.menu = true;
	}

	void CheckRank(int par) {
		if (gameManager.shotCount + penalityCount == 0)
			rank.text = "ACE !!!!";
		if (gameManager.shotCount + penalityCount - par == -3)
			rank.text = "ALBATROS !!!";
		if (gameManager.shotCount + penalityCount - par == -2)
			rank.text = "EAGLE !!";
		if (gameManager.shotCount + penalityCount - par == -1)
			rank.text = "BIRDIE !";
		if (gameManager.shotCount + penalityCount - par == 0)
			rank.text = "PAR";
		if (gameManager.shotCount + penalityCount - par == 1)
			rank.text = "BOGEY";
		if (gameManager.shotCount + penalityCount - par == 2)
			rank.text = "DOUBLE BOGEY";
		if (gameManager.shotCount + penalityCount - par == 3)
			rank.text = "TRIPLE BOGEY";
		if (gameManager.shotCount + penalityCount - par >= 4)
			rank.text = "BAD +" + (gameManager.shotCount + penalityCount - par).ToString();

	}
}