using UnityEngine;

public class GameController : MonoBehaviour
{
    float spawnTimer;
    float spawnRate = 3f;
    public GameObject tubo;
    public Rigidbody2D rb;
    public static bool gameover;
    public static bool win;
    AudioSource audioSource;

    void Start()
    {
        // Crea un componente per l'utilizzo di una traccia audio
        audioSource = GetComponent<AudioSource>();

        // Avvia la traccia audio per l'inizio
        audioSource.Play();

        gameover = false;
        win = false;

        if (Punti.primaEsecuzione)
        {
            tubo.SetActive(false); // Disabilita i tubi durante la prima esecuzione
        }
        else
        {
            tubo.SetActive(true); // Riattiva i tubi dopo il restart
        }
    }

    void Update()
    {
        if (rb.simulated && !gameover && !win && !Punti.primaEsecuzione)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnRate)
            {
                spawnTimer -= spawnRate;
                Vector2 spawnPosition = new Vector2(2f, Random.Range(-1f, 2f));
                Instantiate(tubo, spawnPosition, Quaternion.identity);
            }
        }
    }
}