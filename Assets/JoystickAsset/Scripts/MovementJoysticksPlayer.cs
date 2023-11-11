using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementJoysticksPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(MyJoystick.JHV, MyJoystick.JVV);
    }

    private void Move(float h, float v)
    {
        rb.velocity = new Vector2(h * speed, v * speed);      
    }
}
