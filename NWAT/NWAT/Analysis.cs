using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NWAT.DB;

namespace NWAT
{
    class Analysis
    {

        public void Analyse()
        {
            // this instance of project criterion controller is needed to work with the Project_Criterion table
            ProjectCriterionController projCritController = new ProjectCriterionController();

            // This method will return all project ctiterions for one project
            int projectId = 0;
            List<ProjectCriterion> projectCriterions = projCritController.GetAllProjectCriterionsForOneProject(projectId);



            
        }
    }
}
