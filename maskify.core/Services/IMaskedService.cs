using maskify.core.Models;

namespace maskify.core.Services
{
    public interface IMaskedService
    {
        ProcessMaskedResult ProcessMask(ProcessMaskedRequest processMaskedRequest);
    }
}
