using NWAT.DB;

namespace NWAT.Analysis
{
    public class AnalysisResultCrit
    {
        private double _resultValue;

        public double ResultValue
        {
            get { return _resultValue; }
            set { _resultValue = value; }
        }

        private bool _isReCalculated;

        public bool IsReCalculated
        {
            get { return _isReCalculated; }
            set { _isReCalculated = value; }
        }

        private ProjectCriterion _projCrit;

        public ProjectCriterion ProjCrit
        {
            get { return _projCrit; }
            set { _projCrit = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalysisResultCrit"/> class.
        /// </summary>
        /// <param name="projCrit">The proj crit.</param>
        /// Erstellt von Joshua Frey, am 20.01.2016
        public AnalysisResultCrit(ProjectCriterion projCrit)
        {
            this.ProjCrit = projCrit;
            this.IsReCalculated = false;
            this.ResultValue = this.ProjCrit.Weighting_Percentage_Project.Value;
        }
        
    }
}
