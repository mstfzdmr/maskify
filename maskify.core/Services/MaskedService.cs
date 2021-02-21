using maskify.core.Extensions;
using maskify.core.Models;

namespace maskify.core.Services
{
    public class MaskedService : IMaskedService
    {
        private readonly IMasked _masked;

        public MaskedService(IMasked masked)
        {
            _masked = masked;
        }

        public ProcessMaskedResult ProcessMask(ProcessMaskedRequest processMaskedRequest)
        {
            var maskedProcessor = _masked.GetMaskedProcessor(processMaskedRequest.PropertyName);
            return maskedProcessor.ProcessMask(processMaskedRequest);
        }
    }
}
