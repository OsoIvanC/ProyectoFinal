using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DG.Tweening;

public class EnemyController : MonoBehaviour,IController
{
    [SerializeField] Stats myStats;
    public Stats EnemyStats { get { return myStats; } }

    Renderer myRenderer;

    [SerializeField]
    Color actualColor;


    [SerializeField]
    bool isStatic;
    //public bool IsStatic { get { return isStatic; } set { isStatic = value; } }

    [SerializeField]
    float pathTravelTime;

    [SerializeField]
    Transform[] wayPoints;

    [SerializeField]
    Transform targetToRotate;


    Vector3[] wp;

    public float timeToActivate;

    //public List<Transform> WayPoints { get { return wayPoints; }  }

    private void OnDisable()
    {
        //StartCoroutine(Enable()); 
    }
    
    IEnumerator Enable()
    {
        yield return new WaitForSecondsRealtime(timeToActivate);
        this.gameObject.SetActive(true);
    }

    private void Awake()
    {
        myRenderer = TryGetComponent<Renderer>(out Renderer r) ? r : null;

        if(myRenderer!= null)
            actualColor = myRenderer.material.color;
       
        myStats.Init();
        
        wp = new Vector3[wayPoints.Length];

        if(!isStatic)
        {
            for (int i = 0; i < wayPoints.Length; i++)
            {
                wp[i] = wayPoints[i].position;
            }
        }
    
    }

    private void OnEnable()
    {
        //TakeDamage();
    }

    private void Start()
    {
        Move();
    }
    private void Update()
    {
       
        Rotate();            
    }
    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void Gravity()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        if (isStatic)
            return;

        transform.DOPath(wp, pathTravelTime, PathType.CatmullRom, PathMode.Full3D, 30, Color.red).SetLoops(-1,LoopType.Yoyo);

    }

    public void Rotate()
    {
        if (targetToRotate == null)
            return;

        transform.LookAt(targetToRotate);

    }

    public void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float value = 0)
    {
        this.gameObject.SetActive(false);
        GameController.instance.ActivateEnemy(this.gameObject);

        //StartCoroutine(Disable());

        // this.gameObject.SetActive(false);
        //StartCoroutine(ColorChange());
    }


    IEnumerator Disable()
    {
        yield return new WaitForSeconds(1);
        
    }
    
    IEnumerator ColorChange()
    {
        myRenderer.material.color =  Color.red;
        yield return new WaitForSeconds(0.1f);
        myRenderer.material.color = actualColor;
        this.gameObject.SetActive(false);
    }


    
}


