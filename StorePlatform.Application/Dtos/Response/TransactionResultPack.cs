using StorePlatform.Application.Dtos.Enums;

namespace StorePlatform.Application.Dtos.Response
{


    public class TransactionResultPack<T>
    {
        public T? Result { get; set; }
        public TransactionResult OperationResult { get; set; }
        public object? RefId { get; set; }
        //public decimal Id { get; set; }

        public bool OperationStatus => OperationResult.Result == TransactionResultEnm.Success;

        public TransactionResultPack()
        {
            Result = default;
            OperationResult = new TransactionResult();
        }
    }

}
