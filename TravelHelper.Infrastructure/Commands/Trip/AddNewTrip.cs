namespace TravelHelper.Infrastructure.Commands.Trip
{
    public class AddNewTrip: ICommand
    {
        public string UserID { get; set; }
        public string Name {get; set;}
        public string Location {get;set;}
        public string Link {get; set;}
    
    }
}