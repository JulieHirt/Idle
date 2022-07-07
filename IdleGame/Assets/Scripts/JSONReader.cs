using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset jsonFile;

    void Start()
    {
        Generators generatorsInJson = JsonUtility.FromJson<Generators>(jsonFile.text);

        foreach (GeneratorData generator in generatorsInJson.generators)
        {
            Debug.Log("Found generator: " + generator.name + " " + generator.base_cost);
        }
    }
}
