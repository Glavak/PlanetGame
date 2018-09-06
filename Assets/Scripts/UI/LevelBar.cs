using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    public Text CurrentLevel;
    public Text NextLevel;

    public RectTransform ExpirienceImage;

    private int expToLevelUp;
    private float expirience;

    private void Start()
    {
        GameData.Instance.Expirience = 0;
        expToLevelUp = GameData.Instance.ExpirienceRequiredForLevelUp();

        UpdateLabels();
    }

    private void UpdateLabels()
    {
        CurrentLevel.text = GameData.Instance.Level.ToString();
        if (NextLevel != null) NextLevel.text = (GameData.Instance.Level + 1).ToString();
    }

    private void Update()
    {
        if (ExpirienceImage != null)
        {
            expirience = Mathf.MoveTowards(expirience, GameData.Instance.Expirience, Time.deltaTime*7);

            if (expirience > expToLevelUp)
            {
                GameData.Instance.Level++;
                UpdateLabels();

                GameData.Instance.Expirience = 0;
                expirience = 0;
                expToLevelUp = GameData.Instance.ExpirienceRequiredForLevelUp();
            }

            ExpirienceImage.sizeDelta = new Vector2(expirience / expToLevelUp * 370+30, ExpirienceImage.sizeDelta.y);
            ExpirienceImage.anchoredPosition = new Vector2(expirience / expToLevelUp * 370/2+15,0);
        }
    }
}
