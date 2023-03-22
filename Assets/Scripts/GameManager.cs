using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text descText;
    [SerializeField] TMP_Text costText;
    [SerializeField] Material carBodyMat;
    int totalCost;
    List<string> descriptions = new List<string>();

    private void Awake()
    {
        //Initial parameters. Gets changed after in SwitchType but is here for reset.
        UpdateCost(0);
        AddDesc("");
        UpdateBodyColor(Color.white);
    }

    public void UpdateCost(int amt)
    {
        totalCost += amt;
        //Sets total cost text on UI.
        costText.text = "£" + totalCost.ToString();
    }

    public void ChangeDesc(string oldDesc, string newDesc)
    {
        //Finds the matching description in the list.
        descriptions.Remove(descriptions.Find(x => x == oldDesc));
        //Adds new description.
        descriptions.Add(newDesc);
        UpdateDesc();
    }

    public void AddDesc(string desc)
    {
        descriptions.Add(desc);
        UpdateDesc();
    }

    void UpdateDesc()
    {
        //Fresh full description each time. Potentially you could just store this as global and remove part
        //of the string that matches with old description then add new to end but that felt like a messier solution.
        string fullDesc ="";
        foreach(string desc in descriptions)
        {
            //Adds each description to the string. Also adds a space after.
            fullDesc += desc + " ";
        }

        //Display full description.
        descText.text = fullDesc;
    }

    public void UpdateBodyColor(Color col)
    {
        carBodyMat.color = col;
    }
}
