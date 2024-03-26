using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Villano : MonoBehaviour
{
    public Sprite[] mySprites;
    private int index = 0;
    private SpriteRenderer mySpriteRenderer;
    public Text textScore; // Objeto Text para mostrar la puntuación en la interfaz de usuario

    public float animationSpeed = 0.1f; // Velocidad de la animación, ajustable desde el editor

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRoutine());
    }

    IEnumerator WalkCoRoutine()
    {
        yield return new WaitForSeconds(animationSpeed); // Ajusta la velocidad de la animación
        mySpriteRenderer.sprite = mySprites[index];
        index = (index + 1) % mySprites.Length; // Simplifica la lógica del índice
        StartCoroutine(WalkCoRoutine());
    }

    // Detectar colisiones con el jugador
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Si el objeto con el que colisiona tiene la etiqueta "Player"
        {
            //ScoreManager.AddScore(10); // Aumentar la puntuación del jugador al recoger la moneda (por ejemplo, 10 puntos)
            Destroy(this.gameObject); // Destruir la moneda
        }
    }
}
