using UnityEngine;

public class PowerUpEscudo : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;
    private bool coletou;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.tag == "Player" && coletou == false)
        {
            //Definir que coletou
            coletou = true;

            //Ativar o escudo
            colisao.GetComponentInChildren<EscudoPlayer>().AtivarEscudo();
            
            //Ocultar o sprite
            GetComponent<SpriteRenderer>().enabled = false;

            //Tocar o audio
            audioSource.PlayOneShot(audioClip);
        }
    }
}
