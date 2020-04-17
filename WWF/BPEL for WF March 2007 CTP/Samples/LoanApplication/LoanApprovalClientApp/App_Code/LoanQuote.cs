using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace LoanApprovalProcessClient
{

    /// <summary>
    /// Summary description for LoanQuote
    /// </summary>
    public class LoanQuote
    {
        Guid requestId;
        double interestRate;
        int timePeriod;
        DateTime startDate;
        int amountSanctioned;

        public LoanQuote(Guid requestId)
        {
            this.requestId = requestId;
        }

        public Guid RequestId
        {
            get
            {
                return requestId;
            }
            set
            {
                requestId = value;
            }
        }

        public int TimePeriod
        {
            get
            {
                return timePeriod;
            }
            set
            {
                timePeriod = value;
            }
        }

        public int AmountSanctioned
        {
            get
            {
                return amountSanctioned;
            }
            set
            {
                amountSanctioned = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
            }
        }

        public double InterestRate
        {
            get
            {
                return interestRate;
            }
            set
            {
                interestRate = value;
            }
        }
    }
}