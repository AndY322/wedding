using System;
using System.Collections;
using System.Collections.Generic;

namespace DomainModel.Models
{
    public class User
    {
        public virtual Guid UserId { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string Surname { get; set; }

        public virtual string LastName { get; set; }
        
        public virtual int AccessCode { get; set; }
        
        public virtual ICollection<Survey> Surveys { get; set; }
    }
}