using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script structure was taken from "Sid Makes Games"
// https://drive.google.com/file/d/1MJSLczbbWJNuTifJ3a7StfDrwR_EzZs-/view

public class EnemyBehaviour : MonoBehaviour {

    #region Public Variables
    public Animator anim;
    public float attackDistance; //Minimum distance for attack
    public float moveSpeed;
    public float timer; //Timer for cooldown between attacks
    public Transform leftLimit;
    public Transform rightLimit;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange;  //Check if Player is in range
    public GameObject triggerArea;
    public GameObject hotZone;
    [HideInInspector] public bool hurt = false;
    [HideInInspector] public bool dying = false;
    [HideInInspector] public bool attackMode;
    #endregion

    #region Private Variables
    private float distance; //Store the distance b/w enemy and player
    private bool cooling; //Check if Enemy is cooling after attack
    private float intTimer;
    #endregion

    void Awake() {
        SelectTarget();
        intTimer = timer; //Store the inital value of timer
        anim = GetComponent<Animator>();
    }

    void Update() {
        if (!attackMode && !hurt && !dying) {
            Move();
        }

        if (!InsideOfLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
            SelectTarget();
        }

        if (inRange) {
            EnemyLogic();
        }
    }

    void EnemyLogic() {
        distance = Vector2.Distance(transform.position, target.position);

        if (distance > attackDistance) {
            StopAttack();
        } else if (attackDistance >= distance && cooling == false) {
            Attack();
        }

        if (cooling) {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }

    void Move() {
        anim.SetBool("Walk", true);

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack() {
        timer = intTimer; //Reset Timer when Player enter Attack Range
        attackMode = true; //To check if Enemy can still attack or not

        anim.SetBool("Walk", false);
        anim.SetBool("Attack", true);
    }

    void Cooldown() {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode) {
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack() {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }

    public void TriggerCooling() {
        cooling = true;
    }

    private bool InsideOfLimits() {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    public void SelectTarget() {
        float distanceToLeft = Vector3.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector3.Distance(transform.position, rightLimit.position);

        if (distanceToLeft > distanceToRight) {
            target = leftLimit;
        } else {
            target = rightLimit;
        }

        Flip();
    }

    public void Flip() {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)  {
            rotation.y = 180;
        } else {
            rotation.y = 0;
        }

        transform.eulerAngles = rotation;
    }
}
