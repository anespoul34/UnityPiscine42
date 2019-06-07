using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorRdmTxt : MonoBehaviour
{

    float timer = 0.1f;
    [SerializeField]
    AnimationCurve curve1;
    [SerializeField]
    AnimationCurve curve2;
    [SerializeField]
    AnimationCurve curve3;
    Text img;

    float color1 = 0.2f;
    float color2 = 0.1f;
    float color3 = 0f;

    // Use this for initialization
    void Start()
    {
        img = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime / 10;
        color1 = curve1.Evaluate(timer);
        color2 = curve2.Evaluate(timer);
        color3 = curve3.Evaluate(timer);
        img.color = new Color(color1, color2, color3);
    }
}
