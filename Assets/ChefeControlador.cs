using UnityEngine;

public class ChefeControlador : MonoBehaviour
{
    public float velocidade;
    public GameObject explosao;
    public GameObject[] lasers;
    public GameObject chefeMain;
    private bool chegouNaPosicaoInicial;
    private bool chegouNaEsquerdaOuDireita;
    private int totalMovimentos;
    private float anguloAlvo;
    private CanvasGameMng canvasGame;
    private Vector3 coordenadaEsquerda;
    private Vector3 coordenadaDireita;

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

        //Definir a coordenada esquerda e direita para onde o chefe deve ir
        coordenadaEsquerda = new Vector3(-9.5f, 0, 0);
        coordenadaDireita = new Vector3(9.5f, 0, 0);

        //Desativar todos os lasers
        DesativarLasers();
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
        else if(totalMovimentos != 3)
        {
            //Ativar os lasers
            AtivarLasers();
            //Movimentar horizontalmente
            MovimentarHorizontalmente();
        }
        else
        {
            //Desativar os lasers
            DesativarLasers();
            //Rotacionar o chefe
            Rotacionar();
        }
    }

    private void MovimentarParaPosicaoInicial()
    {
        //movimentar o objeto para a posição inicial
        chefeMain.transform.position = Vector3.MoveTowards(
            chefeMain.transform.position,
            Vector3.zero,
            velocidade * Time.deltaTime
            );

        //Verificar se o objeto chegou ao seu destino
        if (Vector3.Distance(chefeMain.transform.position, Vector3.zero) < 0.001f)
        {
            //Definir que chegou na posição
            chegouNaPosicaoInicial = true;
        }
    }

    private void MovimentarEsquerdaOuDireita(Vector3 coordenadaAlvo)
    {
        //Movimentar para coordenada alvo
        chefeMain.transform.position = Vector3.MoveTowards(
            chefeMain.transform.position,
            coordenadaAlvo,
            velocidade * Time.deltaTime
        );

        //Verificar se chegou no alvo
        if (Vector3.Distance(chefeMain.transform.position, coordenadaAlvo) < 0.001f)
        {
            //Definir que chegou no alvo
            chegouNaEsquerdaOuDireita = !chegouNaEsquerdaOuDireita;

            //Incrementar no total de movimentacoes
            totalMovimentos++;
        }
    }

    private void MovimentarHorizontalmente()
    {
        //Verificar se chegou na extremidade da esquerda
        if(chegouNaEsquerdaOuDireita == false)
        {
            MovimentarEsquerdaOuDireita(coordenadaEsquerda);
        }
        else
        {
            MovimentarEsquerdaOuDireita(coordenadaDireita);
        }
    }

    private void Rotacionar()
    {
        //Definir a rotação alvo do objeto
        var rotacaoAlvo = Quaternion.Euler(new Vector3(0, 0, anguloAlvo));

        //Rotacionar o objeto
        chefeMain.transform.rotation = Quaternion.RotateTowards(
            chefeMain.transform.rotation,
            rotacaoAlvo,
            velocidade * Time.deltaTime * 50
        );

        //Verificar se chegou na rotação alvo
        if (chefeMain.transform.rotation == rotacaoAlvo) 
        {
            //Alterar o angulo alvo
            anguloAlvo = anguloAlvo == 90 ? 0 : 90;

            //Zerar o total de movimentações
            totalMovimentos = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        //Verificar qual tag do objeto que colidiu
        switch (colisao.gameObject.tag) {
            case "LaserPlayer":
                //Obter o script do laser com a info do dano
                PoderLaser laserPlayer = colisao.GetComponent<PoderLaser>();

                //Decrementar a vida do chefe
                canvasGame.painelVidaChefe.DecrementarVidaChefe(laserPlayer.valorDanoAtual);

                //Destruir o laser
                Destroy(colisao.gameObject);
                break;
            case "Player":
                canvasGame.ExibirTelaFimDeJogo();
                break;
        }
    }

    private void DesativarLasers()
    {
        //Percorrer o vetor de lasers para poder desativar eles
        foreach (var laser in lasers)
        {
            //Desativo o laser
            laser.SetActive(false);
        }
    }

    private void AtivarLasers()
    {
        //Percorrer o vetor de lasers para poder desativar eles
        foreach (var laser in lasers)
        {
            //Desativo o laser
            laser.SetActive(true);
        }
    }

    public void DestruirChefe()
    {
        canvasGame.IncrementarPontuacao(500000);
        GameObject novaExplosao = Instantiate(explosao);
        novaExplosao.transform.localScale = new Vector3(20,20,20); 
        novaExplosao.transform.position = transform.position;
        Destroy(chefeMain);
    }
}
