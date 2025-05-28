using System;
using UnityEngine;

public class ColetarPontos : MonoBehaviour
{
    public int pontuacao; //A pontuação que o jogador vai obter ao colidir com o objeto
    private Vector3 direcaoMovimento; //Direção para onde a estrela irá se mover
    private float velocidade; //velocidade que a estrela irá se mover

    public AudioClip AudioClip;
    private AudioSource audioSource;
    private bool coletou;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Definir a velocidade padrão
        velocidade = 1;

        //Definir a direção em X aleatóriamente
        float direcaoX = new System.Random().Next(-1, 2);

        //Definir a direção em Y aleatóriamente
        float direcaoY = new System.Random().Next(-1, 2);

        //Definir a direção de movimento
        direcaoMovimento = new Vector3(direcaoX, direcaoY, 0);

        audioSource = GetComponent<AudioSource>();

        //Definir que o objeto seja destruido depois de 3 segundos
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        //Mover o objeto para a direção apontada
        transform.position += direcaoMovimento * velocidade * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        //verificar se o layer colidiu com a estrela
        if (colisao.gameObject.tag == "Player" && coletou == false)
        {
            coletou = true;

            //Atribuir pontuação no jogo
            FindFirstObjectByType<CanvasGameMng>().IncrementarPontuacao(pontuacao);

            //tocar o audio
            audioSource.PlayOneShot(AudioClip);

            //Ocultar o sprite
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
