using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    //These states represent the states that the CNC machine can be in
    IDLE, STARTUP_POWERON, STARTUP_EMERGENCYPRESSED, STARTUP_EMERGENCYRELEASED, STARTUP_POWERUP, STARTUP_COMPLETE, INSERTTOOL_BLACKBUTTON_PRESSED, INSERTTOOL_BLACKBUTTON_RELEASED
}
