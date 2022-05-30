using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OWS.ObjectPooling;

public class shoot : MonoBehaviour
{    
    // skjuta prefabsen
    private Transform fp; 
    private Rigidbody2D pew;

    // punkt att skjutas ifr�n
    private Vector3 pos;
    private Vector3 angle;

    // variabler fr�n bullets
    private float b_speed;
    private float b_timeBetweenShoots;
    private float b_range;
    private float distance;
    private Vector2 startPosition;
    private Vector2 travelPosition;
    private bool shootingStopped = false;

    // time
    private float timeChange = 1;

    // pooling
    private static MyObjectPool<PoolObject> bulletPool;
    [SerializeField] private GameObject objPrefab;

    //privat lagring av bullets
    List<GameObject> bullets = new List<GameObject>();

    private void Awake()
    {
        bulletPool = new MyObjectPool<PoolObject>(objPrefab, 2);
    }
    void Start()
    {
        fp = transform.Find("firePoint");
        //h�mtar alla variabler fr�n bullet
        b_speed = objPrefab.GetComponent<bulletVar>().speed;
        b_timeBetweenShoots = objPrefab.GetComponent<bulletVar>().timeBetweenShots;
        b_range = objPrefab.GetComponent<bulletVar>().maxDistance;
       
        if (b_timeBetweenShoots < 1)
        {
            timeChange = 0.1f;
        }
    }
    private void Update()
    {
        //travelPosition = pew.transform.position;
        //Debug.Log("position: " + travelPosition);
        //calculateDistance();
        // F�r testing, kan ta bort detta sen n�r det fungerar
        if (Input.GetKeyDown("space"))
        {
            startShooting();
        }
        else if(Input.GetKeyDown("return"))
        {
            Debug.Log("you have stopped");
            stopShooting();
        }
    }
    private void DisableObject() {
        gameObject.SetActive(false);
    }
    public void startShooting() {
        shootingStopped = false;
        startPosition = fp.position;
        //shooting();
        StartCoroutine(Countdown());
    }
    private void calculateDistance() {

        if (Vector2.Distance(startPosition, travelPosition) > b_range) {
            DisableObject();
        }
    }
    public void stopShooting()
    {
        shootingStopped = true;
    }
    private IEnumerator Countdown()
    {
        // add arrays 
        float duration = b_timeBetweenShoots; 
        shooting();
        while (duration > 0f)
        {
            if (shootingStopped){
                yield break;
            }
            else {
                yield return new WaitForSeconds(timeChange);
            }

            duration -= timeChange;
        }
        StartCoroutine(Countdown());
    }

    public void shooting() {

        /* Detta borde fungera */
        spriteAnimation animation = gameObject.GetComponentInParent<spriteAnimation>();
        animation.enabled = true;
        // r�knar ur posiiton och rikting d�r projectilen ska skjutas 
        pos = fp.position;
        angle = fp.transform.eulerAngles;
        angle += new Vector3(0, 0, 90);
        // hämtar en kula från poolen
        GameObject poolClone = bulletPool.PullGameObject(pos, Quaternion.Euler(angle));
        pew = poolClone.GetComponent<Rigidbody2D>();
        pew.velocity = Vector3.zero;
        pew.velocity = transform.right * b_speed * 0.1f;

        bullets.Add(poolClone); // dont know what to do with this
        //pew.transform.rotation = Quaternion.Euler(angle);
        //pew.AddRelativeForce(new Vector2(b_speed,0), ForceMode2D.Force);
    }
    // special effect 

    // i enemie titta vad det �r f�r effect p� den kulan, om det �r samma effekt som fienden g�r detta
    // if(effekt == myEffekt){
    //  Do nothing 
    // or do all
    // }
}
