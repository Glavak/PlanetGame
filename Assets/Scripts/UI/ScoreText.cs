using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private float time;
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update ()
    {
        time += Time.deltaTime;

        text.text = "" + (int)time;
    }
}
