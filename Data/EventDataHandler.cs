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
            string sql = "UPDATE event SET deleted= 'Y' WHERE eventId=@eventid";
            var values = GetValues(events);
            db.Open();
            db.Update(sql, values);
            db.Close();
        }

        public void Insert(Events events)
        {
            string sql = "INSERT INTO event (eventId, employeeId, clientId, clientEmail, clientPhone, confirmed, assigned, dayOfStatus, setupCompleted, inProgress, tearDown, complete, package) ";
            sql += "VALUES (@eventId, @employeeId, @clientId, @clientEmail, @clientPhone, @confirmed, @assigned, @dayOfStatus, @setupCompleted, @inProgress, @tearDown, @complete, @package)";

            var values = GetValues(events);
            db.Open();
            db.Insert(sql, values);
            db.Close();
        }

        public List<Events> Select()
        {
            db.Open();
            string sql = "SELECT * from event";
            List<ExpandoObject> results = db.Select(sql);


            List<Events> events = new List<Events>();
            foreach(dynamic item in results)
            {
                Events temp = new Events(){
                    eventId = item.eventId,
                    employeeId = item.employeeId,
                    clientId = item.clientId,
                    clientEmail = item.clientEmail,
                    package = item.package,
                    confirmed = item.confirmed,
                    assigned = item.assigned,
                    dayOfStatus = item.dayOfStatus,
                    setupCompleted = item.setupCompleted,
                    inProgress = item.inProgress,
                    tearDown = item.tearDown,
                    complete = item.complete
                };

                events.Add(temp);
            }
            db.Close();

            return events;
        }

        public void Update(Events events)
        {
            var values = GetValues(events);
            string sql = "UPDATE event SET employeeId=@employeeId, clientId=@clientId, clientEmail=@clientEmail, clientPhone=@clientPhone,confirmed=@confirmed, assigned=@assigned, dayOfStatus=@dayOfStatus, setupCompleted=@setupCompleted, inProgress=@inProgress, tearDown=@tearDown, complete=@complete, package=@package";
            sql += "WHERE eventId = @eventId;";

            db.Open();
            db.Update(sql, values);
            db.Close();
        }

        public void UpdateStatus(Events events)
        {
            var values = GetValues(events);
            string sql = "UPDATE event SET confirmed=@confirmed, assigned=@assigned, dayOfStatus=@dayOfStatus, setupCompleted=@setupCompleted, inProgress=@inProgress, tearDown=@tearDown, complete=@complete, package=@package";
            sql += "WHERE eventId = @eventId;";

            db.Open();
            db.Update(sql, values);
            db.Close();
        }

        public Dictionary<string, object> GetValues(Events events)
        {
            var values = new Dictionary<string, object>(){
                {"@eventId", events.eventId},
                {"@employeeId", events.employeeId},
                {"@clientId", events.clientId},
                {"@clientEmail", events.clientEmail},
                {"@package", events.package},
                {"@confirmed", events.confirmed},
                {"@assigned", events.assigned},
                {"@dayOfStatus", events.dayOfStatus},
                {"@setupCompleted", events.setupCompleted},
                {"@inProgress", events.inProgress},
                {"@tearDown", events.tearDown},
                {"@complete", events.complete},
            };

            return values;
        }
    }










}