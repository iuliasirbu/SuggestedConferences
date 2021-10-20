using ConferenceSystem.Data;
using System.Collections.Generic;
using System.Linq;

namespace ConferenceSystem.Application.Services
{
    public class NewIban
    {
        private readonly RatingDbContext _dbContext;

        public NewIban(RatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string GetNewIban()
        {
            List<string> ibans = _dbContext.BankAccounts.Select(x => x.Iban).ToList();
           
            if (ibans.Count == 0)
                return "1";

            return (long.Parse(ibans.Last()) + 1).ToString();
        }
    }
}
