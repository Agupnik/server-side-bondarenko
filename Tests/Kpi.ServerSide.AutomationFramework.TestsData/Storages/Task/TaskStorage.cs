using System.Collections.Generic;
using Bogus;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Assignment;
using Kpi.ServerSide.AutomationFramework.TestsData.Generators;

namespace Kpi.ServerSide.AutomationFramework.TestsData.Storages.Task
{
    public static class TaskStorage
    {
        public static Dictionary<string, AssignmentRequest> TaskRequests =>
            new Dictionary<string, AssignmentRequest>
            {
                { "RandomTask", RandomTask },
                { "RandomVeryLongTask", RandomVeryLongTask },
                { "NullValueTask", NullValueTask }
            };

        private static AssignmentRequest RandomTask =>
            new Faker<AssignmentRequest>()
                .RuleFor(u => u.Description, RandomGenerator.RandomString());

        private static AssignmentRequest RandomVeryLongTask =>
            new Faker<AssignmentRequest>()
                .RuleFor(u => u.Description, RandomGenerator.RandomString(500000));

        private static AssignmentRequest NullValueTask =>
            new Faker<AssignmentRequest>()
                .RuleFor(u => u.Description, value: null);
    }
}
