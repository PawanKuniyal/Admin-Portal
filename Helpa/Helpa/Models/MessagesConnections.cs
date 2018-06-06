using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpa.Models
{
    public class MessagesConnections
    {
        public int Id { get; set; }
        public bool RowStatus { get; set; }
        public int GenderId { get; set; }
        public string ProfileImage { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public int LocationId { get; set; }
        public int AverageRating { get; set; }
    }

    public class NotificationEntity
    {
        public int NotificationId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string RowStatus { get; set; }
        public string NotificationState { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ReadDate { get; set; }
        public string NotificationType { get; set; }
    }
}