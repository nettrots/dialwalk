using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Walker {
    private int _totalSteps;
    private int _currentStep;
    private int[, ] originalAdjacency;
    private int[, ] applyAdjacency;
    private int[, ] walkResult;
    private List<IWalkRule> rules;
    private readonly DialLayout layout;
    public void ApplyRulesFromFile (string fileName) {
        foreach (var line in File.ReadLines (fileName)) {
            if (line.StartsWith ("Length:")) {
                var len = line.Split (':') [1];
                int.TryParse (len, out _totalSteps);
            } else if (line.StartsWith ("ExcludeButton:")) {

                var exclButtons = line.Split (':').Last ().Split (',');
                rules.Add (new DisabledButtons (exclButtons.SelectMany (b => layout.GetAllPositions (b)).Select (p => p.Ordinal)));
            } else if (line.StartsWith ("DoNotStartWith:")) {

                var exclButtons = line.Split (':').Last ().Split (',');
                rules.Add (new SkipButtonsOnFirstStep (exclButtons.SelectMany (b => layout.GetAllPositions (b).Select (p => p.Ordinal))));
            }
        }
    }

    public Walker (string pieceName, DialLayout layout) {
        originalAdjacency = ChessPieceFactory.
        GetChessPieceByName (pieceName).
        GenerateAdjacencyMatrix (layout);

        applyAdjacency = (int[, ]) originalAdjacency.Clone ();
        walkResult = MatrixExt.IdentityMatrix (originalAdjacency.GetLength (0));

        _currentStep = 0;

        this.layout = layout;
        rules = new List<IWalkRule> ();
    }

    public bool IsFirstStep () {
        return _currentStep == 0;
    }
    public bool isFinalStep () {
        return _totalSteps == _currentStep;
    }
    public bool isStepNumber (int number) {
        return number == _currentStep;
    }

    public void PreRules () {
        foreach (var rule in rules) {
            if (rule.IsPreRule () && rule.IsApplicable (this)) {
                rule.ApplyRule (ref walkResult, ref applyAdjacency);
            }
        }
    }
    public void PostRules () {
        foreach (var rule in rules) {
            if (rule.IsPostRule () && rule.IsApplicable (this)) {
                rule.ApplyRule (ref walkResult, ref applyAdjacency);
            }
        }
    }
    public void Step () {
        walkResult = walkResult.MultiplyBy (applyAdjacency);
    }

    public int[, ] Walk () {

        while (_currentStep < _totalSteps) {
            PreRules ();
            if (!IsFirstStep ()) { Step (); }
            PostRules ();
            applyAdjacency = (int[, ]) originalAdjacency.Clone ();
            _currentStep++;
        }
        return walkResult;
    }

}