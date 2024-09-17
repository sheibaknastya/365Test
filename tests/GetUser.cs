using System.Net;
using System.Text.Json;
using _365Test.core;
using _365Test.core.entities;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using NUnit.Framework;

namespace _365Test.tests;

[TestFixture]
[AllureNUnit]
public class GetUser : BaseTest
{
    [Test]
    [Retry(3)]
    [AllureName("Get random user's email")]
    public void GetUserEmail()
    {
        var users = GetUsers();
        var user = ChooseRandomUser(users);
        PrintUserEmail(user);
    }
    
    [AllureStep("Get users")]
    private User[] GetUsers()
    {
        var response = ApiClient.GetUsers();
        
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content, Is.Not.Null);

        var data = JsonSerializer.Deserialize<User[]>(response.Content!);
        
        return data!;
    }

    [AllureStep("Choose random user")]
    private static User ChooseRandomUser(User[] users)
    {
        var index = new Random().Next(0, 9);
        var user = users[index];

        Assert.That(user, Is.Not.Null);

        return user;
    }

    [AllureStep("Print user's email")]
    private static void PrintUserEmail(User user)
    {
        Console.WriteLine(user.email);
    }

}