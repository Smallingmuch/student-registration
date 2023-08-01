namespace StudentRegistration.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }

        public BaseEntity()
        {
            DateCreated = DateTime.Now;
        }
    }
}
