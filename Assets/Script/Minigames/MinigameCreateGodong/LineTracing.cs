using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MasakGodong;

public class LineTracing : MonoBehaviour
{
    NGonRenderer lines;
    int lineCount;
    float lineWidth;

    int currentLine;
    
    Camera cam;

    /**
     * this variable is used in order to store the time it takes for player
     * to complete the line tracing
     */
    float timeTaken;

    /**
     * define the time range on which player should finish the line tracing.
     * if player finishes slower then the result is burnt
     * if player finishses too fast, then th e result is raw
     * They are in the form of 
     */
    public float timeLower;
    public float timeHigher;

    public GameObject perfectGodong;
    public GameObject burntGodong;
    public GameObject rawGodong;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
       lines = GetComponent<NGonRenderer>(); 

       currentLine = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentLine >= 0) {
            timeTaken += Time.deltaTime;
        }
    }

    public void HandleTouchBegin(Vector2 position) 
    {
        Vector2 touchWorldSpace = cam.ScreenToWorldPoint(position); 
        int temp = lines.PointInLines(touchWorldSpace);
        if(temp != 0) {
            Debug.Log("Failure");
        } else {
            currentLine = 0;
        }
    }

    public void HandleTouchMoved(Vector2 position) {
        Vector2 touchWorldSpace = cam.ScreenToWorldPoint(position);
        int temp = lines.PointInLines(touchWorldSpace);
        if(temp < currentLine) {
            Debug.Log("Failure");
        } else {
            currentLine = temp;
        }

        if(timeTaken > timeHigher) {
            burntGodong.SetActive(true);
        }

        if(lines.IsLast(temp)) {
            if(timeTaken < timeLower) {
                rawGodong.SetActive(true);
            } else {
                perfectGodong.SetActive(true);
            }
        }
    }

    public void HandleTouchMoved(Touch touch) {
        
    }

    public void HandleTouchStopped(Touch touch) {
        
    }
}
