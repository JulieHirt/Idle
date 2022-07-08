using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GambleWeights
{
    //gamble is case sensitive and must match the string "gambles" in the JSON.
    public GambleWeight[] gambles;
}
