using UnityEngine;

public class RolarFundo : MonoBehaviour
{
    private Material material;
    private float offsetY;//Manipular o offset y do material
    public float velocidade;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //Incrementar a variavel do offsetY
        offsetY += velocidade * Time.deltaTime;

        //Manipular o material como o novo offsetY
        material.SetTextureOffset("_MainTex", new Vector2(0,offsetY));
    }
}
