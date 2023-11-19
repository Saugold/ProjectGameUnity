using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Fogo : MonoBehaviour
{
    public Light2D luz;
    public float intensidadeBase = 2.78f;
    public float velocidadeOscilacao = 2.0f;
    public float amplitudeOscilacao = 1.5f;
    public Rigidbody2D playerBody;
    public LifeSystem Life;

    void Start()
    {
        // Certifique-se de ter uma referência à luz
        if (luz == null)
        {
            luz = GetComponent<Light2D>();
        }
    }

    void Update()
    {
        // Calcule uma oscilação ao longo do tempo
        float oscilacao = Mathf.Sin(Time.time * velocidadeOscilacao) * amplitudeOscilacao;

        // Ajuste a intensidade da luz com base na oscilação
        luz.intensity = intensidadeBase + oscilacao;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FireHit();
        }
    }
    public void FireHit()
    {
        playerBody.velocity += new Vector2(0f, 10f);
        Life.life--;
        GameController.instance.TomarDano();
    }
}
