using UnityEngine;

public class ChefeControlador : MonoBehaviour
{
    public float velocidade;
    public GameObject explosao;
    private bool chegouNaPosicaoInicial;
    private bool chegouNaEsquerdaOuDireita;
    private int totalMovimentos;
    private float anguloAlvo;
    private CanvasGameMng canvasGame;

    private void Start()
    {
        //Referenciar a variavel canvasGame
        canvasGame = FindFirstObjectByType<CanvasGameMng>();

        //resetar o total de movimentos
        totalMovimentos = 0;

        //Definir o angulo alvo
        anguloAlvo = 90;

        //Exibir o painel do chefe
        canvasGame.ExibirVidaChefe(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar se o chefe chegou na posição inicial
        if(chegouNaPosicaoInicial == false)
        {
            //Movimentar o chefe até a posição inicial
            MovimentarParaPosicaoInicial();
        }
    }

    private void MovimentarParaPosicaoInicial()
    {
        //movimentar o objeto para a posição inicial
        transform.position = Vector3.MoveTowards(
            transform.position,
            Vector3.zero,
            velocidade * Time.deltaTime
            );

        //Verificar se o objeto chegou ao seu destino
        if (Vector3.Distance(transform.position, Vector3.zero) < 0.001f)
        {
            //Definir que chegou na posição
            chegouNaPosicaoInicial = true;
        }
    }
}
