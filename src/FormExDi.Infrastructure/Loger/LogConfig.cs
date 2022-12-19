using System.Text;

namespace FormExDi.Infrastructure.Loger
{
    /// <summary>
    /// Model config
    /// </summary>
    public class LogConfig
    {
        /// <summary>
        /// File Name
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Encoding
        /// </summary>
        public Encoding Encoding { get; } = Encoding.UTF8;

        /// <summary>
        /// Instance
        /// </summary>
        /// <param name="quest"></param>
        public LogConfig(string quest)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(quest, @"^[a-zA-Z0-9]{0,}$"))
                throw new ArgumentException($"'{quest}' is a invalid quest name. The name supports only letters and numbers.");

            FileName = $"./logs/{quest} {DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}.txt";
        }
    }
}
