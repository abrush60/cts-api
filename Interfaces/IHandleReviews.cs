using System.Dynamic;
using System.Collections.Generic;
using api.Interfaces;
using api.models;

namespace api.Interfaces
{
    public interface IHandleReviews
    {
          public List<Review> Select();

         public void Delete(Review reviews);

         public void Update(Review reviews);

         public void Insert(Review reviews);
    }
}