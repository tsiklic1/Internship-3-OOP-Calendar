namespace kalendar.Classes
{
    public class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public Dictionary<Guid, bool> AttendanceDict { get; private set; }

        public Person(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            AttendanceDict = new Dictionary<Guid, bool>() { };
        }

        public bool AddEventAttendance(Guid eventId, bool didAttend)
        {
            if (AttendanceDict.ContainsKey(eventId))
            {
                return false;
            }
            else
            {
                AttendanceDict.Add(eventId, didAttend);
                return true;
            }
        }

        public bool MarkAbsent(Guid eventId)
        {
            if (AttendanceDict.ContainsKey(eventId))
            {
                AttendanceDict[eventId] = false;
                return true;
            }
            else
                return false;
        }

        public bool RemoveEvent(Guid eventId)
        {
            if (AttendanceDict.ContainsKey(eventId))
            {
                AttendanceDict.Remove(eventId);
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
