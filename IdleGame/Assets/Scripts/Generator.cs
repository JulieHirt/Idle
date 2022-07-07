using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    public int base_cost;
    public int payout_time;
    public int payout_amount;
    public int qty_owned;

    public Button runButton;
    public Button automateButton;
    public Button buyButton;

    public void Buy()
    {
        PlayerData.data.loseCash(base_cost);
        Debug.Log("spent" + base_cost);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
