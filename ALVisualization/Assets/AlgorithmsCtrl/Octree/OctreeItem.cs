using tmath.geometry;
using tmath.gs.spacial_structure;
using UnityEngine;

public class OctreeItem : MonoBehaviour
{
    public TBox3D Box = new TBox3D(new tmath.TPoint3D(-1,-1,-1), new tmath.TPoint3D(1, 1, 1));
    public Color color = Color.green;

    Octree node;
    GameObject node_prefab;

    public void OnDrawGizmos()
    {
        var tcenter = Box.GetCenter();
        Vector3 center = new Vector3((float)tcenter.X, (float)tcenter.Y, (float)tcenter.Z);
        var tsize = Box.Max - Box.Min;
        Vector3 size = new Vector3((float)tsize.X, (float)tsize.Y, (float)tsize.Z);

        // 在Scene视图中绘制Gizmos
        Gizmos.color = color;
        Gizmos.DrawWireCube(center, size);
    }
}