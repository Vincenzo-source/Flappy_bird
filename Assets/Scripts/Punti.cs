using UnityEngine;
using UnityEngine.UI;

public class Punti : MonoBehaviour
{
    public static int ValorePunti;  // Punteggio totale
    public Text punteggioText;       // Riferimento al componente Text della UI per il punteggio
    public static bool primaEsecuzione = true; // Variabile per la prima esecuzione
    public GameObject scrittaFlappyBird;  // Scritta iniziale
    public GameObject restartButton;     // Pulsante Restart

    void Start()
    {
        ValorePunti = 0;  // Inizializza il punteggio
        UpdatePunteggioUI();  // Aggiorna la UI
        scrittaFlappyBird.SetActive(primaEsecuzione);  // Mostra la scritta FlappyBird
        restartButton.SetActive(primaEsecuzione);    // Mostra il pulsante restart
    }

    void Update()
    {
        // Se il punteggio è cambiato, aggiorna la UI
        if (ValorePunti != int.Parse(punteggioText.text))
        {
            UpdatePunteggioUI();
        }
    }

    public static void ImpostaPrimaEsecuzione(bool valore)
    {
        primaEsecuzione = valore;
    }

    // Metodo per aggiornare il punteggio sulla UI
    void UpdatePunteggioUI()
    {
        punteggioText.text = ValorePunti.ToString();
    }
}