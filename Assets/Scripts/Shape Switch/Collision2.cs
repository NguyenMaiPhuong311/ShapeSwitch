using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Collision2 : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePS;
    MeshFilter playerMeshfilter;
    public static int count = 0;

    [SerializeField] private GameObject Endgame;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CubeObst Instance") || other.CompareTag("PrismObst Instance") || other.CompareTag("SphereObst Instance"))
        {
            if (other.CompareTag(playerMeshfilter.mesh.name))
            {
                GameObject ps = Instantiate(obstaclePS, transform.position, Quaternion.identity);
                ps.GetComponent<ParticleSystemRenderer>().mesh = other.GetComponent<MeshFilter>().mesh;
                Destroy(ps, 3f);
                Destroy(other.gameObject);
                count++;

                FindObjectOfType<ObstacleSpawner>().enabled = true;
            }
            else
            {
                FindObjectOfType<ObstacleSpawner>().enabled = false;
                Endgame.SetActive(true);
            }
        }
    }
    private void Start()
    {
        playerMeshfilter = GetComponent<MeshFilter>();
    }



}