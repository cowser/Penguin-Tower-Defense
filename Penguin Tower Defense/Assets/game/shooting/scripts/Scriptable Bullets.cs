using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "Bullets") ]
public class ScriptableBullets : ScriptableObject
{
    public GameObject prefab; 
    public int speed;
    public int dmg;
    public int firerate;
    public int affect;
    public int meterRange;
}
