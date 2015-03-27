CREATE PROCEDURE [dbo].[sosTracking]
AS
select
	sosID,
	(Asset_Recipient.FirstName + ' ' + Asset_Recipient.LastName) as Recipient,
	CONVERT(date, DateDue) as Due,
	DATEDIFF(DAY,GETDATE(),DateDue) as Soonness,
	Asset_Recipient.EmailAddress as Email,
	Asset_Recipient.PhoneNumber as Phone
from sos
inner join CLA_IT_Member on CLA_IT_Member.claID=SOS.claID
inner join Asset_Recipient on Asset_Recipient.arID=SOS.arID
order by
	Soonness