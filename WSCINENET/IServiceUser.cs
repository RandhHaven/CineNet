using System.ServiceModel;

namespace WSCINENET
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceUser" in both code and config file together.
    [ServiceContract]
    public interface IServiceUser
    {
        [OperationContract]
        string AddUser(string usuario);

        [OperationContract]
        void DeleteUser();
    }
}