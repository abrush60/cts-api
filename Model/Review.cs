using api.Interfaces;
using api.Data;

namespace api.models
{
    public class Review
    {
        public int reviewId {get; set;}
        public string text {get; set;}
        public int clientId {get; set;}

        public int eventId {get; set;}
        public int foodRating{get; set;}
        public int musicRating{get; set;}
        public int equipmentRating{get; set;}
        public int overallRating{get; set;}

        public IHandleReviews reviewHandler {get; set;}

        public Review(){
            reviewHandler = new ReviewDataHandler();
        }
    }
}