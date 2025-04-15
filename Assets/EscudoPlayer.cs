using System.Collections;
using UnityEngine;

public class EscudoPlayer : MonoBehaviour
{
    public bool estaAtivo; //Define se o escudo está ativo
    public GameObject escudo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Definir o escudo como desativado ao iniciar o jogo
        DesativarEscudo();
    }

    private void DesativarEscudo()
    {
        estaAtivo = false;
        escudo.SetActive(false);
    }

    IEnumerator DesativarEscudoNoTempo()
    {
        //Esperar 5 segundos para poder desativar o escudo
        yield return new WaitForSeconds(5f);

        //Desativar o escudo
        DesativarEscudo();
    }

    public void AtivarEscudo()
    {
        //Definir que o escudo está ativo
        estaAtivo = true;

        //Habilitar o objeto do escudo
        escudo.SetActive(true);

        //Parar todas as coroutinas
        StopAllCoroutines();

        //Acionar a coroutina para poder desativar o escudo
        StartCoroutine(DesativarEscudoNoTempo());
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        //Verificar se o escudo está ativo para poder permitir as colisões
        if (estaAtivo == false) return;

        //Verificar se o escudo colidiu com algum inimigo
        if(colisao.gameObject.tag == "Inimigo")
        {
            //Obter o código de dano ao inimigo
            DanoAoInimigo danoInimigo = colisao.GetComponent<DanoAoInimigo>();

            //Destruir o inimigo
            danoInimigo.DestruirInimigo();
        }
        //Verificar se o escudo colidiu com o laser do inimigo
        else if(colisao.gameObject.tag == "LaserInimigo")
        {
            //Destruir o laser
            Destroy(colisao.gameObject);
        }
    }
}
