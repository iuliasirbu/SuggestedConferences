using MediatR;

namespace ConferenceSystem.PublishedLanguage.Events
{
    public class AccountMade: INotification
    {
        public string Name { get; set; }
    }
}
