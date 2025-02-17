using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class SwitchType : MonoBehaviour
{
    [Header("Please populate with all object choices along with corrosponding prices and descriptions.")]
    //List of objects to switch between.
    [SerializeField] GameObject[] objects;
    //List of prices that corrospond to each object.
    [SerializeField] int[] prices;
    //List of descriptions that corrospond to each object.
    [SerializeField] string[] description;

    //Global reference to game manager object.
    GameManager manager;

    private void Start()
    {
        //Get game manager script.
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();

        //Sets all default values in the manager.
        manager.AddDesc(description[0]);
        manager.UpdateCost(prices[0]);

        //Turns off the object by default, allows menu options to be toggled on from UI.
        gameObject.SetActive(false);
    }

    //Allows for number input to switch selected object to, should be set in UI.
    public void SwitchObj(int number)
    {
        //Initialise values.
        int runningCost = 0;
        string desc = "";
        string oldDesc = "";

        //If already active button is pressed, return.
        if(objects[number].activeSelf){
            return;
        }
        else{
            //Find current active object and remove its cost + description, set object to false (off).
            for(int x=0; x<objects.Length; x++){
                if(objects[x].activeSelf){
                    objects[x].SetActive(false);
                    runningCost -= prices[x];
                    oldDesc = description[x];
                }
            }   
            //Add cost, description and turn object on for selected object.
            runningCost += prices[number];
            desc = description[number];
            objects[number].SetActive(true);
        }

        //Updates sent to manager.
        manager.ChangeDesc(oldDesc, oldDesc);
        manager.UpdateCost(runningCost);
    }
}
