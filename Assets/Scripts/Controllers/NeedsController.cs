using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Serialization;

public class NeedsController : MonoBehaviour
{
    [SerializeField] PetController PetController;


    public int foodTickRate, energyTickRate, happinessTickRate;

    public int food, energy, happiness;
     public DateTime lastTimeFed, lastTimeHappy, lastTimeGainedEnergy;
    private void Awake()
    {
        Initialize(1000, 1000, 1000, 1, 1, 1);
    }
    public void Initialize(int food,int happiness,int energy,int foodTickRate,int energyTickRate,int happinessTickRate)
    {
        lastTimeFed = DateTime.Now;
        lastTimeHappy = DateTime.Now;
        lastTimeGainedEnergy = DateTime.Now;

        this.food = food;
        this.happiness = happiness;
        this.energy = energy;
        this.foodTickRate = foodTickRate;
        this.energyTickRate = energyTickRate;
        this.happinessTickRate = happinessTickRate;

        PetUIController.instance.UpdateImages(food, happiness, energy);
    }

    public void Initialize(int food, int happiness, int energy, int foodTickRate, int energyTickRate, int happinessTickRate
        ,DateTime lastTimeFed,DateTime LastTimeHappy,DateTime LastTimeGainedEnergy)
    {
        this.lastTimeFed = lastTimeFed;
        this.lastTimeHappy = LastTimeHappy;
        this.lastTimeGainedEnergy = LastTimeGainedEnergy;

        this.food = food-foodTickRate*TickAmountSinceLastTimeToCurrentTime(lastTimeFed,TimingManager.instance.hourlength);
        this.happiness = happiness-happinessTickRate*TickAmountSinceLastTimeToCurrentTime(lastTimeHappy,TimingManager.instance.hourlength);
        this.energy = energy-energyTickRate*TickAmountSinceLastTimeToCurrentTime(lastTimeGainedEnergy,TimingManager.instance.hourlength);
        this.foodTickRate = foodTickRate;
        this.energyTickRate = energyTickRate;
        this.happinessTickRate = happinessTickRate;

        if (this.food < 10) this.food = 10;
        if (this.happiness < 10) this.happiness = 10;
        if (this.energy < 10) this.energy = 10;


        PetUIController.instance.UpdateImages(this.food, this.happiness, this.energy);
    }

    private void Start()
    {
        ChangeFood(-foodTickRate);
        ChangeEnergy(-energyTickRate);
        ChangeHappiness(-happinessTickRate);
        PetUIController.instance.UpdateImages(food, happiness, energy);
    }
    private void Update()
    {
        if (TimingManager.instance.gamehourtimer < 0)
        {
            ChangeFood(-foodTickRate);
            ChangeEnergy(-energyTickRate);
            ChangeHappiness(-happinessTickRate);
            PetUIController.instance.UpdateImages(food, happiness, energy);
        }
    }

    public void ChangeFood(int amount)
    {
        food+=amount;
        if (amount > 0)
        {
            lastTimeFed = DateTime.Now;
        }
        if (food <= 10)
        {
            food = 10;
            PetManager.instance.Die();
        }
        else if (food > 1000) food = 1000;
       
    }

    public void ChangeHappiness(int amount) { 
        happiness+=amount;
        if (amount > 0)
        {
            lastTimeHappy = DateTime.Now;
        }
        if (happiness <=10)
        {
            happiness = 10;
            PetManager.instance.Die();
        }
        else if (happiness > 1000) happiness = 1000;
        SetPetControllerForHappiness();
    }
    public void ChangeEnergy(int amount)
    {
        energy+=amount;
        if (amount > 0)
        {
            lastTimeGainedEnergy = DateTime.Now;
        }
        if (energy <= 10)
        {
            energy = 10;
            PetManager.instance.Die();
            
        }
        else if (energy > 1000) energy = 1000;
    }

    public int TickAmountSinceLastTimeToCurrentTime(DateTime lastTime,float tickRateInSeconds)
    {
        DateTime currentDateTime = DateTime.Now;
        int dayOfYearDifference = currentDateTime.DayOfYear - lastTime.DayOfYear;
        if (currentDateTime.Year > lastTime.Year||
            dayOfYearDifference>=7) return 1500;

        int dayOfDifferenceSecondsAmount = dayOfYearDifference * 86400;
        if(dayOfYearDifference>0)return Mathf.RoundToInt(dayOfDifferenceSecondsAmount/tickRateInSeconds);


        int hourDifferenceSeondsAmount = (currentDateTime.Hour - lastTime.Hour) * 3600;
        if(hourDifferenceSeondsAmount>0) return Mathf.RoundToInt(hourDifferenceSeondsAmount/tickRateInSeconds);

        int minuteDifferenceSecondsAmount=(currentDateTime.Minute - lastTime.Minute) * 60;
        if (minuteDifferenceSecondsAmount > 0) return Mathf.RoundToInt(minuteDifferenceSecondsAmount / tickRateInSeconds);

        int secondDifferenceSecondsAmount=(currentDateTime.Second - lastTime.Second);    
        return Mathf.RoundToInt(secondDifferenceSecondsAmount/tickRateInSeconds);
    }
    public void LambON()
    {
        this.energyTickRate = -50;
    }
    
    private void SetPetControllerForHappiness()
    {
        if (this.energy <= 200&&this.energy>=0)
        {
            PetController.Sick();
        }
       else if (this.energy <= 400 &&this.energy >= 200)
        {
            PetController.SoSad();
        }
        else if (this.energy <= 600 && this.energy >= 400)
        {
            PetController.Sad();
        }
        else if (this.energy <= 800 && this.energy >= 600)
        {
            PetController.Okay();
        }
        else if (this.energy <= 1000 && this.energy >= 800)
        {
            PetController.Happy();
        }
    }
    public void IncreaseHappinesWhenClick()
    {
        this.happiness += 50;
        PetController.OnClickHappines();
        if(this.happiness<=1000)lastTimeHappy = DateTime.Now;
    }

    public void IncreaseFirstFOODThanHAPPINESS(int foodnumber,int happinessnumber)
    {
        this.food += foodnumber;
        this.happiness += happinessnumber;
    }
    public void FullEnergy(int energy)
    {
        this.energy += energy;
    }
}
