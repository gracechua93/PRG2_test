﻿// Dictionaries
using PRG2_test;

Dictionary<string, Airline> airlineDict = new Dictionary<string, Airline>();
Dictionary<string, Flight> flightDict = new Dictionary<string, Flight>();


LoadFlights(flightDict);

void LoadFlights(Dictionary<string, Flight> fDict)
{
    using (StreamReader sr = new StreamReader("flights.csv"))
    {
        string? s = sr.ReadLine();

        while ((s = sr.ReadLine()) != null)
        {
            string[] data = s.Split(',');
            string fNum = data[0];
            string fOrigin = data[1];
            string fDest = data[2];
            DateTime eDepart_Arrival = DateTime.Parse(data[3]);

            // Add to the flight dictionary
            Flight flight = new Flight(fNum, fOrigin, fDest, eDepart_Arrival);
            flightDict[fNum] = flight;
        }
    }


    using (StreamReader sr = new StreamReader("airlines.csv"))
    {
        string? s = sr.ReadLine();

        while ((s = sr.ReadLine()) != null)
        {
            string[] data = s.Split(',');
            string airname = data[0];
            string aircode = data[1];

            // Add to the airline dictionary
            Airline airline = new Airline(aircode, airname);
            airlineDict[aircode] = airline;
        }
    }
    Console.WriteLine("{0,-15} {1,-20} {2,-23} {3,-20} {4,-15}",
                "Flight Number", "Airline Number", "Origin", "Destination", "Expected Departure/Arrival Time");
    foreach (KeyValuePair<string, Airline> a in airlineDict)
    {

        foreach (KeyValuePair<string, Flight> f in flightDict)
        {

            Console.WriteLine("{0,-15} {1,-20} {2,-23} {3,-20} {4,-15}",
                f.Value.FlightNumber, a.Value.Name, f.Value.Origin, f.Value.Destination, f.Value.ExpectedTime);
        }
    }

}
