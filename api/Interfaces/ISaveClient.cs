using System.ComponentModel.Design.Serialization;
using System.Security.Cryptography;
using cts.models;

namespace api.interfaces
{
    public interface ISaveClient
    {
         public void CreateClient(Client myClient);
         public void SaveBook(Client myClient);
    }
}