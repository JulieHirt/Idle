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
        PlayerData.data.loseCash(base_cost);
        Debug.Log("spent" + base_cost);
    }
    // Start is called before the first frame update
    void Start()
    {
        runButton.GetComponentInChildren<Text>().text = name +"\n"+ qty_owned;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
