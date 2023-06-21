using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour

    //Reads the JSON and loads generators based on that
{
    public TextAsset jsonFile;
    public Generator generatorPrefab;
    private Generators generatorsInJson;

    void Start()
    {
        generatorsInJson = JsonUtility.FromJson<Generators>(jsonFile.text);

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

    private void Update()
    {
        //TO DO: call this only on save and not every frame
        foreach (GeneratorData generator in generatorsInJson.generators)
        {
            // TO DO get the generator object //probably by name- store name in tag?
            //call get_qty_owned()
            //set get_qty_owned() in PlayerPrefs
            PlayerPrefs.SetFloat(generator.name, 0);

            //on game load, need to load this data and set up the generators based on it

        }
    }
}
