using UnityEngine;

public class PowerUpLaser : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colisao)
    {
        //Verificar se colidiu com o player
        if(colisao.gameObject.tag == "Player")
        {
            //Aumentar o nivel da nave
            colisao.gameObject.GetComponent<AtirarLaser>().AumentarNivel();

            //Destruir o power up
            Destroy(gameObject);
        }
    }
}
