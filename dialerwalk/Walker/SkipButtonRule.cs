using System.Collections.Generic;

public class SkipButtonsOnFirstStep :  IWalkRule
{
    private readonly IEnumerable<int> disableButtonOrdinal;

    public SkipButtonsOnFirstStep(IEnumerable<int> buttonsOrdinal){
        this.disableButtonOrdinal = buttonsOrdinal;
    }
    public bool IsPreRule()    {
        return true;
    }
    public bool IsPostRule(){
        return false;
    }
    public bool IsApplicable(Walker walker){
        return walker.IsFirstStep();
    }
    public void ApplyRule(ref int[,] prevStepResult, ref int[,] applyMatrix){
        foreach(var i in disableButtonOrdinal){
            prevStepResult.RemoveGraphVertex(i);
        }
    }

}