using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnellyFinish : MonoBehaviour
{
    [SerializeField] private UnityEvent m_WinEvent;

    void Start()
    {
        m_ParticleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If collision happens invoke UnityEvent
        if(collision.CompareTag("Player"))
        {
            m_WinEvent.Invoke();
        }
    }

    public void WinLevel()
    {
        m_ParticleSystem.Play();

        AudioManager.Instance.Stop("Music_1");
        AudioManager.Instance.Play("Music_3");
    }

    private ParticleSystem m_ParticleSystem = null;
}
