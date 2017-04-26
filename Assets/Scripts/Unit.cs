using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    const string ANIMATOR_SPEED = "Speed",
        ANIMATOR_ALIVE = "Alive",
        ANIMATOR_ATTACK = "Attack";

    public static List<ISelectable> SelectableUnits { get { return selectableUnits; } }
    static List<ISelectable> selectableUnits = new List<ISelectable>();

    public float HealthPercent { get { return hp / hpMax; } }

    public Transform target;

    [SerializeField]
    float hp, hpMax = 100;
    [SerializeField]
    GameObject hpBarPrefab;

    protected HealthBar healthBar;

    NavMeshAgent nav;
    Animator animator;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        hp = hpMax;
        healthBar = Instantiate(hpBarPrefab, transform).GetComponent<HealthBar>();
    }

    private void Start()
    {
        if (this is ISelectable)
        {
            selectableUnits.Add(this as ISelectable);
            (this as ISelectable).SetSelected(false);
        }
    }

    private void OnDestroy()
    {
        if (this is ISelectable) selectableUnits.Remove(this as ISelectable);
    }

    void Update()
    {
        if (target)
        {
            nav.SetDestination(target.position);
        }
        Animate();
    }

    protected virtual void Animate()
    {
        var speedVector = nav.velocity;
        speedVector.y = 0;
        float speed = speedVector.magnitude;
        animator.SetFloat(ANIMATOR_SPEED, speed);
        animator.SetBool(ANIMATOR_ALIVE, hp > 0);
    }
}
