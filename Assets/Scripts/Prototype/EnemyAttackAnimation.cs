using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAnimation : MonoBehaviour
{
    public void EndAnimation()
    {
        HealthManager.RemoveHealth();
        Destroy(this.gameObject);
    }
}
