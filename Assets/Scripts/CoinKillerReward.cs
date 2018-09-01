using UnityEngine;

public class CoinKillerReward : MonoBehaviour
{
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
            }
        }
    }
}
