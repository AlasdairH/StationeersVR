using Assets.Scripts.Objects.Entities;
using HarmonyLib;
using StationeersVR.Utilities;
using JetBrains.Annotations;
using Assets.Scripts.Objects;
using UnityEngine;
using StationeersVR.VRCore;

namespace StationeersVR
{

    [HarmonyPatch(typeof(LanderCapsule))]
    public class CapsulePatches
    {
        // public override void OnInteractableStateChanged(Interactable interactable, int newState, int oldState)
        [HarmonyPatch("BeginDescent")]
        [UsedImplicitly]
        [HarmonyPrefix]
        private static void OnInteractableStateChanged_PrefixPatch(LanderCapsule __instance)
        {
            VRManager.TryRecenter();
        }
    }
}
