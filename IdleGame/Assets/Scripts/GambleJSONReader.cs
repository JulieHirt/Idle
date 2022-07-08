using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GambleJSONReader : MonoBehaviour
{
    public TextAsset jsonFile;
    public Button gambleButton;

    private int GAMBLE_COST = 30;
    // Start is called before the first frame update
    void Start()
    {
        //Generators generatorsInJson = JsonUtility.FromJson<Generators>(jsonFile.text);
        gambleButton.GetComponentInChildren<Text>().text = "Gamble: \n$" + GAMBLE_COST;
    }

    public void Gamble()
    {
        //spend GAMBLE_COST
        PlayerData.data.loseCash(GAMBLE_COST);
        int weight1 = 2;
        float weight1amt = 40;//cash
        int weight2 = 3;
        float weight2amt = 20;//cash

        int total =5; //change to sum of weights or 100
        int num = Random.Range(1, total+1); //add +1 so that total is included
        if(num > 0 && num < 3)
        {
            PlayerData.data.addCash(weight1amt);
            Debug.Log("you got this $ from gamble"+ weight1amt.ToString()+"num is"+num);
        }else if(num >=3) //&& num < 5 )
        {
            PlayerData.data.addCash(weight2amt);
            Debug.Log("you got this $ from gamble" + weight2amt.ToString()+"num is" + num);
        }

    }

    void Update()
    {
        if(PlayerData.data.getCash() > GAMBLE_COST)
        {
            gambleButton.interactable = true;
        }
    }

}
