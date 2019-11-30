using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;

namespace Client
{
    /// <summary>
    /// Intended for testing the service: https://localhost:44370/api/Cylinders
    /// Need to run the Service project to start service in the background
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int menuItem = 0;
            string result = "";

            // start menu
            do
            {
                menuItem = StartMainMenu();
            } while (menuItem <= 0 || menuItem > 5);

            // switch to choice
            switch (menuItem)
            {
                case 1:
                    result = GetMaxNumberOfCylindersRecPattern();
                    break;
                case 2:
                    result = GetMaxNumberOfCylindersTriangularPattern();
                    break;
                case 3:
                    result = GetPositionsOfCylindersRecPattern();
                    JToken jt1 = JToken.Parse(result);
                    result = jt1.ToString(Formatting.Indented);
                    break;
                case 4:
                    result = GetPositionsOfCylindersTriangularPattern();
                    JToken jt2 = JToken.Parse(result);
                    result = jt2.ToString(Formatting.Indented);
                    break;
                case 5:
                    Console.WriteLine("Izhod");
                    break;
                default:
                    Console.WriteLine("Izhod");
                    break;
            }

            Console.WriteLine(result);
            Console.Read();
        }

        /// <summary>
        /// Main menu
        /// </summary>
        /// <returns></returns>
        static int StartMainMenu()
        {
            Console.WriteLine("1 - Maksimalno število rondelic - preprost vzorec");
            Console.WriteLine("2 - Maksimalno število rondelic - trikotniški vzorec");
            Console.WriteLine("3 - Pozicije rondelic - preprost vzorec");
            Console.WriteLine("4 - Pozicije rondelic - trikotniški vzorec");
            Console.WriteLine("5 - Izhod");
            Console.Write("Vnesite izbiro (1-5): ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            int.TryParse(choice, out int choiceNr);

            return choiceNr;
        }

        /// <summary>
        /// Takes input data from console (length of the tape, width of the tape,
        /// radius of cylinder, distance between cylinders, distance between cylinder and edge)
        /// </summary>
        /// <returns></returns>
        static Tuple<int, int, int, int, int> InputData()
        {
            bool isDataOk = true;
            int length = 0;
            int width = 0;
            int r = 0;
            int minDistC2C = 0;
            int minDistC2E = 0;

            do
            {
                // take inputs from user
                Console.Write("Vnesite dolžino traku: ");
                string lengthInput = Console.ReadLine();
                Console.Write("Vnesite širino traku: ");
                string widthInput = Console.ReadLine();
                Console.Write("Vnesite polmer rondelice: ");
                string rInput = Console.ReadLine();
                Console.Write("Vnesite minimalno razdaljo med rondelicami: ");
                string minDistC2CInput = Console.ReadLine();
                Console.Write("Vnesite minimalno razdaljo med rondelicami in robovi: ");
                string minDistC2EInput = Console.ReadLine();

                // parse to integer
                int.TryParse(lengthInput, out length);
                int.TryParse(widthInput, out width);
                int.TryParse(rInput, out r);
                int.TryParse(minDistC2CInput, out minDistC2C);
                int.TryParse(minDistC2EInput, out minDistC2E);

                // validate data
                isDataOk = ValidateInputData(length, width, r, minDistC2C, minDistC2E);
            } while (isDataOk == false);

            Tuple<int, int, int, int, int> tuple = new Tuple<int, int, int, int, int>(length, width, r, minDistC2C, minDistC2E);

            return tuple;
        }

        /// <summary>
        /// Validates input data from user
        /// </summary>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="r"></param>
        /// <param name="minDistC2C"></param>
        /// <param name="minDistC2E"></param>
        /// <returns></returns>
        static bool ValidateInputData(int length, int width, int r, int minDistC2C, int minDistC2E)
        {
            if (length <= 0 || width <= 0 || r <= 0)
            {
                Console.WriteLine("Napačni podatki.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Gets the result from service
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        static string GetDataFromService(string url)
        {
            string downloadedString = "";
            try
            {
                WebClient client = new WebClient();
                downloadedString = client.DownloadString(url);
            }
            catch (WebException e)
            {
                Console.WriteLine("Napaka pri povezavi na servis ...");
            }
            return downloadedString;
        }

        /// <summary>
        /// Gets maximum number of Cylinders with rectangle pattern
        /// </summary>
        /// <returns></returns>
        static string GetMaxNumberOfCylindersRecPattern()
        {
            Tuple<int, int, int, int, int> data = InputData();
            string url =
                "https://localhost:44370/api/Cylinders/MaxRec/" +
                data.Item1.ToString() + "/" +
                data.Item2.ToString() + "/" +
                data.Item3.ToString() + "/" +
                data.Item4.ToString() + "/" +
                data.Item5.ToString();

            string result = GetDataFromService(url);

            return result;
        }

        /// <summary>
        /// Gets maximum number of Cylinders with triangular pattern
        /// </summary>
        /// <returns></returns>
        static string GetMaxNumberOfCylindersTriangularPattern()
        {
            Tuple<int, int, int, int, int> data = InputData();
            string url =
                "https://localhost:44370/api/Cylinders/MaxTriangle/" +
                data.Item1.ToString() + "/" +
                data.Item2.ToString() + "/" +
                data.Item3.ToString() + "/" +
                data.Item4.ToString() + "/" +
                data.Item5.ToString();

            string result = GetDataFromService(url);

            return result;
        }

        /// <summary>
        /// Gets json of positions of cylinders with rectangle pattern
        /// </summary>
        /// <returns></returns>
        static string GetPositionsOfCylindersRecPattern()
        {
            Tuple<int, int, int, int, int> data = InputData();
            string url =
                "https://localhost:44370/api/Cylinders/PositionsRec/" +
                data.Item1.ToString() + "/" +
                data.Item2.ToString() + "/" +
                data.Item3.ToString() + "/" +
                data.Item4.ToString() + "/" +
                data.Item5.ToString();

            string result = GetDataFromService(url);

            return result;
        }

        /// <summary>
        /// Gets json of positions of cylinders with triangular pattern
        /// </summary>
        /// <returns></returns>
        static string GetPositionsOfCylindersTriangularPattern()
        {
            Tuple<int, int, int, int, int> data = InputData();
            string url =
                "https://localhost:44370/api/Cylinders/PositionsTriangle/" +
                data.Item1.ToString() + "/" +
                data.Item2.ToString() + "/" +
                data.Item3.ToString() + "/" +
                data.Item4.ToString() + "/" +
                data.Item5.ToString();

            string result = GetDataFromService(url);

            return result;
        }
    }
}
