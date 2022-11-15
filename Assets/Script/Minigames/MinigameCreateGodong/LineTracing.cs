using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MasakGodong;

public class LineTracing : MonoBehaviour
{
    NGonRenderer lines;
    int lineCount;
    float lineWidth;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
       lines = GetComponent<NGonRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleTouchBegin(Touch touch) 
    {
        Vector2 touchWorldSpace = cam.ScreenToWorldPoint(touch.position); 
        Debug.Log(lines.PointInLines(touchWorldSpace));
    }

    public void HandleTouchBegin(Vector2 position) 
    {
        Vector2 touchWorldSpace = cam.ScreenToWorldPoint(position); 
        Debug.Log(lines.PointInLines(touchWorldSpace));
    }

    public void HandleTouchMoved(Touch touch) {
        
    }

    public void HandleTouchStopped(Touch touch) {
        
    }
}
