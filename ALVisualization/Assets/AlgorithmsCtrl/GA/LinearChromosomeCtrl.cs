using GeneticSharp.Domain.Chromosomes;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Renderer))]
public class LinearChromosomeCtrl : MonoBehaviour
{
    public GameObject GenePrefab;
    [SerializeField, Range(0, 100)]
    public int GeneLength = 0;
    private int PreGeneLength = 0;

    public float StepLength = 0.1f;
    private float PreStepLength = 0.1f;

    Renderer m_renderer;
    Gene[] m_Gene;

    void Start()
    {
        if (!Application.isPlaying || !gameObject.activeInHierarchy) return;
        CreateGenes();
    }

    void Update()
    {
        if (!Application.isPlaying || !gameObject.activeInHierarchy) return;

        if(PreGeneLength != GeneLength || PreStepLength != StepLength)
        {
            CreateGenes();
            PreStepLength = StepLength;
            PreGeneLength = GeneLength;
        }
    }
    void OnValidate()
    {
        if(Application.isPlaying || !gameObject.activeInHierarchy) return;
        CreateGenes();
    }

    void CreateGenes()
    {

        if (GenePrefab == null)
        {
            Debug.LogError("Cube Prefab is not assigned.");
            return;
        }

        // ���֮ǰ���ɵ�������
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

        // ��ȡCube�Ĵ�С
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
}
