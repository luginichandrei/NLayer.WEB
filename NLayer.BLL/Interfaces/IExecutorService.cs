using NLayer.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.BLL.Interfaces
{
    public interface IExecutorService
    {
        void MakeExecutor(ExecutorDTO executorDTO);
        ExecutorDTO GetExecutor(int? id);
        IEnumerable<ExecutorDTO> GetExecutor();
        void Dispose();
    }
}
