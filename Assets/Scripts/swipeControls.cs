using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipeControls : MonoBehaviour
{
    public enum Swipe { None, Up };

    TouchPhase touchPhase = TouchPhase.Ended;
    public float minSwipeLength = 1f;
        Vector2 firstPressPos;
        Vector2 secondPressPos;
        Vector2 currentSwipe;

        Vector3 touchPosWorld;
        public static Swipe swipeDirection;

        public GameObject cannonBall;
        public Transform ShotSpawn;

    bool canAttack = true;
     AudioSource shotaudio;

    void Update()
    {
    //    if (Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhase)
    //    {
    //        Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
    //        RaycastHit raycastHit;

    //        if (Physics.Raycast(raycast, out raycastHit))
    //        {
    //            if(raycastHit.collider.CompareTag("cannon"))
    //             {
    //                DetectSwipe();
    //            }
    //        }

    //    }
    //}
    //    public void DetectSwipe()
    //    {
    //        if (Input.touches.Length > 0)
    //        {
    //            Touch t = Input.GetTouch(0);

    //            if (t.phase == TouchPhase.Began)
    //            {
    //                firstPressPos = new Vector2(t.position.x, t.position.y);
                    
                    
    //        }

    //            if (t.phase == TouchPhase.Ended)
    //            {
    //                secondPressPos = new Vector2(t.position.x, t.position.y);
    //                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

    //                // Make sure it was a legit swipe, not a tap
    //                if (currentSwipe.magnitude < minSwipeLength)
    //                {
    //                    swipeDirection = Swipe.None;
    //                    return;
    //                }

    //                currentSwipe.Normalize();

                    
    //                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
    //                {
                        
    //                    swipeDirection = Swipe.Up;
    //                    Instantiate(cannonBall, ShotSpawn.position, ShotSpawn.rotation);

    //                }
    //            }
    //        }
    //        else
    //        {
    //            swipeDirection = Swipe.None;
    //        }
        }
    void Start()
    {
        shotaudio = GetComponent<AudioSource>();
        
    }

//#if UNITY_EDITOR

    private void OnMouseOver()
    {
        Click();
    }

    public void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {

            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            currentSwipe.Normalize();
            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                if (canAttack)
                {

                    Instantiate(cannonBall, ShotSpawn.position, ShotSpawn.rotation);
                    shotaudio.Play();
                    StartCoroutine("waitforAttack");
                }

            }
        }
       
    }
    IEnumerator waitforAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds(0.5f);
        canAttack = true;
    }
//#endif
 
}

