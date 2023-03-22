using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchType : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    [SerializeField] int[] prices;
    [SerializeField] string[] description;

    GameManager manager;

    private void Start()
    {
        //Get game manager script.
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        
        //Set defaults. If default car option changes from body 0 (at initial runtime) this will also need to be updated as it just
        //grabs whatever is first in the arrays. 
        manager.AddDesc(description[0]);
        manager.UpdateCost(prices[0]);
        gameObject.SetActive(false);
    }

    public void SwitchObj(int number)
    {
        //Holding values for the for loop.
        int runningCost = 0;
        string desc = "";
        string oldDesc = "";

        //Loops through all objects in arrays.
        for(int x = 0; x < objects.Length; x++)
        {
            //If you click the button that is already selected it'll just not do anything - removing this causes duplicate descriptions. Also just wastes compute time.
            if(objects[x].activeSelf && x == number)
            {
                return;
            }
            //If the object matches the button input number then set new stuff to that array position.
            else if(x == number)
            {
                objects[x].SetActive(true);
                runningCost += prices[x];
                desc = description[x];
                continue;
            }
            //If the object at the current array pos is active then its the old one and we want to note these details so we can remove them.
            else if (objects[x].activeSelf)
            {
                objects[x].SetActive(false);
                runningCost -= prices[x];
                oldDesc = description[x];
            }
            
        }

        //Updates sent to manager.
        manager.ChangeDesc(oldDesc, desc);
        manager.UpdateCost(runningCost);
    }
}
