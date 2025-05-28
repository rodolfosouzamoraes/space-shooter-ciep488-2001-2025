using UnityEngine;

public class PowerUpPoderLaser : MonoBehaviour
{
    public Sprite[] pilulas;
    public SpriteRenderer spriteLaser;
    private bool coletou;
    private int nivel;
    private AudioSource audioSource;
    public AudioClip audioClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Definir o nível da pilula
        nivel = new System.Random().Next(1,pilulas.Length);

        //Atualizar o sprite da pilula
        spriteLaser.sprite = pilulas[nivel];

        //Configurar o audio
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.tag == "Player" && coletou == false)
        {
            coletou = true;

            //Definir o nivel do laser na nave
            colisao.gameObject.
                GetComponent<AtirarLaser>().
                HabilitarNivelLaser(nivel);

            //Ocultar a imagem
            spriteLaser.enabled = false;

            //Tocar o audio
            audioSource.PlayOneShot(audioClip);
        }
    }
}
