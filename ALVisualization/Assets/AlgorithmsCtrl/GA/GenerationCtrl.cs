using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class GenerationCtrl : MonoBehaviour
{
    public GameObject ChromosomePrefab;

    [SerializeField, Range(0, 20)]
    public int NumberOfChromosome;
    private int PreNumberOfChromosome;

    [SerializeField, Range(0, 10)]
    public float StepLength;
    private float PreStepLength;

    // Start is called before the first frame update
    void Start()
    {
        if (!Application.isPlaying || !gameObject.activeInHierarchy) return;
        UpdateGeneration();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying || !gameObject.activeInHierarchy) return;

        if (PreNumberOfChromosome != NumberOfChromosome || PreStepLength != StepLength)
        {
            UpdateGeneration();
            PreStepLength = StepLength;
            PreNumberOfChromosome = NumberOfChromosome;
        }
    }

    void OnValidate()
    {
        if (Application.isPlaying || !gameObject.activeInHierarchy) return;
        UpdateGeneration();
    }

    void UpdateGeneration()
    {
        if (ChromosomePrefab == null)
        {
            Debug.LogError("ChromosomePrefab is not assigned.");
            return;
        }

        // 清空之前生成的立方体
        foreach (Transform child in transform)
        {
            if ((child != null))
            {
                EditorApplication.delayCall += () =>
                {
                    DestroyImmediate(child.gameObject);
                };
            }
        }

        // 获取Cube的大小

        for (int i = 0; i < NumberOfChromosome; i++)
        {
            GameObject cube = Instantiate(ChromosomePrefab, transform);
            // set random parameters;
            LinearChromosomeCtrl component = cube.GetComponent<LinearChromosomeCtrl>();
            component.GeneLength = 5;
            component.StepLength = StepLength;

            component.SendMessage("OnValidate", null);

            Vector3 geneSize = cube.GetComponent<Renderer>().bounds.size;
            cube.transform.position = new Vector3(0, i * (geneSize.y + StepLength), 0);
            cube.SetActive(true);
        }
    }
}
