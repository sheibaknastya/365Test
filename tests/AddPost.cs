using System.Net;
using _365Test.core;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using NUnit.Framework;

namespace _365Test.tests;

[TestFixture]
[AllureNUnit]
public class AddPost : BaseTest
{
    [Test]
    [Retry(3)]
    [AllureName("Add post to random user")]
    public void AddUserPost()
    {
        var userId = GetRandomUserId();
        CreatePost(userId);
    }
    
    [AllureStep("Get random user's ID")]
    private int GetRandomUserId()
    {
        var user = ApiClient.GetRandomUser(); 
        
        return user.id;
    }

    [AllureStep("Create post using random user's ID")]
    private void CreatePost(int userId)
    {
        var response = ApiClient.CreatePost(userId);
        
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(response.Content, Is.Not.Null);
    }
}