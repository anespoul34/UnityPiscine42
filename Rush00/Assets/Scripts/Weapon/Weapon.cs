using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public SoundManager soundManager;

	public int _NbProj;
	public int _Ammo;
	public string _name;
	public int _ClipAmmo;
	public float _CoolDownValue;
	protected float _CoolDown;
	public GameObject _Projectile;
	Vector3 mouseDir;
	Rigidbody2D _rb;

	public Sprite hand;
	public Sprite noHand;

	private bool isDropped;
	private Vector3 dropPoint;
	private float dropDist;

    [SerializeField]
    bool PlayerWeapon = true;

	void Start () {
		_rb = GetComponent<Rigidbody2D> ();
		_rb.isKinematic = true;
		isDropped = false;
	}

	void FixedUpdate(){
		var mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mouseDir = mousePos - gameObject.transform.position;
		mouseDir.z = 0.0f;
		mouseDir = mouseDir.normalized;
		if (_CoolDown > 0)
			_CoolDown -= Time.deltaTime;
		if (isDropped && dropDist >= 10.005f)
		{
			dropDist = Vector3.Distance(dropPoint, transform.position);
			transform.Rotate(Vector3.forward * 1000 * Time.deltaTime);
			transform.position = Vector3.MoveTowards(transform.position, dropPoint, 45 * Time.deltaTime);
			transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

		} else {
			isDropped = false;
		}
	}

	public void Lacher(){
		transform.parent = null;
		_rb.isKinematic = false;
		dropPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		dropDist = Vector3.Distance(dropPoint, transform.position);
		GetComponent<BoxCollider2D> ().enabled = true;
		isDropped = true;
	}


	public void ProjShoot(float angle, Vector2 v) {
		GameObject _proj;
		_proj = Instantiate (_Projectile, transform.position, Quaternion.Euler(new Vector2(0,0)));
        _proj.GetComponent<Projectile>()._PlayerProj = PlayerWeapon;
		_proj.transform.rotation = transform.rotation * Quaternion.Euler(0,0,90);
		_proj.GetComponent<Rigidbody2D>().AddRelativeForce(v * _proj.GetComponent<Projectile>()._Velocity);
		if (_name == "Katana") 
		{
			soundManager.WooshSound(transform.position);	
			Destroy(_proj.gameObject, 0.1f);
		}
		else
		{
			soundManager.ShootSound(transform.position);
			Destroy(_proj.gameObject, 10);		
		}
	}

	public void Shoot(){
		var angle = this.GetComponentInParent<Mover> ().angle;
		if (_CoolDown <= 0 && _Ammo > 0) {
			Vector2 vect = Vector2.zero;
			var _move = GetComponentInParent<Mover> ()._rb;
			_move.AddForce (new Vector2(mouseDir.x, mouseDir.y) * -100);
			if (_NbProj == 1 || _NbProj == 5)
				ProjShoot (angle, mouseDir);
			if (_NbProj == 5) {
				vect.Set((mouseDir.x - mouseDir.y) * Mathf.Sqrt(2)/2, (mouseDir.x + mouseDir.y) * Mathf.Sqrt(2)/2);
				ProjShoot(angle + 45, vect);
				vect.Set((mouseDir.x + mouseDir.y) * Mathf.Sqrt(2)/2, (mouseDir.x - mouseDir.y) * Mathf.Sqrt(2)/-2);
				ProjShoot(angle - 45, vect);
				vect.Set(mouseDir.x * Mathf.Sqrt(3)/2 - mouseDir.y / 2, mouseDir.x / 2 + mouseDir.y * Mathf.Sqrt(3)/2);
				ProjShoot(angle + 30, vect);
				vect.Set(mouseDir.x * Mathf.Sqrt(3)/2 + mouseDir.y / 2, mouseDir.x / -2 + mouseDir.y * Mathf.Sqrt(3)/2);
				ProjShoot(angle - 30, vect);
			}
			_CoolDown = _CoolDownValue;
			_Ammo--;
		}
	}

	void OnCollisionEnter2D (Collision2D collider)
	{
		if (isDropped && collider.gameObject.name != "Player" && collider.gameObject.tag != "projectile") {
			isDropped = false;
		}
	}
}
