using System;
namespace Micro.Common.Events
{
    public class ActivityCreated : IAuthenticatedEvent
    {

        public Guid Id { get;  }
        public Guid UserId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }





        protected ActivityCreated()
        {

        }
        public ActivityCreated(Guid id , Guid userId,string category,string name,string description)
        {
            this.UserId = id;
            this.Id = id;
            this.Category = category;
            this.Name = name;
            this.Description = description;
        }
    }
}
