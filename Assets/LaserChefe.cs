using UnityEngine;

public class LaserChefe : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.tag == "Player")
        {
            //Exibir game over
            FindFirstObjectByType<CanvasGameMng>().ExibirTelaFimDeJogo();    
        }
    }
}
