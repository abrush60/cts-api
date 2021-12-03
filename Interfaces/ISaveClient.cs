using System.ComponentModel.Design.Serialization;
using System.Security.Cryptography;
using api.models;

namespace api.interfaces
{
    public interface ISaveClient
    {
         public void CreateClient(Client myClient);
         public void SaveBook(Client myClient);
    }
}