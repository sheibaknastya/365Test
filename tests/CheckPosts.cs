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
public class CheckPosts : BaseTest
{
    [Test]
    [Retry(3)]
    [AllureName("Check random user's posts")]
    public void CheckUserPost()
    {
        var userId = GetRandomUserId();
        var posts = GetAllPosts();
        
        CheckRandomUserPosts(posts, userId);
    }
    
    [AllureStep("Get random user's ID")]
    private int GetRandomUserId()
    {
        var user = ApiClient.GetRandomUser(); 
        
        return user.id;
    }

    [AllureStep("Get all posts")]
    private Post[] GetAllPosts()
    {
        var response = ApiClient.GetPosts();
        
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content, Is.Not.Null);
        
        var posts = JsonSerializer.Deserialize<Post[]>(response.Content!);

        return posts!;
    }
    
    [AllureStep("Check random user's posts")]
    private static void CheckRandomUserPosts(Post[] posts, int userId)
    {
        foreach (var post in posts)
        {
            if (post.userId != userId) continue;
            
            Assert.That(post.id, Is.InRange(1, 100));
        }
    }
}