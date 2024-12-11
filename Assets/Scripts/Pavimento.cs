using UnityEngine;

public class Pavimento : MonoBehaviour
{
    Vector2 posIniziale;

    void Start()
    {
        posIniziale = transform.position;
    }

    void Update()
    {
        // Muovi il pavimento solo se il gioco non è in modalità win o gameover
        if (!GameController.gameover && !GameController.win)
        {
            if (transform.position.x >= -0.76f)
                transform.position = new Vector2(transform.position.x - 2f * Time.deltaTime, transform.position.y);
            else
                transform.position = posIniziale;
        }
    }
}