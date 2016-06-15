namespace PresentationForYou.DAL.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CurrentState { get; set; }
        public string Description { get; set; }
    }
}