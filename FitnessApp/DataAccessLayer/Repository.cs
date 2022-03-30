using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    public class Repository
    {
        public static string membersFile = @"C:\repos\memberlist.json";

        public static List<Member> WriteMemberListToFile(List<Member> membersList)
        {           
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            string json = JsonConvert.SerializeObject(membersList, settings);

            File.WriteAllText(membersFile, json);

            return membersList;
        }

        public static List<Member> ReadMemberListFromFile()
        {
            if (!File.Exists(membersFile)) // Check if the membersFile exists or create it if it doesn't.
            {
                File.Create(membersFile).Close();
                Console.WriteLine("Member file did not exist, but was created. You can now add members.\n");
                return new List<Member>();
            }
            else // No need to read if the file is brand new and empty.
            {
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

                List<Member> myMemberList = JsonConvert.DeserializeObject<List<Member>>(File.ReadAllText(membersFile), settings);

                return myMemberList;
            }
        }
    }
}
