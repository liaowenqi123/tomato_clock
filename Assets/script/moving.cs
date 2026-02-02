using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Infinity;


public class moving : MonoBehaviour
{
    public Vector2 speed = new Vector2(0,0);
    public float run_speed;
    public float jump_force;
    public float horizontalInput;
    public bool onGround;
    public bool keyup=true;
    
    Rigidbody2D rb;

    Collider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation=true;
        jump_force = 15f;
        run_speed = 6;
    }
    void Update()
    {

        horizontalInput = Input.GetAxisRaw("Horizontal");
        speed = new Vector2(run_speed * horizontalInput,speed.y);

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && onGround && keyup)
        {
            speed = new Vector2(speed.x, jump_force);
            keyup = false;
        }
        if (!onGround)
        {
            speed = new Vector2(speed.x, 0);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Space))
        {
            speed = new Vector2(speed.x, 0);
            keyup = true;
        }
    }
    void FixedUpdate()
    {   
        rb.velocity = new Vector2(speed.x,rb.velocity.y+speed.y);
        
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.CompareTag("ground"))
        // {
        //     //onGround = true;
        // }
        foreach (ContactPoint2D contact in collision.contacts)
        {
            
            // 判断脚下碰撞（y值在下方）
            // 注意：这里只是设置状态，不处理物理
            if (contact.normal.y > Mathf.Cos(20*Mathf.Deg2Rad))
            {
                // 只是标记着地状态，用于动画、音效等
                onGround = true;
                break;  // 找到一个脚下碰撞点就够了

            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // 碰撞持续期间每帧调用
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = false;
        }
    }
}