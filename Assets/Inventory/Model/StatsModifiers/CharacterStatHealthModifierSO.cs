using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterStatHealthModifierSO : CharacterStatModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
        PlayerHealth health = character.GetComponent<PlayerHealth>();
        if (health != null)
            health.addHealth((int)val);
    }
}
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// [CreateAssetMenu]
// public class CharacterStatHealthModifierSO : MonoBehaviour
// {
//     public void AffectCharacter(float val)
//     {
//         GameObject player = GameObject.FindGameObjectWithTag("Player");
//         PlayerHealth health = player.GetComponent<PlayerHealth>();
//         if (health != null)
//             health.addHealth((int)val);
//     }
// }
