using GeneticSharp.Domain.Chromosomes;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Renderer))]
public class LinearChromosomeCtrl : MonoBehaviour
{
    public GameObject GenePrefab;
    [SerializeField, Range(0, 100)]
    private int GeneLength = 0;
    private int PreGeneLength = 0;

    public float StepLength = 0.1f;
    private float PreStepLength = 0.1f;

    //#region Chromosome Parameters
    //public object MinValue;
    //public object MaxValue;
    //public object Fraction;
    //#endregion

    public Gene[] genes;
    //private string[] PreChromosomeOptions = { "Alternating-position (AP)", "Cycle (CX)", "Order-based (OX2)", "Ordered (OX1)", "Partially Mapped (PMX)", "Position-based (POS)" };
    private string[] PreChromosomeOptions = { "FloatintPoint", "Integer" };
    private int SelectedOptionIndex;

    Renderer m_renderer;

    IChromosome chromosome;

    void Start()
    {
        if (!Application.isPlaying || !gameObject.activeInHierarchy) return;
        CreateGenes();
    }

    void Update()
    {
        if (!Application.isPlaying || !gameObject.activeInHierarchy) return;

        if (PreGeneLength != GeneLength || PreStepLength != StepLength)
        {
            CreateGenes();
            PreStepLength = StepLength;
            PreGeneLength = GeneLength;
        }
    }
    void OnValidate()
    {
        if (Application.isPlaying || !gameObject.activeInHierarchy) return;
        CreateGenes();
    }

    void CreateGenes()
    {

        if (GenePrefab == null)
        {
            Debug.LogError("Cube Prefab is not assigned.");
            return;
        }

        // 清空之前生成的立方体
        foreach (Transform child in transform)
        {
            if ((child != null) || child.transform != null || child.gameObject != null)
            {
                EditorApplication.delayCall += () =>
                {
                    DestroyImmediate(child.gameObject);
                };
            }
        }

        // 获取Cube的大小
        Vector3 geneSize = GenePrefab.GetComponent<Renderer>().bounds.size;

        for (int i = 0; i < GeneLength; i++)
        {
            GameObject cube = Instantiate(GenePrefab, transform);
            cube.transform.position = new Vector3(i * (geneSize.x + StepLength), 0, 0);
        }

        m_renderer = GetComponent<Renderer>();
        Renderer[] childRenderers = GetComponentsInChildren<Renderer>();
        Bounds combinedBounds = new Bounds(m_renderer.transform.position, Vector3.zero);
        foreach (var item in childRenderers)
        {
            combinedBounds.Encapsulate(item.bounds);
        }

        m_renderer.bounds = combinedBounds;
    }

    public string[] GetOptions() => PreChromosomeOptions;

    public void SelectIndex(int index = 0)
    {
        string option_name = PreChromosomeOptions[index];
        switch (option_name)
        {
            case "FloatintPoint":
                //chromosome = new FloatingPointChromosome((double.Parse(MinValue)), (double.Parse(MaxValue)), (int.Parse(Fraction)));
                break;
            case "Integer":
                //chromosome = new IntegerChromosome((int.Parse(MinValue)), (int.Parse(MaxValue)));
                break;
        }

    }
}
