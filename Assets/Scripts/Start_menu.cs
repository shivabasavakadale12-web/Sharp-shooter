using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_menu : MonoBehaviour
{
  public void gamestart()
    {
        SceneManager.LoadScene(1);
    }
  public void quitgame()
    {
        Application.Quit();
    }
}
