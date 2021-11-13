﻿using System.Threading.Tasks;

namespace Kpi.ServerSide.AutomationFramework.Model.Domain.Assignment
{
    public interface IAssignmentContext
    {
        Task<AssignmentCountResponse> GetAssignmentCountAsync(
            string accessToken);

        Task<AssignmentResponse> GetAssignmentByIdAsync(
            string assignmentId,
            string accessToken);

        Task<ResponseMessage> GetAssignmentResponseByIdAsync(
            string assignmentId,
            string accessToken = null);

        Task<ResponseMessage> CreateAssignmentResponseAsync(
            AssignmentRequest assignmentRequest,
            string accessToken);

        Task<AssignmentResponse> CreateAssignmentAsync(
            AssignmentRequest assignmentRequest,
            string accessToken);

        Task<ResponseMessage> DeleteAssignmentResponseAsync(
            string assignmentId,
            string accessToken = null);

        Task<ResponseMessage> UpdateAssignmentResponseAsync(
            AssignmentRequest assignmentRequest,
            string assignmentId,
            string accessToken);
    }
}
