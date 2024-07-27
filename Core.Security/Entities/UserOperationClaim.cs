using Core.Domain.Entities.Commons;

namespace Core.Security.Entities
{
    public class UserOperationClaim : BaseEntity
    {
        public UserOperationClaim( int userId, int operationClaimId)
        {
            UserId = userId;
            OperationClaimId = operationClaimId;
        }
        public UserOperationClaim(int id,int userId, int operationClaimId):base(id)
        {
            UserId = userId;
            OperationClaimId = operationClaimId;
        }

        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        //public virtual User User{ get; set; }
        //public virtual OperationClaim OperationClaim{ get; set; }

    }
}
