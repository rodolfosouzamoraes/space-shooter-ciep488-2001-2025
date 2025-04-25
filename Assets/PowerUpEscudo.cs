using UnityEngine;

public class PowerUpEscudo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.tag == "Player")
        {
            //Ativar o escudo
            colisao.GetComponentInChildren<EscudoPlayer>().AtivarEscudo();
            
            //Destruir objeto
            Destroy(gameObject);    
        }
    }
}
