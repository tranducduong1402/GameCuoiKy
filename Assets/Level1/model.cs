using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class model : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Animator anim;
    public Rigidbody2D body;
    private BoxCollider2D boxCollider;

    public float speed;
    public float jump;
    public float wallJumpCooldown;
    public bool grounded;
    private float horizontalInput;


    void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
    }

    public void setBool(string name, bool value)
    {
        anim.SetBool(name, value);
    }

    public bool isGrounded()
    {
          RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    public bool onWall()
    {
         RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

// public bool  canAttack() {
//         return  View.GetComponent<View>().move == 0 && model.GetComponent<model>().isGrounded() && !model.GetComponent<model>().onWall(); 
//     }

}
