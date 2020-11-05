using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    [SerializeField] private Material[] materials;
    [SerializeField] private GameObject smashedWall;
    [SerializeField] private GameObject deadPrefab;
   [SerializeField] private GameState gameState;
    MeshRenderer meshRenderer;
    Rigidbody rb;
    Vector3 force;
    float random_x;
    float random_y;
   
    private void Start()
    {
         meshRenderer = smashedWall.GetComponent<MeshRenderer>();
         rb = smashedWall.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Blue" && gameObject.name == "Blue")
        {
            transform.gameObject.SetActive(false);
            for (int i = 0; i < 5; i++)
            {
                random_x = Random.Range(-10f, 10f);
                random_y = Random.Range(15f, 20f);
                force = new Vector3(random_x, random_y, 0f);
                Instantiate(smashedWall, transform.position, Quaternion.identity);
                meshRenderer.material = materials[1];
                rb.AddForce(force);
            }
            gameState.ChangeScore(15);
        }

        else if (other.gameObject.tag == "Green" && gameObject.name == "Green")
        {
            transform.gameObject.SetActive(false);
            for (int i = 0; i < 5; i++)
            {
                random_x = Random.Range(-10f, 10f);
                random_y = Random.Range(15f, 20f);
                force = new Vector3(random_x, random_y, 0f);
                Instantiate(smashedWall, other.gameObject.transform.position, Quaternion.identity);
                meshRenderer.material = materials[0];
                rb.AddForce(force);
            }
            gameState.ChangeScore(15);
        }

        else if( other.gameObject.tag == "Green" && gameObject.name == "Blue")
        {

            other.gameObject.SetActive(false);

            for (int i = 0; i < 10; i++)
            {
                Instantiate(deadPrefab, other.gameObject.transform.position, Quaternion.identity);
                deadPrefab.GetComponent<MeshRenderer>().material = materials[0];
                deadPrefab.GetComponent<TrailRenderer>().material = materials[0];
            }
            gameState.enabled = false;
        }

        else if(other.gameObject.tag == "Blue" && gameObject.name == "Green")
        {
            other.gameObject.SetActive(false);

            for (int i = 0; i < 10; i++)
            {
                Instantiate(deadPrefab, other.gameObject.transform.position, Quaternion.identity);
                deadPrefab.GetComponent<MeshRenderer>().material = materials[1];
                deadPrefab.GetComponent<TrailRenderer>().material = materials[1];
            }
            gameState.enabled = false;
        }

    }
}
