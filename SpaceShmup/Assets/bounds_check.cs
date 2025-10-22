using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Keeps the GameObject within the screen bounds
/// Note: this script assumes the camera is orthographic
/// 
/// </summary>

public class bounds_check : MonoBehaviour
{
    [Header("Dynamic")]
    public float camWidth;
    public float camHeight;
    public bool keepOnScreen = true;

    public bool isOnScreen = true;

    void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    // Start is called before the first frame update
  

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        // restrict x to the camera bounds

        isOnScreen = true;

        if (pos.x > camWidth)
        {
            pos.x = camWidth;
            isOnScreen = false;
        }

        if (pos.x < -camWidth)
        {
            pos.x = -camWidth;
            isOnScreen = false;
        }

        if (pos.y > camHeight)
        {
            pos.y = camHeight;
            isOnScreen = false;
        }

        if (pos.y < -camHeight)
        {
            pos.y = -camHeight;
            isOnScreen = false;
        }
        if (keepOnScreen && !isOnScreen)
        {
            transform.position = pos;
            isOnScreen = true;
        }
        transform.position = pos;
    }
}
