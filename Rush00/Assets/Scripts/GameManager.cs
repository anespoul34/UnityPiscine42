using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour {

    [SerializeField]
    GameObject Player;
    [SerializeField]
    List<GameObject> Waypoints;

    public SoundManager soundManager;

    public List<GameObject> Enemies;

    [SerializeField]
    GameObject EndScreen;

    public bool endState = false;
    public bool winState = false;
    public bool play = true;

    public LayerMask WallMask;
    public LayerMask WallMask2;

	void Start () {
	}
	
	void Update () {
        if (play)
        {
            if (Enemies.Count <= 0)
            {
                endState = true;
                winState = true;
                EndScreen.SetActive(true);
                soundManager.WinSound(transform.position);
                play = false;
            }
            if (!Player){
                endState = true;
                EndScreen.SetActive(true);
                soundManager.LooseSound(transform.position);
                play = false;
            }  
        } else {
            foreach(GameObject enemy in Enemies) {
                Destroy(enemy);
            }
        }
	}

    Vector2 GetNextNode(Vector2 CurrentNode, Vector2 StartPoint)
    {
        Vector2 currentWaypoint = CurrentNode;
        float distToCurrent = 0;
        float distToPlayer = Vector2.Distance(currentWaypoint, Player.transform.position);
        foreach (var Waypoint in Waypoints)
        {
            if (Vector2.Distance(currentWaypoint, Waypoint.transform.position) > distToCurrent && Vector2.Distance(StartPoint, Waypoint.transform.position) < distToPlayer) // check for the farsest waypoint from the current one and the closest to the player
            {
                RaycastHit2D hit = Physics2D.Raycast(currentWaypoint, (new Vector2(Waypoint.transform.position.x, Waypoint.transform.position.y) - currentWaypoint).normalized, Mathf.Infinity, WallMask);
                Debug.DrawRay(currentWaypoint, (new Vector2(Waypoint.transform.position.x, Waypoint.transform.position.y) - currentWaypoint), Color.red, 50);
                //Debug.Log("hit = " + hit.transform.tag);
                if (hit && hit.transform.tag != "wall")
                {
                    Debug.Log("hit name =" + hit.transform.tag);
                    distToCurrent = Vector2.Distance(currentWaypoint, Waypoint.transform.position);
                    distToPlayer = Vector2.Distance(Waypoint.transform.position, Player.transform.position);
                    currentWaypoint = Waypoint.transform.position;
                }
            }
        }
        if (currentWaypoint != CurrentNode)
            return (currentWaypoint);
        // Debug.LogError("No path found");
        return (Vector2.zero);
    }

    public List<Vector2> FindPath(Vector2 StartPath){
        List<Vector2> Path = new List<Vector2>();

        Path.Add(StartPath);
        RaycastHit2D Direct = Physics2D.Raycast(StartPath, (new Vector2(Player.transform.position.x, Player.transform.position.y) - StartPath).normalized, Mathf.Infinity, WallMask); //check for direct path
        Debug.DrawRay(StartPath, new Vector2(Player.transform.position.x, Player.transform.position.y) - StartPath, Color.cyan, 50);
        if (Direct.transform.tag == "player"){
            // Debug.Log("direct Path");
            Path.Add(Player.transform.position);
            return (Path);
        }
        RaycastHit2D hit = Direct; //if there is no direct path

        int i = 0; //DEBUG TO DELETE

        while (hit.transform.tag != "player" && i++ < 150){ // while no clear view from waypoint to player

            Vector2 nextWaypoint = GetNextNode(Path[Path.Count - 1], Path[0]); // search a new waypoint from the last one found
            Path.Add(nextWaypoint); // add it to the path
            hit = Physics2D.Raycast(nextWaypoint, (new Vector2(Player.transform.position.x, Player.transform.position.y) - nextWaypoint).normalized, Mathf.Infinity, WallMask2);
        }
        // Debug.Log("Path Found");
        Path = Path.Distinct().ToList();
        return (Path);
    }


}
