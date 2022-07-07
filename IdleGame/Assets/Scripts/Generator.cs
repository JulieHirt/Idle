using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    public string name;
    private int base_cost;
    private int payout_time;
    private int payout_amount;
    private int qty_owned;
    private int automate_cost;

    private float current_cost; //calculated based on base_cost, formula: base_cost^(qty_owned+1)

    public Button runButton;
    public Button automateButton;
    public Button buyButton;
    public Text timeText;



    //getters and setters
    public string get_name()
    {
        return name;
    }
    public void set_name(string newname)
    {
        name = newname;
    }
    public int get_base_cost()
    {
        return base_cost;
    }
    public void set_base_cost(int num)
    {
        base_cost = num;
    }
    public int get_payout_time()
    {
        return payout_time;
    }
    public void set_payout_time(int num)
    {
        payout_time = num;
    }
    public int get_payout_amount()
    {
        return payout_amount;
    }
    public void set_payout_amount(int num)
    {
        payout_amount = num;
    }
    public int get_qty_owned()
    {
        return payout_amount;
    }
    public void set_qty_owned(int num)
    {
        payout_amount = num;
    }
    public void Buy()
    {
        //update the player's cash
        PlayerData.data.loseCash(current_cost);
        Debug.Log("spent" + current_cost);

        //update the qty_owned and the new current_cost
        qty_owned += 1;
        float exponent = (float)qty_owned + 1;
        current_cost = Mathf.Pow((float)base_cost, exponent);

        //update the ui with new numbers
        UpdateRunUI();
        UpdateBuyUI();

    }
    // Start is called before the first frame update
    void Start()
    {
        automate_cost = base_cost * 1000; //automation costs a fixed amount of cash, differnt for each generator
        //calculating it from the base cost, which is unique for each generator, will give an automate cost that is unique.
        UpdateRunUI();
        // qty_owned = 0, therefore base_cost^(qty_owned+1) = base_cost^1 = base_cost
        // we do not need to calculate the current_cost; it is simply base_cost
        current_cost = base_cost;
        UpdateBuyUI();
        automateButton.GetComponentInChildren<Text>().text = "Automate: $" + automate_cost;
    }

    void UpdateBuyUI()
    {
        buyButton.GetComponentInChildren<Text>().text = "Buy: $" + current_cost;
    }

    void UpdateRunUI()
    {
        runButton.GetComponentInChildren<Text>().text = name + "\n" + qty_owned;
    }

    // Update is called once per frame
    void Update()
    {
        //determine if buttons are interactive
        //buy
        if(PlayerData.data.getCash() < current_cost)
        {
            buyButton.interactable = false;
        }
        else
        {
            buyButton.interactable = true;
        }
        //automate
        if (PlayerData.data.getCash() < automate_cost)
        {
            automateButton.interactable = false;
        }
        else
        {
            automateButton.interactable = true;
        }

    }
}
