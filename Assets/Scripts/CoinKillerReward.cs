using UnityEngine;
using UnityEngine.UI;

public class CoinKillerReward : MonoBehaviour
{
    public RectTransform CoinRewardAnimation;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.enabled) return;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            KillInteractable killInteractable = collision.gameObject.GetComponent<KillInteractable>();
            if (killInteractable == null) return;

            if (killInteractable.CoinReward > 0)
            {
                GameData.Instance.Coins += killInteractable.CoinReward;
                SpawnLabel(collision.contacts[0].point, killInteractable.CoinReward);
                killInteractable.CoinReward = 0; // To avoid double rewarding
            }
        }
    }

    private void SpawnLabel(Vector3 worldPosition, int coinReward)
    {
        Canvas canvas = FindObjectOfType<Canvas>();

        RectTransform instance = Instantiate(CoinRewardAnimation, canvas.transform);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
        instance.position = screenPosition;

        instance.GetComponentInChildren<Text>().text = "+ " + coinReward;
    }
}
