using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    public Text CurrentLevel;
    public Text NextLevel;

    public Image ExpirienceImage;

    private void Start()
    {
        CurrentLevel.text = GameData.Instance.Level.ToString();
        if (NextLevel != null) NextLevel.text = (GameData.Instance.Level + 1).ToString();
    }

    private void Update()
    {
        if (ExpirienceImage != null)
        {
            ExpirienceImage.fillAmount = GameData.Instance.Expirience / GameData.Instance.ExpirienceRequiredForLevelUp();
        }
    }
}
