using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    public bool IsFlickering;

    [Range(0.1f, 2.0f)]
    public float FlickerMinDelayOn;
    [Range(0.1f, 2.0f)]
    public float FlickerMaxDelayOn;

    [Range(0.1f, 2.0f)]
    public float FlickerMinDelayOff;
    [Range(0.1f, 2.0f)]
    public float FlickerMaxDelayOff;

    private void Start()
    {
        m_FlickerLight = GetComponentInChildren<Light2D>();
    }   

    private void Update()
    {
        if (IsFlickering == true)
        {
            StartCoroutine(FlickeringLight());
        }
    }

    IEnumerator FlickeringLight()
    {
        // Turn off
        IsFlickering = false;
        m_FlickerLight.enabled = false;
        m_TimeDelay = Random.Range(FlickerMinDelayOff, FlickerMaxDelayOff);
        yield return new WaitForSeconds(m_TimeDelay);

        // Turn on
        m_FlickerLight.enabled = true;
        m_TimeDelay = Random.Range(FlickerMinDelayOn, FlickerMaxDelayOn);
        yield return new WaitForSeconds(m_TimeDelay);
        IsFlickering = true;
    }

    private float m_TimeDelay = 0.0f;
    private Light2D m_FlickerLight = null;
}
