using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void Escenas(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void Salir()
    {
        Application.Quit();
    }   
}
