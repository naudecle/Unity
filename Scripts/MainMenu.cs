using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // il est responsablle de changement de scene ou de niveau dans unity

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        /*
         SceneManager.GetActiveScene().buildIndex nous permet d'avoir l'index du niveau actuel.
        l'index est fixe selon la maniere dont on a disponiser les scenes dans le build settings dans unity.
        donc si on augmente de 1 alors ca nous conduit au prochain scene ou niveau
         */

    }
    public void quitGame()
    {
        Application.Quit(); //Fermer le jeu
    }
}
