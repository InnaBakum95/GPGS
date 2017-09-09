using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocillate : MonoBehaviour {
    public GameObject ball;
	 public float CurveSpeed = 5;
     public float MoveSpeed = 1;
    public float amplitude;
    
     
     float fTime = 0;
     Vector3 vLastPos = Vector3.zero;
     
     // Use this for initialization
     void Start () 
     {
         vLastPos = transform.position;
     }
     
     // Update is called once per frame
     void Update () 
     {
         vLastPos = transform.position;
         
         fTime += Time.deltaTime * CurveSpeed;
         
         Vector3 vSin = new Vector3(Mathf.Sin(fTime)*amplitude, -Mathf.Sin(fTime)*amplitude, 0);
         Vector3 vLin = new Vector3(0, 1, 0);
         
         transform.position += (vSin + vLin) * Time.deltaTime;
        Debug.DrawLine(vLastPos, transform.position, Color.green, 100);

    }
}
