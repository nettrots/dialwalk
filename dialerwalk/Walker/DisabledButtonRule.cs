using System.Collections.Generic;

public class DisabledButtons :  IWalkRule
{
    private readonly IEnumerable<int> disableButtonOrdinal;

    public DisabledButtons(IEnumerable<int> disableButtonOrdinal){
        this.disableButtonOrdinal = disableButtonOrdinal;
    }
    public bool IsPreRule()    {
        return true;
    }
    public bool IsPostRule(){
        return false;
    }
    public bool IsApplicable(Walker walker){
        return true;
    }
    public void ApplyRule(ref int[,] prevStepResult, ref int[,] applyMatrix){
        foreach(var i in disableButtonOrdinal){
            applyMatrix.RemoveGraphVertex(i);
            prevStepResult.RemoveGraphVertex(i);
        }
    }

}