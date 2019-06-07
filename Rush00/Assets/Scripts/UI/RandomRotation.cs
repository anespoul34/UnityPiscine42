using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomRotation : MonoBehaviour {

    float timer = 0.1f;
    [SerializeField]
    AnimationCurve curve1;

    RectTransform rc;


	void Start () {
        rc = GetComponent<RectTransform>();
	}
	
	void Update () {
        timer += Time.deltaTime;
        //rc.rotation.eulerAngles.Set(0, 0, curve1.Evaluate(timer) * 180);
        rc.eulerAngles = new Vector3(0, 0, curve1.Evaluate(timer) * 20);
        Debug.Log(curve1.Evaluate(timer) * 180);
	}
}
