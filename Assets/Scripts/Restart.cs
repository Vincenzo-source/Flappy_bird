using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void ClickRestart()
    {
        // Termina la prima esecuzione
        Punti.ImpostaPrimaEsecuzione(false);

        // Resetta tutte le variabili statiche
        GameController.gameover = false;
        GameController.win = false;
        Punti.ValorePunti = 0; // Reset del punteggio

        // Ricarica la scena per ripristinare tutto
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}