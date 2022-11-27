namespace kalendar.Classes
{
    public class Event
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime EventBeginDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public List<string> ParticipantsList { get; private set; }

        public Event()
        {
            Id = Guid.NewGuid();
            ParticipantsList = new List<string>();
        }

        public bool AddParticipant(string participantEmail)
        {
            if (ParticipantsList.Contains(participantEmail))
            {
                return false;
            }
            else
                ParticipantsList.Add(participantEmail);
            return true;
        }

        public bool RemoveParticipant(string participantEmail)
        {
            if (ParticipantsList.Contains(participantEmail))
            {
                ParticipantsList.Remove(participantEmail);
                return true;
            }
            else
            {
                return false;
            }
        }

        public string WriteParticipants()
        {
            var joinedEmails = string.Join(", ", ParticipantsList);
            return joinedEmails;
        }
    }
}
