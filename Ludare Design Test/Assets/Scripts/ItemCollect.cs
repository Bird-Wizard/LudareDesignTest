using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollect : MonoBehaviour
{
    public TMP_Text ScoreText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Collectible"))
        {
            Destroy(collision.gameObject);
            m_Counter++;
            ScoreText.text = "Score: " + m_Counter;

            AudioManager.Instance.Play("Collect");
        }
    }

    private int m_Counter = 0;
}
