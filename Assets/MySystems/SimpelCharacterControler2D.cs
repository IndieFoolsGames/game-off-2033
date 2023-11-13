using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpelCharacterControler2D : MonoBehaviour
{    
    public Rigidbody2D rb2D;   


    public LayerMask ground;
    public Vector3 groundCheckOffset;
    public float groundCheckSize;
    public Color groundCheckColor;

   
    private float curentMove;
    private Vector2 lastMove;

    private void Awake()
    {
        if (rb2D == null)
        {
            rb2D = GetComponent<Rigidbody2D>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void SetMove(float move)
    {
        curentMove = move;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb2D.velocity = new Vector2(curentMove,rb2D.velocity.y);
    }

    public void Jump()
    {
        rb2D.AddForce(new Vector2(0, 2));
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapBox(transform.position, groundCheckSize * Vector2.one,0, ground);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = groundCheckColor;
        Gizmos.DrawWireCube(transform.position + groundCheckOffset,groundCheckSize * Vector3.one);
    }
}
