using UnityEngine;

public class PlanetSkinSelector : MonoBehaviour
{
    public Mesh[] PlanetSkins;

    private void Start ()
    {
        int skinIndex = GameData.Instance.PlanetSkin;
        GetComponent<MeshFilter>().mesh = PlanetSkins[skinIndex];
        Destroy(this);
    }
}
