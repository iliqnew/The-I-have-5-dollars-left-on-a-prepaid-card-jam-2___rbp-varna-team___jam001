using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEffect : MonoBehaviour
{
    public int RandomNumber = 0;
    
    public PlayerController player;
    public Transform mainCamera;
    public Damage enemy;
    public TrowRock rock;
    public AcidBall ball;
    public GameObject indexes;
    
    int modifierAmount = 1;

    //void Awake() {
    //    DontDestroyOnLoad(RandomNumber);
    //}
    void Start()
    {
        indexes = GameObject.FindGameObjectsWithTag("DoNotDestroy")[0];
        modifierAmount = indexes.GetComponent<save_index>().modifierCount;
        if(modifierAmount > 0)
        {
            for (int i = 0; i < modifierAmount; i++)
            {
                RandomNumber = indexes.GetComponent<save_index>().modifier_indexes[i];
                if (RandomNumber == 0)
                {
                    player.health += 1;
                }
                if (RandomNumber == 1)
                {
                    mainCamera.transform.eulerAngles = mainCamera.transform.eulerAngles + new Vector3(0, 0, 180);
                }
                if (RandomNumber == 2)
                {
                    player.maxSpeed *= 1.5f;
                    player.horizontalSpeed *= 1.5f;
                }
                if (RandomNumber == 3)
                {
                    enemy.damageTake ++;
                }
                if (RandomNumber == 4)
                {
                    player.enemyDamage ++ ;
                }
                if (RandomNumber == 5)
                {
                    enemy.healthMultiplier *= 2;
                }
                if (RandomNumber == 6)
                {
                    player.skillRockTimer = 0.1f;
                    player.skillAcidBallTimer = 0.3f;
                    player.skillWindTimer = 0.1f;
                    player.skillForceFieldTimer = 1f;
                }
                if (RandomNumber == 7)
                {
                    player.allAttack = true;
                }
                if (RandomNumber == 8)
                {
                    player.doubleAttack = true;
                }
                if (RandomNumber == 9)
                {
                    enemy.SpeedModifier *= 1.5f;
                }
                if (RandomNumber == 10)
                {
                    rock.particleSpeed = 3.0f;
                    ball.particleSpeed = 3.0f;
                }
                if (RandomNumber == 11)
                {
                    
                }
            }
        }
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
