using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour {

    RectTransform rc;

	// Update is called once per frame
	private void Start()
	{
        rc = GetComponent<RectTransform>();
	}

	void Update () {
        rc.localScale =  new Vector3(rc.localScale.x + 0.01f, rc.localScale.y + 0.01f );
        if (rc.localScale.x >= 1.5)
            rc.localScale = new Vector3(0, 0, 1);
	}
}
