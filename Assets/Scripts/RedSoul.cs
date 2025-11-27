using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSoul : MonoBehaviour
{
    float speed;
    public float normspeed;
    public float lowspeed;
    bool touchleft = false;
    bool touchright = false;
    bool touchtop = false;
    bool touchbottom = false;
    BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        speed = normspeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.myTurn)
        { 
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && !touchleft)
                this.transform.Translate(new Vector2(-speed, 0f) * Time.deltaTime, Space.World);
            if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && !touchright)
                this.transform.Translate(new Vector2(speed, 0f) * Time.deltaTime, Space.World);
            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && !touchtop)
                this.transform.Translate(new Vector2(0f, speed) * Time.deltaTime, Space.World);
            if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && !touchbottom)
                this.transform.Translate(new Vector2(0f, -speed) * Time.deltaTime, Space.World);
            if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
                speed = lowspeed;
            if (Input.GetKeyUp(KeyCode.X) || Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
                speed = normspeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LeftBord"))
            touchleft = true;
        else touchleft = false;
        if (collision.gameObject.CompareTag("RightBord"))
            touchright = true;
        else touchright = false;
        if (collision.gameObject.CompareTag("TopBord"))
            touchtop = true;
        else touchtop = false;
        if (collision.gameObject.CompareTag("BottomBord"))
            touchbottom = true;
        else touchbottom = false;
    }
}
