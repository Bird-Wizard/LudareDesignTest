using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_RigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If player hits hazard or enemy
        if(collision.gameObject.CompareTag("Hazard") || collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    private void Die()
    {
        m_RigidBody.bodyType = RigidbodyType2D.Static;
        m_Animator.SetTrigger("Death");
        AudioManager.Instance.Play("Player_Death");

        // Wait a bit beforehand
        Invoke("Restart", 2);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private Animator m_Animator = null;
    private Rigidbody2D m_RigidBody = null;
}
