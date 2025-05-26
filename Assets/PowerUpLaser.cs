using UnityEngine;

public class PowerUpLaser : MonoBehaviour
{
    public AudioClip clipPowerUp;
    private AudioSource audioPowerUp;
    private bool coletou = false;

    private void Start()
    {
        audioPowerUp = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D colisao)
    {
        //Verificar se colidiu com o player
        if(colisao.gameObject.tag == "Player" && coletou == false)
        {
            //Emitir o audio do power up
            audioPowerUp.PlayOneShot(clipPowerUp);

            //Aumentar o nivel da nave
            colisao.gameObject.GetComponent<AtirarLaser>().AumentarNivel();

            //Definir que coletou o item
            coletou = true;

            //Ocultar o sprite do power Up
            transform.GetComponent<SpriteRenderer>().enabled = false; 
        }
    }
}
