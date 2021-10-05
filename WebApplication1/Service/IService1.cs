using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Globalization;
using System.Resources;
using System.Text.RegularExpressions;
using System.Threading;

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
        public List<string> Value { get; set; }
        [DataMember]
        public List<string> Key { get; set; }
      /*  public string Language { get; set; }
        [DataMember]
        public string Title { get; set; }*/
        public void GetLanguage()
        {
            Regex regex = new Regex("Eng", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(Value[0]);
            if (matches.Count > 0)
            {
             
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
                CreateResource(CultureInfo.CurrentCulture.Name);
            }
             regex = new Regex("Arab", RegexOptions.IgnoreCase);
             matches = regex.Matches(Value[0]);
            if (matches.Count > 0)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("ar-Sa");
                CultureInfo.CurrentCulture = new CultureInfo("ar-Sa", false);
                CreateResource(CultureInfo.CurrentCulture.Name);
            }
            regex = new Regex("ru", RegexOptions.IgnoreCase);
            matches = regex.Matches(Value[0]);
            if (matches.Count > 0)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("ru-Ru");
                CultureInfo.CurrentCulture = new CultureInfo("ru-Ru", false);
                
                CreateResource(CultureInfo.CurrentCulture.Name);
            }


        }
        public void CreateResource(string lang)
        {
           
                using (System.IO.FileStream fs = new System.IO.FileStream("C:\\Resources."+lang+".resx", System.IO.FileMode.Create))
                {
                    using (ResXResourceWriter resx = new ResXResourceWriter(fs))
                {
                   // resx.AddResource(new ResXDataNode("Key", Key));
                   // resx.AddResource(new ResXDataNode("Language", Language));
                   for(int count=1; count<Value.Count; count++)
                    {
                        resx.AddResource(new ResXDataNode(Key[count], Value[count]));
                    }
                        
                       // resx.AddResource(new ResXDataNode("Value", Value));
                    }
                }

                   
        }
    }
}
