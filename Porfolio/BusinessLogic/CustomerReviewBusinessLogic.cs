using Porfolio.Model;

namespace Porfolio.BusinessLogic
{
    public class CustomerReviewBusinessLogic
    {
        public void ValidateReview(CustomerReview review)
        {
            if (review.Rating < 1 || review.Rating > 5)
                throw new ArgumentException("Rating must be between 1 and 5.");

            if (string.IsNullOrWhiteSpace(review.Name))
                throw new ArgumentException("Name cannot be empty.");
        }
    }
}
