using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Публичная переменная для хранения ссылки на игрока
    public Transform player;

    // Публичные переменные для настройки поведения врага
    public float speed = 3f; // Скорость передвижения врага
    public float activationRadius = 10f; // Радиус срабатывания движения к игроку
    public float attackRadius = 1.5f; // Радиус атаки
    public float attackCooldown = 2f; // Задержка между атаками
    public float attackDamage = 10f; // Урон, наносимый врагом

    // Приватная переменная для хранения времени последней атаки
    private float lastAttackTime;

    // Приватная переменная для хранения ссылки на компонент PlayerHealth игрока
    private PlayerHealth playerHealth;

    // Приватная переменная для хранения ссылки на компонент Animator
    private Animator animator;

    // Метод Start вызывается перед первым кадром
    private void Start()
    {
        // Находим объект игрока в сцене по тегу "Player"
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            // Получаем трансформ игрока
            player = playerObject.transform;
            // Получаем компонент PlayerHealth игрока
            playerHealth = playerObject.GetComponent<PlayerHealth>();
        }

        // Получаем компонент Animator
        animator = GetComponent<Animator>();
    }

    // Метод Update вызывается каждый кадр
    void Update()
    {
        if (player != null)
        {
            // Вычисление расстояния между врагом и игроком
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Если расстояние меньше радиуса срабатывания, то враг начинает двигаться к игроку
            if (distanceToPlayer <= activationRadius)
            {
                // Определяем направление к игроку
                Vector3 direction = (player.position - transform.position).normalized;

                // Поворачиваем врага в сторону игрока
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);

                // Перемещаем врага в направлении игрока
                if (distanceToPlayer > attackRadius)
                {
                    transform.position += direction * speed * Time.deltaTime;
                    // Устанавливаем анимацию движения
                    animator.SetBool("isMoving", true);
                }
                // Если враг находится в радиусе атаки и прошло достаточно времени с последней атаки
                else if (Time.time - lastAttackTime >= attackCooldown)
                {
                    // Выполняем атаку
                    Attack();
                    // Обновляем время последней атаки
                    lastAttackTime = Time.time;
                }
            }
            else
            {
                // Останавливаем анимацию движения
                animator.SetBool("isMoving", false);
            }
        }
    }

    // Метод для выполнения атаки
    void Attack()
    {
        Debug.Log("Враг атакует игрока!");
        if (playerHealth != null)
        {
            // Устанавливаем анимацию атаки
            animator.SetTrigger("attack");
            // Наносим урон игроку
            playerHealth.TakeDamage(attackDamage);
        }
    }

    
}
