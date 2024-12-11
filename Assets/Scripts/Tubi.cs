using UnityEngine;

public class Tubi : MonoBehaviour
{
    bool giaContato = false; // Impedisce il conteggio ripetuto
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Muovi i tubi solo se il gioco è attivo
        if (!GameController.gameover && !GameController.win && !Punti.primaEsecuzione)
        {
            transform.position = new Vector2(transform.position.x - 2f * Time.deltaTime, transform.position.y);
        }

        // Distruggi i tubi fuori dalla scena
        if (transform.position.x < -6)
        {
            Destroy(gameObject);
        }

        // Conta i punti solo se il tubo non è già stato contato
        if (!giaContato && transform.position.x < -4.5)
        {
            // Incrementa i punti solo se il gioco è attivo
            if (!GameController.gameover && !GameController.win && !Punti.primaEsecuzione)
            {
                audioSource.Play();
                giaContato = true;
                Punti.ValorePunti += 1; // Incrementa il valore dei punti
            }
        }
    }
}