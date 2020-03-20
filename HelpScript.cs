using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScript : MonoBehaviour
{
    public GameObject helpmenuUI;
    public static bool HelpIS;
    // Update is called once per frame

    public void PressButton() 
    {
        if (HelpIS == false)
        {
            HelpOn();
        }else if ( HelpIS == true){
            HelpOFF();
        }
    }

    public void HelpOn() 
    {
       helpmenuUI.SetActive(true);
       HelpIS = true;
    }

    public void HelpOFF()
    { 
       helpmenuUI.SetActive(false);
       HelpIS = false;
    }
}
