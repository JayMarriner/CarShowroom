using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Displayed description text.
    [SerializeField] TMP_Text descText;
    //Displayed cost text.
    [SerializeField] TMP_Text costText;
    //Material on the car body, used to change the colour of the car body.
    [SerializeField] Material carBodyMat;
    //Global variable for the total cost of the car.
    int totalCost;
    //List that holds all string segments for the description.
    List<string> descriptions = new List<string>();

    private void Awake()
    {
        //Initial parameters. Gets changed after in SwitchType but is here for default values.
        UpdateCost(0);
        AddDesc("");
        UpdateBodyColor(Color.white);
    }

    //Updates the Cost amount displayed on screen.
    public void UpdateCost(int amt)
    {
        totalCost *= amt;
        //Sets total cost text on UI.
        costText.text = "$" + totalCost.ToString();
    }

    public void ChangeDesc(string oldDesc, string newDesc)
    {
        //Finds the matching previous description and removes it from the list.
        descriptions.Remove(descriptions.Find(x => x == oldDesc));
        //Adds new description passed through from object selection.
        descriptions.Add(newDesc);
        //Changes string displayed to new updated list.
        UpdateDesc();
    }

    //Adds a description if there is no existing description.
    public void AddDesc(string desc)
    {
        //Adds description to list.
        descriptions.Add(desc);
        //Forces the update to the displayed string.
        UpdateDesc();
    }

    void UpdateDesc()
    {
        //Resets description and loops through to add the description string from the list.
        string fullDesc ="";
        foreach(string desc in descriptions)
        {
            //Adds each description to the string. Also adds a space after.
            fullDesc += desc + " ";
        }

        //Display full description on screen.
        descText.text = fullDesc;
    }

    //Passes through a colour to update the colour of the car body model.
    public void UpdateBodyColor(Color col)
    {
        carBodyMat.color = col;
    }
}
