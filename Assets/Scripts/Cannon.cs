using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems; 

public class Cannon : MonoBehaviour
{
    public GameObject cannonBall;
    public Transform ShotSpawn;
    public AudioSource shotaudio;
    Animator myAnim;
    bool canAttack = true;
    

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    void Start()
    {
        shotaudio = GetComponent<AudioSource>();
        myAnim = GetComponent<Animator>();
    }

    //void Update()
    //{
    //    TouchSwipe();
    //}

    //private void OnMouseOver()
    //{
    //    Swipe();
    //}

    //public void Swipe()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {

    //        firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    //    }
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    //        currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
    //        currentSwipe.Normalize();
    //        if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
    //        {
    //            if (canAttack)
    //            {

    //                Instantiate(cannonBall, ShotSpawn.position, ShotSpawn.rotation);
    //                shotaudio.Play();
    //                StartCoroutine("waitforAttack");
    //            }

    //        }
    //    }
    //}
    IEnumerator waitforAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds(0.5f);
        canAttack = true;
    }

    //public void TouchSwipe()
    //{
    //    if (Input.touches.Length > 0)
    //    {
    //        Touch t = Input.GetTouch(0);
    //        if (t.phase == TouchPhase.Began)
    //        {
    //            //save began touch 2d point
    //            firstPressPos = new Vector2(t.position.x, t.position.y);

    //            if (t.phase == TouchPhase.Ended)
    //            {
    //                //save ended touch 2d point
    //                secondPressPos = new Vector2(t.position.x, t.position.y);

    //                //create vector from the two points
    //                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

    //                //normalize the 2d vector
    //                currentSwipe.Normalize();

    //                //swipe upwards
    //                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
    //                {
    //                    if (canAttack)
    //                    {

    //                        Instantiate(cannonBall, ShotSpawn.position, ShotSpawn.rotation);
    //                        shotaudio.Play();
    //                        StartCoroutine("waitforAttack");

    //                    }
    //                }
    //            }
    //        }
    //    }
    //}

    }


