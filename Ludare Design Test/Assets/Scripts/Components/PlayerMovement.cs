using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float PlayerSpeed = 5.0f;
    public float JumpForce = 1.0f;
    public int NumJumps = 2;

    [SerializeField]
    private LayerMask m_JumpableGround;

    private enum MoveState
    {
        eIdle, // 0 
        eWalk, // 1
        eJump, // 2
        eFall, // 3
    }

    private void Start()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_Collider = GetComponent<BoxCollider2D>();
        m_Animator = GetComponent<Animator>();
        m_Renderer = GetComponent<SpriteRenderer>();

        m_BoundsOffset = new Vector2(m_Collider.bounds.size.x - 0.1f, m_Collider.bounds.size.y);
    }

    private void Update()
    {
        Movement();
        UpdateAnimations();
    }

    private void Movement()
    {
        // Basic movement
        if (Input.GetButtonDown("Jump") && NumJumps > 1)
        {
            m_RigidBody.velocity = new Vector2(m_RigidBody.velocity.x, JumpForce);
            AudioManager.Instance.Play("Jump");
            NumJumps--;
        }

        if (IsGrounded())
        {
            NumJumps = 2;
        }

        m_PlayerDirX = Input.GetAxis("Horizontal");
        m_RigidBody.velocity = new Vector2(m_PlayerDirX * PlayerSpeed, m_RigidBody.velocity.y);
    }

    private void UpdateAnimations()
    {
        // Update animation states based on movement
        MoveState state;

        if (m_PlayerDirX > 0.0f)
        {
            state = MoveState.eWalk;
            m_Renderer.flipX = false;
        }
        else if (m_PlayerDirX < 0.0f)
        {
            state = MoveState.eWalk;
            m_Renderer.flipX = true;
        }
        else
        {
            state = MoveState.eIdle;
        }

        if (m_RigidBody.velocity.y > 0.1f)
        {
            state = MoveState.eJump;
        }
        else if (m_RigidBody.velocity.y < -0.1f)
        {
            state = MoveState.eFall;
        }

        m_Animator.SetInteger("State", (int)state);
    }

    // Simple grounded check
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(m_Collider.bounds.center, m_BoundsOffset, 0.0f, Vector2.down, 0.1f, m_JumpableGround);
    }

    private Rigidbody2D m_RigidBody = null;
    private BoxCollider2D m_Collider = null;
    private Animator m_Animator = null;
    private SpriteRenderer m_Renderer = null;

    private float m_PlayerDirX = 0.0f;
    private Vector2 m_BoundsOffset = Vector2.zero;
}
