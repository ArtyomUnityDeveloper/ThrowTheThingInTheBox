using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsThrower : MonoBehaviour
{
    public GameObject[] prefabsToThrow;
    public float throwingSpeed = 50.0f;
    public float DelayBetweenThrows = 2;
    [SerializeField] private float lastThrowDate;
    private GameManager gameManager;
    public AudioClip[] throwSounds;
    private AudioSource playerAudio;


    // Start is called before the first frame update
    void Start()
    {
        lastThrowDate = Time.time;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GameStatus())
        { 
                Vector3 lookDirection = transform.forward;

                if (Input.GetKey(KeyCode.Mouse0) && (Time.time - lastThrowDate > DelayBetweenThrows))
                {
                    int soundIndex = Random.Range(0, throwSounds.Length);
                    int throwablePrefabIndex = Random.Range(0, prefabsToThrow.Length);
                    playerAudio.PlayOneShot(throwSounds[soundIndex], 0.68f);
                    GameObject obj = Instantiate(prefabsToThrow[throwablePrefabIndex], transform.position, prefabsToThrow[throwablePrefabIndex].transform.rotation);
                    obj.GetComponent<Rigidbody>().AddForce(lookDirection * throwingSpeed, ForceMode.Impulse);
                    lastThrowDate = Time.time;
                }
        }
    }
}
