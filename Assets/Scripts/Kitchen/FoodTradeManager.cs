using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTradeManager : MonoBehaviour
{
    [SerializeField] private AudioClip buysound;
    private void DoBuyItemStuffs()
    {
        SoundManager.instance.PlaySound(buysound);
    }
    public void BuyFood0()
    {
        if (PlayerPrefs.GetInt("coin") >= 20)
        {
            PlayerPrefs.SetInt("food0", PlayerPrefs.GetInt("food0") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 20); DoBuyItemStuffs();
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////
    public void BuyFood1()
    {
        if (PlayerPrefs.GetInt("coin") >= 20)
        {
            PlayerPrefs.SetInt("food1", PlayerPrefs.GetInt("food1") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 20); DoBuyItemStuffs();
        }
    }
/////////////////////////////////////////////////////////////////////////////////////////////////////////
  public void BuyFood2()
    {
        if (PlayerPrefs.GetInt("coin") >= 20)
        {
            PlayerPrefs.SetInt("food2", PlayerPrefs.GetInt("food2") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 20); DoBuyItemStuffs();
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void BuyFood3()
    {
        if (PlayerPrefs.GetInt("coin") >= 30)
        {
            PlayerPrefs.SetInt("food3", PlayerPrefs.GetInt("food3") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 30); DoBuyItemStuffs();
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////7
    public void BuyFood4()
    {
        if (PlayerPrefs.GetInt("coin") >= 30)
        {
            PlayerPrefs.SetInt("food4", PlayerPrefs.GetInt("food4") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 30); DoBuyItemStuffs();
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void BuyFood5()
    {
        if (PlayerPrefs.GetInt("coin") >= 30)
        {
            PlayerPrefs.SetInt("food5", PlayerPrefs.GetInt("food5") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 30); DoBuyItemStuffs();
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////7
    public void BuyFood6()
    {
        if (PlayerPrefs.GetInt("coin") >= 50)
        {
            PlayerPrefs.SetInt("food6", PlayerPrefs.GetInt("food6") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 50); DoBuyItemStuffs();
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////
    public void BuyFood7()
    {
        if (PlayerPrefs.GetInt("coin") >= 50)
        {
            PlayerPrefs.SetInt("food7", PlayerPrefs.GetInt("food7") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 50); DoBuyItemStuffs();
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////
    public void BuyFood8()
    {
        if (PlayerPrefs.GetInt("coin") >= 50)
        {
            PlayerPrefs.SetInt("food8", PlayerPrefs.GetInt("food8") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 50); DoBuyItemStuffs();
        }
    }
    /////////////////////////////////////////////////////////////////
    public void BuyFood9()
    {
        if (PlayerPrefs.GetInt("coin") >= 50)
        {
            PlayerPrefs.SetInt("food9", PlayerPrefs.GetInt("food9") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 50); DoBuyItemStuffs();
        }
    }
    /////////////////////////////////////////////////////////////////
    public void BuyFood10()//apple
    {
        if (PlayerPrefs.GetInt("coin") >= 10)
        {
            PlayerPrefs.SetInt("food10", PlayerPrefs.GetInt("food10") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 10); DoBuyItemStuffs();
        }
    }
    public void BuyFood11()//cherry
    {
        if (PlayerPrefs.GetInt("coin") >= 10)
        {
            PlayerPrefs.SetInt("food11", PlayerPrefs.GetInt("food11") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 10); DoBuyItemStuffs();
        }
    }
    public void BuyFood12()//strawberry
    {
        if (PlayerPrefs.GetInt("coin") >= 10)
        {
            PlayerPrefs.SetInt("food12", PlayerPrefs.GetInt("food12") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 10); DoBuyItemStuffs();
        }
    }
    public void BuyFood13()//pear
    {
        if (PlayerPrefs.GetInt("coin") >= 20)
        {
            PlayerPrefs.SetInt("food13", PlayerPrefs.GetInt("food13") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 20); DoBuyItemStuffs();
        }
    }
    public void BuyFood14()//banana
    {
        if (PlayerPrefs.GetInt("coin") >= 20)
        {
            PlayerPrefs.SetInt("food14", PlayerPrefs.GetInt("food14") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 20); DoBuyItemStuffs();
        }
    }
    public void BuyFood15()//peach
    {
        if (PlayerPrefs.GetInt("coin") >= 20)
        {
            PlayerPrefs.SetInt("food15", PlayerPrefs.GetInt("food15") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 20); DoBuyItemStuffs();
        }
    }
    public void BuyFood16()//watermelon
    {
        if (PlayerPrefs.GetInt("coin") >= 40)
        {
            PlayerPrefs.SetInt("food16", PlayerPrefs.GetInt("food16") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 40); DoBuyItemStuffs();
        }
    }

    public void BuyFood17()//orange
    {
        if (PlayerPrefs.GetInt("coin") >= 40)
        {
            PlayerPrefs.SetInt("food17", PlayerPrefs.GetInt("food17") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 40); DoBuyItemStuffs();
        }
    }
    public void BuyFood18()//blueberry
    {
        if (PlayerPrefs.GetInt("coin") >= 40)
        {
            PlayerPrefs.SetInt("food18", PlayerPrefs.GetInt("food18") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 40); DoBuyItemStuffs();
        }
    }
    public void BuyFood19()//watermelon
    {
        if (PlayerPrefs.GetInt("coin") >= 40)
        {
            PlayerPrefs.SetInt("food19", PlayerPrefs.GetInt("food19") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 40); DoBuyItemStuffs();
        }
    }
    public void BuyFood20()//avocado
    {
        if (PlayerPrefs.GetInt("coin") >= 20)
        {
            PlayerPrefs.SetInt("food20", PlayerPrefs.GetInt("food20") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 20); DoBuyItemStuffs();
        }
    }
    public void BuyFood21()//cucumber
    {
        if (PlayerPrefs.GetInt("coin") >= 20)
        {
            PlayerPrefs.SetInt("food21", PlayerPrefs.GetInt("food21") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 20); DoBuyItemStuffs();
        }
    }
    public void BuyFood22()//egg
    {
        if (PlayerPrefs.GetInt("coin") >= 20)
        {
            PlayerPrefs.SetInt("food22", PlayerPrefs.GetInt("food22") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 20); DoBuyItemStuffs();
        }
    }
    public void BuyFood23()//salmon
    {
        if (PlayerPrefs.GetInt("coin") >= 30)
        {
            PlayerPrefs.SetInt("food23", PlayerPrefs.GetInt("food23") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 30); DoBuyItemStuffs();
        }
    }
    public void BuyFood24()//tuna
    {
        if (PlayerPrefs.GetInt("coin") >= 30)
        {
            PlayerPrefs.SetInt("food24", PlayerPrefs.GetInt("food24") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 30); DoBuyItemStuffs();
        }
    }
    public void BuyFood25()//california
    {
        if (PlayerPrefs.GetInt("coin") >= 50)
        {
            PlayerPrefs.SetInt("food25", PlayerPrefs.GetInt("food25") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 50); DoBuyItemStuffs();
        }
    }
    public void BuyFood26()//egesus
    {
        if (PlayerPrefs.GetInt("coin") >= 30)
        {
            PlayerPrefs.SetInt("food26", PlayerPrefs.GetInt("food26") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 30); DoBuyItemStuffs();
        }
    }
    public void BuyFood27()//kani
    {
        if (PlayerPrefs.GetInt("coin") >= 50)
        {
            PlayerPrefs.SetInt("food27", PlayerPrefs.GetInt("food27") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 50); DoBuyItemStuffs();
        }
    }
    public void BuyFood28()//salmon
    {
        if (PlayerPrefs.GetInt("coin") >= 50)
        {
            PlayerPrefs.SetInt("food28", PlayerPrefs.GetInt("food28") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 50); DoBuyItemStuffs();
        }
    }
    public void BuyFood29()//shrimp
    {
        if (PlayerPrefs.GetInt("coin") >= 50)
        {
            PlayerPrefs.SetInt("food29", PlayerPrefs.GetInt("food29") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 50); DoBuyItemStuffs();
        }
    }
    public void BuyFood30()//bread
    {
        if (PlayerPrefs.GetInt("coin") >= 20)
        {
            PlayerPrefs.SetInt("food30", PlayerPrefs.GetInt("food30") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 20); DoBuyItemStuffs();
        }
    }
    public void BuyFood31()//eggs
    {
        if (PlayerPrefs.GetInt("coin") >= 20)
        {
            PlayerPrefs.SetInt("food31", PlayerPrefs.GetInt("food31") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 20); DoBuyItemStuffs();
        }
    }
    public void BuyFood32()//sandwich
    {
        if (PlayerPrefs.GetInt("coin") >= 20)
        {
            PlayerPrefs.SetInt("food32", PlayerPrefs.GetInt("food32") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 20); DoBuyItemStuffs();
        }
    }
    public void BuyFood33()//fries
    {
        if (PlayerPrefs.GetInt("coin") >= 30)
        {
            PlayerPrefs.SetInt("food33", PlayerPrefs.GetInt("food33") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 30); DoBuyItemStuffs();
        }
    }
    public void BuyFood34()//spagetti
    {
        if (PlayerPrefs.GetInt("coin") >= 30)
        {
            PlayerPrefs.SetInt("food34", PlayerPrefs.GetInt("food34") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 30); DoBuyItemStuffs();
        }
    }
    public void BuyFood35()//beef
    {
        if (PlayerPrefs.GetInt("coin") >= 30)
        {
            PlayerPrefs.SetInt("food35", PlayerPrefs.GetInt("food35") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 30); DoBuyItemStuffs();
        }
    }
    public void BuyFood36()//drumstick
    {
        if (PlayerPrefs.GetInt("coin") >= 50)
        {
            PlayerPrefs.SetInt("food36", PlayerPrefs.GetInt("food36") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 50); DoBuyItemStuffs();
        }
    }
    public void BuyFood37()//turkey
    {
        if (PlayerPrefs.GetInt("coin") >= 50)
        {
            PlayerPrefs.SetInt("food37", PlayerPrefs.GetInt("food37") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 50); DoBuyItemStuffs();
        }
    }
    public void BuyFood38()//pizza
    {
        if (PlayerPrefs.GetInt("coin") >= 50)
        {
            PlayerPrefs.SetInt("food38", PlayerPrefs.GetInt("food38") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 50); DoBuyItemStuffs();
        }
    }
    public void BuyFood39()//hamburger
    {
        if (PlayerPrefs.GetInt("coin") >= 50)
        {
            PlayerPrefs.SetInt("food39", PlayerPrefs.GetInt("food39") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 50); DoBuyItemStuffs();
        }
    }
    public void BuyFood40()//peas
    {
        if (PlayerPrefs.GetInt("coin") >= 20)
        {
            PlayerPrefs.SetInt("food40", PlayerPrefs.GetInt("food40") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 20); DoBuyItemStuffs();
        }
    }
    public void BuyFood41()//pepper
    {
        if (PlayerPrefs.GetInt("coin") >= 20)
        {
            PlayerPrefs.SetInt("food41", PlayerPrefs.GetInt("food41") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 20); DoBuyItemStuffs();
        }
    }
    public void BuyFood42()//brocoli
    {
        if (PlayerPrefs.GetInt("coin") >= 20)
        {
            PlayerPrefs.SetInt("food42", PlayerPrefs.GetInt("food42") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 20); DoBuyItemStuffs();
        }
    }
    public void BuyFood43()//corn
    {
        if (PlayerPrefs.GetInt("coin") >= 30)
        {
            PlayerPrefs.SetInt("food43", PlayerPrefs.GetInt("food43") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 30); DoBuyItemStuffs();
        }
    }
    public void BuyFood44()//carrot
    {
        if (PlayerPrefs.GetInt("coin") >= 30)
        {
            PlayerPrefs.SetInt("food44", PlayerPrefs.GetInt("food44") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 30); DoBuyItemStuffs();
        }
    }
    public void BuyFood45()//eggplant
    {
        if (PlayerPrefs.GetInt("coin") >= 30)
        {
            PlayerPrefs.SetInt("food45", PlayerPrefs.GetInt("food45") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 30); DoBuyItemStuffs();
        }
    }
    public void BuyFood46()//mushroom
    {
        if (PlayerPrefs.GetInt("coin") >= 50)
        {
            PlayerPrefs.SetInt("food46", PlayerPrefs.GetInt("food46") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 50); DoBuyItemStuffs();
        }
    }
    public void BuyFood47()//tomato
    {
        if (PlayerPrefs.GetInt("coin") >= 50)
        {
            PlayerPrefs.SetInt("food47", PlayerPrefs.GetInt("food47") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 50); DoBuyItemStuffs();
        }
    }
    public void BuyFood48()//radish
    {
        if (PlayerPrefs.GetInt("coin") >= 50)
        {
            PlayerPrefs.SetInt("food48", PlayerPrefs.GetInt("food48") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 50); DoBuyItemStuffs();
        }
    }
    public void BuyFood49()//pumpkin
    {
        if (PlayerPrefs.GetInt("coin") >= 50)
        {
            PlayerPrefs.SetInt("food49", PlayerPrefs.GetInt("food49") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 50); DoBuyItemStuffs();
        }
    }
    public void BuyFood50()//andyapple
    {
        if (PlayerPrefs.GetInt("coin") >= 20)
        {
            PlayerPrefs.SetInt("food50", PlayerPrefs.GetInt("food50") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 20); DoBuyItemStuffs();
        }
    }
    public void BuyFood51()//cottoncandy
    {
        if (PlayerPrefs.GetInt("coin") >= 30)
        {
            PlayerPrefs.SetInt("food51", PlayerPrefs.GetInt("food51") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 30); DoBuyItemStuffs();
        }
    }
    public void BuyFood52()//vanillaicecream
    {
        if (PlayerPrefs.GetInt("coin") >= 50)
        {
            PlayerPrefs.SetInt("food52", PlayerPrefs.GetInt("food52") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 50); DoBuyItemStuffs();
        }
    }
    public void BuyFood53()//chocoicecraem
    {
        if (PlayerPrefs.GetInt("coin") >= 20)
        {
            PlayerPrefs.SetInt("food53", PlayerPrefs.GetInt("food53") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 20); DoBuyItemStuffs();
        }
    }
    public void BuyFood54()//strawicecrem
    {
        if (PlayerPrefs.GetInt("coin") >= 30)
        {
            PlayerPrefs.SetInt("food54", PlayerPrefs.GetInt("food54") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 30); DoBuyItemStuffs();
        }
    }
    public void BuyFood55()//chocodonut
    {
        if (PlayerPrefs.GetInt("coin") >= 50)
        {
            PlayerPrefs.SetInt("food55", PlayerPrefs.GetInt("food55") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 50); DoBuyItemStuffs();
        }
    }
    public void BuyFood56()//starwdonut
    {
        if (PlayerPrefs.GetInt("coin") >= 30)
        {
            PlayerPrefs.SetInt("food56", PlayerPrefs.GetInt("food56") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 30); DoBuyItemStuffs();
        }
    }
    public void BuyFood57()//starwdonut
    {
        if (PlayerPrefs.GetInt("coin") >= 50)
        {
            PlayerPrefs.SetInt("food57", PlayerPrefs.GetInt("food57") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 50); DoBuyItemStuffs();
        }
    }
    public void BuyFood58()//starwdonut
    {
        if (PlayerPrefs.GetInt("coin") >= 50)
        {
            PlayerPrefs.SetInt("food58", PlayerPrefs.GetInt("food58") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 50); DoBuyItemStuffs();
        }
    }
    public void BuyFood59()//starwdonut
    {
        if (PlayerPrefs.GetInt("coin") >= 50)
        {
            PlayerPrefs.SetInt("food59", PlayerPrefs.GetInt("food59") + 1);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 50); DoBuyItemStuffs();
        }
    }
}
