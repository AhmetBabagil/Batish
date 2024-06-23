using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public SpriteRenderer backgroundcolor;

    private void Start()
    {

        if (gameObject.name.Equals("BedroomColors")) setBedroomBackgroundColor();
        if (gameObject.name.Equals("BathRoomColors")) setBathRoomBackgroundColor();
        if (gameObject.name.Equals("KitchenColors")) setKitchenBackgroundColor();
        if (gameObject.name.Equals("GameRoomColors")) setGameRoomBackgroundColor();
    }



    //BU METOT ANLIK BACKGROUNDI BELÝRLEMEK ÝÇÝN VARDIR
    // ÝÇÝNDE LEVEL VEYA PARAYLA ALMA Parametresini kontrol etmez
    private void setBedroomBackgroundColor()
    {
        if (PlayerPrefs.GetInt("bedroombackground_0") == 1)
        {
            backgroundcolor.color = Color.black;
        }

        if (PlayerPrefs.GetInt("bedroombackground_1") == 1)
        {
            backgroundcolor.color = Color.blue;
        }

        if (PlayerPrefs.GetInt("bedroombackground_2") == 1)
        {
            backgroundcolor.color = Color.yellow;
        }

        if (PlayerPrefs.GetInt("bedroombackground_3") == 1)
        {
            backgroundcolor.color = Color.cyan;
        }

        if (PlayerPrefs.GetInt("bedroombackground_4") == 1)
        {
            backgroundcolor.color = Color.gray;
        }

        if (PlayerPrefs.GetInt("bedroombackground_5") == 1)
        {
            backgroundcolor.color = Color.green;
        }

        if (PlayerPrefs.GetInt("bedroombackground_6") == 1)
        {
            backgroundcolor.color = Color.grey;
        }

        if (PlayerPrefs.GetInt("bedroombackground_7") == 1)
        {
            backgroundcolor.color = Color.magenta;
        }

        if (PlayerPrefs.GetInt("bedroombackground_8") == 1)
        {
            backgroundcolor.color = Color.red;
        }

    }
    private void setBathRoomBackgroundColor()
    {
        if (PlayerPrefs.GetInt("bathroombackground_0") == 1)
        {
            backgroundcolor.color = Color.black;
        }

        if (PlayerPrefs.GetInt("bathroombackground_1") == 1)
        {
            backgroundcolor.color = Color.blue;
        }

        if (PlayerPrefs.GetInt("bathroombackground_2") == 1)
        {
            backgroundcolor.color = Color.yellow;
        }

        if (PlayerPrefs.GetInt("bathroombackground_3") == 1)
        {
            backgroundcolor.color = Color.cyan;
        }

        if (PlayerPrefs.GetInt("bathroombackground_4") == 1)
        {
            backgroundcolor.color = Color.gray;
        }

        if (PlayerPrefs.GetInt("bathroombackground_5") == 1)
        {
            backgroundcolor.color = Color.green;
        }

        if (PlayerPrefs.GetInt("bathroombackground_6") == 1)
        {
            backgroundcolor.color = Color.grey;
        }

        if (PlayerPrefs.GetInt("bathroombackground_7") == 1)
        {
            backgroundcolor.color = Color.magenta;
        }

        if (PlayerPrefs.GetInt("bathroombackground_8") == 1)
        {
            backgroundcolor.color = Color.red;
        }
    }
    private void setKitchenBackgroundColor()
    {
        if (PlayerPrefs.GetInt("kitchenbackground_0") == 1)
        {
            backgroundcolor.color = Color.black;
        }

        if (PlayerPrefs.GetInt("kitchenbackground_1") == 1)
        {
            backgroundcolor.color = Color.blue;
        }

        if (PlayerPrefs.GetInt("kitchenbackground_2") == 1)
        {
            backgroundcolor.color = Color.yellow;
        }

        if (PlayerPrefs.GetInt("kitchenbackground_3") == 1)
        {
            backgroundcolor.color = Color.cyan;
        }

        if (PlayerPrefs.GetInt("kitchenbackground_4") == 1)
        {
            backgroundcolor.color = Color.gray;
        }

        if (PlayerPrefs.GetInt("kitchenbackground_5") == 1)
        {
            backgroundcolor.color = Color.green;
        }

        if (PlayerPrefs.GetInt("kitchenbackground_6") == 1)
        {
            backgroundcolor.color = Color.grey;
        }

        if (PlayerPrefs.GetInt("kitchenbackground_7") == 1)
        {
            backgroundcolor.color = Color.magenta;
        }

        if (PlayerPrefs.GetInt("kitchenbackground_8") == 1)
        {
            backgroundcolor.color = Color.red;
        }
    }
    private void setGameRoomBackgroundColor()
    {
        if (PlayerPrefs.GetInt("gameroombackground_0") == 1)
        {
            backgroundcolor.color = Color.black;
        }

        if (PlayerPrefs.GetInt("gameroombackground_1") == 1)
        {
            backgroundcolor.color = Color.blue;
        }

        if (PlayerPrefs.GetInt("gameroombackground_2") == 1)
        {
            backgroundcolor.color = Color.yellow;
        }

        if (PlayerPrefs.GetInt("gameroombackground_3") == 1)
        {
            backgroundcolor.color = Color.cyan;
        }

        if (PlayerPrefs.GetInt("gameroombackground_4") == 1)
        {
            backgroundcolor.color = Color.gray;
        }

        if (PlayerPrefs.GetInt("gameroombackground_5") == 1)
        {
            backgroundcolor.color = Color.green;
        }

        if (PlayerPrefs.GetInt("gameroombackground_6") == 1)
        {
            backgroundcolor.color = Color.grey;
        }

        if (PlayerPrefs.GetInt("gameroombackground_7") == 1)
        {
            backgroundcolor.color = Color.magenta;
        }

        if (PlayerPrefs.GetInt("gameroombackground_8") == 1)
        {
            backgroundcolor.color = Color.red;
        }
    }

    public void SetAllRoomsBackGrounds()
    {
        setBathRoomBackgroundColor();
        setBedroomBackgroundColor();
        setKitchenBackgroundColor();
        setGameRoomBackgroundColor();
    }

    public void SetAllBathRoomBackGroundColorsDataToZero()
    {
        string id = "bathroombackground_";
        for (int i = 0; i <= 8; i++)
        {
            PlayerPrefs.SetInt(id + i, 0);
        }
    }
    public void SetAllBedRoomBackGroundColorsDataToZero()
    {
        string id = "bedroombackground_";
        for (int i = 0; i <= 8; i++)
        {
            PlayerPrefs.SetInt(id + i, 0);
        }
    }
    public void SetAllKitchenBackGroundColorsDataToZero()
    {
        string id = "kitchenbackground_";
        for (int i = 0; i <= 8; i++)
        {
            PlayerPrefs.SetInt(id + i, 0);
        }
    }
    public void SetAllGameRoomBackGroundColorsDataToZero()
    {
        string id = "gameroombackground_";
        for (int i = 0; i <= 8; i++)
        {
            PlayerPrefs.SetInt(id + i, 0);
        }
    }
}
