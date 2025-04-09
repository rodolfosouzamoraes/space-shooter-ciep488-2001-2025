using UnityEngine;

public class DanoPlayer : MonoBehaviour
{
    public GameObject explosao;

    public void DestruirPlayer()
    {
        //Instanciar a explosao
        GameObject novaExplosao = Instantiate(explosao);

        //Posicionar a explosao no local onde está o player
        novaExplosao.transform.position = transform.position;

        //Destruir o Player
        Destroy(gameObject);
    }
}
