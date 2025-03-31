using UnityEngine;

public class DanoAoInimigo : MonoBehaviour
{
    private float vida = 100; //Vida total do inimigo
    public GameObject explosao; //GameObject da explosao 

    //Capta a colisao do objeto ao entrar no outro objeto
    private void OnTriggerEnter2D(Collider2D colisao)
    {
        //Verificar se foi o laser do player que colidiu
        if(colisao.gameObject.tag == "LaserPlayer")
        {
            //Decrementar a vida do inimigo
            vida -= 25;

            //Destruir o laser que colidiu com o inimigo
            Destroy(colisao.gameObject);

            //Verificar se acabou a vida do inimigo
            if(vida <= 0)
            {
                //Destruir o inimigo
                DestruirInimigo();
            }
        }
    }

    public void DestruirInimigo()
    {
        //Instanciar o gameObject da explosao
        GameObject novaExplosao = Instantiate(explosao);
        
        //Colocar o gameObject da explosao na mesma posição do inimigo
        novaExplosao.transform.position = transform.position;

        //Destruir o objeto
        Destroy(gameObject);
    }
}
