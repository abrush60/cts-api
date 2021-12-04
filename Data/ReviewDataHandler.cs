using System.Dynamic;
using System.Collections.Generic;
using api.Interfaces;
using api.models;

namespace api.Data
{
    public class ReviewDataHandler : IHandleReviews
    {
        private Database db;

        public ReviewDataHandler()
        {
            db = new Database();
        }

        public void Delete(Review review)
        {
            string sql = "UPDATE review SET deleted= 'Y' WHERE reviewId=@reviewid";
            var values = GetValues(review);
            db.Open();
            db.Update(sql, values);
            db.Close();
        }

        public void Insert(Review review)
        {
            string sql = "INSERT INTO review (text, foodRating, musicRating, equipmentRating, overallRating) ";
            sql += "VALUES (@text, @foodRating, @musicRating, @equipmentRating, @overallRating)";

            var values = GetValues(review);
            db.Open();
            db.Insert(sql, values);
            db.Close();
        }

        public List<Review> Select()
        {
            db.Open();
            string sql = "SELECT * from review";
            List<ExpandoObject> results = db.Select(sql);

            List<Review> reviews = new List<Review>();
            foreach(dynamic item in results)
            {
                Review temp = new Review(){
                    eventId = item.eventId,
                    reviewId = item.reviewId,
                    clientId = item.clientId,
                    text = item.text,
                    foodRating = item.foodRating,
                    musicRating = item.musicRating,
                    equipmentRating = item.equipmentRating,
                    overallRating = item.overallRating
                };

                reviews.Add(temp);
            }
            db.Close();

            return reviews;
        }

        public void Update(Review review)
        {
            string sql = "UPDATE review SET eventId=@eventId, reviewId=@reviewId, clientId=@clientId, text=@text, foodRating=@foodRating, musicRating=@musicRating, equipmentRating=@equipmentRating, overallRating=@overallRating";
            sql += "WHERE eventId = @Id;";

            var values = GetValues(review);
            db.Open();
            db.Update(sql, values);
            db.Close();
        }

        public Dictionary<string, object> GetValues(Review review)
        {
            var values = new Dictionary<string, object>(){
                {"@eventId", review.eventId},
                {"@reviewId", review.reviewId},
                {"@clientId", review.clientId},
                {"@text", review.text},
                {"@foodRating", review.foodRating},
                {"@musicRating", review.musicRating},
                {"@equipmentRating", review.equipmentRating},
                {"@overallRating", review.overallRating},
            };

            return values;
        }
    }
}