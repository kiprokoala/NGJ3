using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    private int score = 0;

    public static Points instance;

    public Text text;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    void Start()
    {
    }

    public void addPoint()
    {
        score += 1;
        text.text = score.ToString();
    }


}
