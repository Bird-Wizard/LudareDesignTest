using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }
}
