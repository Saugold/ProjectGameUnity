using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class Agarrar : MonoBehaviour
{
    [SerializeField] private Light2D luz;
    [SerializeField] private float intensidadeInicial = 1.0f;
    [SerializeField] private float intensidadeAoAproximar = 5.0f;
    [SerializeField] private float distanciaParaBrilhar = 5.0f;
    [SerializeField] Collider2D agarrarCol;
    [SerializeField] GameObject agarrar2;
    // Start is called before the first frame update
    void Start()
    {
        GraphicsSettings.renderPipelineAsset = GraphicsSettings.renderPipelineAsset as UniversalRenderPipelineAsset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerGrappling.playerGrap.onArea = true;
            agarrar2.SetActive(true);

            
            luz.intensity = 1.38f;
            luz.shapeLightFalloffSize = 11.01f;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            agarrar2.SetActive(false);
            luz.intensity = 1.2f;
            luz.shapeLightFalloffSize = 5.01f;
        }
    }

}
