using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
  public static DataBaseManager instance;
    private DataBase dataBase;
    public NeedsController needscontroller;
    private void Awake()
    {
        dataBase = new DataBase();
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than 1 database manager in the scene");
    }
    private void Start()
    {
        Pet pet = LoadPet();
        if (pet != null)
        {
            needscontroller.Initialize(
                pet.food, pet.happiness, pet.energy, 1, 1, 1,
               DateTime.Parse( pet.lastTimeFed),
                DateTime.Parse(pet.lastTimeHappy),
                DateTime.Parse(pet.lastTimeGainedEnergy)
                );
        }
    }
    private void Update()
    {
        if (TimingManager.instance.gamehourtimer < 0)
        {
            Pet pet = new Pet(needscontroller.lastTimeFed.ToString(),needscontroller.lastTimeHappy.ToString(), needscontroller.lastTimeGainedEnergy.ToString()
                , needscontroller.food, needscontroller.happiness, needscontroller.energy);SavePet(pet);
        }
    }
    public void SavePet(Pet pet)
    {
        dataBase.SaveData("pet", pet);
    }

    public Pet LoadPet()
    {
        Pet returnvalue = null;
        dataBase.LoadData<Pet>("pet", (pet) =>
        {
            returnvalue= pet;
        });
        return returnvalue;
    }
}
