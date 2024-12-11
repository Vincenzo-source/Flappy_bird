using UnityEngine;

public class Flappy : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject gameover;
    public GameObject win;
    public GameObject restart;
    public AudioClip[] audioClips;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        if (Punti.primaEsecuzione)
        {
            rb.linearVelocity = Vector2.zero; // Nessun salto iniziale
            rb.simulated = false;            // Disbilita la fisica per cadere
        }
    }

    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.anyKeyDown) &&
            !GameController.gameover &&
            !GameController.win &&
            !Punti.primaEsecuzione)
        {
            if (!rb.simulated)
                rb.simulated = true; // Abilita la fisica per cadere se è disattivata
            audioSource.PlayOneShot(audioClips[0]);
            rb.linearVelocity = new Vector2(0f, 7f); // Salto
        }

        // Controlla la modalità win
        if (Punti.ValorePunti == 999 && !GameController.win)
        {
            GameController.win = true;
            win.SetActive(true);
            restart.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameController.win || Punti.primaEsecuzione) return;

        if (collision.gameObject.CompareTag("UpperBarrier")) return;

        // Modalità Game Over
        audioSource.PlayOneShot(audioClips[1]);
        GameController.gameover = true;
        gameover.SetActive(true);
        restart.SetActive(true);
    }
}