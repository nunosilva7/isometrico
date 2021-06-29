using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agente : MonoBehaviour
{

    private Camera camara;
    private NavMeshAgent agente;

    // Start is called before the first frame update
    void Start()
    {
        camara = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray raio = camara.ScreenPointToRay(Input.mousePosition);
            RaycastHit alvo;
            
            if(Physics.Raycast(raio, out alvo))
            {
                agente.SetDestination(alvo.point);
            }
        }
    }
}
