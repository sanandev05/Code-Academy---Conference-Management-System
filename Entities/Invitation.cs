﻿using Code_Academy___Conference_Management_System.User;

namespace Code_Academy___Conference_Management_System.Entities
{
    public class Invitation : BaseEntity
    {
        public enum Status
        {
            Pending,
            Accepted,
            Declined
        }
        public int EventId { get; set; }
        public string UserId { get; set; }

        public Event Event { get; set; }
        public UserIdentity User { get; set; }

        public Status InvitationStatus { get; set; } = Status.Pending;

        public DateTime SentAt { get; set; } = DateTime.Now;
    }
}
