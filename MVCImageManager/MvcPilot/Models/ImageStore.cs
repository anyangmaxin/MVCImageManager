namespace MvcPilot.Models
{
    /// <summary>
    /// 图片存储实体类
    /// </summary>
    public class ImageStore
    {
        /// <summary>
        /// 主键
        /// </summary>
        public  int ImageStore_nbr { get; set; }

        /// <summary>
        /// 图片名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 图片类型
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// 图片转化为二进制存入数据库
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// 图片所在路径
        /// </summary>
        public string Src { get; set; }
    }
}