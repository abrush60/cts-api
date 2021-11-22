using System.Dynamic;
using System.Collections.Generic;
using api.Interfaces;
using api.models;

namespace api.Data
{
    public class EventDataHandler : IHandleEvents
    {
        private Database db;

        public EventDataHandler()
        {
            db = new Database();
        }

        public void Delete(Events events)
        {
            // string sql = "UPDATE person SET deleted= 'Y' WHERE id=@id";
            // var values = GetValues(person);
            // db.Open();
            // db.Update(sql, values);
            // db.Close();
        }

        public void Insert(Events events)
        {
            string sql = "INSERT INTO events (id, ownerName) ";
            sql += "VALUES (@id, @ownerName";

            var values = GetValues(events);
            db.Open();
            db.Insert(sql, values);
            db.Close();
        }

        public List<Events> Select()
        {
            db.Open();
            string sql = "SELECT * from events";
            List<ExpandoObject> results = db.Select(sql);

            List<Events> events = new List<Events>();
            foreach(dynamic item in results)
            {
                Events temp = new Events(){
                    Id = item.Id,
                    Name = item.Name,
                };

                events.Add(temp);
            }

            return events;
        }

        public void Update(Events events)
        {
            // string sql = "UPDATE person SET first_name=@firstName, last_name=@lastName, major=@major, minor=@minor, pledge_class=@pledgeClass, ";
            // sql += "graduation_semester=@graduatingSemester, grad_school=@gradSchool, university=@gradSchoolName, employed=@employed, position=@position, company=@company, ";
            // sql += "city=@city, email=@email WHERE id = @id;";

            // var values = GetValues(person);
            // db.Open();
            // db.Update(sql, values);
            // db.Close();
        }

        public Dictionary<string, object> GetValues(Events events)
        {
            var values = new Dictionary<string, object>(){
                {"@id", events.Id},
                {"@ownerName", events.Name},
            };

            return values;
        }
    }










}