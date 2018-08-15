using UnityEngine;
using UnityEditor;
using System.IO;

public class BlenderAssetProcessor : AssetPostprocessor
{
    public void OnPostprocessModel(GameObject obj)
    {
        ModelImporter importer = (ModelImporter) assetImporter;
        if (Path.GetExtension(importer.assetPath) == ".blend")
        {
            RotateObject(obj.transform);
        }

        obj.transform.rotation = Quaternion.identity;
    }

    private static void RotateObject(Transform obj, bool root = true)
    {
        // Minus y is to compensate unity internal importer, that already worked on that mesh
        obj.position = new Vector3(-obj.position.x, obj.position.z, obj.position.y);

        // Rotate root back, resetting transform.Rotation and putting to right position
        /*if (root)*/ obj.RotateAround(Vector3.zero, Vector3.right, 90);

        MeshFilter meshFilter = obj.GetComponent<MeshFilter>();
        if (meshFilter != null) RotateMesh(meshFilter.sharedMesh);

        foreach (Transform child in obj) RotateObject(child, false);
    }

    private static void RotateMesh(Mesh mesh)
    {
        Vector3[] vertices = mesh.vertices;

        for (int index = 0; index < vertices.Length; index++)
        {
            // Minus y is to compensate unity internal importer, that already worked on that mesh
            vertices[index] = new Vector3(-vertices[index].x, vertices[index].z, vertices[index].y);
        }

        mesh.vertices = vertices;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }
}
