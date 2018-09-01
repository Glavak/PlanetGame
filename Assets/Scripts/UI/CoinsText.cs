using UnityEngine;
using UnityEngine.UI;

public class CoinsText : MonoBehaviour
{
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
        GameData.Instance.OnCoinsChanged += SetText;
        SetText(GameData.Instance.Coins);
    }

    private void OnDestroy()
    {
        GameData.Instance.OnCoinsChanged -= SetText;
    }

    private void SetText(int coins)
    {
        text.text = "" + coins;
    }
}
