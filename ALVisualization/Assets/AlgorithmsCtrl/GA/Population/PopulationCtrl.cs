using GeneticSharp.Domain.Populations;
using UnityEngine;

[ExecuteInEditMode]
public class PopulationCtrl : MonoBehaviour
{
    public int MinSize = 10;
    public int MaxSize = 20;

    public GameObject AdamChromosomePerfab;
    IPopulation population;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdatePopulation()
    {

    }

    public void CreateInitialGeneration()
    {
        Debug.Log("CreateInitialGeneration");
    }

    public void CreateNewGeneration()
    {

    }

    public void EndCurrentGeneration()
    {

    }
}
