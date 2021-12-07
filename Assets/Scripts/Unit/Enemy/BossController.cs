using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BossController : EnemyController
{
    [Header("BulletLine")]
    [SerializeField] float lineWidth;
    [SerializeField] Material material;
    [SerializeField] Color bulletColor1;
    [SerializeField] Color bulletColor2;
    [Header("<Phase 1>")]
    [SerializeField] Vector2 bulletOffSet;
    [SerializeField] float attackCul1;
    [Header("Fast Attack")]
    [SerializeField] float bulletSpread1;
    [SerializeField] float buletRange1;
    [SerializeField] int attackCount1;
    [SerializeField] float attackSpeed1;
    [Header("Slow Attack")]
    [SerializeField] float bulletSpread2;
    [SerializeField] float buletRange2;
    [SerializeField] int attackCount2;
    [SerializeField] float attackSpeed2;
    [Header("<Phase 2>")]
    [SerializeField] RuntimeAnimatorController phase2Controller;
    [SerializeField] float phase2AttackRange;
    [SerializeField] float attackCul2;
    [SerializeField] float attack2Delay;
    [SerializeField] Vector2 attackOffset;
    [SerializeField] Vector2 attackSize;
    [SerializeField] SpriteRenderer deadBody;
    List<LineRenderer> bulletLine;
    int bulletIndex = 0;

    int bulletLayerMask;

    int phaseIndex = 1;

    float attackcul1 = 0;
    float attackcul2  = 0;
    Coroutine phase1AttackRoutine;
    protected override void Awake() {
        base.Awake();

        int bulletLineCount = Mathf.Max(attackCount2, attackCount1);

        bulletLine = new List<LineRenderer>(bulletLineCount);
        for(int i = 0; i < bulletLineCount; i++) {
            GameObject lineObject = new GameObject("Line");
            lineObject.transform.parent = transform;
            LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();
            lineRenderer.startWidth = lineWidth;
            lineRenderer.endWidth = lineWidth;

            lineRenderer.material = material;
            bulletLine.Add(lineRenderer);
        }
        bulletLayerMask = (1 << LayerMask.NameToLayer("Player")) + (1 << LayerMask.NameToLayer("Platform"));
        hpValueChange += PhaseTwoCondition;
        StartCoroutine(C_PhaseTwoSensing());
    }
    protected override void Start() {
        base.Start();
        UnitManager.Instance.GetUnit("Player").TryGetComponent(out playerController);
    }
    protected override void Update() {
        base.Update();
        if(Mathf.Abs(rigidbody2d.velocity.x) >= 0.1f) {
            animator.SetBool("isMove", true);
        }
        else {
            animator.SetBool("isMove", false);
        }

        if (!IsActiveState(UnitAnimState.Cinematic)) {
            if (phaseIndex == 1) {
                if(attackcul1 <= 0 && Vector2.Distance(transform.position, playerController.transform.position) <= attackRange) {
                    int attackIndex = Random.Range(0, 2);
                    if (attackIndex == 0) {
                        SlowAttack();
                    }
                    else {
                        FastAttack();
                    }
                    attackcul1 = 100;
                }
                else {
                    attackcul1 -= Time.deltaTime;
                }
                Move("Boss_Phase1_Attack");
            }
            else if (phaseIndex == 2) {
                if(attackcul2 <= 0 && Vector2.Distance(transform.position, playerController.transform.position) <= phase2AttackRange) {
                    PhaseTwoAttack();
                    attackcul2 = 100;
                }
                else {
                    attackcul2 -= Time.deltaTime;
                }
                Move("Boss_Phase2_Attack");
            }
        }
    }
    void PhaseTwoAttack() {
        StartCoroutine(C_PhaseTwoAttack());
    }
    IEnumerator C_PhaseTwoAttack() {
        moveController.isMove = false;

        yield return new WaitForSeconds(attack2Delay);
        animator.SetTrigger("Attack");
        Vector2 point = spriteRenderer.flipX ? new Vector2(-attackOffset.x, attackOffset.y) : attackOffset;
        Collider2D player = Physics2D.OverlapBox((Vector2)transform.position + point, attackSize, 0, 1 << LayerMask.NameToLayer("Player"));
        UnitControllerBase unit;
        if (player && player.TryGetComponent(out unit)) {
            unit.Damaged(damage, this, WeaponType.NULL);
        }

        yield return new WaitForSeconds(1);
        moveController.isMove = true;
        attackcul2 = attackCul2;
    }
    void Move(string attackClipName) {
        AnimatorClipInfo[] info = animator.GetCurrentAnimatorClipInfo(0);
        if (info[0].clip != null) {
            if (!animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals(attackClipName)) {
                float axis = playerController.transform.position.x > transform.position.x ? 1 : -1;

                int flip = spriteRenderer.flipX ? 1 : 0;
                int dir = transform.position.x > playerController.transform.position.x ? 1 : 0;
                float dst = Vector2.Distance(transform.position, playerController.transform.position);
                if(flip != dir || dst > 0.2f)
                moveController.Move(axis);
            }
        }
    }
    void PhaseTwoCondition(int hp) {
        if (phaseIndex != 2) {
            if (hp <= (MaxHP * 0.4f)) {
                EventManager.Instance.TriggerEventMessage("Phase2Start");
                animator.speed = 1;
                phaseIndex = 2;
                if (phase1AttackRoutine != null)
                    StopCoroutine(phase1AttackRoutine);
            }
        }
    }
    void FastAttack() {
        StartCoroutine(C_AttackDelay(1));
        phase1AttackRoutine = StartCoroutine(C_ShotBulletAttack(attackCount1, bulletSpread1, buletRange1, attackSpeed1));
    }
    void SlowAttack() {
        StartCoroutine(C_AttackDelay(3));
        phase1AttackRoutine = StartCoroutine(C_ShotSlowBulletAttack(bulletSpread2, buletRange2, attackSpeed2));
    }
    IEnumerator C_ShotBulletAttack(int count, float spread, float range, float delay) {
        animator.Play("Boss_Phase1_Attack", 0, 0);
        animator.speed = 0;

        yield return new WaitForSeconds(1);
        animator.speed = 1;
        WaitForSeconds wait = new WaitForSeconds(delay);
        for(int i = 0; i < count; i++) {
            animator.Play("Boss_Phase1_Attack", 0, 0);
            ShotBullet(spread, range, bulletColor1);
            yield return wait;
        }
        attackcul1 = attackCul1;
    }
    IEnumerator C_ShotSlowBulletAttack(float spread, float range, float delay) {
        animator.Play("Boss_Phase1_Attack", 0, 0);
        animator.speed = 0;
        yield return new WaitForSeconds(delay);
        animator.speed = 1;
        ShotBullet(spread, range, bulletColor2);
        attackcul1 = attackCul1;
    }
    void ShotBullet(float spread, float range, Color color) {
        Vector2 offSet = spriteRenderer.flipX ? new Vector2(-bulletOffSet.x, bulletOffSet.y) : bulletOffSet;
        float angle = Random.Range(-spread, spread);
        float bulletdirAngle = spriteRenderer.flipX ? 180 : 0;
        bulletdirAngle += angle;
        bulletdirAngle *= Mathf.Deg2Rad;
        Vector2 bulletDir = new Vector2(Mathf.Cos(bulletdirAngle), Mathf.Sin(bulletdirAngle));
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + offSet, bulletDir * range, range, bulletLayerMask);
        if (hit) {
            Vector2 pos1 = (Vector2)transform.position + offSet;
            Vector2 pos2 = hit.point;
            BulletLineCreate(1, pos1, pos2, color);

            UnitControllerBase enemy;
            if (hit.transform.TryGetComponent(out enemy)) {
                enemy.Damaged(damage, this, WeaponType.NULL);
            }
        }
        else {
            Vector2 pos1 = (Vector2)transform.position + offSet;
            Vector2 pos2 = (Vector2)transform.position + offSet + bulletDir * 10;
            BulletLineCreate(1, pos1, pos2, color);
        }
    }

    void BulletLineCreate(int count, Vector2 pos1, Vector2 pos2, Color bulletColor) {
        for(int i = 0; i < count; i++) {
            bulletIndex++;
            if(bulletIndex >= bulletLine.Count) {
                bulletIndex = 0;
            }
            LineRenderer lineRenderer = bulletLine[bulletIndex];
            lineRenderer.SetPosition(0, pos1);
            lineRenderer.SetPosition(1, pos2);

            lineRenderer.DOKill();
            lineRenderer.startColor = bulletColor;
            lineRenderer.endColor = bulletColor;
            Color lineStartColor = bulletColor;
            Color lineEndColor = bulletColor;
            Color2 startColor = new Color2(lineStartColor, lineEndColor);
            Color2 endColor = new Color2(new Color(lineStartColor.r, lineStartColor.g, lineStartColor.b, 0), new Color(lineEndColor.r, lineEndColor.g, lineEndColor.b, 0));
            lineRenderer.DOColor(startColor, endColor, 0.1f);
        }
    }
    IEnumerator C_AttackDelay(float duration) {
        moveController.isMove = false;
        yield return new WaitForSeconds(duration);
        moveController.isMove = true;
    }
    IEnumerator C_PhaseTwoSensing() {
        while (true) {
            if (phaseIndex == 2 && !IsActiveState(UnitAnimState.Cinematic)) {
                animator.runtimeAnimatorController = phase2Controller;
                animator.speed = 1;
                break;
            }
            yield return null;
        }
    }

    protected override void die() {
        animator.SetBool("isDie", true);
        SetActiveState(UnitAnimState.Cinematic, true);
        moveController.isMove = false;
        deadBody.flipX = spriteRenderer.flipX;
        deadBody.transform.position = transform.position - Vector3.right * 0.085f;
        EventManager.Instance.TriggerEventMessage("BossDie");
    }
    protected override void OnDrawGizmos() {
        base.OnDrawGizmos();
        MyGizmos.DrawWireCicle((Vector2)transform.position + bulletOffSet, 0.02f, 30);
        Gizmos.DrawWireCube((Vector2)transform.position + attackOffset, attackSize);
        MyGizmos.DrawWireCicle(transform.position, phase2AttackRange, 30);
    }
}