using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        //m_RigidBody = GetComponent<Rigidbody2D>();
        m_Collider = GetComponent<Collider2D>();

        // Offset for boxcast to check if player is stomping on head
        m_BoundsOffset = new Vector2(m_Collider.bounds.size.x - 0.1f, m_Collider.bounds.size.y);
    }

    private void Update()
    {
        if(PlayerHit() && !m_IsDying)
        {
            Die();
        }
    }

    // Checks to see if player jumped on head
    private bool PlayerHit()
    {
        return Physics2D.BoxCast(m_Collider.bounds.center, m_BoundsOffset, 0.0f, Vector2.up, 0.1f, LayerMask.GetMask("Player"));
    }

    private void Die()
    {
        // Prevent repeat calls
        m_IsDying = true;

        // change tag to allow for feedback on killing enemy and prevent movement
        gameObject.tag = "Untagged";
        //m_RigidBody.bodyType = RigidbodyType2D.Static;

        // Play death anim and audio
        m_Animator.SetTrigger("Death");
        AudioManager.Instance.Play("Enemy_Death");
    }    

    // Gets called from anim event
    private void Destroy()
    {
        Destroy(gameObject);
    }

    private Animator m_Animator = null;
    private Rigidbody2D m_RigidBody = null;
    private Collider2D m_Collider = null;

    private bool m_IsDying = false;
    private Vector2 m_BoundsOffset;
}
