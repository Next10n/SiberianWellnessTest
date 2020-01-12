using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUpdater : MonoBehaviour
{
    private GameObject[] buttons;



    public void UpdateButtons()
    {
        buttons = GameObject.FindGameObjectsWithTag("ColorButton");
        foreach (GameObject b in buttons)
        {
            print("buttons");
            b.GetComponent<ButtonController>().SetButtonText();
        }
    }

}
