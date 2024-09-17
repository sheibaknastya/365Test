using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using ApiClient = _365Test.core.api.ApiClient;

namespace _365Test.core;

public class BaseTest
{
   protected readonly ApiClient ApiClient;

   protected BaseTest()
   {
      IConfiguration apiData = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("data/api.json", optional: false, reloadOnChange: true)
        .Build();

      ApiClient = new ApiClient(
          apiData["BaseUrl"] ?? 
          throw new NullReferenceException("Unable to get BaseUrl from API data file")); 
   }
   
   [OneTimeSetUp]
   public void StartTest()
   {
       Trace.Listeners.Add(new ConsoleTraceListener());
   }

   [OneTimeTearDown]
   public void EndTest()
   {
       Trace.Flush();
   }
}