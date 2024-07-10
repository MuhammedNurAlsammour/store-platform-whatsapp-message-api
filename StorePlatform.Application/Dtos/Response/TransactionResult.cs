

using StorePlatform.Application.Dtos.Enums;

namespace StorePlatform.Application.Dtos.Response
{


    public class TransactionResult
    {
        public decimal ReferenceId { get; set; }
        public string? MessageTitle { get; set; }
        public string? MessageContent { get; set; }
        public string? MessageDetail { get; set; }
        public TransactionResultEnm Result { get; set; }
    }

}
