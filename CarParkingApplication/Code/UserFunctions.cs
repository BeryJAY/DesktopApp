using MyREST.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarParkingApplication.Code
{
    class UserFunctions
    {
        public async Task<Park> GetPark(int ID)
        {
            HttpClient httpClient = new HttpClient();
            

            HttpResponseMessage response = await httpClient.GetAsync("http://localhost/dcss/api/parking/parks/"+ID);

            string responsemsg = await response.Content.ReadAsStringAsync();

            JObject ParkObject = JObject.Parse(responsemsg);

            Park p = new Park();
            p.id = Convert.ToInt32(ParkObject["id"].ToString());
            p.Name = ParkObject["Name"].ToString();

            return p;
        }
        
        public async Task<List<ParkingYard.Activities>> GetActivities(int ParkID)
        {
            HttpClient httpClient = new HttpClient();

            List<ParkingYard.Activities> HistoryList = new List<ParkingYard.Activities>();

            HttpResponseMessage response = await httpClient.GetAsync("http://localhost/dcss/api/parking/GetActivities/" + ParkID);

            string responsemsg = await response.Content.ReadAsStringAsync();

            JArray ActivityArray = JArray.Parse(responsemsg);
            
            foreach(JObject Activity in ActivityArray)
            {
                ParkingYard.Activities activity = new ParkingYard.Activities();
                activity.License = Activity["License"].ToString();
                activity.Owner = Activity["Owner"].ToString();
                activity.IN = Convert.ToDateTime(Activity["IN"].ToString());
                activity.OUT = Convert.ToDateTime(Activity["OUT"].ToString());

                HistoryList.Add(activity);

            }


            return HistoryList;


        }

        public async Task<string> Login(User user,int Type,int ParkID)
        {
            HttpClient httpClient = new HttpClient();

            
            var httpContent = new StringContent(JsonConvert.SerializeObject(user));
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


            HttpResponseMessage response = await httpClient.PostAsync("http://127.0.0.1/dcss/api/security/authenticate?UserType="+Type.ToString()+"&ParkID="+ParkID,httpContent);

            string responsemsg=await response.Content.ReadAsStringAsync();

            return responsemsg;

            System.Diagnostics.Debug.WriteLine("Success");
            
        }

       
        public async Task<int> GetDriver(string fingerprint)
        {
            HttpClient httpClient = new HttpClient();

            var httpContent = new StringContent(JsonConvert.SerializeObject(fingerprint));
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            
            HttpResponseMessage response = await httpClient.PostAsync("http://127.0.0.1/dcss/api/parking/GetUser",httpContent);

            string responsemsg = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine("test: " + responsemsg);
            return Convert.ToInt32(responsemsg);

        }

        public async Task<bool> RegisterDriver(int userid)
        {
            HttpClient httpClient = new HttpClient();
            
            HttpResponseMessage response = await httpClient.GetAsync("http://127.0.0.1/dcss/api/parking/RegisterDriver?userid="+userid);

            string responsemsg = await response.Content.ReadAsStringAsync();

            return true;
        }

        public async Task<User> GetUser(int UserID)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.GetAsync("http://127.0.0.1/dcss/api/parking/users?id=" +UserID);

            Stream data = await response.Content.ReadAsStreamAsync();

            StreamReader reader = new StreamReader(data);

            string responseFromServer = reader.ReadToEnd();

            JObject UserObject = JObject.Parse(responseFromServer);
            JObject UserNIRAObject = (JObject)(UserObject["NationalRegInfo"]);

            User u = new User();

            if (UserNIRAObject != null)
            {


                u.ID = Convert.ToInt32(UserObject["ID"]);

                Citizen NIRA = new Citizen();
                NIRA.FirstName = UserNIRAObject["FirstName"].ToString();
                NIRA.LastName = UserNIRAObject["LastName"].ToString();
                NIRA.NIN = UserNIRAObject["NIN"].ToString();

                u.FingerPrint = UserObject["FingerPrint"].ToString();
                u.PhoneNumber = UserObject["PhoneNumber"].ToString();
                u.Email = UserObject["Email"].ToString();

                u.NationalRegInfo = NIRA;

            }
            else
            {
                u = null;
            }
            return u;

        }

        public async Task<User> GetUser(string NIN)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.GetAsync("http://127.0.0.1/dcss/api/parking/users?nin=" + NIN);

            Stream data = await response.Content.ReadAsStreamAsync();

            StreamReader reader = new StreamReader(data);

            string responseFromServer = reader.ReadToEnd();

            JObject UserObject = JObject.Parse(responseFromServer);
            JObject UserNIRAObject =(JObject)(UserObject["NationalRegInfo"]);

            User u = new User();

            if (UserNIRAObject != null)
            {
                
               
                u.ID = Convert.ToInt32(UserObject["ID"]);

                Citizen NIRA = new Citizen();
                NIRA.FirstName = UserNIRAObject["FirstName"].ToString();
                NIRA.LastName = UserNIRAObject["LastName"].ToString();
                NIRA.NIN = UserNIRAObject["NIN"].ToString();

                u.FingerPrint = UserObject["FingerPrint"].ToString();
                u.PhoneNumber = UserObject["PhoneNumber"].ToString();
                u.Email = UserObject["Email"].ToString();

                u.NationalRegInfo = NIRA;

            }
            else
            {
                u = null;
            }
            return u;
        }
        
        public async Task<ParkTicket> GetParkTicket(int ParkID,int CarID)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.GetAsync("http://127.0.0.1/dcss/api/parking/GetTicket?ParkID=" + ParkID + "&CarID=" + CarID);

            Stream data = await response.Content.ReadAsStreamAsync();

            StreamReader reader = new StreamReader(data);

            string responseFromServer = reader.ReadToEnd();

            JObject TicketObject = JObject.Parse(responseFromServer);

            ParkTicket pt = new ParkTicket();

            if (TicketObject != null)
            {
               
                pt.TicketID = Convert.ToInt32(TicketObject["TicketID"].ToString());
                pt.ParkName = TicketObject["ParkName"].ToString();
                pt.License = TicketObject["License"].ToString();
                pt.DriverName = TicketObject["DriverName"].ToString();
                pt.Date = Convert.ToDateTime(TicketObject["Date"].ToString());
            }
            else
            {
                pt = null;
            }
            return pt;
        }
        
        public async Task<bool> ExitParking(int ParkID, int CarID, int UserID)
        {
            HttpClient httpClient = new HttpClient();
            
            HttpResponseMessage response = await httpClient.GetAsync("http://127.0.0.1/dcss/api/parking/ExitParking?ParkID=" + ParkID + "&CarID=" + CarID + "&UserID=" + UserID);

            string responsemsg = await response.Content.ReadAsStringAsync();

            System.Diagnostics.Debug.WriteLine("test: " + responsemsg);

            return Convert.ToBoolean(responsemsg);
        }

        public async Task<bool> GetParking(int ParkID,int CarID,int UserID)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.GetAsync("http://127.0.0.1/dcss/api/parking/GetParking?ParkID=" + ParkID+"&CarID="+CarID+"&UserID="+UserID);

            string responsemsg = await response.Content.ReadAsStringAsync();

            System.Diagnostics.Debug.WriteLine("test: " + responsemsg);

            return Convert.ToBoolean(responsemsg);
        }

        public async Task<int> RegisterCar(string License)
        {
            HttpClient httpClient = new HttpClient();
           
            HttpResponseMessage response = await httpClient.GetAsync("http://127.0.0.1/dcss/api/parking/registercar?license="+License);

            string responsemsg = await response.Content.ReadAsStringAsync();
            

            return Convert.ToInt32(responsemsg);

           
        }

    }
}
