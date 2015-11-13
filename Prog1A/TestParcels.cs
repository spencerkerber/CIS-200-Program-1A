// Spencer Kerber
//CIS 200-10
// Program 1B
// Sorted Parcels
// Due 6/3/15

// File: TestParcels.cs
// This is a simple, console application designed to exercise the Parcel hierarchy.
// It creates several different Parcels and prints them.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
        static void Main(string[] args)
        {
            // Test Data - Magic Numbers OK
            Address a1 = new Address("John Smith", "123 Any St.", "Apt. 45",
                "Louisville", "KY", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.", "",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4
            Address a5 = new Address("Luke Skywalker", "101 dessert way", "Hut 1",
                "Mos Eisley", "TA", 12345); // Test Address 5
            Address a6 = new Address("Bilbo Baggins", "202 Bagshot Row", "Bag End",
                "Hobbiton", "TS", 12346);   // Test Address 6
            Address a7 = new Address("Jon Snow", "303 Kings Rd", "",
                "Winterfell", "TN", 12347); // Test Address 7
            Address a8 = new Address("Sherlock Holmes", "221B Baker St", "",
                "London", "GL", 12348);     // Test Address 8

            Letter letter1 = new Letter(a1, a2, 3.95M);                            // Letter test object
            Letter letter2 = new Letter(a8, a7, 4.1M);                             // Letter test object
            GroundPackage gp1 = new GroundPackage(a3, a4, 14, 10, 5, 12.5);        // Ground test object
            GroundPackage gp2 = new GroundPackage(a7, a6, 10, 12, 4, 20.5);        // Ground test object
            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15,    // Next Day test object
                85, 7.50M);
            NextDayAirPackage ndap2 = new NextDayAirPackage(a6, a5, 26, 16, 16,    // Next Day test object
                86, 8.5M);
            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0, // Two Day test object
                80.5, TwoDayAirPackage.Delivery.Saver);
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a5, a4, 47.7, 40.5, 29.0, // Two Day test object
                81.5, TwoDayAirPackage.Delivery.Early);

            List<Parcel> parcels;      // List of test parcels

            parcels = new List<Parcel>();

            parcels.Add(letter1); // Populate list
            parcels.Add(letter2);
            parcels.Add(gp1);
            parcels.Add(gp2);
            parcels.Add(ndap1);
            parcels.Add(ndap2);
            parcels.Add(tdap1);
            parcels.Add(tdap2);

            Console.WriteLine("Original List:");
            Console.WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }
            Pause();

            var parcelsByZip =      // Parcels sorted by zip code
              from p in parcels
              orderby p.DestinationAddress.Zip descending
              select p;

            Console.WriteLine("Parcels sorted by zip code");
            Console.WriteLine("====================");
            foreach (Parcel p in parcelsByZip)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }
            Pause();

            var parcelsByCost =     // Parcels sorted by cost
               from p in parcels
               orderby p.CalcCost() ascending
               select p;

            Console.WriteLine("Parcels sorted by cost");
            Console.WriteLine("====================");
            foreach (Parcel p in parcelsByCost)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }
            Pause();

            var parcelsByType =     // Parcels sorted by type
             from p in parcels
             orderby p.GetType().ToString() ascending
             select p;

            var parcelsByCost2 =    // Sorted by type parcels sorted by cost
                from p in parcelsByType
                orderby p.CalcCost() descending
                select p;

            Console.WriteLine("Parcels sorted by type then cost");
            Console.WriteLine("====================");
            foreach (Parcel p in parcelsByCost2)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }
            Pause();

            var airPackages =       // Parcels that are air packages and heavy
                from p in parcels
                where p is AirPackage && ((AirPackage)p).IsHeavy()
                orderby ((AirPackage)p).Weight
                select p;

            Console.WriteLine("Heavy air packages sorted by weight");
            Console.WriteLine("====================");
            foreach (Parcel p in airPackages)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }
            Pause();
       }

        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            Console.Clear(); // Clear screen
        }
    }
}
