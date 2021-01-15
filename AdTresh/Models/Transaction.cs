using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdTresh.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string ReceiptNo { get; set; }
        public decimal TitheAmount { get; set; }
        public decimal Offering { get; set; }
        // Special Project Id.
        public int SpecialProjectID { get; set; }
        // Church Member Id.
        public int MemberID { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }

    }
}