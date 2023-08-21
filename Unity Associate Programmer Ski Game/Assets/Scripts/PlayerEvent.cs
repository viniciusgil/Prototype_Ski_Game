using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent : MonoBehaviour
{
    public delegate void playerHitAction();
    public static event playerHitAction OnPlayerHit;

    public static void PlayerHit()
    {
        if (OnPlayerHit != null)
        {
            OnPlayerHit();
        }
    }
}
