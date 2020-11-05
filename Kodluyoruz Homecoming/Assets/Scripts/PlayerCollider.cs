using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public Color color;
    public Color color1;
    public Color color2;
    [SerializeField] private Material[] materials;
    [SerializeField] private MeshRenderer player;
    [SerializeField] private GameObject deadPrefab;
    [SerializeField] private PlayerController playerController;
    private TrailRenderer trailRenderer;
    public GameObject particle1, particle2;

    Camera cam;
    private void Start()
    {
        trailRenderer = GameObject.Find("Player").GetComponent<TrailRenderer>();
        cam = Camera.main.GetComponent<Camera>();
        color = Color.blue;
        color1 = Color.green;
        color2 = Camera.main.backgroundColor;
        cam.backgroundColor = Color.black;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {

            particle1.SetActive(true);
            particle2.SetActive(true);
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            playerController.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Green")
        {
            player.material = materials[0];
            trailRenderer.material = materials[0];
            cam.backgroundColor = Color.Lerp(color2, color1, 1f);
           transform.gameObject.tag = "Green";
        }

        if (other.gameObject.tag == "Blue")
        {
            player.material = materials[1];
            trailRenderer.material = materials[1];
            cam.backgroundColor = Color.Lerp(color2, color, 1f);
            transform.gameObject.tag = "Blue";
        }

        if(other.gameObject.tag == "Halfway")
        {
            gameObject.GetComponent<Rigidbody>().AddForce(0f, 1000f, 0f);
        }
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Wall")
        {

            if (collision.gameObject.GetComponent<MeshRenderer>().material != player.material)
            {

                {

                    
                }

            }

            /*
            if (collision.gameObject.tag == "Green" && transform.gameObject.tag == "Green")
            {
                collision.transform.gameObject.SetActive(false);
                for (int i = 0; i < 5; i++)
                {
                    Instantiate(smashedWall, transform.position, Quaternion.identity);
                    smashedWall.GetComponent<MeshRenderer>().material = materials[0];
                }
            }

            else if (collision.gameObject.tag == "Blue" && transform.gameObject.tag == "Blue")
            {
                collision.transform.gameObject.SetActive(false);
                for (int i = 0; i < 5; i++)
                {
                    Instantiate(smashedWall, transform.position, Quaternion.identity);
                    smashedWall.GetComponent<MeshRenderer>().material = materials[1];
                }
            }

        }
*/
    }
/*
    public void CreateDead()
    {
        transform.gameObject.SetActive(false);

        for (int i = 0; i < 10; i++)
        {
            Instantiate(deadPrefab, transform.position, Quaternion.identity);
            deadPrefab.GetComponent<MeshRenderer>().material = player.material;
            deadPrefab.GetComponent<TrailRenderer>().material = player.material;
        }
    }*/



