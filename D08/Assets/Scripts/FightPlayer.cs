using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class FightPlayer : MonoBehaviour {

	NavMeshAgent agent;
	public GameObject Target { get { return target; } set { target = value; } }
	public Text hpText;
	public Text expText;
	
	[SerializeField]private int str;
	[SerializeField]private int agi;
	[SerializeField]private int con;
	[SerializeField]private int armor;

	private GameObject target;

	private int hpMax;
	private int minDamage;
	private int maxDamage;
	[SerializeField]private float cooldown = 0.85f;
	[SerializeField]private float exp = 0f;
	public int lvl = 1;
	private int money = 0;	

	[SerializeField]private GameObject Bar;
	[SerializeField]private GameObject GameOver;
	[SerializeField]private Slider healthBar;
	[SerializeField]private Slider expBar;

	private Animator animator;
	private float cooldownGlobal;
	private int hp, expMax;
	private bool isAttack;

	private bool InRangeAttack;
	
	void Start () {
		hpMax = 5 * con;
		hp = hpMax;

		minDamage = str / 2;
		maxDamage = minDamage + 4;

		expMax = 100;

		GameOver.SetActive(false);
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
	}
	
	void Update () {
		if (target) {
			if (Vector3.Distance(transform.position, target.transform.position) < 2f)
				InRangeAttack = true;
			else 
				InRangeAttack = false;
			if (Input.GetMouseButtonDown(0) && !target.GetComponent<Mob>().isHover)
			{
				target = null;
				isAttack = false;
				RaycastHit hit;

				if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) 
				{
					animator.SetBool("Attack", false);
					animator.SetBool("Run", true);
					agent.destination = hit.point;
				}
			}
		} else { InRangeAttack = false; }
		if (InRangeAttack)
		{
			animator.SetBool("Run", false);
			agent.destination = transform.position;
		}
		if (Input.GetMouseButton(0) && target)
			isAttack = true; 
		if (isAttack && !InRangeAttack && target)
		{
			animator.SetBool("Run", true);
			agent.destination = target.transform.position;
		} 
		else if (isAttack && InRangeAttack && target && cooldownGlobal <= Time.time) 
		{
			cooldownGlobal = Time.time + cooldown;
			transform.LookAt(target.transform.position);
			animator.SetBool("Run", false);
			animator.SetBool("Attack", true);
			isAttack = false;
		}


		healthBar.value = Mathf.Lerp(healthBar.value, (float)hp / (float)hpMax, 0.2f);
		expBar.value = Mathf.Lerp(expBar.value, (float)exp / (float)expMax, 0.2f);
		hpText.text = "HP : " + hp;
		expText.text = "Lvl : " + lvl + "\nNext: " + exp + "/" + expMax;
	}

	public void Hit()
	{
		if (target != null)
			target.GetComponent<Mob>().GetHit(Random.Range(minDamage, maxDamage), agi);
		animator.SetBool("Attack", false);
	}
	public void GetHit(int damage, int enemyAgi)
	{
		var hitChance = 75 + agi - enemyAgi;
		var hit = Random.Range(0, 100);
		if (hit < hitChance)
		{
			hp -= damage * (1 - (armor / 200));
			if (hp <= 0)
			{
				Bar.SetActive(false);
				animator.SetBool("Die", true);
			}
		}
	}
	public void GetExp(int addExp, int addMoney)
	{
		money += addMoney;
		exp += addExp;
		if (exp == expMax)
		{
			lvl += 1;
			expMax *= 2;
			exp = 0;
		}
	}

	public void Die() 
	{
		GameOver.SetActive(true);
	}
}
