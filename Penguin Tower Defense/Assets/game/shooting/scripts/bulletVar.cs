using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletVar : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed;
    public int dmg;
    [SerializeField][Range(0f, 5f)]
    public float timeBetweenShots;
    public int affect;
    [SerializeField]
    [Range(0f, 10f)]
    public float maxDistance;
}
