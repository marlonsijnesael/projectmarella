

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {
  
    private int currentLane = 0;
    private int amountOflanes = 4;
    
    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    // Update is called once per frame
    void FixedUpdate() {
        Swipe();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.tag == "Obstacle") {
           // GameManager._Instance.score += 10;
            Destroy(collision.gameObject);
            Debug.Log("gotcha");
        }
    }


    

    public void Swipe() {
        if (Input.touches.Length > 0) {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began) {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended) {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe upwards
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
                    Debug.Log("Swipe up");
                }
                //swipe down
                if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
                    Debug.Log("down swipe");
                }
                //swipe left
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
                    if (currentLane > 0) {
                        currentLane--;
                        transform.position = new Vector3(transform.position.x, transform.position.y, currentLane);
                        return;
                    }
                    Debug.Log("left swipe");
                }
                //swipe right
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
                    if (currentLane < amountOflanes - 1) {
                        currentLane++;
                        transform.position = new Vector3(transform.position.x, transform.position.y, currentLane);
                        return;
                    }
                    Debug.Log("right swipe");
                }
            }
        }
    }

}

