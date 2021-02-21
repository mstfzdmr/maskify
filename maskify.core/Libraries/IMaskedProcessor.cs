using maskify.core.Models;

namespace maskify.core.Libraries
{
    public interface IMaskedProcessor
    {
        ProcessMaskedResult ProcessMask(ProcessMaskedRequest processMaskedRequest);
    }
}
