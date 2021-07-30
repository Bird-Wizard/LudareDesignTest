using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.Rendering.Universal;

public class ItemCollect : MonoBehaviour
{
    public TMP_Text ScoreText;
    
    public float LightStartRadius = 1.5f;
    public float ExpandAmount = 0.3f;
    public float ExpandSpeed = 0.1f;

    private void Start()
    {
        m_PlayerLight = GetComponentInChildren<Light2D>();
        m_PlayerLight.pointLightOuterRadius = LightStartRadius;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object is collectible
        if(collision.gameObject.CompareTag("Collectible"))
        {
            Destroy(collision.gameObject);

            // Increase score
            m_Counter++;
            ScoreText.text = "Score: " + m_Counter;

            // Expand the light when a battery is collected
            StartCoroutine(ExpandLight(m_PlayerLight.pointLightOuterRadius));

            // Play collect audio
            AudioManager.Instance.Play("Collect");
        }
    }

    // Small effect for expanding light
    private IEnumerator ExpandLight(float originalRadius)
    {
        for(float i = originalRadius; i < (originalRadius + ExpandAmount); i += ExpandSpeed)
        {
            m_PlayerLight.pointLightOuterRadius = i;

            // I like the choppiness that this gives for a more "pixel-y" feel
            yield return new WaitForSeconds(ExpandAmount);
        }
    }

    private Light2D m_PlayerLight = null;
    private int m_Counter = 0;
}
