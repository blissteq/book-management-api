using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Abstraction.Models
{
    [DataContract]
 public   class BookLoan
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string ReaderName { get; set; }
        [DataMember]
        public string BookId { get; set; }
        [DataMember]
        public DateTime IssueDate { get; set; }
        [DataMember]
        public DateTime ReturnDate { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
}
