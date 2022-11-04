﻿using Microsoft.Extensions.Configuration;

namespace Fhi.ClientCredentialsUsingSecrets;

public static class ConfigurationExtensions
{
    public static ClientCredentialsConfiguration GetWorkerKonfigurasjon(
        this IConfiguration root)
    {
        return root.GetConfig<ClientCredentialsConfiguration>("ClientCredentialsConfiguration");
    }

    public static T GetConfig<T>(this IConfiguration root, string name) => root.GetSection(name).Get<T>();
}