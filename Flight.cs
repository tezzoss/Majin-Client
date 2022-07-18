﻿using UnityEngine;
using Majin.Config;

namespace Majin.Movement
{
    class Flight
    {
        internal class Fly
        {
            internal static bool _FlyToggle = false;
            internal static float _FlySpeed { get; set; }

            internal static void fly()
            {
                try { if (VRC.Player.prop_Player_0.transform == null) return; } catch { return; }
                try
                {
                    if (Settings.Hooks.cameraeye == null) return;

                    _FlySpeed = Input.GetKey(KeyCode.LeftShift) ? Time.deltaTime * (Settings.ConfigVars.Flyspeed * 50) : Time.deltaTime * (Settings.ConfigVars.Flyspeed * 25);
                    if (VRC.Player.prop_Player_0.field_Private_VRCPlayerApi_0.IsUserInVR())
                    {
                        if (Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") < 0f)
                            VRC.Player.prop_Player_0.transform.position -= VRC.Player.prop_Player_0.transform.up * _FlySpeed;
                        if (Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") > 0f)
                            VRC.Player.prop_Player_0.transform.position += VRC.Player.prop_Player_0.transform.up * _FlySpeed;

                        if (Input.GetAxis("Vertical") != 0f)
                            VRC.Player.prop_Player_0.transform.position += Settings.Hooks.cameraeye.transform.forward * (_FlySpeed * Input.GetAxis("Vertical"));

                        if (Input.GetAxis("Horizontal") != 0f)
                            VRC.Player.prop_Player_0.transform.position += Settings.Hooks.cameraeye.transform.transform.right * (_FlySpeed * Input.GetAxis("Horizontal"));

                        return;
                    }
                    if (Input.GetKey(KeyCode.W))
                        VRC.Player.prop_Player_0.transform.position += Settings.Hooks.cameraeye.transform.forward * _FlySpeed;

                    if (Input.GetKey(KeyCode.S))
                        VRC.Player.prop_Player_0.transform.position -= Settings.Hooks.cameraeye.transform.forward * _FlySpeed;

                    if (Input.GetKey(KeyCode.A))
                        VRC.Player.prop_Player_0.transform.position -= Settings.Hooks.cameraeye.transform.right * (_FlySpeed / 2);

                    if (Input.GetKey(KeyCode.D))
                        VRC.Player.prop_Player_0.transform.position += Settings.Hooks.cameraeye.transform.right * (_FlySpeed / 2);

                    if (Input.GetKey(KeyCode.Q))
                        VRC.Player.prop_Player_0.transform.position -= VRC.Player.prop_Player_0.transform.up * (_FlySpeed / 5);

                    if (Input.GetKey(KeyCode.E))
                        VRC.Player.prop_Player_0.transform.position += VRC.Player.prop_Player_0.transform.up * (_FlySpeed / 5);
                }
                catch { }
            }
        }
    }
}