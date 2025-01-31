using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // ��������� ���������� ��� �������� ������ �� ������
    public Transform player;

    // ��������� ���������� ��� ��������� ��������� �����
    public float speed = 3f; // �������� ������������ �����
    public float activationRadius = 10f; // ������ ������������ �������� � ������
    public float attackRadius = 1.5f; // ������ �����
    public float attackCooldown = 2f; // �������� ����� �������
    public float attackDamage = 10f; // ����, ��������� ������

    // ��������� ���������� ��� �������� ������� ��������� �����
    private float lastAttackTime;

    // ��������� ���������� ��� �������� ������ �� ��������� PlayerHealth ������
    private PlayerHealth playerHealth;

    // ��������� ���������� ��� �������� ������ �� ��������� Animator
    private Animator animator;

    // ����� Start ���������� ����� ������ ������
    private void Start()
    {
        // ������� ������ ������ � ����� �� ���� "Player"
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            // �������� ��������� ������
            player = playerObject.transform;
            // �������� ��������� PlayerHealth ������
            playerHealth = playerObject.GetComponent<PlayerHealth>();
        }

        // �������� ��������� Animator
        animator = GetComponent<Animator>();
    }

    // ����� Update ���������� ������ ����
    void Update()
    {
        if (player != null)
        {
            // ���������� ���������� ����� ������ � �������
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // ���� ���������� ������ ������� ������������, �� ���� �������� ��������� � ������
            if (distanceToPlayer <= activationRadius)
            {
                // ���������� ����������� � ������
                Vector3 direction = (player.position - transform.position).normalized;

                // ������������ ����� � ������� ������
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);

                // ���������� ����� � ����������� ������
                if (distanceToPlayer > attackRadius)
                {
                    transform.position += direction * speed * Time.deltaTime;
                    // ������������� �������� ��������
                    animator.SetBool("isMoving", true);
                }
                // ���� ���� ��������� � ������� ����� � ������ ���������� ������� � ��������� �����
                else if (Time.time - lastAttackTime >= attackCooldown)
                {
                    // ��������� �����
                    Attack();
                    // ��������� ����� ��������� �����
                    lastAttackTime = Time.time;
                }
            }
            else
            {
                // ������������� �������� ��������
                animator.SetBool("isMoving", false);
            }
        }
    }

    // ����� ��� ���������� �����
    void Attack()
    {
        Debug.Log("���� ������� ������!");
        if (playerHealth != null)
        {
            // ������������� �������� �����
            animator.SetTrigger("attack");
            // ������� ���� ������
            playerHealth.TakeDamage(attackDamage);
        }
    }

    
}
