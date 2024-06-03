using System.Net.Http.Headers;
using System.Numerics;
using System.Xml.Linq;


namespace Final_ALgosi
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentsApp app = new StudentsApp();

            app.students["Kulmatov_Baiastan"] = "2.7";
            app.students["Bekzhanov_Nuzhigit"] = "5.0";
            app.students["Suleimanov_Rinat"] = "4.0";
            app.students["Kalbaev_Timur"] = "3.8";

            app.StartApp();
        }
    }
}