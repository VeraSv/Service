﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Globalization;
using System.Resources;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetDetails(byte[] file);
        //  string GetData(int value);

        //  [OperationContract]
        // CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
  /*  [DataContract]
    public class ReadFile
    {


        [DataMember]
        public string info { get; set; }

    }*/
    [DataContract]
    public class Resource
    {

        [DataMember]
        public string Value { get; set; }
        
        public void createResource()
        {
            ResXResourceWriter resx = new ResXResourceWriter("C:\\Resource" + "." + CultureInfo.CurrentCulture.Name + ".resx");
            resx.AddResource("Title", Value);
            resx.AddResource("Value", Value);
        }
    }
}
