using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Uzenetkuldo.Models;

namespace Uzenetkuldo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IUzenetkuldoService
    {

        [OperationContract]
        List<Uzenet> GetUzenetek();

        [OperationContract]
        string CreateUzenet(Uzenet uzenet);

        [OperationContract]
        string UpdateUzenet(Uzenet uzenet);

        [OperationContract]
        string DeleteUzenet(int id);
    }
}
