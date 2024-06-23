using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetTradeManager : MonoBehaviour
{
    RemovePriceWhenBuyed removePriceWhenBuyed;
    ClosetactivateHelper closetactivateHelper;

    private void Awake()
    {
        removePriceWhenBuyed = GetComponent<RemovePriceWhenBuyed>();
        closetactivateHelper = GetComponent<ClosetactivateHelper>();
    }
    public void Hair0Purchase() {

        if (PlayerPrefs.GetInt("coin") >= 100 && PlayerPrefs.GetInt("hair0payed") == 0)
        {
            removePriceWhenBuyed.hairs[0].SetActive(false);
            PlayerPrefs.SetInt("hair0payed", 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 100);
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("hair" + i, 0);
            }
            PlayerPrefs.SetInt("hair0", 1);
        }
        else if (PlayerPrefs.GetInt("hair0payed") == 1)
        {
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("hair" + i, 0);
            }
            PlayerPrefs.SetInt("hair0", 1);
            closetactivateHelper.CheckIfActive();

            closetactivateHelper.hairs[1].SetActive(false);
            closetactivateHelper.hairs[2].SetActive(false);
            closetactivateHelper.hairs[3].SetActive(false);
            closetactivateHelper.hairs[4].SetActive(false);
        }

    }
     
        
    

    public void Hair1Purchase() {
        if (PlayerPrefs.GetInt("coin") >= 150 && PlayerPrefs.GetInt("hair1payed") == 0)
        {
            removePriceWhenBuyed.hairs[1].SetActive(false);
            PlayerPrefs.SetInt("hair1payed", 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 150);
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("hair" + i, 0);
            }
            PlayerPrefs.SetInt("hair1", 1);
        }
        else if (PlayerPrefs.GetInt("hair1payed") == 1)
        {
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("hair" + i, 0);
            }
            PlayerPrefs.SetInt("hair1", 1);
            closetactivateHelper.CheckIfActive();

            closetactivateHelper.hairs[0].SetActive(false);
            closetactivateHelper.hairs[2].SetActive(false);
            closetactivateHelper.hairs[3].SetActive(false);
            closetactivateHelper.hairs[4].SetActive(false);
        }
    }

    public void Hair2Purchase() {
        if (PlayerPrefs.GetInt("coin") >= 200 && PlayerPrefs.GetInt("hair2payed") == 0)
        {
            removePriceWhenBuyed.hairs[2].SetActive(false);
            PlayerPrefs.SetInt("hair2payed", 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 200);
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("hair" + i, 0);
            }
            PlayerPrefs.SetInt("hair2", 1);

        }
        else if (PlayerPrefs.GetInt("hair2payed") == 1)
        {
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("hair" + i, 0);
            }
            PlayerPrefs.SetInt("hair2", 1);
            closetactivateHelper.CheckIfActive();


            closetactivateHelper.hairs[0].SetActive(false);
            closetactivateHelper.hairs[1].SetActive(false);
            closetactivateHelper.hairs[3].SetActive(false);
            closetactivateHelper.hairs[4].SetActive(false);
        }
    }

    public void Hair3Purchase() {
        if (PlayerPrefs.GetInt("coin") >= 250 && PlayerPrefs.GetInt("hair3payed") == 0)
        {
            removePriceWhenBuyed.hairs[3].SetActive(false);
            PlayerPrefs.SetInt("hair3payed", 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 250);
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("hair" + i, 0);
            }
            PlayerPrefs.SetInt("hair3", 1);
        }
        else if (PlayerPrefs.GetInt("hair3payed") == 1)
        {
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("hair" + i, 0);
            }
            PlayerPrefs.SetInt("hair3", 1);
            closetactivateHelper.CheckIfActive();


            closetactivateHelper.hairs[0].SetActive(false);
            closetactivateHelper.hairs[1].SetActive(false);
            closetactivateHelper.hairs[2].SetActive(false);
            closetactivateHelper.hairs[4].SetActive(false);
        }
    }
    public void Hair4Purchase() {
        if (PlayerPrefs.GetInt("coin") >= 300 && PlayerPrefs.GetInt("hair4payed") == 0)
        {
            removePriceWhenBuyed.hairs[4].SetActive(false);
            PlayerPrefs.SetInt("hair4payed", 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 300);
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("hair" + i, 0);
            }
            PlayerPrefs.SetInt("hair4", 1);

        }
        else if (PlayerPrefs.GetInt("hair4payed") == 1)
        {
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("hair" + i, 0);
            }
            PlayerPrefs.SetInt("hair4", 1);
            closetactivateHelper.CheckIfActive();


            closetactivateHelper.hairs[0].SetActive(false);
            closetactivateHelper.hairs[1].SetActive(false);
            closetactivateHelper.hairs[2].SetActive(false);
            closetactivateHelper.hairs[3].SetActive(false);
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////
 public void Clothes0Purchase() {
        if (PlayerPrefs.GetInt("coin") >= 100 && PlayerPrefs.GetInt("clothes0payed")==0)
        {
            removePriceWhenBuyed.clothes[0].SetActive(false);
            PlayerPrefs.SetInt("clothes0payed", 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 100);
            for (int i = 0; i < 6; i++)
            {
                PlayerPrefs.SetInt("clothes" + i, 0);
            }
            PlayerPrefs.SetInt("clothes0", 1);
        }
        else if (PlayerPrefs.GetInt("clothes0payed") == 1)
        {
            for (int i = 0; i < 6; i++)
            {
                PlayerPrefs.SetInt("clothes" + i, 0);
            }
            PlayerPrefs.SetInt("clothes0", 1);
            closetactivateHelper.CheckIfActive();

            closetactivateHelper.clothes[1].SetActive(false);
            closetactivateHelper.clothes[2].SetActive(false);
            closetactivateHelper.clothes[3].SetActive(false);
            closetactivateHelper.clothes[4].SetActive(false);
            closetactivateHelper.clothes[5].SetActive(false);
        }

    }

    public void Clothes1Purchase()
{
    if (PlayerPrefs.GetInt("coin") >= 150 && PlayerPrefs.GetInt("clothes1payed") == 0)
    {
            removePriceWhenBuyed.clothes[1].SetActive(false);
            PlayerPrefs.SetInt("clothes1payed", 1);
        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 150);
            for (int i = 0; i < 6; i++)
            {
                PlayerPrefs.SetInt("clothes" + i, 0);
            }
            PlayerPrefs.SetInt("clothes1", 1);
        }
        else if (PlayerPrefs.GetInt("clothes1payed") == 1)
        {
            for (int i = 0; i < 6; i++)
            {
                PlayerPrefs.SetInt("clothes" + i, 0);
            }
            PlayerPrefs.SetInt("clothes1", 1);
            closetactivateHelper.CheckIfActive();

            closetactivateHelper.clothes[0].SetActive(false);
            closetactivateHelper.clothes[2].SetActive(false);
            closetactivateHelper.clothes[3].SetActive(false);
            closetactivateHelper.clothes[4].SetActive(false);
            closetactivateHelper.clothes[5].SetActive(false);
        }

    }

public void Clothes2Purchase()
{
    if (PlayerPrefs.GetInt("coin") >= 200 && PlayerPrefs.GetInt("clothes2payed") == 0)
    {
            removePriceWhenBuyed.clothes[2].SetActive(false);
            PlayerPrefs.SetInt("clothes2payed", 1);
        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 200);
            for (int i = 0; i < 6; i++)
            {
                PlayerPrefs.SetInt("clothes" + i, 0);
            }
            PlayerPrefs.SetInt("clothes2", 1);
        }

        else if (PlayerPrefs.GetInt("clothes2payed") == 1)
        {
            for (int i = 0; i < 6; i++)
            {
                PlayerPrefs.SetInt("clothes" + i, 0);
            }
            PlayerPrefs.SetInt("clothes2", 1);
            closetactivateHelper.CheckIfActive();

            closetactivateHelper.clothes[0].SetActive(false);
            closetactivateHelper.clothes[1].SetActive(false);
            closetactivateHelper.clothes[3].SetActive(false);
            closetactivateHelper.clothes[4].SetActive(false);
            closetactivateHelper.clothes[5].SetActive(false);
        }
    }

public void Clothes3Purchase()
{
    if (PlayerPrefs.GetInt("coin") >= 250 && PlayerPrefs.GetInt("clothes3payed") == 0)
    {
            removePriceWhenBuyed.clothes[3].SetActive(false);
            PlayerPrefs.SetInt("clothes3payed", 1);
        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 250);
            for (int i = 0; i < 6; i++)
            {
                PlayerPrefs.SetInt("clothes" + i, 0);
            }
            PlayerPrefs.SetInt("clothes3", 1);
        }
        else if (PlayerPrefs.GetInt("clothes3payed") == 1)
        {
            for (int i = 0; i < 6; i++)
            {
                PlayerPrefs.SetInt("clothes" + i, 0);
            }
            PlayerPrefs.SetInt("clothes3", 1);
            closetactivateHelper.CheckIfActive();

            closetactivateHelper.clothes[0].SetActive(false);
            closetactivateHelper.clothes[1].SetActive(false);
            closetactivateHelper.clothes[2].SetActive(false);
            closetactivateHelper.clothes[4].SetActive(false);
            closetactivateHelper.clothes[5].SetActive(false);
        }
    }
public void Clothes4Purchase()
{
    if (PlayerPrefs.GetInt("coin") >= 300 && PlayerPrefs.GetInt("clothes4payed") == 0)
    {
            removePriceWhenBuyed.clothes[4].SetActive(false);
            PlayerPrefs.SetInt("clothes4payed", 1);
        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 300);
            for (int i = 0; i < 6; i++)
            {
                PlayerPrefs.SetInt("clothes" + i, 0);
            }
            PlayerPrefs.SetInt("clothes4", 1);
        }
        else if (PlayerPrefs.GetInt("clothes4payed") == 1)
        {
            for (int i = 0; i < 6; i++)
            {
                PlayerPrefs.SetInt("clothes" + i, 0);
            }
            PlayerPrefs.SetInt("clothes4", 1);
            closetactivateHelper.CheckIfActive();

            closetactivateHelper.clothes[0].SetActive(false);
            closetactivateHelper.clothes[1].SetActive(false);
            closetactivateHelper.clothes[2].SetActive(false);
            closetactivateHelper.clothes[3].SetActive(false);
            closetactivateHelper.clothes[5].SetActive(false);
        }
    }
public void Clothes5Purchase()
{
    if (PlayerPrefs.GetInt("coin") >= 350 && PlayerPrefs.GetInt("clothes5payed") == 0)
    {
            removePriceWhenBuyed.clothes[5].SetActive(false);
            PlayerPrefs.SetInt("clothes5payed", 1);
        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 350);
            for (int i = 0; i < 6; i++)
            {
                PlayerPrefs.SetInt("clothes" + i, 0);
            }
            PlayerPrefs.SetInt("clothes5", 1);
        }
        else if (PlayerPrefs.GetInt("clothes5payed") == 1)
        {
            for (int i = 0; i < 6; i++)
            {
                PlayerPrefs.SetInt("clothes" + i, 0);
            }
            PlayerPrefs.SetInt("clothes5", 1);
            closetactivateHelper.CheckIfActive();

            closetactivateHelper.clothes[0].SetActive(false);
            closetactivateHelper.clothes[1].SetActive(false);
            closetactivateHelper.clothes[2].SetActive(false);
            closetactivateHelper.clothes[3].SetActive(false);
            closetactivateHelper.clothes[4].SetActive(false);
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////
    ///

    public void ACC0Purchase()
    {
        if (PlayerPrefs.GetInt("coin") >= 100 && PlayerPrefs.GetInt("accesories0payed") == 0)
        {
            removePriceWhenBuyed.accesories[0].SetActive(false);
            PlayerPrefs.SetInt("accesories0payed", 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 100);
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("accesories" + i, 0);
            }
            PlayerPrefs.SetInt("accesories0", 1);
        }
        else if (PlayerPrefs.GetInt("accesories0payed") == 1)
        {
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("accesories" + i, 0);
            }
            PlayerPrefs.SetInt("accesories0", 1);
            closetactivateHelper.CheckIfActive();

            closetactivateHelper.accesories[1].SetActive(false);
            closetactivateHelper.accesories[2].SetActive(false);
            closetactivateHelper.accesories[3].SetActive(false);
            closetactivateHelper.accesories[4].SetActive(false);
        }

    }

    public void ACC1Purchase()
    {
        if (PlayerPrefs.GetInt("coin") >= 150 && PlayerPrefs.GetInt("accesories1payed") == 0)
        {
            removePriceWhenBuyed.accesories[1].SetActive(false);
            PlayerPrefs.SetInt("accesories1payed", 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 150);
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("accesories" + i, 0);
            }
            PlayerPrefs.SetInt("accesories1", 1);
        }
        else if (PlayerPrefs.GetInt("accesories1payed") == 1)
        {
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("accesories" + i, 0);
            }
            PlayerPrefs.SetInt("accesories1", 1);
            closetactivateHelper.CheckIfActive();

            closetactivateHelper.accesories[0].SetActive(false);
            closetactivateHelper.accesories[2].SetActive(false);
            closetactivateHelper.accesories[3].SetActive(false);
            closetactivateHelper.accesories[4].SetActive(false);
        }
    }

    public void ACC2Purchase()
    {
        if (PlayerPrefs.GetInt("coin") >= 200 && PlayerPrefs.GetInt("accesories2payed") == 0)
        {
            removePriceWhenBuyed.accesories[2].SetActive(false);
            PlayerPrefs.SetInt("accesories2payed", 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 200);
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("accesories" + i, 0);
            }
            PlayerPrefs.SetInt("accesories2", 1);
        }
        else if (PlayerPrefs.GetInt("accesories2payed") == 1)
        {
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("accesories" + i, 0);
            }
            PlayerPrefs.SetInt("accesories2", 1);
            closetactivateHelper.CheckIfActive();

            closetactivateHelper.accesories[0].SetActive(false);
            closetactivateHelper.accesories[1].SetActive(false);
            closetactivateHelper.accesories[3].SetActive(false);
            closetactivateHelper.accesories[4].SetActive(false);
        }
    }

    public void ACC3Purchase()
    {
        if (PlayerPrefs.GetInt("coin") >= 250 && PlayerPrefs.GetInt("accesories3payed") == 0)
        {
            removePriceWhenBuyed.accesories[3].SetActive(false);
            PlayerPrefs.SetInt("accesories3payed", 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 250);
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("accesories" + i, 0);
            }
            PlayerPrefs.SetInt("accesories3", 1);
        }
        else if (PlayerPrefs.GetInt("accesories3payed") == 1)
        {
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("accesories" + i, 0);
            }
            PlayerPrefs.SetInt("accesories3", 1);
            closetactivateHelper.CheckIfActive();

            closetactivateHelper.accesories[0].SetActive(false);
            closetactivateHelper.accesories[1].SetActive(false);
            closetactivateHelper.accesories[2].SetActive(false);
            closetactivateHelper.accesories[4].SetActive(false);
        }
    }
    public void ACC4Purchase()
    {
        if (PlayerPrefs.GetInt("coin") >= 300 && PlayerPrefs.GetInt("accesories4payed") == 0)
        {
            removePriceWhenBuyed.accesories[4].SetActive(false);
            PlayerPrefs.SetInt("accesories4payed", 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 300);
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("accesories" + i, 0);
            }
            PlayerPrefs.SetInt("accesories4", 1);
        }
        else if (PlayerPrefs.GetInt("accesories4payed") == 1)
        {
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("accesories" + i, 0);
            }
            PlayerPrefs.SetInt("accesories4", 1);
            closetactivateHelper.CheckIfActive();

            closetactivateHelper.accesories[0].SetActive(false);
            closetactivateHelper.accesories[1].SetActive(false);
            closetactivateHelper.accesories[2].SetActive(false);
            closetactivateHelper.accesories[3].SetActive(false);
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////
    ///
    
}
