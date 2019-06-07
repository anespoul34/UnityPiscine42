using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Mob : MonoBehaviour {

	public Transform player;
	public GameObject healthBar;
	public Slider sliderHp;
	public bool isHover;
	public string name;

	public Text nameText;
	public Text lvlText;

	[SerializeField]
	private float range, rangeAttack;
	NavMeshAgent agent;
	private Animator animator;
	private bool isAttack;
	private bool Inrange { get { return Vector3.Distance(transform.position, player.position) <= range; } }
	private bool IsAlive { get { return hp > 0; } }
	private bool InrangeAttack { get { return Vector3.Distance(transform.position, player.position) <= rangeAttack; } }
	private float cooldownGlobal;
	private float time = 0;

	[SerializeField]private int str;
	[SerializeField]private int agi;
	[SerializeField]private int con;
	[SerializeField]private int armor;
	[SerializeField]private float cooldown = 0.85f;

	private int hpMax;
	private int minDamage;
	private int maxDamage;
	private int hp;
	private int exp = 20;
	private int money = 20;
	private int lvl = 1;

	void Start () {
		hpMax = con * 5;
		hp = hpMax;

		minDamage = str / 2;
		maxDamage = str + 4;

		lvl = player.GetComponent<FightPlayer>().lvl;

		healthBar.SetActive(false);
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
	}
	
	void Update () {

		if (IsAlive)
		{
			Attack();
			Chase();
		}
		if (player.GetComponent<FightPlayer>().Target == gameObject)
		{
			sliderHp.value = Mathf.Lerp(sliderHp.value, (float)hp / (float)hpMax, 0.2f);
			nameText.text = name;
			lvlText.text = lvl.ToString(); 
		}
	}

	private void Chase() 
	{	
		if (Inrange && !isAttack) 
		{
			animator.SetBool("Run", true);
			agent.destination = player.position;
			transform.LookAt(player);			
		} else {
			agent.destination = transform.position;
			animator.SetBool("Run", false);
		}
	}

	private void Attack()
	{
		if (InrangeAttack) 
		{
			agent.destination = transform.position;
			if (cooldownGlobal <= Time.time)
			{
				cooldownGlobal = Time.time + cooldown;
				animator.SetBool("Attack", true);
				isAttack = true;
			}
			transform.LookAt(player);			
		} else {
			animator.SetBool("Attack", false);
			isAttack = false;
		}
	}

	private void OnMouseOver()
	{
		isHover = true;
		if (IsAlive)
		{
			healthBar.SetActive(true);
			sliderHp.value = (float)hp / (float)hpMax;
			nameText.text = name;
			lvlText.text = lvl.ToString(); 
		}
		if (Input.GetMouseButtonDown(0))
		{
			player.GetComponent<FightPlayer>().Target = gameObject;
		}
	}
	private void OnMouseExit()
	{
		isHover = false;
		healthBar.SetActive(false);
	}
	
	public void Hit()
	{
		player.GetComponent<FightPlayer>().GetHit(Random.Range(minDamage, maxDamage), agi);
	}
	public void GetHit(int damage, int playerAgi) 
	{
		var hitChance = 75 + agi - playerAgi;
		var hit = Random.Range(0, 100);
		if (hit < hitChance){

			hp -= damage * (1 - (armor / 200));
			if (hp <= 0)
			{
				player.GetComponent<FightPlayer>().GetExp(exp, money);		
				player.GetComponent<FightPlayer>().Target = null;
				gameObject.layer = 2;
				healthBar.SetActive(false);
				animator.SetBool("Die", true);
			}
		} else {
		}
	}
	public void Die()
	{
		StartCoroutine(TerminateMob());
		GetComponent<CapsuleCollider>().enabled = false;
		agent.enabled = false;
	}
	
	IEnumerator TerminateMob() {
		var pos = transform.position.y;
		yield return new WaitForSeconds(2);
		
		while (transform.position.y > pos - 0.5f)
		{
			transform.Translate(0f, -0.01f, 0f);
			yield return new WaitForSeconds(0.1f);
		}
		Destroy(gameObject);
	}

}
