using Assets.Scripts.Objects.Entities;
using HarmonyLib;
using StationeersVR.Utilities;
using JetBrains.Annotations;
using Assets.Scripts.Objects;
using UnityEngine;
using StationeersVR.VRCore;

namespace StationeersVR
{

    [HarmonyPatch(typeof(Entity))]
    public class EntityPatches
    {
        // public override void OnInteractableStateChanged(Interactable interactable, int newState, int oldState)
        [HarmonyPatch("MoveToWorld")]
        [UsedImplicitly]
        [HarmonyPostfix]
        private static void MoveToWorld_PostfixPatch(Entity __instance,
                                                    Vector3 worldPosition,
                                                    Quaternion worldRotation,
                                                    Vector3 velocity,
                                                    Vector3 angularVelocity,
                                                    float force = 0f)
        {
            VRPlayer.instance.transform.SetParent(__instance.CameraRig.transform);
            VRManager.TryRecenter();
            VRPlayer.headPositionInitialized = false;
        }
        // public override void OnInteractableStateChanged(Interactable interactable, int newState, int oldState)
        [HarmonyPatch("HasEnteredExitable")]
        [UsedImplicitly]
        [HarmonyPostfix]
        private static void HasEnteredExitable_PostfixPatch(Entity __instance,
                                                            IExitable exitable)
        {
            VRPlayer.instance.transform.SetParent(__instance.CameraRig.transform);
            VRManager.TryRecenter();
        }
    }
}
