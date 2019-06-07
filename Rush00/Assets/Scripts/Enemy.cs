using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    GameObject Projectile;
    [SerializeField]
    GameManager GameManager;
    [SerializeField]
    int speed = 2;

    public SoundManager soundManager;

    GameObject Player;

    [SerializeField]
    List<Vector2> Path;

    [SerializeField]
    LayerMask Mask;

    Vector2 CurrentWaypointTarger;
    int currentWaypoint = 0;
    bool Move = false;
    bool TargetPlayer = false;
    [SerializeField]
    bool Patroling = false;
    bool follow = false;
    bool shooting = false;

    [SerializeField]
    int distEngage = 1;

	void Start () {
        CurrentWaypointTarger = transform.position;
        Player = GameObject.Find("Player");
        Move = Patroling;
    }
	
    void Shoot(){
        GameObject t = Instantiate(Projectile, transform.position + new Vector3(0f,0f, 1f), Quaternion.identity) as GameObject; //shoot
        soundManager.ShootSound(transform.position);
        t.transform.rotation = transform.rotation * Quaternion.Euler(0,0,-90);
        t.GetComponent<Rigidbody2D>().AddForce((Player.transform.position - transform.position).normalized * t.GetComponent<Projectile>()._Velocity);
    }

	void Update () {
        if (currentWaypoint == Path.Count && Path.Count > 0)
            follow = true;
        if (Move && Path != null && Path.Count > 1 && !follow && currentWaypoint < Path.Count){ // if there is a Path, follow it.
            if (CurrentWaypointTarger.Equals(new Vector2(transform.position.x, transform.position.y)) && currentWaypoint + 1 <= Path.Count) //if the enemy is at the waypoint look for the next one
            {
                currentWaypoint++;
                CurrentWaypointTarger = Path[currentWaypoint];
            }
            if (!transform.position.Equals(CurrentWaypointTarger)) // move to the waypoint
                transform.position = Vector2.MoveTowards(transform.position, CurrentWaypointTarger, speed * Time.deltaTime);
        }
        if (TargetPlayer)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, (Player.transform.position - transform.position).normalized, Mathf.Infinity, Mask);
            Debug.Log("Is trying to shoot at:" +hit.transform.tag);
            Debug.DrawRay(transform.position, (Player.transform.position - transform.position).normalized, Color.green, 50);
            if (hit && hit.transform.tag == "player") //if Enemy as line of sight
            {
                Debug.Log("Player in sight! SHOOT!");
                if (!shooting)
                {
                    shooting = true;
                    InvokeRepeating("Shoot", 0f, 0.3f);
                }
                transform.rotation = Quaternion.AngleAxis(Mathf.Atan2((Player.transform.position - transform.position).y, (Player.transform.position - transform.position).x) * Mathf.Rad2Deg + 90, Vector3.forward);
                Move = false; //and stop moving
            }
            else if (((hit && hit.transform.tag != "player") || !hit) && TargetPlayer)
            {
                Move = true;
                CancelInvoke("Shoot");
                shooting = false;
            }
            var dir = Player.transform.position - transform.position;
            transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90, Vector3.forward);
        }
        if (Patroling == true && currentWaypoint == Path.Count){
            currentWaypoint = -1; follow = false;
        }
        if (follow == true && Mathf.Abs(Vector2.Distance(transform.position, Player.transform.position)) > distEngage)
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
            
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.tag == "player" || collision.tag == "PlayerProjectile"){ //If Player enter detection area
            Path = GameManager.FindPath(transform.position); //search a path to the player
            TargetPlayer = true; //target mode = true
            Patroling = false;
        }
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.tag == "PlayerProjectile")
            Destroy(gameObject);
	}

	public void Death(){
        soundManager.PlayDeath(transform.position);
        GameManager.Enemies.Remove(gameObject);
        Destroy(gameObject);
    }
}
