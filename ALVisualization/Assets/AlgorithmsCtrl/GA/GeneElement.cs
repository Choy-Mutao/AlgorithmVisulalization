using UnityEngine;

[System.Serializable]
public class GeneElement
{

    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    public Color color;

    // 初始化随机基因
    public GeneElement()
    {
        position = new Vector3(
            Random.Range(-10f, 10f),
            Random.Range(-10f, 10f),
            Random.Range(-10f, 10f)
        );

        rotation = Random.rotation;
        scale = new Vector3(
            Random.Range(0.5f, 2f),
            Random.Range(0.5f, 2f),
            Random.Range(0.5f, 2f)
        );

        color = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );
    }
}