using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceSystem.PublishedLanguage.Commands
{
    public class CreateConferenceCommand: MediatR.IRequest
    {
        public CreateConferenceCommand(string organizerEmail, string name, DateTime startDate, DateTime endDate, int conferenceTypeId, int locationId, int categoryId)
        {
            OrganizerEmail = organizerEmail;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            ConferenceTypeId = conferenceTypeId;
            LocationId = locationId;
            CategoryId = categoryId;
        }

        public string OrganizerEmail { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ConferenceTypeId { get; set; }
        public int LocationId { get; set; }
        public int CategoryId { get; set; }
    }
}
