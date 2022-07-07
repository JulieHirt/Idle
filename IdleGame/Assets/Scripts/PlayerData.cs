using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    //Singleton
    public static PlayerData data; //static reference

    public float START_CASH = 1000; //starting cash for the player on initial game start
    private float cash;
    private int numGenerators;

    public Text cashText;

    public float getCash()
    {
        return cash;
    }
    public void setCash(float num)
    {
        cash = num;
    }
    public void gainCash(float num)
    {
        cash += num;
    }
    public void loseCash(float num)
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
        cash = 2000;
        //cash = PlayerPrefs.GetFloat("cash", START_CASH);
    }

    private void Update()
    {
        cashText.text = "$" + cash;

        //save the cash TODO: Don't do this every frame, only on game exit
        PlayerPrefs.SetFloat("cash", cash);
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

