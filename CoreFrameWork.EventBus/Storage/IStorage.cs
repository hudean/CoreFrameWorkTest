using System.Threading;
using System.Threading.Tasks;

namespace CoreFrameWork.EventBus.Storage
{
    /// <summary>
    /// 存储接口
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task InitializeAsync(CancellationToken cancellationToken);

        /// <summary>
        /// 存储消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="dbTransaction"></param>
        void StoreMessage(MediumMessage message, object dbTransaction = null);
    }
}
