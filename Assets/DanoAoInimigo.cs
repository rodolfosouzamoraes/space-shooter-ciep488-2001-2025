using UnityEngine;

public class DanoAoInimigo : MonoBehaviour
{
    public float vida = 100; //Vida total do inimigo
    public GameObject explosao; //GameObject da explosao 
    public GameObject objetoPontuacao; //GameObject da pontuação

    //Capta a colisao do objeto ao entrar no outro objeto
    private void OnTriggerEnter2D(Collider2D colisao)
    {
        //Verificar se foi o laser do player que colidiu
        if(colisao.gameObject.tag == "LaserPlayer")
        {
            //Obter o valor do dano a ser tirado do inimigo
            PoderLaser poderLaser = colisao.GetComponent<PoderLaser>();

            //Decrementar a vida do inimigo
            vida -= poderLaser.valorDanoAtual;

            //Destruir o laser que colidiu com o inimigo
            Destroy(colisao.gameObject);

            //Verificar se acabou a vida do inimigo
            if(vida <= 0)
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
        }

        //Destruir o objeto
        Destroy(gameObject);
    }
}
