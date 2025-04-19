using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Referencias
    private Transform player;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private float initialY; // Variable para guardar la posición Y inicial

    // Parámetros de comportamiento
    public float moveSpeed = 2f;
    public float attackRange = 1.5f;
    public float attackCooldown = 2f;
    private float lastAttackTime;
    //private bool //isAttacking = false;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        // Encontrar el jugador
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        // Obtener componentes
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        
        // Guardar la posición Y inicial
        initialY = transform.position.y;
        
        lastAttackTime = -attackCooldown; // Permite atacar inmediatamente
    }

    // Update is called once per frame
    void Update()
    {
        // No hacer nada si está muerto
        if (isDead) return;
        
        // No hacer nada si no se encuentra al jugador
        if (player == null) return;

        // Calcular distancia al jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Verificar si debe atacar
        if (distanceToPlayer <= attackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            StartCoroutine(Attack());
        }
        // Si no está atacando, moverse hacia el jugador
/*         else if (!isAttacking)
        {
            MoveTowardsPlayer();
        } */
    }

    void MoveTowardsPlayer()
    {
        // Obtener dirección hacia el jugador (solo en X)
        float directionX = Mathf.Sign(player.position.x - transform.position.x);
        
        // Voltear sprite
        spriteRenderer.flipX = (directionX < 0);
        
        // Mover en X
        rb.linearVelocity = new Vector2(directionX * moveSpeed, 0);
        
        // Restaurar posición Y inicial
        transform.position = new Vector3(transform.position.x, initialY, transform.position.z);
        
        // Asegurarse que la animación de caminar está activa
        //animator.SetBool("isAttacking", false);
    }

    IEnumerator Attack()
    {
        // Registrar tiempo de ataque
        lastAttackTime = Time.time;
        
        // Detener movimiento
        rb.linearVelocity = Vector2.zero;
        
        // Activar animación de ataque
        //animator.SetBool("isAttacking", true);
        
        // Esperar a que termine la animación (ajustar según duración)
        yield return new WaitForSeconds(0.5f); // Ajusta este tiempo según la duración de tu animación
        
        // Aquí iría el código para causar daño al jugador
        // Dejamos esto vacío por ahora
        
        // Terminar ataque
        //animator.SetBool("isAttacking", false);
    }

    // Método para recibir daño (lo dejamos preparado pero vacío como solicitaste)
    public void TakeDamage(int damage)
    {
        // Aquí iría la lógica de daño
        // Por ahora solo activamos la muerte para probar
        Die();
    }

    void Die()
    {
        // Marcar como muerto
        isDead = true;
        
        // Detener movimiento
        rb.linearVelocity = Vector2.zero;
        
        // Activar animación de muerte
        animator.SetBool("isDead", true);
        
        // Desactivar colisiones
        GetComponent<Collider2D>().enabled = false;
        
        // Autodestruir después de la animación
        Destroy(gameObject, 1f); // Ajusta este tiempo según la duración de tu animación de muerte
        
        // Generar nuevo enemigo (opcional)
        Invoke("SpawnNewEnemy", 2f);
    }

    void SpawnNewEnemy()
    {
        // Código para generar un nuevo enemigo
        // Puedes usar Instantiate para crear una nueva instancia del prefab
        Vector3 spawnPosition = new Vector3(
            Random.Range(-5f, 5f),  // Posición X aleatoria
            initialY,               // Misma altura Y que el enemigo original
            0f
        );
        
        Instantiate(gameObject, spawnPosition, Quaternion.identity);
    }
}