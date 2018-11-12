public interface  IWalkRule
{
    bool IsPreRule();
    bool IsPostRule();
    bool IsApplicable(Walker walker);
    void ApplyRule(ref int[,] prevStepResult, ref int[,] applyMatrix);

}