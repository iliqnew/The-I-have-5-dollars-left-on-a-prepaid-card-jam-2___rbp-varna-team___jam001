using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        float position_x = transform.position.x;
        float position_y = transform.position.y;
        float position_z = transform.position.z;
        Instantiate(Player, new Vector3(position_x, position_y, position_z), Quaternion.identity);
        Player.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
