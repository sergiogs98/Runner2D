using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Atributos
    public float fuerzaSalto = 7f;
    public float playerSpeed = 7f;
    private Rigidbody2D myRigidBody2D;
    private Manager gameManager;
    private bool enSuelo;
    private AudioSource[] audioSources;
    private AudioSource coinSound, fallSound, deathSound;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<Manager>();
        enSuelo = true;
        audioSources = GetComponents<AudioSource>();
        coinSound = audioSources[0];
        fallSound = audioSources[1];
        deathSound = audioSources[2];
    }

    // Update is called once per frame
    void Update()
    {
        // Comprueba si ha pulsado el espacio
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            // Le aplicamos el valor de la fuerza en la componente vertical
            myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x, fuerzaSalto);
            enSuelo = false;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            // Le aplicamos el valor de la fuerza en la componente vertical
            myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x, -fuerzaSalto + 3);
        }

        // Modificamos la coordenada x para movimiento horizontal
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody2D.velocity = new Vector2(playerSpeed, myRigidBody2D.velocity.y);
        }
    }

    // Se llama cuando player colisiona con cualquier objeto con la propiedad collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Moneda"))
        {

            Debug.Log("Ganas 10 puntos");
            Destroy(collision.gameObject);
            gameManager.incrementaPuntos(10);
            coinSound.Play();

        }else if (collision.gameObject.CompareTag("ZonaMuerte"))
        {
            fallSound.Play();
            gameOver();
        }else if (collision.gameObject.CompareTag("enemy"))
        {
            deathSound.Play();
            gameOver();
        }
        
    }

    private void gameOver()
    {
        // Carga una nueva escena o reinicia - Pantalla principal del juego
        SceneManager.LoadScene("pantallaMuerte");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bloque1") || collision.gameObject.CompareTag("Bloque2") || collision.gameObject.CompareTag("Bloque3"))
        {
            enSuelo = true;
        }
    }
}
