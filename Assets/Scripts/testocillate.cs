using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testocillate : MonoBehaviour {

    public float MoveSpeed = -5.0f;

    public float frequency = 20.0f;  // Speed of sine movement
    public float magnitude = 0.5f;   // Size of sine movement
    private Vector3 axis;

    private Vector3 pos;
    public bool isMoving;

    void Start()
    {
        pos = transform.position;
        //DestroyObject(gameObject, 1.0f);
        axis = transform.right;  // May or may not be the axis you want
        isMoving = true;
    }

    void Update()
    {
        if (isMoving==true)
        {
            pos += transform.up * Time.deltaTime * MoveSpeed;
            transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
            StartCoroutine("stay");
            isMoving = false;
        }
       

    }
    IEnumerator stay()
    {
        yield return new WaitForSeconds(0.1f);
        isMoving = true;
    }
}
