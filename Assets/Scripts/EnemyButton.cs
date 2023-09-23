using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyButton : MonoBehaviour
{
    [SerializeField] private float AnimationSpeed=1;
    [SerializeField] private float DamageDelay=0;
    [SerializeField] private BoxCollider2D damageCollider;
    private void Start()
    {
        DeactivateDamageZone();
        // playAnimation  for DamageDelay seconds with AnimationSpeed speed;
        //OnAnimationEnd():
        ActivateDamageZone();
        //Destroy(this);
    }
    public void ActivateDamageZone()
    {
        damageCollider.enabled = true;
    }

    // Функция для деактивации зоны поражения
    public void DeactivateDamageZone()
    {
        damageCollider.enabled = false;
    }
}
