using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
    [SerializeField] private float xAxis;
    [SerializeField] private float yAxis;
    public Rigidbody2D rb2D;
    private Camera zoomCamera;
    public float moveSpeed;
    public float scrollSpeed;

    private void Start()
    {
        zoomCamera = Camera.main;
    }

    void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");

        rb2D.velocity = new Vector2(xAxis, yAxis).normalized * moveSpeed * Time.deltaTime;

        zoomCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime;
        if (zoomCamera.orthographicSize < 0)
        {
            zoomCamera.orthographicSize = 0;
        }
    }
}
