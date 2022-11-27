using kalendar.Classes;
using System;

namespace kalendar 
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ode pravimo evente
            var event1 = new Event()
            {
                Name = "Trening",
                Location = "Marjan",
                EventBeginDate = new DateTime(2022, 12, 22, 10, 0, 0),
                EventEndDate = new DateTime(2022, 12, 22, 12, 0, 0)
            };
            event1.AddParticipant("jpasalic@gmail.com");
            event1.AddParticipant("mario.simic@outlook.com");
            event1.AddParticipant("sdelalija@gmail.com");
            event1.AddParticipant("ivana21@gmail.com");

            var event2 = new Event()
            {
                Name = "Kava",
                Location = "Domacin",
                EventBeginDate = new DateTime(2022, 12, 27, 15, 0, 0),
                EventEndDate = new DateTime(2022, 12, 27, 16, 0, 0)
            };
            event2.AddParticipant("ivo.horvat@gmail.com");
            event2.AddParticipant("mbaric23@outlook.com");


            var event3 = new Event()
            {
                Name = "Pikado turnir",
                Location = "Pikado klub",
                EventBeginDate = DateTime.Now.AddHours(-3),  //cisto da sigurno iman neki aktivni event
                EventEndDate = DateTime.Now.AddDays(3),
            };
            event3.AddParticipant("jpasalic@gmail.com");
            event3.AddParticipant("mario.simic@outlook.com");
            event3.AddParticipant("sdelalija@gmail.com");
            event3.AddParticipant("ltomic@pmfst.hr");

            var event4 = new Event()
            {
                Name = "Misa",
                Location = "Crkva",
                EventBeginDate = new DateTime(2022, 12, 25, 9, 0, 0),
                EventEndDate = new DateTime(2022, 12, 25, 10, 0, 0)
            };
            event4.AddParticipant("jpasalic@gmail.com");
            event4.AddParticipant("mario.simic@outlook.com");
            event4.AddParticipant("sdelalija@gmail.com");

            var event5 = new Event()
            {
                Name = "Radionice",
                Location = "PMF",
                EventBeginDate = new DateTime(2022, 10, 4, 10, 0, 0),
                EventEndDate = new DateTime(2022, 10, 9, 16, 0, 0)
            };
            event5.AddParticipant("mmatic@gmail.com");
            event5.AddParticipant("josko.kapitanovic@outlook.com");
            event5.AddParticipant("sdelalija@gmail.com");
            event5.AddParticipant("ana.perisic@gmail.com");

            var listOfEvents = new List<Event>()
            {
                event1,
                event2,
                event3,
                event4,
                event5
            };

            //ode pravimo osobe

            var person1 = new Person("Mate", "Matic", "mmatic@gmail.com") { };
            person1.AddEventAttendance(event5.Id, true);

            var person2 = new Person("Jure", "Pasalic", "jpasalic@gmail.com") { };
            person2.AddEventAttendance(event1.Id, true);
            person2.AddEventAttendance(event3.Id, true);
            person2.AddEventAttendance(event4.Id, true);

            var person3 = new Person("Mario", "Simic", "mario.simic@outlook.com") { };
            person3.AddEventAttendance(event1.Id, true);
            person3.AddEventAttendance(event3.Id, true);
            person3.AddEventAttendance(event4.Id, true);

            var person4 = new Person("Stipe", "Delalija", "sdelalija@gmail.com") { };
            person4.AddEventAttendance(event1.Id, true);
            person4.AddEventAttendance(event3.Id, true);
            person4.AddEventAttendance(event4.Id, true);
            person4.AddEventAttendance(event4.Id, true);

            var person5 = new Person("Ivo", "Horvat", "ivo.horvat@gmail.com") { };
            person5.AddEventAttendance(event2.Id, true);

            var person6 = new Person("Lara", "Tomic", "ltomic@pmfst.hr") { };
            person6.AddEventAttendance(event3.Id, true);

            var person7 = new Person("Josko", "Kapitanovic", "josko.kapitanovic@outlook.com") { };
            person7.AddEventAttendance(event5.Id, true);

            var person8 = new Person("Ana", "Peirisic", "ana.perisic@gmail.com") { };
            person8.AddEventAttendance(event5.Id, true);

            var person9 = new Person("Miro", "Baric", "mbaric23@outlook.com") { };
            person9.AddEventAttendance(event2.Id, true);

            var person10 = new Person("Ivana", "Franic", "ivana21@gmail.com") { };
            person10.AddEventAttendance(event1.Id, true);

            var listOfPersons = new List<Person>()
            {
                person1, person2, person3, person4, person5, person6, person7, person8, person9, person10
            };

            var listOfKnownEmails = new List<string>();

            foreach (var item in listOfPersons)
            {
                listOfKnownEmails.Add(item.Email);
            }

            var choice = "";
            while (choice != "0")
            {
                Console.WriteLine("Nalazite se u izborniku aplikacije Kalendar. Izaberite željenu akciju. \n" + "1 - Aktivni eventi\n" + "2 - Nadolazeci eventi\n" + "3 - Eventi koji su zavrsili\n" + "4 - Kreiraj event\n" + "0 - Izlaz iz programa" + "");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Izabrali ste opciju 1 - Aktivni eventi");
                        ActiveEvents(listOfEvents, listOfPersons);
                        break;
                    case "2":
                        Console.WriteLine("Izabrali ste opciju 2 - Nadolazeci eventi");
                        UpcomingEvents(listOfEvents, listOfPersons);
                        break;
                    case "3":
                        Console.WriteLine("Izabrali ste opciju 3 - Eventi koji su zavrsili");
                        CompletedEvents(listOfEvents, listOfPersons);
                        break;
                    case "4":
                        Console.WriteLine("Izabrali ste opciju 4 - Kreiraj event");
                        CreateEvent(listOfEvents, listOfPersons);
                        break;
                    case "0":
                        Console.WriteLine("Izlaz iz aplikacije");
                        break;
                    default:
                        Console.WriteLine("Niste odabrali valjanu opciju. Vraćeni ste na početni izbornik. \n");
                        break;
                }
            }

            void ActiveEvents(List<Event> eventList, List<Person> personList)
            {
                Console.Clear();
                var count = 0;
                var listOfActiveEvents = new List<Event>();
                Console.WriteLine("Svi trenutno aktivni eventi su: ");
                foreach (var item in eventList)
                {
                    if (item.EventBeginDate < DateTime.Now && item.EventEndDate > DateTime.Now)
                    {
                        count++;
                        Console.WriteLine($"- Id eventa: {item.Id} \n{item.Name} - {item.Location} - {item.EventEndDate}");
                        Console.WriteLine("Sudionici: " + item.WriteParticipants());
                        listOfActiveEvents.Add(item);
                    }

                }
                if (count == 0)
                {
                    Console.WriteLine("Nema trenutno aktivnih evenata");
                }

                Console.WriteLine("");
                var choiceOfSubOption = "";
                while (choiceOfSubOption != "0")
                {
                    Console.WriteLine("Submenu: \n1 - Zabiljezi neprisutnost \n0 - Povratak na glavni menu");
                    choiceOfSubOption = Console.ReadLine();

                    switch (choiceOfSubOption)
                    {
                        case "1":
                            Console.WriteLine("Odabrali ste opciju 1 - Zabiljezi neprisutnost");
                            Console.WriteLine("Unesite Id eventa na kojem zelite zabiljeziti neprisutnost");

                            Guid guidOutput;
                            var idToMarkAbsence = Console.ReadLine();
                            bool isGuid = Guid.TryParse(idToMarkAbsence, out guidOutput);
                            var eventExists = false;
                            foreach (var item in listOfActiveEvents)  //ide kroz aktivne evente
                            {
                                if (item.Id == guidOutput)  //trazi onaj koji je unesen od korisnika
                                {
                                    eventExists = true;
                                    Console.WriteLine("Unesite emailove osoba kojima zelite zabiljeziti neprisutnost (odvojene razmakom)");

                                    var stringOfEmailsAbsent = Console.ReadLine();
                                    string[] emailsSplitList = stringOfEmailsAbsent.Split(" ");  //ovo je ka neka fejk lista sa mailovima koji su uneseni

                                    Console.WriteLine("Ako želite nastaviti s radnjom upišite DA");
                                    var confirmation = Console.ReadLine();
                                    if (confirmation == "DA")
                                    {
                                        foreach (var person in personList)
                                        {
                                            foreach (var email in emailsSplitList)
                                            {
                                                if (email == person.Email)
                                                {
                                                    person.MarkAbsent(guidOutput); //svima koji su imali taj event, on se stavi na false
                                                }

                                            }
                                        }

                                        foreach (var email in emailsSplitList) //ovo miče sve neprisutne koji su uneseni
                                        {
                                            item.RemoveParticipant(email);
                                        }
                                        var joinedEmails = string.Join(", ", item.ParticipantsList);

                                        Console.WriteLine($"Na eventu {item.Name} ostali su prisutni: {joinedEmails}"); //ovo ispiše sve koji su prisutni na eventu
                                    }
                                    else
                                        Console.WriteLine("Poništavanje radnje");
                                }
                            }

                            if (!eventExists)
                                Console.WriteLine("Aktivni event s tim id-om ne postoji.");
                            break;

                        case "0":
                            choiceOfSubOption = "0";
                            Console.WriteLine("Povratak na glavni menu");
                            break;
                        default:
                            Console.WriteLine("Niste odabrali valjanu opciju.");
                            break;
                    }
                }
            }

            void UpcomingEvents(List<Event> eventList, List<Person> personList)
            {
                Console.Clear();
                var count = 0;
                var listOfUpcomingEvents = new List<Event>();
                Console.WriteLine("Svi nadolazeci eventi su: ");
                foreach (var item in eventList)
                {
                    if (item.EventBeginDate > DateTime.Now)
                    {
                        count++;
                        Console.WriteLine($"- Id eventa: {item.Id} \n{item.Name} - {item.Location} - {(item.EventBeginDate - DateTime.Now).Days} - {(item.EventEndDate - item.EventBeginDate).TotalHours}");
                        Console.WriteLine("Sudionici: " + item.WriteParticipants());
                        listOfUpcomingEvents.Add(item);
                    }
                }

                if (count == 0)
                    Console.WriteLine("Nema trenutno aktivnih evenata");
                Console.WriteLine("");
                var choiceOfSuboption = "";
                while (choiceOfSuboption != "0")
                {
                    Console.WriteLine("Submenu: \n1 - Izbrisi event \n2 - Ukloni osobe s eventa \n0 - Povratak na glavni menu");
                    choiceOfSuboption = Console.ReadLine();

                    switch (choiceOfSuboption)
                    {
                        case "1":
                            Console.WriteLine("Odabrali ste opciju 1 - Izbrisi event");
                            Console.WriteLine("Unesite id nadolazeceg eventa kojeg želite izbrisati");
                            Guid guidOutput;                                        //ode spremin uneseni guid (id)
                            var idToMarkAbsence = Console.ReadLine();
                            bool isGuid = Guid.TryParse(idToMarkAbsence, out guidOutput);
                            var eventExists = false;


                            Console.WriteLine("Ako zelite nastaviti s radnjom napisite DA");
                            var confirmation = Console.ReadLine();
                            if (confirmation == "DA")
                            {
                                foreach (var item1 in listOfUpcomingEvents)  //ide kroz upcoming evente
                                {

                                    if (item1.Id == guidOutput)  //nalazi onaj event sa unesenim idom
                                    {
                                        eventExists = true;
                                        eventList.Remove(item1);
                                        Console.WriteLine($"Event {item1.Name} uspješno obrisan");

                                        foreach (var person in personList)   //poziva remove event za odredenu osobu koji mu mice taj event ako postoji u AttendanceDict
                                        {
                                            var isRemoveEvent = person.RemoveEvent(guidOutput);
                                        }
                                        break;
                                    }
                                }
                                if (!eventExists)
                                    Console.WriteLine("Nadolazeci event s tim id-om ne postoji.");
                            }

                            else
                                Console.WriteLine("Ponistavanje radnje");
                            break;
                        case "2":
                            Console.WriteLine("Odabrali ste opciju 2 - Ukloni osobe s eventa");
                            Console.WriteLine("Unesite id nadolazeceg eventa s kojeg zelite obrisati osobe");
                            Guid eventId;                                        
                            var eventToRemovePersons = Console.ReadLine();
                            bool isEventGuid = Guid.TryParse(eventToRemovePersons, out eventId);
                            var eventExists1 = false;

                            foreach (var item in listOfUpcomingEvents)
                            {
                                if (item.Id == eventId)
                                {
                                    eventExists1 = true;
                                    Console.WriteLine("Unesite emailove osoba kojima zelite ukloniti s eventa (odvojene razmakom)");
                                    var stringOfEmailsAbsent = Console.ReadLine();
                                    string[] emailsSplitList = stringOfEmailsAbsent.Split(" ");
                                    Console.WriteLine("Ako želite potvrditi radnju napisite DA");
                                    var confirmation2 = Console.ReadLine();

                                    if (confirmation2 == "DA")
                                    {
                                        foreach (var mail in emailsSplitList)
                                        {
                                            var didRemove = item.RemoveParticipant(mail);  //ovaj dio uklanja mailove iz objekta Event
                                            if (!didRemove)
                                            {
                                                Console.WriteLine($"Osoba koja ima mail {mail} nije ni bila sudionik");
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Osoba koja ima mail {mail} uspjesno je uklonjena");
                                            }
                                        }

                                        foreach (var person in personList)
                                        {
                                            var didRemoveEvent = person.RemoveEvent(eventId);
                                        }
                                        break;  //ovi break je tu da kad nađe trazeni event u listi evenata da obavi šta triba i izađe, da ne vrti sve do kraja
                                    }
                                    else
                                        Console.WriteLine("Ponistavanje radnje");
                                }

                            }
                            if (!eventExists1)
                                Console.WriteLine("Nadolazeci event s tim id-om ne postoji.");
                            break;
                        case "0":
                            Console.WriteLine("Odabrali ste opciju 0 - povratak na glavni menu");
                            break;
                        default:
                            Console.WriteLine("Niste odabrali valjanu opciju");
                            break;
                    }



                }
            }

            void CompletedEvents(List<Event> eventList, List<Person> personList)
            {
                var count = 0;
                var listOfCompletedEvents = new List<Event>();
                var listOfPresentPersons = new List<string>();
                var listOfAbsentPersons = new List<string>();
                Console.WriteLine("Svi eventi koji su zavrsili su: ");
                foreach (var item in eventList)
                {
                    if (item.EventEndDate < DateTime.Now)
                    {
                        count++;
                        Console.WriteLine($"- Id eventa: {item.Id} \n{item.Name} - {item.Location} - {(DateTime.Now - item.EventEndDate).Days} - {(item.EventEndDate - item.EventBeginDate).TotalHours}");

                        foreach (var person in personList)
                        {
                            if (person.AttendanceDict.ContainsKey(item.Id))
                            {
                                if (person.AttendanceDict[item.Id] == true)
                                {
                                    listOfPresentPersons.Add(person.Email);
                                }
                                else
                                {
                                    listOfAbsentPersons.Add(person.Email);
                                }
                            }
                        }
                        var joinedEmailsAbsent = string.Join(", ", listOfAbsentPersons);
                        var joinedEmailsPresent = string.Join(", ", listOfPresentPersons);
                        Console.WriteLine($"Prisutni: {joinedEmailsPresent}\nOdsutni: {joinedEmailsAbsent}\n");
                    }

                }
                if (count == 0)
                    Console.WriteLine("Nema evenata koji su zavrsili\n");
            }

            void CreateEvent(List<Event> eventList, List<Person> personList)
            {
                var listOfKnownIds = new List<Guid>();
                foreach (var item in eventList)
                {
                    listOfKnownIds.Add(item.Id);
                }

                var newEventList = new List<Event>();

                Console.WriteLine("Unesite naziv eventa");
                var newEventName = Console.ReadLine();

                Console.WriteLine("Unesite lokaciju eventa");
                var newEventLocation = Console.ReadLine();

                DateTime eventBeginDate = new DateTime();
                DateTime eventEndDate = new DateTime();
                int eventBeginHours = new int();
                int eventEndHours = new int();

                Console.WriteLine("Unesite datum početka eventa (u formatu mjesec/dan/godina)");
                var inputtedBeginDate = DateTime.TryParse(Console.ReadLine(), out eventBeginDate);
                if (inputtedBeginDate)
                {
                    Console.WriteLine("Unesite u koliko sati počinje");
                    var inputtedBeginHours = int.TryParse(Console.ReadLine(), out eventBeginHours);
                    eventBeginDate = eventBeginDate.AddHours(eventBeginHours);

                    if (inputtedBeginHours)
                    {
                        if (eventBeginDate < DateTime.Now)
                            Console.WriteLine("Ne može se kreirati event u proslosti. Vraceni ste na pocetni menu.");

                        else 
                        {
                            Console.WriteLine("Unesite datum kraja eventa (u formatu mjesec/dan/godina)");
                            var inputtedEndDate = DateTime.TryParse(Console.ReadLine(), out eventEndDate);
                            if (inputtedEndDate)
                            {
                                Console.WriteLine("Unesite u koliko sati završava");
                                var inputtedEndHours = int.TryParse(Console.ReadLine(), out eventEndHours);

                                if (inputtedEndHours)
                                {
                                    eventEndDate = eventEndDate.AddHours(eventEndHours);
                                    Console.WriteLine("Unesite emailove sudionika na ovome eventu (odvojene razmakom)");
                                    var participantEmailsString = Console.ReadLine();
                                    string[] emailsSplitList = participantEmailsString.Split(" ");
                                    Console.WriteLine("Ako ste sigurni da zelite kreirati event upisite DA");
                                    var confirmation = Console.ReadLine();

                                    if (confirmation == "DA")
                                    {
                                        if (eventBeginDate >= eventEndDate)
                                        {
                                            Console.WriteLine("Ne moze se kreirati event kojemu je kraj prije pocetka (ili u isto vrijeme)");
                                        }
                                        else //ako je uslo u ovi else onda sve valja i triba kreirat event
                                        {
                                            var newEvent = new Event()
                                            {
                                                Name = newEventName,
                                                Location = newEventLocation,
                                                EventBeginDate = eventBeginDate,
                                                EventEndDate = eventEndDate,
                                            };

                                            foreach (var person in listOfPersons)
                                            {
                                                if (emailsSplitList.Contains(person.Email))    
                                                {
                                                    var overlappingEvents = 0;
                                                    foreach (var item in person.AttendanceDict.Keys.ToList()) 
                                                    {
                                                        if (person.AttendanceDict[item] == true)
                                                        {
                                                            foreach (var event1 in eventList)  
                                                            {
                                                                if (item == event1.Id)  
                                                                {

                                                                    if ((newEvent.EventBeginDate < event1.EventBeginDate && newEvent.EventEndDate > event1.EventBeginDate) || (newEvent.EventBeginDate < event1.EventEndDate && newEvent.EventEndDate > event1.EventEndDate))
                                                                    {
                                                                        overlappingEvents++;
                                                                    }
                                                                }
                                                            }

                                                        }
                                                    }
                                                    if (overlappingEvents == 0)
                                                    {
                                                        person.AddEventAttendance(newEvent.Id, true);
                                                        newEvent.AddParticipant(person.Email);
                                                    }
                                                    else
                                                        Console.WriteLine($"Osobi s mailom {person.Email} se event preklapa s drugim pa nije dodana");
                                                }

                                            }
                                            eventList.Add(newEvent);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Kreiranje eventa ponisteno. Vraceni ste na pocetni menu");
                                    }
                                }
                                else
                                    Console.WriteLine("Niste unijeli sate ispravno");
                            }
                            else
                                Console.WriteLine("Niste unijeli datum ispravno");
                        }
                    }
                    else
                        Console.WriteLine("Niste unijeli sate ispravno");
                }
                else
                    Console.WriteLine("Niste unijeli datum ispravno.");
            }

        }
    }
}