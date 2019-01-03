using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerComponent : MonoBehaviour
{

    private static PlayerComponent _instance;

    public static PlayerComponent Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private int count;

    [SerializeField]
    private float speed;
    [SerializeField]
    private Text countText;
    [SerializeField]
    private Text winText;

    private Rigidbody rb;
    private GameObject pickUps;

    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody>();
        pickUps = GameObject.Find("Pick Ups");
        count = 0;
        winText.text = "";
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    public void IncreaseCount()
    {
        count++;
        SetCountText();
        if (pickUps.transform.childCount == 1)
        {
            winText.text = "You Won!";
        }
        Debug.Log(pickUps.transform.childCount);
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
