using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RatingRepository : IRatingRepository
    {
        EstyWebApiContext _estyWebApiContext;

        public RatingRepository(EstyWebApiContext estyWebApiContext)
        {
            _estyWebApiContext = estyWebApiContext;
        }

        public async Task<Rating> AddRating(Rating rating)
        {
            await _estyWebApiContext.Rating.AddAsync(rating);
            await _estyWebApiContext.SaveChangesAsync();
            return rating;
        }
    }
}
