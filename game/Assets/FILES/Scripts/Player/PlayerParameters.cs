using System.Data.Common;
using System.Drawing;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class PlayerParameters : MonoBehaviour
{
    public BuyManager characterData;
    public int totalSouls;
    public float playerSize;
    public int playerHealth;
    public int playerFearMultiply;
    public string advantage;
    public string playerWeakness;

    void Start()
    {
        CharacterDataApply();
    }

    void Update()
    {
        
    }

    void CharacterDataApply()
    {
        playerFearMultiply = characterData.fearMultiply;
        playerHealth = characterData.health;
        advantage = characterData.advantage;
        playerWeakness = characterData.weakness;
    }
}
