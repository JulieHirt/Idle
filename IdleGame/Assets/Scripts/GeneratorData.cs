using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GeneratorData
{
    //these variables are case sensitive and must match the strings ie "name" and "base_cost" in the JSON.
    public string name;
    public int base_cost;
    public int payout_time;
    public int payout_amount;
    public int qty_owned;
}
