using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///Extends from Switch type. Adds a method for updating the body type. 
/// </summary>
public class BodySwitch : SwitchType
{

    public void UpdateBodyColor(int num)
    {
        //Get game manager script.
        GameManager manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();

        //Gives colour depending on number.
        switch (num)
        {
            case 1:
                manager.UpdateBodyColor(Color.white);
                break;
            case 2:
                manager.UpdateBodyColor(Color.red);
                break;
            case 3:
                manager.UpdateBodyColor(Color.blue);
                break;
        }
    }
}
