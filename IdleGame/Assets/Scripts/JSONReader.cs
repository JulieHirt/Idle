using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour

    //Reads the JSON and loads generators based on that
{
    public TextAsset jsonFile;
    public Generator generatorPrefab;

    void Start()
    {
        Generators generatorsInJson = JsonUtility.FromJson<Generators>(jsonFile.text);

        float yCoord = -100;
        foreach (GeneratorData generator in generatorsInJson.generators)
        {
            Debug.Log("Found generator: " + generator.name + " " + generator.base_cost);

           
            Generator generatorobj = Instantiate(generatorPrefab, new Vector3(this.transform.position.x, this.transform.position.y + yCoord, this.transform.position.z), Quaternion.identity);
            //set parent to the canvas so that it is visible on the screen
            generatorobj.transform.SetParent(GameObject.Find("Canvas").transform, false);
            generatorobj.set_name(generator.name);
            generatorobj.set_base_cost(generator.base_cost);
            generatorobj.set_payout_time(generator.payout_time);
            generatorobj.set_payout_amount(generator.payout_amount);
            generatorobj.set_qty_owned(generator.qty_owned);


            //new generators y values change so they are not on top of each other
            //TO DO: Add to a scrolling list so they do not go off screen
            yCoord += 80;


        }
    }
}
