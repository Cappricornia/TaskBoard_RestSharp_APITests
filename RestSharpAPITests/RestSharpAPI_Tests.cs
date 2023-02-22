using RestSharp;
using System.Net;
using System.Text.Json;


namespace RestSharpAPITests
{
    public class RestSharpAPI_Tests
    {

        private RestClient client;
        private const string baseUrl = "https://taskboardjs.cappricornia.repl.co/api";



        [SetUp]
        public void Setup()
        {
            this.client = new RestClient(baseUrl);

        }


        [Test]
        public void Test_Assert_Title_Of_The_First_Task_From_Board_Done()
        {

            // Arrange
            var request = new RestRequest("tasks/board/done", Method.Get);

            // Act
            var response = this.client.Execute(request);


            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var tasks = JsonSerializer.Deserialize<List<Task>>(response.Content);
          
            Assert.That(tasks[0].title, Is.EqualTo("Project skeleton"));
        }

        [Test]
        public void Test_Search_By_ValidKeyword()
        {

            // Arrange  
            var request = new RestRequest("tasks/search/home", Method.Get);

            // Act
            var response = this.client.Execute(request);


            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var tasks = JsonSerializer.Deserialize<List<Task>>(response.Content);

            Assert.That(tasks[0].title, Is.EqualTo("Home page"));


        }

        [Test]
        public void Test_Search_By_Keyword_MissingRandnum()
        {

            // Arrange  
            var request = new RestRequest("tasks/search/missing" + DateTime.Now.Ticks, Method.Get);

            // Act
            var response = this.client.Execute(request);
            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
           
            Assert.That(response.Content, Is.EqualTo("[]"));
            
        }


        [Test]
        public void Test_Create_NewTask_With_Invalid_data_MissingTitle()
        {

            // Arrange 
            var request = new RestRequest("tasks", Method.Post);

            // Act

            var reqBody = new
            {
                description = "some info",
                board = "Open"
            };

            request.AddBody(reqBody);

            var response = this.client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(response.Content, Is.EqualTo("{\"errMsg\":\"Title cannot be empty!\"}"));

        }

        [Test]
        public void Test_Create_NewTask_With_Correct_data()
        {

            // Arrange 	
            var request = new RestRequest("tasks", Method.Post);

            // Act

            var reqBody = new
            {
                title = "New title" + DateTime.Now.Ticks,
                description = "some info",
                board = "Open"
            };

            request.AddBody(reqBody);


            var response = this.client.Execute(request);
          
            var taskObj = JsonSerializer.Deserialize<TaskObj>(response.Content);

            // Assert 
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(taskObj.msg, Is.EqualTo("Task added."));
            Assert.That(taskObj.task.id, Is.GreaterThan(0));
            Assert.That(taskObj.task.title, Is.EqualTo(reqBody.title));
            Assert.That(taskObj.task.description, Is.EqualTo(reqBody.description));
            Assert.That(taskObj.task.board.id, Is.GreaterThan(0));
            Assert.That(taskObj.task.board.name, Is.EqualTo(reqBody.board));
            Assert.That(taskObj.task.dateCreated, Is.Not.Empty);
            Assert.That(taskObj.task.dateModified, Is.Not.Empty);

        }

    }
        
}
