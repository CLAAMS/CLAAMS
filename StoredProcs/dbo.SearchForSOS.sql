CREATE PROCEDURE [dbo].[SearchForSOS]
    @arID int,
    @claID varchar(MAX),
    @assingmentPeriod varchar(MAX),
    @dateCreated dateTime,
	@assetDescription varchar(MAX)
AS
BEGIN
	if @assetDescription = ''
		if @dateCreated = '1/1/1900 12:00:00 AM'
			if @arID = 0
				select * from SoS where claID like '%' + CAST(@claID as varchar) + '%' and AssingmentPeriod like '%' + @assingmentPeriod + '%'
			else 
				select * from SoS where arID = @arID and claID like '%' + CAST(@claID as varchar) + '%' and  AssingmentPeriod like '%' + @assingmentPeriod + '%' 
		else
			if @arID = 0
				select * from SoS where claID like '%' + CAST(@claID as varchar) + '%' and  AssingmentPeriod like '%' + @assingmentPeriod + '%' and DateCreated = @dateCreated
			else 
				select * from SoS where arID = @arID and claID like '%' + CAST(@claID as varchar) + '%' and  AssingmentPeriod like '%' + @assingmentPeriod + '%' and DateCreated = @dateCreated
	else
		if @dateCreated = '1/1/1900 12:00:00 AM'
			if @arID = 0
				select *
				from SoS 
				where claID like '%' + CAST(@claID as varchar) + '%'
				and  AssingmentPeriod like '%' + @assingmentPeriod + '%'
				and sosID in (SELECT sosID FROM Asset WHERE Make + ' ' + Model like '%' + @assetDescription  + '%')
			else 
				select * from SoS where arID = @arID and claID like '%' + CAST(@claID as varchar) + '%' and  AssingmentPeriod like '%' + @assingmentPeriod + '%' and ((sosID in (SELECT sosID FROM Asset WHERE Make + ' ' + Model like '%' + @assetDescription  + '%')) OR sosID IS NULL) 
		else
			if @arID = 0
				select * from SoS where claID like '%' + CAST(@claID as varchar) + '%' and  AssingmentPeriod like '%' + @assingmentPeriod + '%' and DateCreated = @dateCreated and ((sosID in (SELECT sosID FROM Asset WHERE Make + ' ' + Model like '%' + @assetDescription  + '%')) OR sosID IS NULL)
			else 
				select * from SoS where arID = @arID and claID like '%' + CAST(@claID as varchar) + '%' and  AssingmentPeriod like '%' + @assingmentPeriod + '%' and DateCreated = @dateCreated and ((sosID in (SELECT sosID FROM Asset WHERE Make + ' ' + Model like '%' + @assetDescription  + '%')) OR sosID IS NULL)

END