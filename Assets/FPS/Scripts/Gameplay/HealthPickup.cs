using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class HealthPickup : Pickup
    {
        [Header("Parameters")] [Tooltip("Amount of health to heal on pickup")]
        public float HealAmount;
      //  [Tooltip("Amount of time (in seconds) before pickups despawn")]
    //    public float despawnTimer;
        protected override void OnPicked(PlayerCharacterController player)
        {
            Health playerHealth = player.GetComponent<Health>();
            if (playerHealth && playerHealth.CanPickup())
            {
                Debug.Log("heal");
                playerHealth.Heal(HealAmount);
                PlayPickupFeedback();
                Destroy(gameObject);
            }
        }
        protected override void Start()
        {
            base.Start();
            Debug.Log("pickup start");
       //     StartCoroutine(base.Despawn(despawnTimer));
        }
    }
}