using UnityEngine;

public class PowerUpPoderLaser : MonoBehaviour
{
    public Sprite[] pilulas;
    public SpriteRenderer spriteLaser;
    private int nivel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Definir o nível da pilula
        nivel = new System.Random().Next(1,pilulas.Length);

        //Atualizar o sprite da pilula
        spriteLaser.sprite = pilulas[nivel];
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.tag == "Player")
        {
            //Definir o nivel do laser na nave
            colisao.gameObject.
                GetComponent<AtirarLaser>().
                HabilitarNivelLaser(nivel);

            Destroy(gameObject);
        }
    }
}
