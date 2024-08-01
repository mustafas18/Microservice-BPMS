﻿using BpmsApi.Services;

namespace BpmsApi.Extensions
{
    public static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {


            builder.Services.AddSingleton<IWeatherForcast, WeatherForcast>();
        }
    }

}