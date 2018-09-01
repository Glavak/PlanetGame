using UnityEngine;
using UnityEngine.UI;

public class PlanetSkinSwitcher : MonoBehaviour
{
    public Mesh[] PlanetSkins;
    public MeshFilter Planet;

    public Button PrevButton;
    public Button NextButton;

    private void Start()
    {
        int skinIndex = GameData.Instance.PlanetSkin;

        UpdateSkinIndex(skinIndex);
    }

    private void UpdateSkinIndex(int skinIndex)
    {
        Planet.mesh = PlanetSkins[skinIndex];

        PrevButton.interactable = skinIndex > 0;
        NextButton.interactable = skinIndex < PlanetSkins.Length - 1;
    }

    public void Prev()
    {
        int skinIndex = GameData.Instance.PlanetSkin;
        skinIndex--;
        GameData.Instance.PlanetSkin = skinIndex;

        UpdateSkinIndex(skinIndex);
    }

    public void Next()
    {
        int skinIndex = GameData.Instance.PlanetSkin;
        skinIndex++;
        GameData.Instance.PlanetSkin = skinIndex;

        UpdateSkinIndex(skinIndex);
    }
}
