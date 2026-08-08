using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_manager : MonoBehaviour
{
    [SerializeField] TMP_Text enemycounttext;
    [SerializeField] GameObject Youwintext;

    int enemycount = 0;

    public void adjustenemy(int amount)
    {
        enemycount += amount;
        enemycounttext.text = "Enemies Left: " + enemycount.ToString();
        if (enemycount <= 0)
        {
            Time.timeScale = 0f;
            Youwintext.SetActive(true);
        }
    }       

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   public void quit()
    {
        Application.Quit();
    }
}
