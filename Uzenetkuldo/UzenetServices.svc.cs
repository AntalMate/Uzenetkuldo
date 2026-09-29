using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Uzenetkuldo.Models;
using Uzenetkuldo.Services;

namespace Uzenetkuldo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class UzenetServices : IUzenetService
    {
        public string CreateUzenet(Uzenet uzenet)
        {
            return new UzenetService().Create(uzenet);
        }

        public List<Uzenet> GetUzenetek()
        {
            List<Tablazat> tablazatok = new UzenetService().Read();
            List<Uzenet> UzenetList = new List<Uzenet>();
            foreach (var elem in tablazatok)
            {
                UzenetList.Add(elem as Uzenet);
            }
            return UzenetList;
        }

        public string UpdateUzenet(Uzenet uzenet)
        {
            return new UzenetService().Update(uzenet);
        }

        public string DeleteUzenet(int id)
        {
            return new UzenetService().Delete(id);
        }
    }
}
