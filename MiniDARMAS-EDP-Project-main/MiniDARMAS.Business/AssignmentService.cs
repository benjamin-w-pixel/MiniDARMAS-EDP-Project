using MiniDARMAS.Data;
using MiniDARMAS.Models;

namespace MiniDARMAS.Business
{
    public class AssignmentService
    {
        private AssignmentRepository _assignmentRepository;

        public AssignmentService()
        {
            _assignmentRepository = new AssignmentRepository();
        }

        public List<Assignment> GetAssignmentsByTranscriberId(int transcriberId)
        {
            return _assignmentRepository.GetAssignmentsByTranscriberId(transcriberId);
        }

        public bool CreateAssignment(Assignment assignment)
        {
            return _assignmentRepository.CreateAssignment(assignment);
        }

        public bool UpdateAssignmentStatus(int assignmentId, string status)
        {
            return _assignmentRepository.UpdateAssignmentStatus(assignmentId, status);
        }

        public Assignment? GetAssignmentById(int assignmentId)
        {
            return _assignmentRepository.GetAssignmentById(assignmentId);
        }
    }
}

