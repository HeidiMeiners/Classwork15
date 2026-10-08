using UnityEngine;

public class CombosCubo : MonoBehaviour
{
    private string secuenciaActual = "";
    private float tiempoEsperaCombo = 0f;
    private bool esperandoCombo3 = false;

    public Rigidbody rb;
    public AudioSource reproductor;

    [Header("Sonidos")]
    public AudioClip sonidoCombo1;
    public AudioClip sonidoCombo2;
    public AudioClip sonidoCombo3;

    [Header("Ajustes de Movimiento")]
    public float fuerzaSalto = 6f;
    public float fuerzaGiro = 10f;

    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        if (reproductor == null) reproductor = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            RegistrarTecla("UP");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            RegistrarTecla("DOWN");
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            RegistrarTecla("Q");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            RegistrarTecla("A");
        }

        if (esperandoCombo3)
        {
            tiempoEsperaCombo -= Time.deltaTime;
            if (tiempoEsperaCombo <= 0f)
            {
                EjecutarCombo3();
            }
        }
    }

    void RegistrarTecla(string tecla)
    {
        if (esperandoCombo3)
        {
            esperandoCombo3 = false;
        }

        secuenciaActual += tecla;
        ComprobarCombos();
    }

    void ComprobarCombos()
    {
        if (secuenciaActual == "UPUPDOWNDOWNQA")
        {
            reproductor.PlayOneShot(sonidoCombo1);
            rb.AddForce(new Vector3(2f, 1f, 0f) * fuerzaSalto, ForceMode.Impulse); 
            rb.AddTorque(new Vector3(0f, 0f, -1f) * fuerzaGiro, ForceMode.Impulse);

            secuenciaActual = "";
            esperandoCombo3 = false;
        } 
        else if (secuenciaActual == "UPUPUPDOWNQA")
        {
            reproductor.PlayOneShot(sonidoCombo2);
            rb.AddForce(Vector3.up * (fuerzaSalto * 1.8f), ForceMode.Impulse); 
            rb.AddTorque(Vector3.up * fuerzaGiro, ForceMode.Impulse);

            secuenciaActual = "";
            esperandoCombo3 = false;
        }
        else if (secuenciaActual == "UPUPUP")
        {
            esperandoCombo3 = true;
            tiempoEsperaCombo = 0.4f; 
        }
        else if (secuenciaActual.Length > 15)
        {
            secuenciaActual = "";
            esperandoCombo3 = false;
        }
    }

    void EjecutarCombo3()
    {
        esperandoCombo3 = false;

        if (secuenciaActual == "UPUPUP")
        {
            reproductor.PlayOneShot(sonidoCombo3);
            rb.AddForce(new Vector3(-2f, 1f, 0f) * fuerzaSalto, ForceMode.Impulse); 
            rb.AddTorque(new Vector3(0f, 0f, 1f) * fuerzaGiro, ForceMode.Impulse);

            secuenciaActual = "";
        }
    }
}