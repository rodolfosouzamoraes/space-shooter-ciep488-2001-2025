using UnityEngine;

public class LaserInimigo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colisao)
    {
        //Verificar se colidiu com o player
        if(colisao.gameObject.tag == "Player")
        {
            //Decrementar uma vida do player
            FindFirstObjectByType<CanvasGameMng>().DecrementarVidaJogador();

            //Destruir o laser
            Destroy(gameObject);
        }
    }
}
