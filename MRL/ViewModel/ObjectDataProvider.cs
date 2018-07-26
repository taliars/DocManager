using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using MRL.Model;

namespace MRL.ViewModel
{
    public class ObjectDataProvider
    {
        public ObjectDataViewModel GetObjectData()
        {
            ObjectDataViewModel objectData = new ObjectDataViewModel
                (new ObjectData {
                    CustomerName = "Новый заказчик",
                    CustomerAddress = "Адрес нового заказчика",
                    ObjectAddress = "Адрес объекта",
                    ObjectName = "Наименование объекта ",
                    Measurement = "Протяженность объекта 2.0 км",
                    Acts = new List<Act> { new Act { Name = "112пч-18х"}, new Act { Name = "112пв-18х"} },
                    Protocols = new List<Protocol>(),
                    Order = "Договор № 112",
                    Purpose = "новое строительство",
                    WeatherDays = new List<WeatherDay>(),
                });

            return objectData;
        }
    }
}