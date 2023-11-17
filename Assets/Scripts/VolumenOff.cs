using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumenOnOff : MonoBehaviour
{
    public Dropdown miDropdown;


    // Update is called once per frame
    void Update()
    {
        if (miDropdown.value == 0)
        {
            AudioListener.pause = false;
        }
        else if (miDropdown.value == 1)
        {
            AudioListener.pause = true;
        }
    }
}
