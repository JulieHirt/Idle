using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    //Singleton
    public static PlayerData data; //static reference

    public int START_CASH = 1000; //starting cash for the player on initial game start
    private int cash;
    private int numGenerators;

    public Text cashText;

    public int getCash()
    {
        return cash;
    }
    public void setCash(int num)
    {
        cash = num;
    }
    public void gainCash(int num)
    {
        cash += num;
    }
    public void loseCash(int num)
    {
        cash -= num;
    }
    public int getNumGenerators()
    {
        return numGenerators;
    }
    public void setNumGenerators(int num)
    {
        numGenerators = num;
    }
    void Start()
    {
        //call on game start

        //will load the cash and set it to START_CASH if there is no saved value
        cash = PlayerPrefs.GetInt("cash", START_CASH);
    }

    private void Update()
    {
        cashText.text = "Cash: " + cash;

        cash += 1;
        //save the cash TODO: Don't do this every frame, only on game exit
        PlayerPrefs.SetInt("cash", cash);
    }


    void Awake()

    {
        if (data == null)
        {
            DontDestroyOnLoad(gameObject);
            data = this;
        }
        else if (data != this)
        {
            Destroy(gameObject);
        }
    }

}

