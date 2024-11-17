using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum HaamunTila
{
    Idle,
    Liiku,
    Hyokkaa,
    Kuole
};

public class HaamunAI : MonoBehaviour
{
    [SerializeField]
    HaamunTila haamunTila = HaamunTila.Idle;

    NavMeshAgent haamunLiike;
    Animator haamunAnimaatio;
    GameObject kohde;

    float polunEtsintaTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        haamunLiike = GetComponent<NavMeshAgent>();
        haamunAnimaatio = GetComponent<Animator>();
        kohde = GameObject.Find("Einari");
        StartCoroutine("AlkuViive");

    }

    IEnumerator AlkuViive()
    {
        yield return new WaitForSeconds(2f);
        haamunLiike.SetDestination(kohde.transform.position);
        haamunTila = HaamunTila.Liiku;
    }

    // Update is called once per frame
    void Update()
    {
        float etaisyys = Vector3.Distance(transform.position, kohde.transform.position);

        switch (haamunTila)
        {
            case HaamunTila.Idle:
                {
                    haamunLiike.isStopped = true;
                    haamunAnimaatio.SetBool("HaamuHyokkaa", false);
                    if (etaisyys < 25f)
                    {
                        haamunTila = HaamunTila.Liiku;
                    }
                    break;
                }
            case HaamunTila.Liiku:
                {
                    haamunAnimaatio.SetFloat("HaamuNopeus", haamunLiike.velocity.magnitude);
                    haamunLiike.isStopped = false;
                    haamunAnimaatio.SetBool("HaamuHyokkaa", false);
                    polunEtsintaTimer += Time.deltaTime;
                    
                    if (polunEtsintaTimer > 1f)
                    {
                        haamunLiike.SetDestination(kohde.transform.position);
                        polunEtsintaTimer = 0f;
                    }
                    if (etaisyys < 5f)
                    {
                        haamunTila = HaamunTila.Hyokkaa;
                    }
                    if (etaisyys > 25f)
                    {
                        haamunTila = HaamunTila.Idle;
                    }
                    break;
                }
            case HaamunTila.Hyokkaa:
                {
                    haamunAnimaatio.SetFloat("HaamuNopeus", 0f);
                    haamunAnimaatio.SetBool("HaamuHyokkaa", true);
                    haamunLiike.isStopped = true;
                    transform.LookAt(kohde.transform.position);
                    if (etaisyys > 2f)
                    {
                        transform.position = transform.TransformPoint(Vector3.forward * 0.01f);
                    }
                    if (etaisyys > 7f)
                    {
                        haamunTila = HaamunTila.Liiku;
                        haamunLiike.SetDestination(kohde.transform.position);
                    }
                    break;
                }
            case HaamunTila.Kuole:
                {
                    break;
                }
            default:
                {
                    Debug.Log("Haamun tilaa ei ole määritelty " + haamunTila);
                    break;
                }
        }
    }
}
