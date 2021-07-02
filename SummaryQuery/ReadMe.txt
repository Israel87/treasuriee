Brief Documentation

Use the Query whenever the last figures do not jive.

Treasuriee App 
Modified qryPrintSummary added PaymentType and TransactionDetails

SELECT qryPrintReceipts.Names, qryPrintReceipts.PaymentDate, qryPrintReceipts.EntryDate, qryPrintReceipts.MembershipID, qryPrintReceipts.ReceiptNo, qryPrintReceipts.Amount, qryPrintReceipts.PaymentType
FROM qryPrintReceipts
WHERE (((qryPrintReceipts.PaymentType)="Tithe" Or (qryPrintReceipts.PaymentType)="Church Expense Offering" Or (qryPrintReceipts.PaymentType)="Special Project"));

qryPrintSummary_Crosstab

TRANSFORM Sum(qryPrintSummary.Amount) AS SumOfAmount
SELECT qryPrintSummary.Names, qryPrintSummary.MembershipID, qryPrintSummary.ReceiptNo, qryPrintSummary.PaymentDate, Sum(qryPrintSummary.Amount) AS [Weekly Total], Format([Paymentdate],"mmmm") AS PmtMonthName, Month([PaymentDate]) AS pmtMonth, Year([PaymentDate]) AS mYear
FROM qryPrintSummary
GROUP BY qryPrintSummary.Names, qryPrintSummary.ReceiptNo, qryPrintSummary.PaymentDate, qryPrintSummary.MembershipID
PIVOT qryPrintSummary.PaymentType;

qryPrintReceipts

SELECT qryNames.Names, Format(qryPrintReceipts_All.MembershipID,"000") AS MembershipID, Format(qryPrintReceipts_All.ReceiptNo,"0000000") AS ReceiptNo, qryPrintReceipts_All.PaymentDate, qryPrintReceipts_All.EntryDate, qryPrintReceipts_All.Amount, qryPrintReceipts_All.PaymentType, qryPrintReceipts_All.Account, IIf(Mid(qryPrintReceipts_All.Account,1,2)="01","Conference",IIf(Mid(qryPrintReceipts_All.Account,1,2)="02","District","Local Church")) AS AccountGroup, IIf([AppearInSummary],"Yes","No") AS Displayed, qryPrintReceipts_All.TransactionDetails, qryPrintReceipts_All.Receipted, qryPrintReceipts_All.Locked
FROM tblTransactionsCardAccounts RIGHT JOIN (qryNames INNER JOIN qryPrintReceipts_All ON qryNames.MembershipID = qryPrintReceipts_All.MembershipID) ON tblTransactionsCardAccounts.OfferingName = qryPrintReceipts_All.PaymentType
WHERE (((qryPrintReceipts_All.Amount)>0));


Always ensure to change the currency symbol to naira.

The Summary query is the updated query to always yield the right figures and the default file size should be about 52kb.

Format system date accordingly.

DB Password is June14