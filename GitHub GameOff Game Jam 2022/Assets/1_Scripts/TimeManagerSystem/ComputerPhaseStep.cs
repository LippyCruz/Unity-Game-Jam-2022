using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ComputerPhaseStep : MonoBehaviour {

    public abstract void DoProcessingForComputerPhaseDuringGameInit();
    public abstract void DoProcessingForComputerPhase();

}
