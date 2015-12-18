using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT.DB
{


    class ProjectCriterionOperations
    {

        /// <summary>
        /// Gets the project criterion by ids.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="criterionId">The criterion identifier.</param>
        /// <returns>
        /// An instance of 'ProjectCriterion'
        /// </returns>
        /// Erstellt von Joshua Frey, am 18.12.2015
        public static ProjectCriterion GetProjectCriterionByIds(NWATDataContext dataContext,  int projectId, int criterionId)
        {

            ProjectCriterion resultProjectCriterion = dataContext.ProjectCriterion.SingleOrDefault(projectCriterion => projectCriterion.Criterion_Id == criterionId 
                                                                              && projectCriterion.Project_Id == projectId);

              
            
            Console.WriteLine(resultProjectCriterion.Criterion.Name);
            return resultProjectCriterion;
        }
    }
}
