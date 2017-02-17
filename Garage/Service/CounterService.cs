﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage.Service
{
    public class CounterService
    {
        public string ConvertToTime(int minuts)
        {
            string time = "";
            time = TimeSpan.FromMinutes(minuts).ToString();
            return time;
        }

        public int ConvertToMinuts(DateTime StartTime, DateTime EndTime)
        {
            TimeSpan span = EndTime - StartTime;
            int minuts = (int)span.TotalMinutes;
            return minuts;
        }

        public int GetCost(int minuts)
        {
            int price = new ParkingService().pricePerHour;
            return minuts * price;
        }

    }
}