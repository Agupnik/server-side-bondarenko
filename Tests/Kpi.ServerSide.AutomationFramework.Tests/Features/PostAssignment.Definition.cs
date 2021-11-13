using System.Threading.Tasks;
using FluentAssertions;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Assignment;
using Kpi.ServerSide.AutomationFramework.Model.Domain.User;
using Kpi.ServerSide.AutomationFramework.TestsData.Storages.Task;
using Kpi.ServerSide.AutomationFramework.TestsData.Storages.User;
using TechTalk.SpecFlow;

namespace Kpi.ServerSide.AutomationFramework.Tests.Features
{
    [Binding]
    [Scope(Feature = "Assignment Creation")]
    public class PostAssignmentDefinition
    {
        private readonly IAssignmentContext _assignmentContext;
        private readonly IUserContext _userContext;
        private AssignmentRequest _assignment;
        private ResponseMessage _responseMessage;
        private string _userToken;
        private int _assignmentCount;

        public PostAssignmentDefinition(
            IUserContext userContext,
            IAssignmentContext taskContext)
        {
            _userContext = userContext;
            _assignmentContext = taskContext;
            _assignment = TaskStorage.TaskRequests["RandomTask"];
        }

        [Given(@"I have logged user")]
        public async Task GivenIHaveLoggedUser()
        {
            _userToken = (await _userContext.CreateUserTokenByCredentialsAsync(
                    UserStorage.UserRequests["ValidUser"]))
                .Token;
        }

        [When(@"I send the assignment creation request with null value")]
        public async Task WhenISendTheAssignmentCreationRequestWithNullValue()
        {
            _assignment = TaskStorage.TaskRequests["NullValueTask"];
            _responseMessage = await _assignmentContext.CreateAssignmentResponseAsync(
                _assignment,
                _userToken);
        }

        [Then(@"I see (.*) status code")]
        public void ThenISeeStatusCode(string statusCode)
        {
            _responseMessage.StatusCode.Should().Be(
                statusCode);
        }

        [When(@"I send the assignment creation request with very long task description")]
        public async Task WhenISendTheAssignmentCreationRequestWithVeryLongTaskDescription()
        {
            _assignment = TaskStorage.TaskRequests["RandomVeryLongTask"];
            _responseMessage = await _assignmentContext.CreateAssignmentResponseAsync(
                _assignment,
                _userToken);
        }

        [Given(@"I have current Assignment count")]
        public async Task GivenIHaveCurrentAssignmentCount()
        {
            _assignmentCount = (await _assignmentContext.GetAssignmentCountAsync(_userToken)).Count;
        }

        [When(@"I send the assignment creation request with provided model")]
        public async Task WhenISendTheAssignmentCreationRequestWithProvidedModel()
        {
            await _assignmentContext.CreateAssignmentResponseAsync(
                _assignment, 
                _userToken);
        }

        [Then(@"I see increased Assignment count")]
        public async Task ThenISeeIncreasedAssignmentCount()
        {
            var currentCount = 
                (await _assignmentContext.GetAssignmentCountAsync(_userToken)).Count;
            currentCount.Should().BeGreaterThan(
                _assignmentCount);
        }
    }
}
