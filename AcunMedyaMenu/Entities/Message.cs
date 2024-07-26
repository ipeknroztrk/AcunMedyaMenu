using System;
namespace AcunMedyaMenu.Entities
{
	public class Message
	{
       
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Subject { get; set; }
            public string Content { get; set; }
            public DateTime DateSent { get; set; }
        

    }
}

