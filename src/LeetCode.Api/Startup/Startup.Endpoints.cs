﻿namespace LeetCode.Startup;

public static partial class Startup
{
    private static WebApplicationBuilder AddControllers(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddControllers();

        return builder;
    }
}