using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float maxY = 400;
    private float minY = 40f;
    private float maxX = 850;
    private float minX = 150;
    private float maxZ = 850;
    private float minZ = 150;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Start() {
    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var y = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.E)) {
            y = 1;
        } else if (Input.GetKey(KeyCode.Q)) {
            y = -1;
        } else {
            y = 0;
        }
        transform.Translate(x, y, z);

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        if (transform.position.x < minX)
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        if (transform.position.x > maxX)
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);

        if (transform.position.y < minY)
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);
        if (transform.position.y > maxY)
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);

        if (transform.position.z < minZ)
            transform.position = new Vector3(transform.position.x, transform.position.y, minZ);
        if (transform.position.z > maxZ)
            transform.position = new Vector3(transform.position.x, transform.position.y, maxZ);
    }
}