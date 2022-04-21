using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    [Range(0, 20), SerializeField, Tooltip("Ajustar velocidad del coche")]
    private float speed = 5f;

    [Range(0, 90), Tooltip("Velocidad de giro")]
    public float turnSpeed = 45f;

    [SerializeField] private float horizontalInput, verticalInput;

    public Transform spawnPoint; //Add empty gameobject as spawnPoint

    public float minHeightForDeath;

    public float maxHeightForDeath;

    public GameObject player; //Add your player

    public TextMeshProUGUI countText;

    public GameObject winTextObject;

    private int count;
    
    public GameObject[] hearts;

    public int life;

    public GameObject loseTextObject;

    public GameObject restartButton;
    
    public TextMeshProUGUI fallText;

    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
        winTextObject.SetActive(false);
        
        LifeCountText();
        loseTextObject.SetActive(false);
        
        restartButton.SetActive(false);
    }

    void SetCountText()
    {
        countText.text = "Monedas: " + count.ToString() + "/10";
    }

    void LifeCountText()
    {
        if (life <= 0)
        {
            loseTextObject.SetActive(true);
            restartButton.SetActive(true);
            speed = 0;
            turnSpeed = 0;
        }
    }

    void FinishText()
    {
        winTextObject.SetActive(true);
        restartButton.SetActive(true);
        speed = 0;
        turnSpeed = 0;
    }
    
    void FallText()
    {
        fallText.text = "¡Hey! No te caigas";
        loseTextObject.SetActive(true);
        restartButton.SetActive(true);
        speed = 0;
        turnSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(speed * Time.deltaTime * Vector3.forward * verticalInput);

        transform.Rotate(turnSpeed * Time.deltaTime * Vector3.up * horizontalInput);

        if (player.transform.position.y > minHeightForDeath)
        {
            player.transform.position = spawnPoint.position;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (player.transform.position.y < maxHeightForDeath)
        {
            player.transform.position = spawnPoint.position;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        
        //If you press R
        if (Input.GetKeyDown("r"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        
        void OnRestartButtonClick()
        {

            Application.LoadLevel(Application.loadedLevel);
        }
    }

    private void LifeUpdate()
    
    {
        if (life < 1)
        {
            Destroy(hearts[0].gameObject);
        }
        else if (life < 2)
        {
            Destroy(hearts[1].gameObject);
        }
        else if (life < 3)
        {
            Destroy(hearts[2].gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
        if (other.gameObject.CompareTag("Damage"))
        {
            life = life - 1;
            
            LifeUpdate();
            LifeCountText();
        }
        if (other.gameObject.CompareTag("Win"))
        {
            other.gameObject.SetActive(false);
            FinishText();
        }
        if (other.gameObject.CompareTag("FallDamage"))
        {
            other.gameObject.SetActive(false);
            FallText();
        }
    }
    
    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("Prototype 1");
    }
}
