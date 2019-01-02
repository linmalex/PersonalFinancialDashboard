--GO

--select * from FinancialDashboardMVC.dbo.DataObjects;

--SET IDENTITY_INSERT FinancialDashboardMVC.dbo.DataObjects ON;
--Insert into FinancialDashboardMVC.dbo.DataObjects (ID,Server_knowledge,DateRetrieved)
--	(Select * 
--	from [FinancialSitchContext-c0d1f867-d595-4934-869a-3c9d618e635c].dbo.DataObjects
--	where DataObjects.ID > 2);
Use [FinancialSitchContext-c0d1f867-d595-4934-869a-3c9d618e635c]

Execute sp_addlinkedserver FinancialDashboardMVC;

Insert into FinancialDashboardMVC.dbo.Statements (LastStatementDate,StatementMinPayment,StatementBalance,PaymentDueDate,LastPaymentDate,AutoPayScheduled,YnabAccountID,AccountID,AccountName)
	(Select LastStatementDate,StatementMinPayment,StatementBalance,PaymentDueDate,LastPaymentDate,AutoPayScheduled,YnabAccountID,AccountID,AccountName
	From [FinancialSitchContext-c0d1f867-d595-4934-869a-3c9d618e635c].dbo.Statements);

Select * from FinancialDashboardMVC.dbo.Statements
