using UnityEngine;


[CreateAssetMenu(fileName = "BuyManager", menuName = "game/BuyManager")]
public class BuyManager : ScriptableObject
{
    public int health;
    public string advantage;
    public string weakness;
    public int fearMultiply;

    public Sprite PlayerModel;
    public GameObject PlayerPrefab;
}
