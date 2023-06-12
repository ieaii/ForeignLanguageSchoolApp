using ForeignLanguageSchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLanguageSchoolApp.Controllers
{
    public class ReviewsController : MainController
    {
        public List<Reviews> GetReviewsList()
        {
            return dataBase.context.Reviews.ToList();
        }

        public bool AddNewReview(Reviews reviews)
        {
            dataBase.context.Reviews.Add(reviews);
            try
            {
                if (dataBase.context.SaveChanges() == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
