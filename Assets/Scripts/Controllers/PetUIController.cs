using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetUIController : MonoBehaviour
{
   public GameObject food1;
   public GameObject food2;
    public GameObject food3;
    public GameObject food4;
    public GameObject happiness1;
    public GameObject happiness2;
    public GameObject happiness3;
    public GameObject happiness4;
    public GameObject energy1;
    public GameObject energy2;
    public GameObject energy3;
    public GameObject energy4;

    private  int currentfood, currenthappiness, currentenergy;

    public static PetUIController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.Log("more than one petuicontroller");
    }
    public  void UpdateImages(int food,int happiness,int energy)
    {
        if (happiness <= 1000 && happiness >= 750)
        {
            happiness1.SetActive(true);
            happiness2.SetActive(false);
            happiness3.SetActive(false);
            happiness4.SetActive(false);
     }
        if (happiness <= 750 && happiness >= 500)
        {
            happiness1.SetActive(false);
            happiness2.SetActive(true);
            happiness3.SetActive(false);
            happiness4.SetActive(false);
        }
        if (happiness <= 500 && happiness >= 250)
        {
            happiness1.SetActive(false);
            happiness2.SetActive(false);
            happiness3.SetActive(true);
            happiness4.SetActive(false);
        }
        if (happiness <= 250 && happiness >= 0)
        {
            happiness1.SetActive(false);
            happiness2.SetActive(false);
            happiness3.SetActive(false);
            happiness4.SetActive(true);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (food <= 1000 && food >= 750)
        {
            food1.SetActive(true);
            food2.SetActive(false);
            food3.SetActive(false);
            food4.SetActive(false);
        }
        if (food <= 750 && food >= 500)
        {
            food1.SetActive(false);
            food2.SetActive(true);
            food3.SetActive(false);
            food4.SetActive(false);
        }
        if (food <= 500 && food >= 250)
        {
            food1.SetActive(false);
            food2.SetActive(false);
            food3.SetActive(true);
            food4.SetActive(false);
        }
        if (food <= 250 && food >= 0)
        {
            food1.SetActive(false);
            food2.SetActive(false);
            food3.SetActive(false);
            food4.SetActive(true);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      if (energy <= 1000 && energy >= 750)
        {
            energy1.SetActive(true);
            energy2.SetActive(false);
            energy3.SetActive(false);
            energy4.SetActive(false);
        }
        if (energy <= 750 && energy >= 500)
        {
            energy1.SetActive(false);
            energy2.SetActive(true);
            energy3.SetActive(false);
            energy4.SetActive(false);
        }
        if (energy <= 500 && energy >= 250)
        {
            energy1.SetActive(false);
            energy2.SetActive(false);
            energy3.SetActive(true);
            energy4.SetActive(false);
        }
        if (energy <= 250 && energy >= 0)
        {
            energy1.SetActive(false);
            energy2.SetActive(false);
            energy3.SetActive(false);
            energy4.SetActive(true);
        }
    }
}
