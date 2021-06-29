using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorControlador : MonoBehaviour
{

    [SerializeField]
    float velocidade = 4f;
    Vector3 frontal, lateral;
    Vector3 jogadorPosicaoOriginal;
    Quaternion jogadorOrientacaoOriginal;

    [SerializeField]
    GameObject porta;

    // Start is called before the first frame update
    void Start()
    {
        jogadorPosicaoOriginal = transform.position;
        jogadorOrientacaoOriginal = transform.rotation;
        frontal = transform.forward;
        lateral = Quaternion.Euler(new Vector3(0, 90, 0)) * frontal;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 horizontal = lateral * velocidade * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 vertical = frontal * velocidade * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 movimento = horizontal + vertical;
        transform.position += movimento;
        transform.LookAt(transform.position + movimento);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            transform.position = jogadorPosicaoOriginal;
            transform.rotation = jogadorOrientacaoOriginal;

            porta.SetActive(true);
        }
        else if (other.CompareTag("Colectavel"))
        {
            Destroy(other.gameObject);
            porta.SetActive(false);
        }
    }
}
