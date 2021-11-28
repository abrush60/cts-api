namespace api.Interfaces
{
    public interface IHandleClients
    {
        public List<Events> Select();

        public void Delete(Events person);

        public void Update(Events person);

        public void Insert(Events person);
    }
}