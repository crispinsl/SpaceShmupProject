using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
[RequireComponent(typeof(bounds_check))]

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public float fireRate = 0.3f;
    public float health = 10f;
    public int score = 100; // points earned for destroying this enemy

    private bounds_check bndCheck;

    public Vector3 pos
    {
        get
        {
            return this.transform.position;
        }

        set
        {
            this.transform.position = value;
        }
    }

    private void Awake()
    {
        bndCheck = GetComponent<bounds_check>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (!bndCheck.isOnScreen)
        {
            if (pos.y < bndCheck.camHeight)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

}
