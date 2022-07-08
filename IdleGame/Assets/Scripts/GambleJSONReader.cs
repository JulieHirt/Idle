using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GambleJSONReader : MonoBehaviour
{
    
    public TextAsset jsonFile;
    public Button gambleButton;

    private int GAMBLE_COST = 30;


    //assume 5 sets of amount/weight
    int weight1 = 2;
    float weight1amt = 40;//cash
    int weight2 = 3;
    float weight2amt = 20;//cash

    private Dictionary<int, float> dictionaryOfGambling = new Dictionary<int, float>(); //key is int value is float




    // Start is called before the first frame update
    void Start()
    {
        GambleWeights gambleWeightsInJson = JsonUtility.FromJson<GambleWeights>(jsonFile.text);
        Debug.Log(gambleWeightsInJson);
        foreach (GambleWeight weight in gambleWeightsInJson.gambles)
        {
            Debug.Log("Found gamble weight: " + weight.amount + " " + weight.weight);

            dictionaryOfGambling.Add(weight.weight, weight.amount); //key is weight (how likely it is to be rolled), value is amount (cash payout amount)
        }
        gambleButton.GetComponentInChildren<Text>().text = "Gamble: \n$" + GAMBLE_COST; //set the text based on the GAMBLE_COST constant
    }

    public void Gamble()
    {
        //spend GAMBLE_COST
        PlayerData.data.loseCash(GAMBLE_COST);
        

        int total =100; //TO DO: calculate total based on sum of weights (in case sum is not 100)
        int num = Random.Range(1, total+1); //add +1 so that total is included


        //if num is 0 to this weight
        //or prev weight to this weight
        //or prev weight to end


        //weight indicates the number of numbers that can be rolled to land there
        //ie if weight is 80, there are 80 different possible numbers.
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
        else
        {
            gambleButton.interactable = false;
        }
    }

}
