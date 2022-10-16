using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Repository
{
    
    interface ICache
    {
        List<string> GetValue(string key);
    }

    public class RemoteDataBase : ICache
    {
        private List<string> dataBase;

        public RemoteDataBase()
        {
            dataBase = new List<string>
            {
                "alma",
                "armud",
                "adam",
                "heyvan"
            };
        }

        public List<string> GetValue(string key)
        {
            var temp = new List<string>();
            foreach (var item in dataBase)
            {
                if (item.StartsWith(key))
                {
                    temp.Add(item);
                }
            }
            if (temp != null)
            {
                return temp;
            }
            return null;
        }
    }

    public class CasheProxy : ICache
    {
        private List<string> CasheDataBase;
        private RemoteDataBase dataBase;

        public CasheProxy()
        {
            CasheDataBase=new List<string>();
            CasheDataBase.Add("nar");
            dataBase=new RemoteDataBase();
        }

        public List<string> GetValue(string key)
        {
            var temp=new List<string>();
            foreach (var item in CasheDataBase)
            {
                if (item.StartsWith(key))
                {
                    temp.Add(item);
                }
                else
                {
                    var data=dataBase.GetValue(key); 
                    if (data != null)
                    {
                        foreach (var d in data)
                        { 
                            CasheDataBase.Add(d);
                            temp.Add(d);
                        }
                        return temp;
                    }
                }
                return temp;
            } 
            return null;

        }
    }
}


