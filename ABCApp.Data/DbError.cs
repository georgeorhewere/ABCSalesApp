using System;

namespace ABCApp.Data
{
    public class DbError
    {
        public int ErrorId { get; set; }
        public string ErrorDetail { get; set; }
        public string ErrorBy { get; set; }
        public DateTime ErrorOn { get; set; }
    }
}