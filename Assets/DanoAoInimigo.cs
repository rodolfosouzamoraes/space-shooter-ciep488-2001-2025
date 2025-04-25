using UnityEngine;

public class DanoAoInimigo : MonoBehaviour
{
    public float[] vidasInimigo; //Vida total do inimigo
    public Sprite[] corposInimigo;//As imagens do inimigo referente a seu nivel
    public SpriteRenderer renderInimigo;//Script para manipular o render da imagem
    public GameObject explosao; //GameObject da explosao 
    public GameObject objetoPontuacao; //GameObject da pontuação
    private float vidaAtual;//Vida correspondente ao nivel do jogo
    private int nivelInimigo; //Nivel do inimigo correspondente ao nivel do jogo

    public void DefinirNivelInimigo(int nivel)
    {
        //Definir a vida com relação ao nivel informado
        vidaAtual = vidasInimigo[nivel];

        //Definir o sprite do inimigo com relação ao nivel informado
        renderInimigo.sprite = corposInimigo[nivel];

        //Definir o nivel do inimigo
        nivelInimigo = nivel;
    }

    //Capta a colisao do objeto ao entrar no outro objeto
    private void OnTriggerEnter2D(Collider2D colisao)
    {
        //Verificar se foi o laser do player que colidiu
        if(colisao.gameObject.tag == "LaserPlayer")
        {
            //Obter o valor do dano a ser tirado do inimigo
            PoderLaser poderLaser = colisao.GetComponent<PoderLaser>();

            //Decrementar a vida do inimigo
            vidaAtual -= poderLaser.valorDanoAtual;

            //Destruir o laser que colidiu com o inimigo
            Destroy(colisao.gameObject);

            //Verificar se acabou a vida do inimigo
            if(vidaAtual <= 0)
            {
                //Destruir o inimigo
                DestruirInimigo();
            }
        }
        else if(colisao.gameObject.tag == "Player")
        {
            //Decrementar a vida do jogador
            FindFirstObjectByType<CanvasGameMng>().DecrementarVidaJogador();

            //Destruir o inimigo
            DestruirInimigo();
        }
    }

    public void DestruirInimigo()
    {
        //Instanciar o gameObject da explosao
        GameObject novaExplosao = Instantiate(explosao);
        
        //Colocar o gameObject da explosao na mesma posição do inimigo
        novaExplosao.transform.position = transform.position;

        //Instanciar 3 estrelas de pontuação
        for(int i = 0; i < 3; i++)
        {
            //Instanciar o objeto
            GameObject novaPontuacao = Instantiate(objetoPontuacao);

            //Posicionar a pontuacao na mesma posicao no inimigo
            novaPontuacao.transform.position = transform.position;

            //Definir pontuação a ser gerada pelo inimigo
            novaPontuacao.GetComponent<ColetarPontos>().pontuacao = (int)vidasInimigo[nivelInimigo];
        }

        //Destruir o objeto
        Destroy(gameObject);
    }
}
