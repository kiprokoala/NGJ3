using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private Text txtScore;
    [SerializeField]
    private Text txtHighest;

    public static Menu instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void retryClick()
    {
        Time.timeScale = 1;
        charaMove.instance.enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitClick()
    {
        Application.Quit();
    }

    public void fillInfo()
    {
        txtScore.text += Points.instance.getScore().ToString();
        txtHighest.text += PlayerPrefs.GetInt("best");
    }
}
